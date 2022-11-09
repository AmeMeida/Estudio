using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public enum SQLOp
    {
        EQ,
        LT,
        GT,
        LTEQ,
        GTEQ,
        StrStartsWith,
        StrStartsWithIC,
        StrEndsWith,
        StrEndsWithIC,
        StrContains,
        StrContainsIC,
    }

    public static class SQLConditionExtensions
    {
        public static readonly Dictionary<SQLOp, SQLOp> IgnoreDic = 
            new Dictionary<SQLOp, SQLOp>()
            {
                { SQLOp.StrStartsWithIC, SQLOp.StrStartsWith },
                { SQLOp.StrEndsWithIC, SQLOp.StrEndsWith },
                { SQLOp.StrContainsIC, SQLOp.StrContains },
            };


        public static string ToCondition(this (string column, SQLOp op, object value) condition)
        {
            if (IgnoreDic.ContainsKey(condition.op))
                return ToCondition((condition.column, IgnoreDic[condition.op], condition.value), true);
            else
                return ToCondition(condition, false);
        }

        public static string ToCondition((string column, SQLOp op, object value) condition, bool ignoreCase)
        {
            var condString = new StringBuilder();
            if (ignoreCase)
                condString.Append("LOWER(" + condition.column.Check() + ")");
            else
                condString.Append(condition.column.Check());

            switch (condition.op)
            {
                case SQLOp.EQ:
                    condString.Append(" = ");
                    break;

                case SQLOp.LT:
                    condString.Append(" < ");
                    break;

                case SQLOp.GT:
                    condString.Append(" > ");
                    break;

                case SQLOp.LTEQ:
                    condString.Append(" <= ");
                    break;

                case SQLOp.GTEQ:
                    condString.Append(" >= ");
                    break;

                default:
                    condString.Append(" LIKE ");
                    break;
            }

            var strValue = QueryBuilder.FormatValue(condition.value, true, condition.op);
            strValue = ignoreCase ? "LOWER(" + strValue + ")" : strValue;
            condString.Append(strValue);
            return condString.ToString();
        }
    }


    public class EntityAttribute : Attribute { }

    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
        public TableAttribute(string name) => Name = name;
    }

    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }

    public class IDAttribute : Attribute { }

    public static class ORM
    {
        public static T[] GetAllAtivos<T>() => ORM<T>.Select(("ativo", SQLOp.EQ, 1));
    }

    public class ORM<T>
    {
        public T MapElement { get; set; }

        public static string Table => typeof(T).GetCustomAttribute<TableAttribute>().Name;

        public static IEnumerable<PropertyInfo> Proprieties =>
            typeof(T)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(HasAttribute<ColumnAttribute>);

        public static string GetColumn(PropertyInfo prop)
            => prop.GetCustomAttribute<ColumnAttribute>().Name;

        public static string[] Columns => Proprieties.Select(GetColumn).ToArray();

        public static object[] GetValues(T e) => Proprieties.Select(x => x.GetValue(e)).ToArray();

        public static bool HasAttribute<A>(PropertyInfo prop) where A : Attribute
            => prop.GetCustomAttribute<A>() != null;

        public static PropertyInfo IDProp => Proprieties.First(HasAttribute<IDAttribute>);

        public static string GetIDeqString(T e) => (GetColumn(IDProp), SQLOp.EQ, IDProp.GetValue(e)).ToCondition();

        public static bool Check(T e)
        {
            bool exists = false;

            try
            {
                DAO_Connection.Connection.Open();

                var query = new QueryBuilder()
                    .SELECT()
                    .FROM(Table)
                    .WHERE(GetIDeqString(e))
                    .LogQuery()
                    .DisplayQuery()
                    .ToCommand(DAO_Connection.Connection)
                    .ExecuteReader();

                exists = query.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return exists;
        }
        public bool Check() => Check(MapElement);


        public static bool Save(T e)
        {
            bool status = false;

            try
            {
                DAO_Connection.Connection.Open();
                var trans = DAO_Connection.Connection.BeginTransaction();

                try
                {

                    var query = new QueryBuilder()
                        .INSERT()
                        .INTO(Table)
                        .COLUMNS(Columns)
                        .VALUES(GetValues(e))
                        .LogQuery()
                        .DisplayQuery()
                        .ToCommand(DAO_Connection.Connection)
                        .ExecuteNonQuery();

                    trans.Commit();
                    status = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    trans.Rollback();
                }
                finally
                {
                    trans.Dispose();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return status;
        }

        public static T[] Select(params (string column, SQLOp op, object value)[] equalities)
        {
            var list = new List<T>();
            
            try
            {
                DAO_Connection.Connection.Open();

                var command = new QueryBuilder()
                    .SELECT()
                    .FROM(Table);

                if (equalities.Count() > 0)
                {
                    command.WHERE(equalities.First().ToCondition());

                    foreach (var eqString in equalities.Skip(1).Select(x => x.ToCondition()))
                        command.AND(eqString);
                }

                var query = command
                    .LogQuery()
                    .DisplayQuery()
                    .ToCommand(DAO_Connection.Connection)
                    .ExecuteReader();

                while (query.Read())
                {
                    var row = (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
                    foreach(var prop in Proprieties)
                    {
                        var response = query[GetColumn(prop)];
                        prop.SetValue(row, response is DBNull ? null : response);
                    }

                    list.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return list.Count > 0 ? list.ToArray() : null;
        }

        public static (bool updateStatus, T newState) Update(T oldState, params (string column, object value)[] updatePairs)
        {
            bool updateState = false;

            if (updatePairs.Count() <= 0)
                return (true, oldState);

            try
            {
                DAO_Connection.Connection.Open();
                var trans = DAO_Connection.Connection.BeginTransaction();

                try
                {
                    var query = new QueryBuilder()
                        .UPDATE(Table)
                        .SET(updatePairs)
                        .WHERE(GetIDeqString(oldState))
                        .LogQuery()
                        .DisplayQuery()
                        .ToCommand()
                        .ExecuteNonQuery();

                    trans.Commit();
                    updateState = true;

                    foreach (var (column, value) in updatePairs)
                        Proprieties.First(x => GetColumn(x) == column).SetValue(oldState, value);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    trans.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return (updateState, oldState);
        }

        public static (bool updateStatus, T newState) UpdateFrom(T oldState, T newState)
        {
            var updatePairs = new List<(string column, object value)>();

            foreach(var prop in Proprieties)
                if (prop.GetValue(newState) != null && !prop.GetValue(oldState).Equals(prop.GetValue(newState)))
                    updatePairs.Add((GetColumn(prop), prop.GetValue(newState)));

            return Update(oldState, updatePairs.ToArray());
        }

        public static object FetchProp(T e, string searchProp, bool fullSearch = false, params string[] matchValues)
        {
            var prop = Proprieties.First(x => x.Name == searchProp); ;

            if (!HasAttribute<ColumnAttribute>(prop))
                throw new ArgumentException("A propriedade deve ser uma coluna");

            var conditions = new List<(string column, SQLOp op, object value)>();

            if (fullSearch || matchValues.Count() > 0)
            {
                var usedProps = Proprieties.Where(x => x != prop && (fullSearch || matchValues.Contains(x.Name))).Select(x => (GetColumn(x), SQLOp.EQ, x.GetValue(e)));

                conditions.AddRange(usedProps);
            }

            object res = null;

            try
            {
                DAO_Connection.Connection.Open();
                var command = new QueryBuilder()
                    .SELECT(GetColumn(prop))
                    .FROM(Table);

                if (fullSearch || matchValues.Count() > 0)
                {
                    command.WHERE(conditions.First().ToCondition());

                    foreach (var eqString in conditions.Skip(1).Select(x => x.ToCondition()))
                        command.AND(eqString);
                }
                else
                {
                    command.WHERE(GetIDeqString(e));
                }

                var query = command
                    .LogQuery()
                    .DisplayQuery()
                    .ToCommand()
                    .ExecuteReader();

                if (query.Read())
                    res = query[GetColumn(prop)];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        public static SQLOp Normalize(this SQLOp op)
        {
            try { return IgnoreDic[op]; } catch (KeyNotFoundException) { return op; }
        }

        public static string Format(this SQLOp op, string value)
        {
            value = value.Check();

            switch (op.Normalize())
            {
                case SQLOp.StrStartsWith:
                    return value + "%";

                case SQLOp.StrEndsWith:
                    return "%" + value;

                case SQLOp.StrContains:
                    return "%" + value + "%";

                default:
                    return value;
            }
        }

        public static bool isIgnoreCase(this SQLOp op) => IgnoreDic.ContainsKey(op);

        public static readonly Dictionary<SQLOp, SQLOp> IgnoreDic = 
            new Dictionary<SQLOp, SQLOp>()
            {
                { SQLOp.StrStartsWithIC, SQLOp.StrStartsWith },
                { SQLOp.StrEndsWithIC, SQLOp.StrEndsWith },
                { SQLOp.StrContainsIC, SQLOp.StrContains },
            };

        public static string ToClause(this (string column, SQLOp op, object value) condition)
        {
            bool ignoreCase = condition.op.isIgnoreCase();

            var condString = new StringBuilder();
            if (ignoreCase)
                condString.Append("LOWER(" + condition.column.Check() + ")");
            else
                condString.Append(condition.column.Check());

            switch (condition.op.Normalize())
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

        public static (string column, SQLOp op, object value) ToCondition(this (string column, object value) updatePair) => (updatePair.column, SQLOp.EQ, updatePair.value);
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EntityAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
        public TableAttribute(string name) => Name = name;
    }

    public delegate object Parse(object obj);

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public bool autoIncrement = false;
        public Parse sqlParser;
        public Parse csParser;

        public object ToSQL(object obj)
        {
            if (obj != null && sqlParser != null && sqlParser.GetInvocationList().Length > 0)
                obj = sqlParser(obj);
            return obj;
        }

        public object ToCS(object obj)
        {
            if (obj is DBNull)
                return null;
            else if (csParser != null && csParser.GetInvocationList().Length > 0)
                return csParser(obj);
            else
                return obj;
        }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IDAttribute : Attribute { }

    public class Column
    {
        public static Column[] ToArray(object obj)
            => obj.GetType().GetProperties()
                .Where(ORM.HasAttribute<ColumnAttribute>)
                .Select(x => new Column(obj, x)).ToArray();

        public PropertyInfo Prop { get; set; }
        public ColumnAttribute ColAttr => Prop.GetCustomAttribute<ColumnAttribute>();
        public object Obj { get; set; }
        public string ColName => ColAttr.Name;
        public (string column, SQLOp op, object value) ToCondition(SQLOp op) => (ColName, op, Value);
        public string ToConditionStr(SQLOp op) => ToCondition(op).ToClause();
        public string ToEQString() => ToConditionStr(SQLOp.EQ);
        public (string column, object value) ToPair() => (ColName, Value);

        public object Value
        {
            get => ColAttr.ToSQL(Prop.GetValue(Obj));
            set => Prop.SetValue(Obj, Value is DBNull ? null : ColAttr.ToCS(value));
        }

        public static Column IDCol(object obj) => new Column(obj, obj.GetType().GetProperties().First(ORM.HasAttribute<IDAttribute>));
        public static string IDEqString(object obj) => IDCol(obj).ToEQString();

        public Column(object obj, PropertyInfo prop)
        {
            this.Obj = obj;
            Prop = prop;
        }

        public Column(object obj, string prop)
        {
            this.Obj = obj;
            Prop = obj.GetType().GetProperty(prop);
        }
    }

    public static class ORM
    {
        public static bool HasAttribute<T>(this PropertyInfo prop) where T : Attribute
            => prop.GetCustomAttribute<T>() != null;
        public static T[] GetAllAtivos<T>() => ORM<T>.Select(("ativo", SQLOp.EQ, 1));
    }

    public class ORM<T>
    {
        public T MapElement { get; set; }

        public static string Table => typeof(T).GetCustomAttribute<TableAttribute>().Name;

        public static IEnumerable<PropertyInfo> Proprieties =>
            typeof(T)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(ORM.HasAttribute<ColumnAttribute>);

        public static string GetColumn(PropertyInfo prop)
            => prop.GetCustomAttribute<ColumnAttribute>().Name;

        public static PropertyInfo IDProp => Proprieties.First(ORM.HasAttribute<IDAttribute>);

        public static bool Check(T e)
        {
            bool exists = false;

            try
            {
                if (DAO_Connection.Connection.State != System.Data.ConnectionState.Open)
                    DAO_Connection.Connection.Open();

                var query = new QueryBuilder()
                    .SELECT()
                    .FROM(Table)
                    .WHERE(Column.IDEqString(e))
                    .LogQuery()
                    .DisplayQuery()
                    .ToCommand()
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

        public static bool Save(T e)
        {
            bool status = false;

            try
            {
                DAO_Connection.Connection.Open();
                var trans = DAO_Connection.Connection.BeginTransaction();

                try
                {
                    var cols = Column.ToArray(e).Where(x => !x.ColAttr.autoIncrement);

                    /*
                    var exists = !Check(e);
                    DAO_Connection.Connection.Open();
                    */

                    // if (exists)
                    // {
                        new QueryBuilder()
                            .INSERT()
                            .INTO(Table)
                            .COLUMNS(cols.Select(x => x.ColName).ToArray())
                            .VALUES(cols.Select(x => x.Value).ToArray())
                            .LogQuery()
                            .DisplayQuery()
                            .ToCommand()
                            .ExecuteNonQuery();
                    /*
                    }
                    else
                    {
                        Update(e, cols.Where(x => x.Prop != IDProp).Select(x => x.ToPair()).ToArray());
                    }
                    */

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
                    command.WHERE(equalities.First().ToClause());

                    foreach (var eqString in equalities.Skip(1).Select(x => x.ToClause()))
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
                    foreach (var column in Column.ToArray(row))
                        column.Value = query[column.ColName];
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

        public static bool Delete(T e, params string[] fields)
        {
            bool updateState = false;
            Console.WriteLine("what");

            if (e == null)
            {
                Console.WriteLine("NULL ERROR");
                return false;
            }

            try
            {
                DAO_Connection.Connection.Open();
                var trans = DAO_Connection.Connection.BeginTransaction();

                try
                {
                    var query = new QueryBuilder()
                        .DELETE()
                        .FROM(Table);

                    if (fields == null || fields.Length == 0)
                    {
                        query.WHERE(Column.IDEqString(e));
                    }
                    else
                    {
                        query.WHERE(new Column(e, fields.First()).ToEQString());

                        foreach (var field in fields.Skip(1))
                            query.AND(new Column(e, field).ToEQString());
                    }

                    query
                        .LIMIT()
                        .LogQuery()
                        .DisplayQuery()
                        .ToCommand()
                        .ExecuteNonQuery();
                    
                    trans.Commit();
                    updateState = true;
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

            return updateState;
        }

        public static (bool updateStatus, T newState) Update(T oldState, params (string column, object value)[] updatePairs)
        {
            bool updateState = false;

            if (updatePairs == null || updatePairs.Count() <= 0)
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
                        .WHERE(Column.IDEqString(oldState))
                        .LogQuery()
                        .DisplayQuery()
                        .ToCommand()
                        .ExecuteNonQuery();

                    trans.Commit();
                    updateState = true;

                    foreach (var (column, value) in updatePairs)
                    {
                        new Column(oldState, Proprieties.First(x => GetColumn(x) == column)).Value = value;
                    }
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

        public static (bool updateStatus, T newState) UpdateFrom(T oldState, T newState, bool ignoreNulls = true)
        {
            var updatePairs = new List<(string column, object value)>();

            foreach(var prop in Proprieties)
            {
                if ((!ignoreNulls || prop.GetValue(newState) != null) && !prop.GetValue(oldState).Equals(prop.GetValue(newState)))
                    updatePairs.Add(new Column(newState, prop).ToPair());
            }

            return Update(oldState, updatePairs.Count > 0 ? updatePairs.ToArray() : null);
        }

        public static object FetchProp(T e, string searchProp, bool fullSearch = false, params string[] matchValues)
        {
            var prop = Proprieties.First(x => x.Name == searchProp);

            if (!prop.HasAttribute<ColumnAttribute>())
                throw new ArgumentException("A propriedade deve ser uma coluna");

            var conditions = new List<string>();

            if (fullSearch || (matchValues != null && matchValues.Count() > 0))
            {
                foreach (var property in Proprieties.Where((x) => x != prop && (fullSearch || matchValues.Contains(x.Name))))
                {
                    conditions.Add(new Column(e, property).ToEQString());
                }
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
                    command.WHERE(conditions.First());

                    foreach (var eqString in conditions.Skip(1))
                        command.AND(eqString);
                }
                else
                {
                    command.WHERE(Column.IDEqString(e));
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

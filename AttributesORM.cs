using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
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
        public object[] Values => GetValues(MapElement);


        public static bool HasAttribute<A>(PropertyInfo prop) where A : Attribute
            => prop.GetCustomAttribute<A>() != null;


        public static (string column, object value) GetColValueTuple(T e, PropertyInfo prop)
            => (GetColumn(prop), prop.GetValue(e));
        public (string column, object value) GetColValueTuple(PropertyInfo prop)
            => GetColValueTuple(MapElement, prop);


        public static PropertyInfo IDProp => Proprieties.FirstOrDefault(HasAttribute<IDAttribute>);


        public static (string column, object value) GetID(T e) => GetColValueTuple(e, IDProp);
        public (string column, object value) ID => GetID(MapElement);


        public static string GetEqString(T e, PropertyInfo prop)
        {
            var (column, value) = GetColValueTuple(e, prop);
            return column + " = " + QueryBuilder.FormatValue(value, true);
        }
        public string GetEqString(PropertyInfo prop) => GetEqString(MapElement, prop);


        public static string GetIDeqString(T e) => GetEqString(e, IDProp);
        public string IDeqString => GetIDeqString(MapElement);
        

        public ORM(T mapElement)
        {
            if (typeof(T).GetCustomAttribute<EntityAttribute>() != null)
                MapElement = mapElement;
            else
                throw new ArgumentException("O objeto deve ser uma entidade.");
        }

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
        public bool Save() => Save(MapElement);

        public static T[] GetAll(params (string column, object value)[] equalities)
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
                    command.WHERE(equalities[0].column + " = " + equalities[0].value);

                    foreach (var eqString in equalities.Skip(1).Select(x => x.column + " = " + x.value))
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
                        .SET(updatePairs.Select(x => (x.column, x.value)).ToArray())
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
        public (bool updateStatus, T newState) UpdateFrom(T newState) => UpdateFrom(MapElement, newState);


        public static object FetchProp(T e, string searchProp, bool fullSearch = false, params string[] matchValues)
        {
            var prop = Proprieties.First(x => x.Name == searchProp); ;

            if (!HasAttribute<ColumnAttribute>(prop))
                throw new ArgumentException("A propriedade deve ser uma coluna");

            object res = null;

            try
            {
                DAO_Connection.Connection.Open();
                var command = new QueryBuilder()
                    .SELECT(GetColumn(prop))
                    .FROM(Table);

                if (fullSearch || matchValues.Count() > 0)
                {
                    var eqStrings = Proprieties.Where(x => x != prop && (fullSearch || matchValues.Contains(x.Name))).Select(x => GetEqString(e, x));
                    command.WHERE(eqStrings.First());

                    foreach (var eqString in eqStrings.Skip(1))
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
        public object FetchProp(string searchProp, bool fullSearch = false, params string[] matchValues) => FetchProp(MapElement, searchProp, fullSearch, matchValues);
    }
}

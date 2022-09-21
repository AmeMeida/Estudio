using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public enum UserType
    {
        NotFound = 0,
        User     = 1,
        Admin    = 2,
    }

    public static class DAO_Connection
    {
        private static MySqlConnection con;
        public static bool ConnectionStatus { get; private set; } = false;

        public static bool GetConnection(string host, string database, string user, string password)
        {
            try
            {
                var connectionString = new StringBuilder()
                    .Append("server=").Append(host)
                    .Append(";User ID=").Append(user)
                    .Append(";database=").Append(database)
                    .Append(";password=").Append(password).ToString();

                con = new MySqlConnection(connectionString);
                ConnectionStatus = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ConnectionStatus = false;
            }

            return ConnectionStatus;
        }

        public static bool GetConnection()
        {
            return GetConnection("143.106.241.3", "cl201290", "cl201290", "cl*24032006");
        }

        public static void ExecuteStatement(string sql)
        {
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = sql;
        }

        public static UserType Login(string usuario, string senha)
        {
            UserType utype = 0;

            try {
                con.Open();
                var loginCommand = new StringBuilder()
                    .Append("SELECT * FROM Estudio_Login where usuario = ").Append("'" + usuario + "'")
                    .Append(" and ")
                    .Append("senha = ").Append("'" + senha + "';")
                    .ToString();

                var query = new MySqlCommand(loginCommand, con).ExecuteReader();

                if (query.Read())
                    utype = (UserType)int.Parse(query["tipo"].ToString() ?? "0"); 
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                con.Close();
            }

            return utype;
        } 
    }
}

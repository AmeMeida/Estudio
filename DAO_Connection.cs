using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public class Tipo
    {
        public readonly string Text;

        private Tipo(string text) { Text = text; }

        public static readonly Tipo notFound = new Tipo("Não encontrado.");
        public static readonly Tipo user = new Tipo("user");
        public static readonly Tipo admin = new Tipo("admin");

        public static readonly Tipo[] Values = { user, admin };
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
                    .Append(";password=").Append(password);

                con = new MySqlConnection(connectionString.ToString());
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

        public static Tipo Login(string usuario, string senha)
        {
            Tipo tipo = Tipo.notFound;

            try
            {
                con.Open();
                var loginCommand = new StringBuilder()
                    .Append("SELECT * FROM Estudio_Login where usuario = ").Append("'" + usuario + "'")
                    .Append("and")
                    .Append("senha = ").Append("'" + senha + "';");

                var login = new MySqlCommand(loginCommand.ToString(), con);
                var query = login.ExecuteReader();

                if (query.Read())
                {
                    MessageBox.Show(query["tipo"].ToString());
                    tipo = Tipo.Values.ToList().Find(t => t.Text.ToLower() == query["tipo"].ToString()) ?? Tipo.notFound;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return tipo;
        } 
    }
}

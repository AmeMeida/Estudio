using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{

    internal static class DAO_Connection
    {
        private static MySqlConnection con;

        public static MySqlConnection Connection
        {
            get
            {
                if (con != null || GetConnection())
                    return con;

                throw new ArgumentException("Impossível fazer a conexão!");
            }
        }

        public static bool IsOpen => con != null && con.State == System.Data.ConnectionState.Open;
        public static bool IsConnected { 
            get
            {
                try {
                    return Connection.Ping();
                } catch {
                    return false;
                }
            }
        }
        public static bool GetConnection(string host, string database, string user, string password)
        {
            bool connected = false;

            try
            {
                var connectionString = new StringBuilder()
                    .Append("server=").Append(host)
                    .Append(";User ID=").Append(user)
                    .Append(";database=").Append(database)
                    .Append(";password=").Append(password)
                    .ToString();

                con = new MySqlConnection(connectionString);
                connected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return connected;
        }

        public static bool TestConnection() => (bool)(Connection?.Ping());

        public static bool GetConnection()
        {
            return GetConnection("143.106.241.3", "cl201290", "cl201290", "cl*24032006");
        }
    }

    public static class LoginDAO
    {
        private static readonly MySqlConnection con = DAO_Connection.Connection;

        public static UserType Login(this Usuario user)
        {
            var utype = UserType.NotFound;

            try {
                con.Open();

                MySqlDataReader query = new QueryBuilder()
                    .SELECT()
                    .FROM("Estudio_Login")
                    .WHERE("usuario = " + user.User.Quote())
                    .AND("senha = " + user.Senha.Quote())
                    .ToCommand(con)
                    .ExecuteReader();

                if (query.Read())
                    utype = (UserType)int.Parse(query["tipo"].ToString() ?? "0");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                con.Close();
            }

            user.AccountType = utype;
            return user.AccountType;
        }

        public static bool CadastrarLogin(this Usuario user)
        {
            bool cadStatus = false;

            try
            {
                con.Open();

                var query = new QueryBuilder()
                    .INSERT()
                    .INTO("Estudio_Login")
                    .COLUMNS("usuario", "senha", "tipo")
                    .VALUES(user.User, user.Senha, ((int)user.AccountType).ToString())
                    .ToCommand(con);

                query.ExecuteNonQuery();
                cadStatus = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return cadStatus;
        }
    }

    public static class AlunoDAO
    {
        private static readonly MySqlConnection con = DAO_Connection.Connection;

        public static bool ConsultarAluno(this Aluno al)
        {
            bool exists = false;

            try
            {
                con.Open();

                exists = new QueryBuilder()
                    .SELECT()
                    .FROM("Estudio_Aluno")
                    .WHERE("CPFAluno = " + al.CPF.Quote())
                    .ToCommand(con)
                    .ExecuteReader()
                    .Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return exists;
        }

        public static bool CadastrarAluno(this Aluno al)
        {
            bool status = false;

            try
            {
                con.Open();

                var insert = new QueryBuilder()
                    .INSERT()
                    .INTO("Estudio_Aluno")
                    .COLUMNS("CPFAluno", "nomeAluno", "ruaAluno", "numeroAluno", "bairroAluno", "complementoAluno", "CEPAluno", "cidadeAluno", "estadoAluno", "telefoneAluno", "emailAluno")
                    .VALUES(al.CPF, al.Nome, al.Rua, al.Numero, al.Bairro, al.Complemento, al.CEP, al.Cidade, al.Estado, al.Telefone, al.Email)
                    .ToCommand(con);

                insert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return status;
        }

        public static bool ExcluirAluno(this Aluno al)
        {
            bool status = false;

            try
            {
                con.Open();

                var commmand = new QueryBuilder()
                    .UPDATE("Estudio_Aluno")
                    .SET(("ativoAluno", "1"))
                    .WHERE("CPFAluno = " + al.CPF)
                    .ToCommand(con);

                commmand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return status;
        }
    }
}

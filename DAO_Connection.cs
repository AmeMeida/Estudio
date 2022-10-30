using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{

    internal static class DAO_Connection
    {
        private static MySqlConnection _con;

        public static MySqlConnection Connection
        {
            get
            {
                if (_con != null || GetConnection())
                {
                    return _con;
                }

                throw new ArgumentException("Impossível fazer a conexão!");
            }
        }

        public static bool IsOpen => _con != null && _con.State == System.Data.ConnectionState.Open;
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

                _con = new MySqlConnection(connectionString);
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

    /*
    public static class LoginDAO
    {
        public static Usuario[] GetUsers()
        {
            var users = new List<Usuario>();

            try
            {
                DAO_Connection.Connection.Open();

                MySqlDataReader query = new QueryBuilder()
                    .SELECT()
                    .FROM("Estudio_Login")
                    .ToCommand(DAO_Connection.Connection)
                    .ExecuteReader();

                while (query.Read())
                    users.Add(new Usuario(query["usuario"].ToString(),
                                          query["senha"].ToString(),
                                          (UserType)int.Parse(query["tipo"].ToString())));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return users.ToArray();
        }

        public static UserType Login(this Usuario user)
        {
            var utype = UserType.NotFound;

            try
            {
                DAO_Connection.Connection.Open();

                MySqlDataReader query = new QueryBuilder()
                    .SELECT()
                    .FROM("Estudio_Login")
                    .WHERE("usuario = " + user.User.Quote())
                    .AND("senha = " + user.Senha.Quote())
                    .ToCommand(DAO_Connection.Connection)
                    .ExecuteReader();

                if (query.Read())
                    utype = (UserType)int.Parse(query["tipo"].ToString() ?? "0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            user.AccountType = utype;
            return user.AccountType;
        }

        public static bool CadastrarLogin(this Usuario user)
        {
            bool cadStatus = false;

            try
            {
                DAO_Connection.Connection.Open();

                var query = new QueryBuilder()
                    .INSERT()
                    .INTO("Estudio_Login")
                    .COLUMNS("usuario", "senha", "tipo")
                    .VALUES(user.User, user.Senha, ((int)user.AccountType).ToString())
                    .ToCommand(DAO_Connection.Connection);

                query.ExecuteNonQuery();
                cadStatus = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return cadStatus;
        }

        public static (bool hasUpdated, Usuario user) Update(this Usuario oldUser, Usuario newUser)
        {
            var updatePairs = new List<(string column, string value)>();
            bool hasUpdated = false;

            if (oldUser.Senha != newUser.Senha)
                updatePairs.Add(("senha", newUser.Senha));
            if (oldUser.User != newUser.User)
                updatePairs.Add(("usuario", newUser.User));
            if (oldUser.AccountType != newUser.AccountType)
                updatePairs.Add(("tipo", ((int)newUser.AccountType).ToString()));

            if (updatePairs.Count == 0)
                return (true, oldUser);

            try
            {
                DAO_Connection.Connection.Open();

                var query = new QueryBuilder()
                    .UPDATE("Estudio_Login")
                    .SET(updatePairs.ToArray())
                    .WHERE("usuario = " + oldUser.User.Quote())
                    .AND("senha = " + oldUser.Senha.Quote())
                    .ToCommand(DAO_Connection.Connection);

                query.ExecuteNonQuery();
                hasUpdated = true;
                if (oldUser.Senha != newUser.Senha)
                    oldUser.Senha = newUser.Senha;
                if (oldUser.User != newUser.User)
                    oldUser.User = newUser.User;
                if (oldUser.AccountType != newUser.AccountType)
                    oldUser.AccountType = newUser.AccountType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return (hasUpdated, oldUser);
        }
    }
    */

    /*
    public static class AlunoDAO
    {
        public static bool ConsultarAluno(this Aluno al)
        {
            bool exists = false;

            try
            {
                DAO_Connection.Connection.Open();

                exists = new QueryBuilder()
                    .SELECT()
                    .FROM("Estudio_Aluno")
                    .WHERE("CPFAluno = " + al.CPF.Quote())
                    .ToCommand(DAO_Connection.Connection)
                    .ExecuteReader()
                    .Read();
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

        public static bool CadastrarAluno(this Aluno al)
        {
            bool status = false;

            try
            {
                DAO_Connection.Connection.Open();

                var insert = new QueryBuilder()
                    .INSERT()
                    .INTO("Estudio_Aluno")
                    .COLUMNS("CPFAluno", "nomeAluno", "ruaAluno", "numeroAluno", "bairroAluno", "complementoAluno", "CEPAluno", "cidadeAluno", "estadoAluno", "telefoneAluno", "emailAluno")
                    .VALUES(al.CPF, al.Nome, al.Rua, al.Numero, al.Bairro, al.Complemento, al.CEP, al.Cidade, al.Estado, al.Telefone, al.Email)
                    .ToCommand(DAO_Connection.Connection);

                insert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return status;
        }

        public static bool ExcluirAluno(this Aluno al)
        {
            bool status = false;

            try
            {
                DAO_Connection.Connection.Open();

                var commmand = new QueryBuilder()
                    .UPDATE("Estudio_Aluno")
                    .SET(("ativoAluno", "1"))
                    .WHERE("CPFAluno = " + al.CPF)
                    .ToCommand(DAO_Connection.Connection);

                commmand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DAO_Connection.Connection.Close();
            }

            return status;
        }
    }
    */
}

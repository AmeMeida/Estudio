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

    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendQuote(this StringBuilder builder, string value) => builder.Append(" '").Append(value).Append("' ");
        public static StringBuilder AppendComma(this StringBuilder builder, string value) => builder.Append(" '").Append(value).Append("', ");
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

            con.Close();
        }

        public static UserType Login(string usuario, string senha)
        {
            var utype = UserType.NotFound;

            try {
                con.Open();
                var loginCommand = new StringBuilder()
                    .Append("SELECT * FROM Estudio_Login where usuario = ").Append("'" + usuario.Check() + "'")
                    .Append(" and ")
                    .Append("senha = ").Append("'" + senha.Check() + "';")
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

        public static bool CadLogin(string user, string password, UserType uType)
        {
            bool cadStatus = false;

            try
            {
                con.Open();

                var insert = new StringBuilder()
                    .Append("INSERT INTO Estudio_Login(usuario, senha, tipo) VALUES(")
                    .AppendQuote(user.Check())
                    .Append(",")
                    .AppendQuote(password.Check())
                    .Append(",")
                    .AppendQuote(((int)uType).ToString())
                    .Append(")")
                    .ToString();

                var query = new MySqlCommand(insert, con);
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

        public static bool CadAluno(Aluno al) => CadAluno(al.CPF, al.Nome, al.Rua, al.Numero, al.Bairro, al.Complemento, al.CEP, al.Cidade, al.Estado, al.Telefone, al.Email);

        public static bool CadAluno(string cpf, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            bool status = false;

            try
            {
                con.Open();

                var command = new StringBuilder("INSERT INTO Estudio_Aluno(CPFAluno, nomeAluno, ruaAluno, numeroAluno, bairroAluno, complementoAluno, CEPAluno, cidadeAluno, estadoAluno, telefoneAluno, emailAluno) VALUES(")
                    .AppendComma(cpf)
                    .AppendComma(nome)
                    .AppendComma(rua)
                    .AppendComma(numero)
                    .AppendComma(bairro)
                    .AppendComma(complemento)
                    .AppendComma(cep)
                    .AppendComma(cidade)
                    .AppendComma(estado)
                    .AppendComma(telefone)
                    .AppendQuote(email)
                    .Append(");")
                    .ToString();

                var insert = new MySqlCommand(command, con);
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
    }
}

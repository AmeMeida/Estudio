using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    public static class StringExtensions
    {
        public static string Check(this string str) => !string.IsNullOrEmpty(str) ? str.Trim() : throw new ArgumentNullException(nameof(str) + " não deve estar vazio.");

        public static string Quote(this string str) => "'" + str.Check() + "'";
    }

    class Usuario
    {
        // public static 
        public string User { get; }
        public string Senha { get; }
        public UserType AccountType { get; }

        public Usuario(string user, string senha)
        {
            AccountType = DAO_Connection.Login(user, senha);

            User =  user.Check();
            Senha = senha.Check();
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("Usuário:  ").AppendLine(User)
                .Append("Tipo da conta:  ").AppendLine(Enum.GetName(AccountType.GetType(), AccountType))
                .ToString();
        }
    }
}

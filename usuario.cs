using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    public enum UserType
    {
        NotFound = 0,
        User = 1,
        Admin = 2,
    }

    public static class StringExtensions
    {
        public static string Check(this string str) => !string.IsNullOrEmpty(str) ? str.Trim() : throw new ArgumentNullException(nameof(str) + " não deve estar vazio.");

        public static string Quote(this string str) => "'" + str.Check() + "'";
    }

    public class Usuario
    {
        private string user;
        private string senha;

        // public static 
        public string User
        {
            get => user;
            set => user = value.Check();
        }
        public string Senha 
        {
            get => senha; 
            set => senha = value.Check();
        }
        public UserType AccountType { get; set; }

        public Usuario(string user, string senha)
        {
            User = user;
            Senha = senha;
        }

        public Usuario(string user, string senha, UserType accountType) : this(user, senha)
        {
            AccountType = accountType;
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

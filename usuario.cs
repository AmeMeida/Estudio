using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Usuario
    {
        public string User { get; }
        public string Senha { get; }
        public UserType AccountType { get; }

        public Usuario(string user, string senha)
        {
            AccountType = DAO_Connection.Login(user, senha);

            User = user ?? throw new ArgumentNullException(nameof(user));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
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

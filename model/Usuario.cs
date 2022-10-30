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

    [Entity, Table("Estudio_Login")]
    public class Usuario
    {
        private string user;
        private string senha;

        [Column("tipo")]
        public UserType AccountType { get; set; }

        [ID, Column("usuario")]
        public string User
        {
            get => user;
            set => user = value.Check();
        }

        [Column("senha")]
        public string Senha
        {
            get => senha;
            set => senha = value.Check();
        }

        public Usuario() { }

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

    public static class LoginDAO
    {
        public static bool Cadastrar(this Usuario e) => ORM<Usuario>.Save(e);
        public static bool Consultar(this Usuario e) => ORM<Usuario>.Check(e);
        public static Usuario[] List() => ORM<Usuario>.GetAll(("ativo", 1));
        public static UserType Login(this Usuario e) => (UserType)(ORM<Usuario>.FetchProp(e, "AccountType", true) ?? UserType.NotFound);
        public static (bool hasUpdated, Usuario updatedUser) Update(this Usuario e, Usuario newUser) 
            => ORM<Usuario>.UpdateFrom(e, newUser);
        public static bool Excluir(this Usuario e) => ORM<Usuario>.Update(e, ("ativo", 0)).updateStatus;
    }
}

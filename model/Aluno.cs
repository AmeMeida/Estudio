using Estudio.model.dao;
using MySql.Data.MySqlClient;
using System;
using System.Runtime.CompilerServices;

namespace Estudio
{
    [Entity, Table("Estudio_Aluno")]
    public class Aluno : IDAO<Aluno>
    {
        private string _cpf;
        private string _nome;
        private string _rua;
        private string _numero;
        private string _bairro;
        private string _complemento;
        private string _cep;
        private string _cidade;
        private string _estado;
        private string _telefone;
        private string _email;
        private byte[] _foto;
        private bool _ativo;

        [ID, Column("CPFAluno")]
        public string CPF
        {
            get => _cpf;
            set => _cpf = value.Check();
        }

        [Column("nomeAluno")]
        public string Nome 
        { 
            get => _nome; 
            set => _nome = value.Check();
        }

        [Column("ruaAluno")]
        public string Rua
        {
            get => _rua;
            set => _rua = value.Check();
        }

        [Column("numeroAluno")]
        public string Numero
        {
            get => _numero;
            set => _numero = value.Check();
        }

        [Column("bairroAluno")]
        public string Bairro
        {
            get => _bairro;
            set => _bairro = value.Check();
        }

        [Column("complementoAluno")]
        public string Complemento 
        {
            get => _complemento;
            set => _complemento = value.Check();
        }

        [Column("CEPAluno")]
        public string CEP
        {
            get => _cep;
            set => _cep = value.Check();
        }

        [Column("cidadeAluno")]
        public string Cidade
        {
            get => _cidade;
            set => _cidade = value.Check();
        }

        [Column("estadoAluno")]
        public string Estado
        {
            get => _estado;
            set => _estado = value.Check();
        }

        [Column("telefoneAluno")]
        public string Telefone
        {
            get => _telefone;
            set => _telefone = value.Check();
        }

        [Column("emailAluno")]
        public string Email
        {
            get => _email;
            set => _email = value.Check();
        }

        [Column("fotoAluno")]
        public byte[] Foto
        {
            get => _foto;
            set => _foto = value;
        }

        [Column("ativo")]
        public bool Ativo
        {
            get => _ativo;
            set => _ativo = value;
        }

        public Aluno(string cpf, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            CPF = cpf;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            Telefone = telefone;
            Email = email;
            Ativo = true;
        }

        public Aluno() { }


        public bool Save() => ORM<Aluno>.Save(this);
        public bool Delete() => ORM<Aluno>.Update(this, ("ativo", 0)).updateStatus;
        public bool Check() => ORM<Aluno>.Check(this);
        public bool Update(Aluno newAluno)
            => ORM<Aluno>.UpdateFrom(this, newAluno).updateStatus;
        public object ID => CPF;
    }
}

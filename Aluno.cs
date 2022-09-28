namespace Estudio
{
    public class Aluno
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

        public string CPF
        {
            get => _cpf;
            set
            {
                _cpf = value.Check();
            }
        }


        public string Nome 
        { 
            get => _nome; 
            set
            {
                _nome = value.Check();
            }
        }

        public string Rua
        {
            get => _rua;
            set
            {
                _rua = value.Check();
            }
        }

        public string Numero
        {
            get => _numero;
            set
            {
                _numero = value.Check();
            }
        }

        public string Bairro
        {
            get => _bairro;
            set
            {
                _bairro = value.Check();
            }
        }

        public string Complemento 
        {
            get => _complemento;
            set
            {
                _complemento = value.Check();
            } 
        }

        public string CEP
        {
            get => _cep;
            set
            { 
                _cep = value.Check();
            }
        }

        public string Cidade
        {
            get => _cidade;
            set
            {
                _cidade = value.Check();
            }
        }

        public string Estado
        {
            get => _estado;
            set
            {
                _estado = value.Check();
            }
        }

        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value.Check();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value.Check();
            }
        }

        public byte[] Foto
        {
            get => _foto;
            set
            {
                _foto = value;
            }
        }

        public bool Ativo
        {
            get => _ativo;
            set
            {
                _ativo = value;
            }
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

            DAO_Connection.CadAluno(cpf, nome, rua, numero, bairro, complemento, cep, cidade, estado, telefone, email);
        }

        public Aluno() { }
    }
}

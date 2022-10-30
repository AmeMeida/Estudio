using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.model
{
    [Entity, Table("Estudio_Modalidade")]
    public class Modalidade
    {
        private string _descricao;
        private float _preco;
        private int _qtdeAlunos;
        private int _qtdeAulas;

        [ID, Column("descricaoModalidade")]
        public string Descricao
        {
            get => _descricao;
            set => _descricao = value.Check();
        }

        [Column("precoModalidade")]
        public float Preco
        {
            get => _preco;
            set => _preco = value;
        }

        [Column("qtdeAlunos")]
        public int Qtde_Alunos
        {
            get => _qtdeAlunos;
            set => _qtdeAlunos = value;
        }

        [Column("qtdeAulas")]
        public int Qtde_Aulas
        {
            get => _qtdeAulas;
            set => _qtdeAulas = value;
        }

        public Modalidade(string descricao, float preco, int qtde_Alunos, int qtde_Aulas)
        {
            Descricao = descricao;
            Preco = preco;
            Qtde_Alunos = qtde_Alunos;
            Qtde_Aulas = qtde_Aulas;
        }

        public Modalidade(string descricao) => Descricao = descricao;

        public Modalidade() { }
    }

    public static class ModalidadeDAO
    {
        public static bool Cadastrar(this Modalidade e) => ORM<Modalidade>.Save(e);
        public static bool Update(this Modalidade e, Modalidade newModalide) => ORM<Modalidade>.UpdateFrom(e, newModalide).updateStatus;
        public static bool Excluir(this Modalidade e)
            => ORM<Modalidade>.Update(e, ("ativo", 0)).updateStatus;
        public static Modalidade[] List()
            => ORM<Modalidade>.GetAll(("ativo", 1));
    }
}

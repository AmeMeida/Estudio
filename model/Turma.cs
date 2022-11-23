using Estudio.model.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio.model
{
    [Entity, Table("Estudio_Turma")]
    public class Turma
    {
        [Column("professorTurma")]
        public string Professor { get; set; }

        [Column("diasSemanaTurma")]
        public string DiaSemana { get; set; }

        [Column("horasTurma")]
        public string Hora { get; set; }

        [Column("idModalidade")]
        public int? Modalidade { get; set; }

        [ID, Column("idEstudio_Turma")]
        public int? ID { get; set; }

        [Column("noAlunosMatriculadosTurma")]
        public int NoAlunos { get; set; }

        public Turma(string professor, string diaSemana, string hora, int modalidade, int noAlunos)
        {
            Professor = professor;
            DiaSemana = diaSemana;
            Hora = hora;
            Modalidade = modalidade;
            NoAlunos = noAlunos;
        }

        public Turma() { }

    }

    public static class TurmaDAO
    {
        public static bool Cadastrar(this Turma turma) => ORM<Turma>.Save(turma);
        public static bool Remover(this Turma turma)
        {
            var removed = false;

            DAO_Connection.Connection.Open();
            var trans = DAO_Connection.Connection.BeginTransaction();

            removed = new QueryBuilder()
                .DELETE()
                .FROM("Estudio_Turma")
                .WHERE("idModalidade = '" + turma.Modalidade + "'")
                .AND("professorTurma = '" + turma.Professor + "'")
                .AND("horasTurma = '" + turma.Hora + "'")
                .LogQuery()
                .DisplayQuery()
                .ToCommand()
                .ExecuteNonQuery() > 0;

            trans.Commit();
            DAO_Connection.Connection.Close();
            return removed;
        }
        public static bool Consultar(this Turma turma) => ORM<Turma>.Check(turma);
        public static bool Atualizar(this Turma oldState, Turma newState) => ORM<Turma>.UpdateFrom(oldState, newState).updateStatus;
    }
}

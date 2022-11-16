using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.model
{
    [Entity, Table("Estudio_Turma")]
    public class Turma
    {
        [Column("idEstudio_Turma")]
        public int IDTurma { get; set; }

        [Column("idModalidade")]
        public int IDModalidade { get; set; }

        [Column("diasSemanaTurma")]
        public string DiasSemana { get; set; }

        [Column("professorTurma")]
        public string Professor { get; set; }

        [Column("horasTurma")]
        public string Horas { get; set; }

        [Column("noAlunosMatriculadosTurma")]
        public int QntAlunos { get; set; }

        public Turma(int iDModalidade, string diasSemana, string professor, string horas) : this(iDModalidade, diasSemana)
        {
            Professor = professor;
            Horas = horas;
        }

        public Turma(int iDModalidade, string diasSemana) : this(iDModalidade)
        {
            DiasSemana = diasSemana;
        }

        public Turma(int iDModalidade)
        {
            IDModalidade = iDModalidade;
        }

        public Turma() { }

    }

    public static class TurmaDAO
    {
        public static bool Save(this Turma turma) => ORM<Turma>.Save(turma);
        public static bool Delete(this Turma turma) => ORM<Turma>.Delete(turma);
        public static bool Update(this Turma turma, Turma newState) => ORM<Turma>.UpdateFrom(turma, newState).updateStatus;
        public static bool Check(this Turma turma) => ORM<Turma>.Check(turma);
    }
}

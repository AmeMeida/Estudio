using Estudio.model.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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
        public string Modalidade { get; set; }

        [ID, Column("idEstudio_Turma")]
        public int ID { get; set; }

        [Column("noAlunosMatriculadosTurma")]
        public int NoAlunos { get; set; }

        public Turma(string professor, string diaSemana, string hora, string modalidade, int noAlunos)
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
        public static bool Remover(this Turma turma) => ORM<Turma>.Delete(turma);
        public static bool Consultar(this Turma turma) => ORM<Turma>.Check(turma);
        public static bool Atualizar(this Turma oldState, Turma newState) => ORM<Turma>.UpdateFrom(oldState, newState).updateStatus;
    }
}

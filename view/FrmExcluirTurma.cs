using Estudio.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio.view
{
    public partial class FrmExcluirTurma : Form
    {
        public FrmExcluirTurma()
        {
            InitializeComponent();
        }

        private void FrmExcluirTurma_Load(object sender, EventArgs e)
        {
            cbModalidade.DataSource = ORM<Modalidade>.Select();
        }

        private void cbModalidade_SelectedIndexChanged(object sender = null, EventArgs e = null)
        {
            var turmas = ORM<Turma>.Select(("idModalidade", SQLOp.EQ, ((Modalidade)cbModalidade.SelectedValue).ID));

            if (turmas != null)
            {
                cbProfessor.DataSource = turmas.Select(x => x.Professor).ToArray();
                cbHora.DataSource = turmas.Select(x => x.Hora).ToArray();
            }
            else
            {
                cbProfessor.DataSource = Array.Empty<object>();
                cbProfessor.Text = string.Empty;
                cbHora.DataSource = Array.Empty<object>();
                cbHora.Text = string.Empty;
            }
        }

        private void cbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var turmas = ORM<Turma>.Select(("idModalidade", SQLOp.EQ, ((Modalidade)cbModalidade.SelectedValue).ID), ("professorTurma", SQLOp.EQ, cbProfessor.Text));

            if (turmas != null)
            {
                cbHora.DataSource = turmas.Select(x => x.Hora).ToArray();
            }
            else
            {
                cbHora.DataSource = Array.Empty<object>();
                cbHora.Text = string.Empty;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbHora.Text) || string.IsNullOrWhiteSpace(cbProfessor.Text))
            {
                MessageBox.Show("Uma turma com essa modalidade não existe!", "Impossível excluir.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Turma turma = new Turma()
            {
                Modalidade = ((Modalidade)cbModalidade.SelectedValue).ID,
                Professor = cbProfessor.Text,
                Hora = cbHora.Text,
            };

            if (turma.Remover())
            {
                MessageBox.Show("Turma removida com sucesso!");
                cbModalidade_SelectedIndexChanged();
            }
            else
                MessageBox.Show("Impossível remover!");
        }
    }
}

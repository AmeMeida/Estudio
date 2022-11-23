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
    public partial class FrmConsultarTurma : Form
    {
        public FrmConsultarTurma()
        {
            InitializeComponent();
        }

        private void FrmConsultarTurma_Load(object sender, EventArgs e)
        {
            cbModalidade.DataSource = ORM<Modalidade>.Select();
            cbModalidade.DisplayMember = "Descricao";
            this.ImplementNext();
        }

        private string DiasSemana()
        {
            var items = chklstDias.CheckedItems.Cast<string>();
            var s = new StringBuilder();

            foreach (var item in items.Take(items.Count() - 1))
                s.Append(item + ";");
            s.Append(items.Last());

            return s.ToString();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var turma = new Turma
            {
                Hora = mtxHora.Text,
                DiaSemana = DiasSemana(),
                Modalidade = ((Modalidade)cbModalidade.SelectedValue).Descricao,
                Professor = txtProfessor.Text
            };

            if (turma.Cadastrar())
                MessageBox.Show("Turma salva com sucesso!", "Turma cadastrada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Houve um erro ao cadastrar a turma.", "Impossível cadastrar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtProfessor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

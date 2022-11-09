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
    public partial class FrmConsultarAlunos : Form
    {
        public FrmConsultarAlunos()
        {
            InitializeComponent();
        }

        private void AtualizarLista(object sender = null, EventArgs e = null)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                lstBuscar.DataSource = ORM<Aluno>.GetAll();
            else
                lstBuscar.DataSource = ORM<Aluno>.GetAll().Where(x => x.Nome.StartsWith(txtBuscar.Text, true, System.Globalization.CultureInfo.CurrentCulture)).ToList();
        }

        private void Excluir(object sender = null, EventArgs e = null)
        {
            if (lstBuscar.SelectedIndex < 0)
                return;

            if (((Aluno)lstBuscar.SelectedValue).Delete())
            {
                MessageBox.Show("Aluno excluído com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarLista();
            }
            else
                MessageBox.Show("Não foi possível excluir o aluno.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Visualizar(object sender = null, EventArgs e = null)
            => MdiParent.GetChild<FrmCadastroAluno, Aluno>(FormModes.Visualizacao, lstBuscar.SelectedValue as Aluno);
    }
}

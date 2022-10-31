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
    public partial class FrmConsultarModalidades : Form
    {
        public FrmConsultarModalidades()
        {
            InitializeComponent();

            cbBuscar.DisplayMember = "Descricao";
            ResetSources();
        }

        private void ResetSources(object sender = null, EventArgs e = null) => SetFrom();

        private void SetFrom(Modalidade[] modalidades = null)
            => cbBuscar.DataSource = modalidades ?? ModalidadeDAO.List();

        private void btnAlterarSenha_Click(object sender = null, EventArgs e = null)
        {
            var forms = MdiParent.MdiChildren.OfType<FrmCadastroModalidade>().Where(x => x.Mode == FormModes.Edicao);
            FrmCadastroModalidade form;

            if (!(cbBuscar.SelectedValue is Modalidade modal))
            {
                MessageBox.Show("Por favor, selecione um usuário.", "Impossível editar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (forms.Count() < 1)
            {
                form = new FrmCadastroModalidade(modal) { MdiParent = MdiParent };
            }
            else
            {
                form = forms.First();
                form.Value = modal;
            }
            
            form.Show();
            form.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (((Modalidade)cbBuscar.SelectedValue).Excluir())
            {
                MessageBox.Show("Modalidade excluída com sucesso.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSources();
            }
            else
                MessageBox.Show("Não foi possível excluir a modalidade.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

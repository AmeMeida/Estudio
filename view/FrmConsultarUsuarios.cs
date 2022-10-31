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
    public partial class FrmConsultarUsuarios : Form
    {
        public FrmConsultarUsuarios()
        {
            InitializeComponent();

            cbBuscar.DisplayMember = "User";
            ResetSources();
        }

        private void ResetSources(object sender = null, EventArgs e = null) => SetFrom();

        private void SetFrom(Usuario[] usuarios = null)
            => cbBuscar.DataSource = usuarios ?? LoginDAO.List();

        private void btnAlterarSenha_Click(object sender = null, EventArgs e = null)
        {
            var forms = MdiParent.MdiChildren.OfType<FrmCadastroUsuario>().Where(x => x.Mode == FormModes.Edicao);
            FrmCadastroUsuario form;

            if (!(cbBuscar.SelectedValue is Usuario user))
            {
                MessageBox.Show("Por favor, selecione um usuário.", "Impossível editar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (forms.Count() < 1)
            {
                form = new FrmCadastroUsuario(user) { MdiParent = MdiParent };
            }
            else
            {
                form = forms.First();
                form.Value = user;
            }
            
            form.Show();
            form.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (((Usuario)cbBuscar.SelectedValue).Excluir())
            {
                MessageBox.Show("Usuário excluído com sucesso.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSources();
            }
            else
                MessageBox.Show("Não foi possível excluir o usuário.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

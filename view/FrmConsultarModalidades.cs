using Estudio.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public Modalidade Value => cbBuscar.SelectedValue as Modalidade;

        private void ResetSources(object sender = null, EventArgs e = null) => SetFrom();

        private void SetFrom(Modalidade[] modalidades = null)
            => cbBuscar.DataSource = modalidades ?? ModalidadeDAO.List();

        private void btnAlterarSenha_Click(object sender = null, EventArgs e = null)
        {
            if (cbBuscar.HasSelectedWarn())
                MdiParent.GetChild<FrmCadastroModalidade, Modalidade>(FormModes.Edicao, Value);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Value.Excluir())
            {
                MessageBox.Show("Modalidade excluída com sucesso.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSources();
            }
            else
                MessageBox.Show("Não foi possível excluir a modalidade.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

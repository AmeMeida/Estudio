using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Estudio
{
    public partial class FrmCadastroAluno : Form
    {
        public FrmCadastroAluno()
        {
            InitializeComponent();
            this.ImplementNext();
            txtEmail.KeyPress += txtEmail_KeyPress;
        }

        private void CadastrarAluno(object sender = null, EventArgs e = null)
        {
            if (this.VerifyTextBox())
                return;

            try
            {
                var al = new Aluno(mtxCPF.Text, txtNome.Text, txtEndereco.Text, txtNum.Text, txtBairro.Text, txtComplemento.Text, mtxCEP.Text, txtCidade.Text, txtEstado.Text, mtxTelefone.Text, txtEmail.Text);

                if (al.Cadastrar()) {
                    MessageBox.Show("Aluno cadastrado com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Dispose();
                } else {
                    MessageBox.Show("Houve um erro ao cadastrar o aluno.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Houve um erro ao cadastrar o aluno. Verifique os campos.", "Dados incorretos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter) || ((TextBoxBase)sender).IsEmpty())
                return;

            CadastrarAluno();
        }

        private void FrmCadastroAluno_Load(object sender, EventArgs e)
        {

        }
    }
}

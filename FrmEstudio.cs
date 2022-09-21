using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class FrmEstudio : Form
    {
        private Usuario _user = null;

        public FrmEstudio()
        {
            try {
                DAO_Connection.GetConnection();
                Console.WriteLine("Conexão estabelecida com sucesso");
            } catch (Exception) {
                Console.WriteLine("Houve um erro na conexão.");
            }

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user  = txtLogin.Text.Trim();
            var senha = txtSenha.Text.Trim();

            _user = new Usuario(user, senha);
            UserLogin();
        }

        private void UserLogin()
        {
            if (_user == null)
                return;

            switch (_user.AccountType)
            {
                case UserType.NotFound:
                    MessageBox.Show("Este usuário não foi encontrado.", "Impossível conectar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogin.Focus();
                    break;

                case UserType.User:
                    gbLogin.Visible = false;
                    MessageBox.Show("Bem vindo(a), " + _user.User + "!", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case UserType.Admin:
                    gbLogin.Visible = false;
                    menuStrip1.Enabled = true;
                    MessageBox.Show("Olá, administrador(a) " + _user.User + ".", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCadastrarAluno = new FrmCadastroAluno
            {
                MdiParent = this
            };
            frmCadastrarAluno.Show();
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCadastrarUsuario = new FrmCadastroUsuario
            {
                MdiParent = this
            };
            frmCadastrarUsuario.Show();
        }
    }
}

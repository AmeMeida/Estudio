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
        private Usuario _user;

        private Usuario User
        {
            get => _user;
            set
            {
                _user = value;
                UserLogin();
            }
        }

        public FrmEstudio()
        {
            try {
                DAO_Connection.GetConnection();
                Console.WriteLine("Conexão estabelecida com sucesso");
            } catch (Exception) {
                Console.WriteLine("Houve um erro na conexão.");
            }

            InitializeComponent();
            User = null;
        }

        public void LoginScreen()
        {
            gbLogin.Visible = true;
            menuStrip.Enabled = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = new Size(252, 197);
        }

        public void LoggedScreen()
        {
            Size = new Size(800, 700);
            gbLogin.Visible = false;
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        public void AdminScreen()
        {
            LoggedScreen();
            menuStrip.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e) => User = new Usuario(txtLogin.Text, txtSenha.Text);

        private void UserLogin()
        {
            if (User == null)
            {
                LoginScreen();
                return;
            }

            switch (User.Login())
            {
                case UserType.NotFound:
                    MessageBox.Show("Este usuário não foi encontrado.", "Impossível conectar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogin.Focus();
                    break;

                case UserType.User:
                    LoggedScreen();
                    MessageBox.Show("Bem vindo(a), " + User.User + "!", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case UserType.Admin:
                    AdminScreen();
                    MessageBox.Show("Olá, administrador(a) " + User.User + ".", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void modalidaderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) => User = null;

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

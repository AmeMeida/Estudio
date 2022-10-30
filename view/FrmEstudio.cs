using Estudio.model;
using Estudio.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Estudio.FormExtensions;

namespace Estudio
{
    public partial class FrmEstudio : Form
    {
        private Usuario _user = null;

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
            // if (!DAO_Connection.Connection.Ping())
            // MessageBox.Show("Impossível conectar-se! Verifique sua internet.", "Erro de conexão.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            InitializeComponent();
            User = Params.defaultUser;
        }

        private void LoginScreen()
        {
            gbLogin.Visible = true;
            menuStrip.Enabled = false;
            Size = new Size(289, 201);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
        private void LoggedScreen()
        {
            gbLogin.ClearAllText();
            gbLogin.Visible = false;
            Size = new Size(800, 600);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
        }
        private void AdminScreen()
        {
            LoggedScreen();
            menuStrip.Enabled = true;
        }
        private void RestritoScreen()
        {
            LoggedScreen();
        }
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
                    RestritoScreen();
                    MessageBox.Show("Bem vindo(a), " + _user.User + "!", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case UserType.Admin:
                    AdminScreen();
                    MessageBox.Show("Olá, administrador(a) " + _user.User + ".", "Login realizado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void btnLogin_Click(object sender = null, EventArgs e = null)
        {
            if (this.VerifyTextBox())
                return;

            try {
                User = new Usuario(txtLogin.Text, txtSenha.Text);
            } catch (ArgumentException) {
                MessageBox.Show("Usuário ou senha inválido.", "Aviso do Sistema!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
            }
        }

        private void ShowCadastroAluno(object sender = null, EventArgs e = null) 
            => this.GetChild<FrmCadastroAluno>(true);
        private void ShowCadastroUsuario(object sender = null, EventArgs e = null) 
            => this.GetChild<FrmCadastroUsuario>(FormModes.Cadastro);

        private void NextControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter))
                return;

            SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter))
                return;

            SelectNextControl((Control)sender, true, true, true, true);
            btnLogin_Click();
        }

        private void Sair(object sender = null, EventArgs e = null) => User = null;

        private void ShowConsultarUsuarios(object sender = null, EventArgs e = null) =>
            this.GetChild<FrmConsultarUsuarios>(true);

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ShowCadastroModalidade(object sender, EventArgs e)
            => this.GetChild<FrmCadastroModalidade>(FormModes.Cadastro);

        private void ShowConsultarModalidades(object sender, EventArgs e)
            => this.GetChild<FrmConsultarModalidades>(true);
    }
}

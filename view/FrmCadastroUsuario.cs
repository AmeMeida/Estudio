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
    public interface IModalForm
    {
        FormModes Mode { get; set; }
    }

    public enum FormModes
    {
        Cadastro,
        Edicao,
        Visualizacao
    }

    public partial class FrmCadastroUsuario : Form, IModalForm
    {
        private FormModes _mode;
        private Usuario _user;

        public Usuario User
        {
            get => _user;

            set
            {
                _user = value;
                Mode = value == null ? FormModes.Cadastro : FormModes.Edicao;

                if (value != null)
                {
                    txtUsuario.Text = value.User;
                    txtSenha.Text = string.Empty;
                    cboUserType.SelectedValue = value.AccountType;
                }
            }
        }

        public FormModes Mode
        {
            get => _mode;

            set
            {
                _mode = value;

                switch(value)
                {
                    case FormModes.Cadastro:
                        txtSenha.Location = new Point(70, 46);
                        txtSenha.Size = new Size(250, 20);
                        chkHasSenha.Visible = false;
                        chkHasSenha.Checked = false;
                        txtSenha.Enabled = true;
                        btnCadastrarUsuario.Text = "Cadastrar";
                        Text = "Cadastrar um novo usuário";
                        break;

                    case FormModes.Edicao:
                        txtSenha.Location = new Point(93, 46);
                        txtSenha.Size = new Size(227, 20);
                        chkHasSenha.Visible = true;
                        chkHasSenha.Checked = false;
                        txtSenha.Enabled = false;
                        btnCadastrarUsuario.Text = "Salvar";
                        Text = "Alterar usuário existente";
                        break;
                }
            }
        }

        public FrmCadastroUsuario(Usuario user)
        {
            InitializeComponent();
            cboUserType.DisplayMember = "Key";
            cboUserType.ValueMember = "Value";

            cboUserType.DataSource =
                (from UserType uType in Enum.GetValues(typeof(UserType))
                 where uType != UserType.NotFound
                 select new { Key = Enum.GetName(typeof(UserType), uType), Value = uType }).ToList();

            User = user;
            UpdateSaveButton();
            cboUserType.SelectedIndexChanged += UpdateSaveButton;
            txtUsuario.TextChanged += UpdateSaveButton;
            txtSenha.TextChanged += UpdateSaveButton;
            chkHasSenha.CheckedChanged += UpdateSaveButton;
            this.ImplementNext();
        }

        public FrmCadastroUsuario() : this(null) { }
         
        private bool HasChanged => Mode == FormModes.Edicao && (cboUserType.SelectedIndex != -1 && (UserType)cboUserType.SelectedValue != User.AccountType || txtUsuario.Text.Trim() != User.User || (chkHasSenha.Checked && !string.IsNullOrWhiteSpace(txtSenha.Text)));

        private void UpdateSaveButton(object sender = null, EventArgs e = null)
        {
            if (Mode == FormModes.Cadastro)
                return;

            btnCadastrarUsuario.Enabled = HasChanged;
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario user;

            try
            {
                if (Mode == FormModes.Cadastro && this.VerifyTextBox())
                    return;

                string senha = 
                    Mode == FormModes.Cadastro || (chkHasSenha.Checked && !string.IsNullOrWhiteSpace(txtSenha.Text) && txtSenha.Text != User.Senha) 
                    ? txtSenha.Text : User.Senha;

                user = new Usuario(txtUsuario.Text, senha, (UserType)cboUserType.SelectedValue);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Verifique se todos os campos foram preenchidos e tente novamente.", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            
            switch (Mode)
            {
                case FormModes.Cadastro:
                    if (user.Cadastrar())
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Houve um erro ao cadastrar, tente novamente mais tarde.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case FormModes.Edicao:
                    var (hasUpdated, updatedUser) = User.Update(user);

                    if (hasUpdated)
                    {
                        User = updatedUser;
                        MessageBox.Show("Usuário atualizado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar o cadastro.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    UpdateSaveButton();
                    break;
            }
        }

        private void chkHasSenha_CheckedChanged(object sender = null, EventArgs e = null)
            => txtSenha.Enabled = chkHasSenha.Checked;
    }
}

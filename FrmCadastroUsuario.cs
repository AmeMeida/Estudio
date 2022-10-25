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
    public partial class FrmCadastroUsuario : Form
    {
        public FrmCadastroUsuario()
        {
            InitializeComponent();
            cboUserType.DisplayMember = "Key";
            cboUserType.ValueMember = "Value";

            cboUserType.DataSource =
                (from UserType uType in Enum.GetValues(typeof(UserType))
                 where uType != UserType.NotFound
                 select new { Key = Enum.GetName(typeof(UserType), uType), Value = uType }).ToList();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new Usuario(txtUsuario.Text, txtSenha.Text, (UserType)cboUserType.SelectedValue);

                if (user.CadastrarLogin())
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Houve um erro ao cadastrar, tente novamente mais tarde.", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erro ao cadastrar.", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
            // cboUserType.DataSource = Enum.GetValues(typeof(UserType)).Cast<UserType>().Where(x => x != UserType.NotFound)
            //     .Select(x => new { Key = Enum.GetName(typeof(UserType), x), Value = x }).ToList();
            cboUserType.DisplayMember = "Key";
            cboUserType.ValueMember   = "Value";

            cboUserType.DataSource =
                (from UserType uType in Enum.GetValues(typeof(UserType))
                 where uType != UserType.NotFound
                 select new { Key = Enum.GetName(typeof(UserType), uType), Value = uType }).ToList();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e) =>
            MessageBox.Show(DAO_Connection.CadLogin(txtUsuario.Text, txtSenha.Text, (UserType)cboUserType.SelectedValue) 
                ? "Usuário cadastrado com sucesso!" 
                : "Erro ao cadastrar.");
    }
}

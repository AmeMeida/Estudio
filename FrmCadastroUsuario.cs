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

            cboUserType.DataSource = Enum.GetValues(typeof(UserType)).Cast<UserType>()
                .Select(x => new { Key = Enum.GetName(typeof(UserType), x), Value = x });
            cboUserType.DisplayMember = "Key";
            cboUserType.ValueMember = "Value";
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            // TODO retornar um usuário ao clicar no botão.
        }
    }
}

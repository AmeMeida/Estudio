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

            var tipo = DAO_Connection.Login(user, senha);

            MessageBox.Show(tipo.Text, "Usuário.");
        }
    }
}

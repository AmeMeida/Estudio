using Estudio.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio.view
{
    public partial class FrmCadastroTurma : Form
    {
        public Modalidade Value
        {
            get => ((Modalidade)cbModalidade.SelectedValue);
            set => cbModalidade.Text = value.Descricao;
        }

        public FrmCadastroTurma()
        {
            InitializeComponent();
            this.ImplementNext();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var turma = new Turma()
            {
                Modalidade = Value.Descricao,
                Professor = txtProfessor.Text,
                DiaSemana = DiasSemana,
                Hora = mtxHora.Text,
                NoAlunos = (int)numAlunos.Value
            };

            if (turma.Cadastrar())
                MessageBox.Show("Turma cadastrada com sucesso!", "Cadastro realizado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não foi possível cadastrar a turma.", "Erro no cadastro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmCadastroTurma_Load(object sender, EventArgs e)
        {
            cbModalidade.DataSource = ORM<Modalidade>.Select();
        }

        private string DiasSemana =>
            chklstDiasSemana.CheckedItems.Cast<string>().Aggregate((x, y) => x + ";" + y);
    }
}

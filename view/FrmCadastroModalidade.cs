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
    public partial class FrmCadastroModalidade : Form, IModalForm
    {
        private Modalidade _modalidade;
        public Modalidade Modalidade
        {
            get => _modalidade;

            set
            {
                _modalidade = value;

                if (value != null)
                {
                    txtDescricao.Text = value.Descricao;
                    numPreco.Value = ((decimal)value.Preco);
                    numQntdAlunos.Value = decimal.Parse(value.Qtde_Alunos.ToString());
                    numQntdAulas.Value = decimal.Parse(value.Qtde_Aulas.ToString());
                    Mode = FormModes.Visualizacao;
                }
                else
                {
                    Mode = FormModes.Cadastro;
                }
            }
        }

        private FormModes _mode;
        public FormModes Mode
        {
            get => _mode;
            set
            {
                _mode = value;

                switch (_mode)
                {
                    case FormModes.Cadastro:
                        this.EnableAll();
                        this.ClearAllText();
                        btnEditar.Visible = false;
                        btnCadastro.Text = "Cadastrar";
                        btnCadastro.Enabled = true;
                        break;

                    case FormModes.Edicao:
                        this.EnableAll();
                        btnEditar.Visible = true;
                        btnEditar.Enabled = false;
                        btnCadastro.Text = "Salvar";
                        btnCadastro.Enabled = true;
                        break;

                    case FormModes.Visualizacao:
                        this.DisableAll();
                        btnEditar.Visible = true;
                        btnEditar.Enabled = true;
                        btnCadastro.Enabled = false;
                        btnCadastro.Text = "Salvar";
                        break;
                }
            }
        }


        public FrmCadastroModalidade(Modalidade modalidade)
        {
            InitializeComponent();
            Modalidade = modalidade;
        }

        public FrmCadastroModalidade() : this(null) { }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                var modalidade = new Modalidade(txtDescricao.Text, (float)numPreco.Value, (int)numQntdAlunos.Value, (int)numQntdAulas.Value);

                switch (Mode)
                {
                    case FormModes.Cadastro:
                        if (modalidade.Cadastrar())
                        {
                            MessageBox.Show("Modalidade cadastrada em sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Modalidade = modalidade;
                        } else
                            MessageBox.Show("Houve um erro ao cadastrar a modalidade, tente novamente mais tarde.", "Erro no cadastro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case FormModes.Edicao:
                        if (Modalidade.Update(modalidade))
                        {
                            MessageBox.Show("Modalidade alterada com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Modalidade = modalidade;
                        }
                        else
                            MessageBox.Show("Não foi possível atualizar a modalidade.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Os valores inseridos são inválidos. Tente novamente.", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
            => Mode = FormModes.Edicao;
    }
}

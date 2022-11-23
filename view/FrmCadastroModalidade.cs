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
    public partial class FrmCadastroModalidade : Form, IModalForm<Modalidade>
    {
        private Modalidade _value;
        public Modalidade Value
        {
            get => _value;

            set
            {
                _value = value;

                if (value != null)
                {
                    Mode = FormModes.Visualizacao;
                    cboBuscar.Text = value.Descricao;
                    txtDescricao.Text = Value.Descricao;
                    numPreco.Value = Convert.ToDecimal(Value.Preco);
                    numQntdAlunos.Value = Convert.ToDecimal(Value.Qtde_Alunos);
                    numQntdAulas.Value = Convert.ToDecimal(Value.Qtde_Aulas);
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
                        this.ClearAllText();
                        this.EnableAll();
                        ScrVisualizacao();
                        btnCadastro.Text = "Cadastrar";
                        gbCadastro.Text = "Cadastro";
                        break;

                    case FormModes.Edicao:
                        this.EnableAll();
                        ScrBusca();
                        btnCadastro.Text = "Salvar";
                        gbCadastro.Text = "Edição";
                        break;

                    case FormModes.Visualizacao:
                        this.DisableAll();
                        ScrBusca();
                        cboBuscar.Enabled = true;
                        btnCadastro.Enabled = true;
                        btnCadastro.Text = "Editar";
                        gbCadastro.Text = "Visualização";
                        break;
                }
            }
        }

        private void ScrVisualizacao()
        {
            Size = new Size(311, 297);
            gbCadastro.Location = new Point(0, 0);
            btnCadastro.Location = new Point(12, 225);
            cboBuscar.Visible = false;
            lblBusca.Visible = false;
        }

        private void ScrBusca()
        {
            Size = new Size(311, 347);
            gbCadastro.Location = new Point(0, 52);
            btnCadastro.Location = new Point(12, 277);
            cboBuscar.Visible = true;
            lblBusca.Visible = true;
            if (Value == null)
                cboBuscar.SelectedIndex = -1;
        }

        private void AtualizarCBO() => cboBuscar.DataSource = ORM.GetAllAtivos<Modalidade>();


        public FrmCadastroModalidade(Modalidade modalidade)
        {
            InitializeComponent();
            Value = modalidade;
            AtualizarCBO();
        }

        public FrmCadastroModalidade() : this(null) { }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (Mode == FormModes.Visualizacao)
                Mode = FormModes.Edicao;
            else
            {
                try
                {
                    var modalidade = new Modalidade(txtDescricao.Text, numPreco.FloatValue(), (int)numQntdAlunos.Value, (int)numQntdAulas.Value);

                    switch (Mode)
                    {
                        case FormModes.Cadastro:
                            if (modalidade.Cadastrar())
                            {
                                MessageBox.Show("Modalidade cadastrada em sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Value = modalidade;
                            } 
                            else
                                MessageBox.Show("Houve um erro ao cadastrar a modalidade, tente novamente mais tarde.", "Erro no cadastro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case FormModes.Edicao:
                            if (Value.Update(modalidade))
                            {
                                MessageBox.Show("Modalidade alterada com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Value = modalidade;
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
        }

        private void cboBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscar.HasSelectedWarn())
                Value = (Modalidade)cboBuscar.SelectedValue;
        }
    }
}

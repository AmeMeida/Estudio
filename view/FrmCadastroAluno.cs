using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Estudio
{
    public partial class FrmCadastroAluno : Form, IModalForm<Aluno>
    {
        private Aluno _value;
        public Aluno Value
        {
            get => _value;
            set
            {
                _value = value;

                if (_value == null)
                    Mode = FormModes.Cadastro;
                else
                {
                    txtNome.Text = _value.Nome;
                    txtBairro.Text = _value.Bairro;
                    txtCidade.Text = _value.Cidade;
                    txtComplemento.Text = _value.Complemento;
                    txtEmail.Text = _value.Email;
                    txtEndereco.Text = _value.Rua;
                    txtEstado.Text = _value.Estado;
                    txtNum.Text = _value.Numero;
                    mtxCEP.Text = _value.CEP;
                    mtxCPF.Text = _value.CPF;
                    mtxTelefone.Text = _value.Telefone;

                    Mode = FormModes.Visualizacao;
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

                switch(_mode)
                {
                    case FormModes.Cadastro:
                        gbCadastroAluno.ClearAllText();
                        gbCadastroAluno.EnableAll();
                        btnCadastrar.Text = "Cadastrar";
                        btnPic.Visible = true;
                        break;

                    case FormModes.Visualizacao:
                        gbCadastroAluno.DisableAll();
                        btnPic.Visible = false;
                        btnCadastrar.Text = "Editar";
                        btnCadastrar.Enabled = true;
                        break;

                    case FormModes.Edicao:
                        gbCadastroAluno.EnableAll();
                        btnPic.Visible = true;
                        btnCadastrar.Text = "Salvar";
                        break;
                }
            }
        }

        public FrmCadastroAluno(Aluno aluno)
        {
            InitializeComponent();
            this.ImplementNext();
            txtEmail.KeyPress += txtEmail_KeyPress;
            Value = aluno;
        }

        public FrmCadastroAluno() : this(null) { }

        private void CadastrarAluno(object sender = null, EventArgs e = null)
        {
            if (Mode == FormModes.Visualizacao)
            {
                Mode = FormModes.Edicao;
                return;
            }
        
            if (this.VerifyTextBox())
                return;

            try
            {
                var al = new Aluno(mtxCPF.Text, txtNome.Text, txtEndereco.Text, txtNum.Text, txtBairro.Text, txtComplemento.Text, mtxCEP.Text, txtCidade.Text, txtEstado.Text, mtxTelefone.Text, txtEmail.Text);

                switch (Mode)
                {
                    case FormModes.Cadastro:
                        if (al.Save()) {
                            MessageBox.Show("Aluno cadastrado com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Value = al;
                        } else {
                            MessageBox.Show("Houve um erro ao cadastrar o aluno.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case FormModes.Edicao:
                        if (Value.Update(al))
                        {
                            MessageBox.Show("Aluno atualizado com sucesso!", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Value = Value;
                        }
                        else
                        {
                            MessageBox.Show("Houve um erro ao atualizar o aluno.", "Aviso do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Houve um erro ao cadastrar o aluno. Verifique os campos.", "Dados incorretos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter) || ((TextBoxBase)sender).IsEmpty())
                return;

            CadastrarAluno();
        }

        private void FrmCadastroAluno_Load(object sender, EventArgs e)
        {

        }
    }
}

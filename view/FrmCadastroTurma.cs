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
    public partial class FrmCadastroTurma : Form, IModalForm<Turma>
    {
        private Turma _value;

        public Turma Value
        {
            get => _value;

            set
            {
                _value = value;

                txtProfessor.Text = value.Professor;
                cbModalidade.Text = ORM<Modalidade>.Select(("idEstudio_Modalidade", SQLOp.EQ, value.Modalidade)).First().Descricao;
                numAlunos.Value = value.NoAlunos;
                DiasSemana = value.DiaSemana;
                mtxHora.Text = value.Hora;
            }
        }

        public Turma SelTurma
        {
            get => new Turma() {
                Modalidade = ((Modalidade)cbModalidade.SelectedValue).ID,
                Professor = txtProfessor.Text,
                DiaSemana = DiasSemana,
                Hora = mtxHora.Text,
                NoAlunos = (int)numAlunos.Value
            };
        }

        public FormModes _mode;
        public FormModes Mode
        {
            get => _mode;

            set
            {
                _mode = value;

                switch (value)
                {
                    case FormModes.Visualizacao:
                        txtProfessor.Enabled = false;
                        numAlunos.Enabled = false;
                        chklstDiasSemana.Enabled = false;
                        mtxHora.Enabled = false;
                        cbModalidade.Enabled = false;
                        btnCadastrar.Text = "Atualizar";
                        break;

                    case FormModes.Cadastro:
                        txtProfessor.Enabled = true;
                        numAlunos.Enabled = true;
                        chklstDiasSemana.Enabled = true;
                        mtxHora.Enabled = true;
                        cbModalidade.Enabled = true;
                        btnCadastrar.Text = "Cadastrar";
                        break;

                    case FormModes.Edicao:
                        txtProfessor.Enabled = true;
                        numAlunos.Enabled = true;
                        chklstDiasSemana.Enabled = true;
                        mtxHora.Enabled = true;
                        cbModalidade.Enabled = true;
                        btnCadastrar.Text = "Editar";
                        break;
                }
            }
        }

        public Modalidade SelModal
        {
            get => (Modalidade)cbModalidade.SelectedValue;
            set => cbModalidade.Text = value.Descricao;
        }

        public FrmCadastroTurma()
        {
            InitializeComponent();
            this.ImplementNext();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
                
            if (Mode == FormModes.Cadastro && (this.VerifyTextBox() || chklstDiasSemana.CheckedItems.Count == 0))
            {
                if (chklstDiasSemana.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Selecione ao menos um dia da semana!", "Impossível cadastrar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chklstDiasSemana.Focus();
                }
                return;
            }


            var turma = SelTurma;
            switch (Mode)
            {
                case FormModes.Visualizacao:
                    Mode = FormModes.Edicao;
                    break;

                case FormModes.Cadastro:
                    if (turma.Cadastrar())
                    {
                        MessageBox.Show("Turma cadastrada com sucesso!", "Cadastro realizado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Value = ORM<Turma>.Select(("professorTurma", SQLOp.EQ, turma.Professor), ("idModalidade", SQLOp.EQ, turma.Modalidade), ("horasTurma", SQLOp.EQ, turma.Hora)).First();
                        Mode = FormModes.Visualizacao;
                    }
                    else
                        MessageBox.Show("Não foi possível cadastrar a turma.", "Erro no cadastro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case FormModes.Edicao:
                    if (Value.Atualizar(SelTurma))
                    {
                        MessageBox.Show("Turma atualizada com sucesso.", "Atualização realizada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Value = ORM<Turma>.Select(("professorTurma", SQLOp.EQ, turma.Professor), ("idModalidade", SQLOp.EQ, turma.Modalidade), ("horasTurma", SQLOp.EQ, turma.Hora)).First();
                        Mode = FormModes.Visualizacao;
                    }
                    else
                        MessageBox.Show("Não foi possível atualizar a turma.", "Erro ao atualizar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void FrmCadastroTurma_Load(object sender, EventArgs e)
        {
            cbModalidade.DataSource = ORM<Modalidade>.Select();
        }

        private string DiasSemana
        {
            get => chklstDiasSemana.CheckedItems.Cast<string>().Aggregate((x, y) => x + ";" + y);

            set
            {
                var dias = value.Split(';');

                for (int i = 0; i < chklstDiasSemana.Items.Count; i++)
                    chklstDiasSemana.SetItemChecked(i, false);

                foreach (var dia in dias)
                {
                    var index = chklstDiasSemana.Items.IndexOf(dia);
                    if (index != -1)
                        chklstDiasSemana.SetItemChecked(index, true);
                }
            }
        }

        private void cbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            numAlunos.Maximum = SelModal.Qtde_Alunos;
        }
    }
}

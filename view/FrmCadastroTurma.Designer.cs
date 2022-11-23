using Estudio.model;

namespace Estudio.view
{
    partial class FrmCadastroTurma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblModalidade = new System.Windows.Forms.Label();
            this.cbModalidade = new System.Windows.Forms.ComboBox();
            this.chklstDiasSemana = new System.Windows.Forms.CheckedListBox();
            this.lblDiasSemana = new System.Windows.Forms.Label();
            this.numAlunos = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxHora = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAlunos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(13, 13);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(62, 13);
            this.lblModalidade.TabIndex = 0;
            this.lblModalidade.Text = "Modalidade";
            // 
            // cbModalidade
            // 
            this.cbModalidade.DisplayMember = "Descricao";
            this.cbModalidade.FormattingEnabled = true;
            this.cbModalidade.Location = new System.Drawing.Point(85, 10);
            this.cbModalidade.Name = "cbModalidade";
            this.cbModalidade.Size = new System.Drawing.Size(200, 21);
            this.cbModalidade.TabIndex = 1;
            // 
            // chklstDiasSemana
            // 
            this.chklstDiasSemana.CheckOnClick = true;
            this.chklstDiasSemana.FormattingEnabled = true;
            this.chklstDiasSemana.Items.AddRange(new object[] {
            "Domingo",
            "Segunda",
            "Terça",
            "Quarta",
            "Quinta",
            "Sábado"});
            this.chklstDiasSemana.Location = new System.Drawing.Point(85, 64);
            this.chklstDiasSemana.Name = "chklstDiasSemana";
            this.chklstDiasSemana.Size = new System.Drawing.Size(76, 94);
            this.chklstDiasSemana.TabIndex = 2;
            // 
            // lblDiasSemana
            // 
            this.lblDiasSemana.AutoSize = true;
            this.lblDiasSemana.Location = new System.Drawing.Point(13, 99);
            this.lblDiasSemana.Name = "lblDiasSemana";
            this.lblDiasSemana.Size = new System.Drawing.Size(66, 13);
            this.lblDiasSemana.TabIndex = 3;
            this.lblDiasSemana.Text = "Dias de aula";
            // 
            // numAlunos
            // 
            this.numAlunos.Location = new System.Drawing.Point(170, 79);
            this.numAlunos.Name = "numAlunos";
            this.numAlunos.Size = new System.Drawing.Size(36, 20);
            this.numAlunos.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alunos";
            // 
            // txtProfessor
            // 
            this.txtProfessor.Location = new System.Drawing.Point(85, 38);
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(200, 20);
            this.txtProfessor.TabIndex = 6;
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(13, 41);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(51, 13);
            this.lblProfessor.TabIndex = 7;
            this.lblProfessor.Text = "Professor";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(12, 176);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(272, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hora";
            // 
            // mtxHora
            // 
            this.mtxHora.Location = new System.Drawing.Point(173, 134);
            this.mtxHora.Mask = "90:00";
            this.mtxHora.Name = "mtxHora";
            this.mtxHora.Size = new System.Drawing.Size(33, 20);
            this.mtxHora.TabIndex = 10;
            this.mtxHora.ValidatingType = typeof(System.DateTime);
            // 
            // FrmCadastroTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 211);
            this.Controls.Add(this.mtxHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblProfessor);
            this.Controls.Add(this.txtProfessor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numAlunos);
            this.Controls.Add(this.lblDiasSemana);
            this.Controls.Add(this.chklstDiasSemana);
            this.Controls.Add(this.cbModalidade);
            this.Controls.Add(this.lblModalidade);
            this.Name = "FrmCadastroTurma";
            this.Text = "FrmCadastroTurma";
            this.Load += new System.EventHandler(this.FrmCadastroTurma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.CheckedListBox chklstDiasSemana;
        private System.Windows.Forms.Label lblDiasSemana;
        private System.Windows.Forms.NumericUpDown numAlunos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxHora;
    }
}
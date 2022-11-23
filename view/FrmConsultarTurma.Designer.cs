
namespace Estudio.view
{
    partial class FrmConsultarTurma
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
            this.gbCadastro = new System.Windows.Forms.GroupBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lblDiasSemana = new System.Windows.Forms.Label();
            this.chklstDias = new System.Windows.Forms.CheckedListBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.mtxHora = new System.Windows.Forms.MaskedTextBox();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.cbModalidade = new System.Windows.Forms.ComboBox();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.gbCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCadastro
            // 
            this.gbCadastro.Controls.Add(this.btnCadastrar);
            this.gbCadastro.Controls.Add(this.lblDiasSemana);
            this.gbCadastro.Controls.Add(this.chklstDias);
            this.gbCadastro.Controls.Add(this.lblHora);
            this.gbCadastro.Controls.Add(this.mtxHora);
            this.gbCadastro.Controls.Add(this.lblProfessor);
            this.gbCadastro.Controls.Add(this.txtProfessor);
            this.gbCadastro.Controls.Add(this.cbModalidade);
            this.gbCadastro.Controls.Add(this.lblModalidade);
            this.gbCadastro.Location = new System.Drawing.Point(13, 13);
            this.gbCadastro.Name = "gbCadastro";
            this.gbCadastro.Size = new System.Drawing.Size(353, 260);
            this.gbCadastro.TabIndex = 0;
            this.gbCadastro.TabStop = false;
            this.gbCadastro.Text = "Turma";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(5, 230);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(341, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lblDiasSemana
            // 
            this.lblDiasSemana.AutoSize = true;
            this.lblDiasSemana.Location = new System.Drawing.Point(6, 129);
            this.lblDiasSemana.Name = "lblDiasSemana";
            this.lblDiasSemana.Size = new System.Drawing.Size(83, 13);
            this.lblDiasSemana.TabIndex = 7;
            this.lblDiasSemana.Text = "Dias da semana";
            // 
            // chklstDias
            // 
            this.chklstDias.FormattingEnabled = true;
            this.chklstDias.Items.AddRange(new object[] {
            "Domingo",
            "Segunda",
            "Terça",
            "Quarta",
            "Quinta",
            "Sexta",
            "Sábado"});
            this.chklstDias.Location = new System.Drawing.Point(97, 80);
            this.chklstDias.Name = "chklstDias";
            this.chklstDias.Size = new System.Drawing.Size(120, 109);
            this.chklstDias.TabIndex = 6;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(6, 198);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora";
            // 
            // mtxHora
            // 
            this.mtxHora.Location = new System.Drawing.Point(97, 195);
            this.mtxHora.Mask = "90:00";
            this.mtxHora.Name = "mtxHora";
            this.mtxHora.Size = new System.Drawing.Size(34, 20);
            this.mtxHora.TabIndex = 4;
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(6, 57);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(51, 13);
            this.lblProfessor.TabIndex = 3;
            this.lblProfessor.Text = "Professor";
            // 
            // txtProfessor
            // 
            this.txtProfessor.AutoCompleteCustomSource.AddRange(new string[] {
            "Matioli",
            "Priscila",
            "Fernanda",
            "Dorival",
            "Tânia",
            "Simone",
            "Carol",
            "Camila",
            "Heloísa",
            "Jack"});
            this.txtProfessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtProfessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProfessor.Location = new System.Drawing.Point(97, 54);
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(249, 20);
            this.txtProfessor.TabIndex = 2;
            // 
            // cbModalidade
            // 
            this.cbModalidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbModalidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbModalidade.FormattingEnabled = true;
            this.cbModalidade.Location = new System.Drawing.Point(97, 26);
            this.cbModalidade.Name = "cbModalidade";
            this.cbModalidade.Size = new System.Drawing.Size(250, 21);
            this.cbModalidade.TabIndex = 1;
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(6, 29);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(62, 13);
            this.lblModalidade.TabIndex = 0;
            this.lblModalidade.Text = "Modalidade";
            // 
            // FrmConsultarTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 450);
            this.Controls.Add(this.gbCadastro);
            this.Name = "FrmConsultarTurma";
            this.Text = "FrmConsultarTurma";
            this.Load += new System.EventHandler(this.FrmConsultarTurma_Load);
            this.gbCadastro.ResumeLayout(false);
            this.gbCadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCadastro;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.MaskedTextBox mtxHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.CheckedListBox chklstDias;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lblDiasSemana;
    }
}
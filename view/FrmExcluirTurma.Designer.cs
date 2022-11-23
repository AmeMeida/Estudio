
namespace Estudio.view
{
    partial class FrmExcluirTurma
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
            this.cbProfessor = new System.Windows.Forms.ComboBox();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.cbHora = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(12, 15);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(62, 13);
            this.lblModalidade.TabIndex = 0;
            this.lblModalidade.Text = "Modalidade";
            // 
            // cbModalidade
            // 
            this.cbModalidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbModalidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbModalidade.DisplayMember = "Descricao";
            this.cbModalidade.FormattingEnabled = true;
            this.cbModalidade.Location = new System.Drawing.Point(122, 12);
            this.cbModalidade.Name = "cbModalidade";
            this.cbModalidade.Size = new System.Drawing.Size(200, 21);
            this.cbModalidade.TabIndex = 1;
            this.cbModalidade.SelectedIndexChanged += new System.EventHandler(this.cbModalidade_SelectedIndexChanged);
            // 
            // cbProfessor
            // 
            this.cbProfessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProfessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProfessor.FormattingEnabled = true;
            this.cbProfessor.Location = new System.Drawing.Point(122, 39);
            this.cbProfessor.Name = "cbProfessor";
            this.cbProfessor.Size = new System.Drawing.Size(200, 21);
            this.cbProfessor.TabIndex = 2;
            this.cbProfessor.SelectedIndexChanged += new System.EventHandler(this.cbProfessor_SelectedIndexChanged);
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(12, 42);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(51, 13);
            this.lblProfessor.TabIndex = 3;
            this.lblProfessor.Text = "Professor";
            // 
            // cbHora
            // 
            this.cbHora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbHora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHora.FormattingEnabled = true;
            this.cbHora.Location = new System.Drawing.Point(122, 66);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(200, 21);
            this.cbHora.TabIndex = 4;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(12, 69);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(12, 100);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(310, 23);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FrmExcluirTurma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 135);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.cbHora);
            this.Controls.Add(this.lblProfessor);
            this.Controls.Add(this.cbProfessor);
            this.Controls.Add(this.cbModalidade);
            this.Controls.Add(this.lblModalidade);
            this.Name = "FrmExcluirTurma";
            this.Text = "FrmExcluirTurma";
            this.Load += new System.EventHandler(this.FrmExcluirTurma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.ComboBox cbProfessor;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.ComboBox cbHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button btnExcluir;
    }
}
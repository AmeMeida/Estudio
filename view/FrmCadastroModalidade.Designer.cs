namespace Estudio.view
{
    partial class FrmCadastroModalidade
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.numQntdAlunos = new System.Windows.Forms.NumericUpDown();
            this.numQntdAulas = new System.Windows.Forms.NumericUpDown();
            this.lblQntdAlunos = new System.Windows.Forms.Label();
            this.lblQntdAulas = new System.Windows.Forms.Label();
            this.numPreco = new System.Windows.Forms.NumericUpDown();
            this.lblPreco = new System.Windows.Forms.Label();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCadastro
            // 
            this.gbCadastro.Controls.Add(this.lblPreco);
            this.gbCadastro.Controls.Add(this.numPreco);
            this.gbCadastro.Controls.Add(this.lblQntdAulas);
            this.gbCadastro.Controls.Add(this.lblQntdAlunos);
            this.gbCadastro.Controls.Add(this.numQntdAulas);
            this.gbCadastro.Controls.Add(this.numQntdAlunos);
            this.gbCadastro.Controls.Add(this.lblDescricao);
            this.gbCadastro.Controls.Add(this.txtDescricao);
            this.gbCadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCadastro.Location = new System.Drawing.Point(0, 0);
            this.gbCadastro.Name = "gbCadastro";
            this.gbCadastro.Size = new System.Drawing.Size(295, 231);
            this.gbCadastro.TabIndex = 0;
            this.gbCadastro.TabStop = false;
            this.gbCadastro.Text = "Cadastro";
            this.gbCadastro.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(84, 19);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(200, 40);
            this.txtDescricao.TabIndex = 0;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 35);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Descrição";
            // 
            // numQntdAlunos
            // 
            this.numQntdAlunos.Location = new System.Drawing.Point(15, 87);
            this.numQntdAlunos.Name = "numQntdAlunos";
            this.numQntdAlunos.Size = new System.Drawing.Size(60, 20);
            this.numQntdAlunos.TabIndex = 2;
            this.numQntdAlunos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numQntdAulas
            // 
            this.numQntdAulas.Location = new System.Drawing.Point(15, 139);
            this.numQntdAulas.Name = "numQntdAulas";
            this.numQntdAulas.Size = new System.Drawing.Size(60, 20);
            this.numQntdAulas.TabIndex = 3;
            // 
            // lblQntdAlunos
            // 
            this.lblQntdAlunos.AutoSize = true;
            this.lblQntdAlunos.Location = new System.Drawing.Point(12, 71);
            this.lblQntdAlunos.Name = "lblQntdAlunos";
            this.lblQntdAlunos.Size = new System.Drawing.Size(111, 13);
            this.lblQntdAlunos.TabIndex = 4;
            this.lblQntdAlunos.Text = "Quantidade de alunos";
            // 
            // lblQntdAulas
            // 
            this.lblQntdAulas.AutoSize = true;
            this.lblQntdAulas.Location = new System.Drawing.Point(12, 123);
            this.lblQntdAulas.Name = "lblQntdAulas";
            this.lblQntdAulas.Size = new System.Drawing.Size(106, 13);
            this.lblQntdAulas.TabIndex = 5;
            this.lblQntdAulas.Text = "Quantidade de Aulas";
            // 
            // numPreco
            // 
            this.numPreco.DecimalPlaces = 2;
            this.numPreco.Location = new System.Drawing.Point(15, 194);
            this.numPreco.Name = "numPreco";
            this.numPreco.Size = new System.Drawing.Size(60, 20);
            this.numPreco.TabIndex = 6;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(12, 178);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(35, 13);
            this.lblPreco.TabIndex = 7;
            this.lblPreco.Text = "Preço";
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(13, 238);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(75, 23);
            this.btnCadastro.TabIndex = 1;
            this.btnCadastro.Text = "Cadastrar";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(94, 237);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmCadastroModalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 325);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.gbCadastro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCadastroModalidade";
            this.Text = "Cadastro de Modalidades";
            this.gbCadastro.ResumeLayout(false);
            this.gbCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCadastro;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.NumericUpDown numQntdAlunos;
        private System.Windows.Forms.Label lblQntdAlunos;
        private System.Windows.Forms.NumericUpDown numQntdAulas;
        private System.Windows.Forms.Label lblQntdAulas;
        private System.Windows.Forms.NumericUpDown numPreco;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnEditar;
    }
}
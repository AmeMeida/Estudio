
namespace Estudio
{
    partial class FrmCadastroUsuario
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
            this.gbCadastroUsuario = new System.Windows.Forms.GroupBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.cboUserType = new System.Windows.Forms.ComboBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chkHasSenha = new System.Windows.Forms.CheckBox();
            this.gbCadastroUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCadastroUsuario
            // 
            this.gbCadastroUsuario.Controls.Add(this.chkHasSenha);
            this.gbCadastroUsuario.Controls.Add(this.lblUserType);
            this.gbCadastroUsuario.Controls.Add(this.btnCadastrarUsuario);
            this.gbCadastroUsuario.Controls.Add(this.cboUserType);
            this.gbCadastroUsuario.Controls.Add(this.lblSenha);
            this.gbCadastroUsuario.Controls.Add(this.txtSenha);
            this.gbCadastroUsuario.Controls.Add(this.txtUsuario);
            this.gbCadastroUsuario.Controls.Add(this.lblUsuario);
            this.gbCadastroUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCadastroUsuario.Location = new System.Drawing.Point(0, 0);
            this.gbCadastroUsuario.Name = "gbCadastroUsuario";
            this.gbCadastroUsuario.Size = new System.Drawing.Size(332, 109);
            this.gbCadastroUsuario.TabIndex = 0;
            this.gbCadastroUsuario.TabStop = false;
            this.gbCadastroUsuario.Text = "Dados";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(12, 76);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(28, 13);
            this.lblUserType.TabIndex = 6;
            this.lblUserType.Text = "Tipo";
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(216, 73);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(104, 23);
            this.btnCadastrarUsuario.TabIndex = 5;
            this.btnCadastrarUsuario.Text = "Cadastrar";
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // cboUserType
            // 
            this.cboUserType.FormattingEnabled = true;
            this.cboUserType.Location = new System.Drawing.Point(70, 73);
            this.cboUserType.Name = "cboUserType";
            this.cboUserType.Size = new System.Drawing.Size(140, 21);
            this.cboUserType.TabIndex = 4;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(12, 49);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(93, 46);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(227, 20);
            this.txtSenha.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(70, 19);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(250, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário";
            // 
            // chkHasSenha
            // 
            this.chkHasSenha.AutoSize = true;
            this.chkHasSenha.Location = new System.Drawing.Point(74, 49);
            this.chkHasSenha.Name = "chkHasSenha";
            this.chkHasSenha.Size = new System.Drawing.Size(15, 14);
            this.chkHasSenha.TabIndex = 7;
            this.chkHasSenha.UseVisualStyleBackColor = true;
            this.chkHasSenha.CheckedChanged += new System.EventHandler(this.chkHasSenha_CheckedChanged);
            // 
            // FrmCadastroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 109);
            this.Controls.Add(this.gbCadastroUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCadastroUsuario";
            this.Text = "FrmCadastroUsuario";
            this.gbCadastroUsuario.ResumeLayout(false);
            this.gbCadastroUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCadastroUsuario;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.ComboBox cboUserType;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox chkHasSenha;
    }
}
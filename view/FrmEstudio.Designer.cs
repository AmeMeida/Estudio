
namespace Estudio
{
    partial class FrmEstudio
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.opcoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarAlunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarUsuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarAlunoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modalidadeToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarModalidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarModalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirModalidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.turmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarTurmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Enabled = false;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcoesToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.alunoToolStripMenuItem,
            this.modalidadeToolStripMenu,
            this.turmaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(392, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // opcoesToolStripMenuItem
            // 
            this.opcoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarAlunoToolStripMenuItem,
            this.cadastrarLoginToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.opcoesToolStripMenuItem.Name = "opcoesToolStripMenuItem";
            this.opcoesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opcoesToolStripMenuItem.Text = "&Opções";
            // 
            // cadastrarAlunoToolStripMenuItem
            // 
            this.cadastrarAlunoToolStripMenuItem.Name = "cadastrarAlunoToolStripMenuItem";
            this.cadastrarAlunoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.cadastrarAlunoToolStripMenuItem.Text = "Cadastrar Aluno";
            this.cadastrarAlunoToolStripMenuItem.Click += new System.EventHandler(this.ShowCadastroAluno);
            // 
            // cadastrarLoginToolStripMenuItem
            // 
            this.cadastrarLoginToolStripMenuItem.Name = "cadastrarLoginToolStripMenuItem";
            this.cadastrarLoginToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.cadastrarLoginToolStripMenuItem.Text = "Cadastrar Login";
            this.cadastrarLoginToolStripMenuItem.Click += new System.EventHandler(this.ShowCadastroUsuario);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.Sair);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarUsuárioToolStripMenuItem,
            this.consultarUsuáriosToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "&Usuários";
            // 
            // cadastrarUsuárioToolStripMenuItem
            // 
            this.cadastrarUsuárioToolStripMenuItem.Name = "cadastrarUsuárioToolStripMenuItem";
            this.cadastrarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cadastrarUsuárioToolStripMenuItem.Text = "Cadastrar usuário";
            this.cadastrarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.ShowCadastroUsuario);
            // 
            // consultarUsuáriosToolStripMenuItem
            // 
            this.consultarUsuáriosToolStripMenuItem.Name = "consultarUsuáriosToolStripMenuItem";
            this.consultarUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.consultarUsuáriosToolStripMenuItem.Text = "Consultar usuários";
            this.consultarUsuáriosToolStripMenuItem.Click += new System.EventHandler(this.ShowConsultarUsuarios);
            // 
            // alunoToolStripMenuItem
            // 
            this.alunoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarAlunoToolStripMenuItem1,
            this.consultarAlunosToolStripMenuItem});
            this.alunoToolStripMenuItem.Name = "alunoToolStripMenuItem";
            this.alunoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.alunoToolStripMenuItem.Text = "&Alunos";
            // 
            // cadastrarAlunoToolStripMenuItem1
            // 
            this.cadastrarAlunoToolStripMenuItem1.Name = "cadastrarAlunoToolStripMenuItem1";
            this.cadastrarAlunoToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.cadastrarAlunoToolStripMenuItem1.Text = "Cadastrar aluno";
            this.cadastrarAlunoToolStripMenuItem1.Click += new System.EventHandler(this.ShowCadastroAluno);
            // 
            // consultarAlunosToolStripMenuItem
            // 
            this.consultarAlunosToolStripMenuItem.Name = "consultarAlunosToolStripMenuItem";
            this.consultarAlunosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.consultarAlunosToolStripMenuItem.Text = "Consultar alunos";
            this.consultarAlunosToolStripMenuItem.Click += new System.EventHandler(this.ShowConsultarAlunos);
            // 
            // modalidadeToolStripMenu
            // 
            this.modalidadeToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarModalidadeToolStripMenuItem,
            this.consultarModalidadesToolStripMenuItem,
            this.excluirModalidadeToolStripMenuItem});
            this.modalidadeToolStripMenu.Name = "modalidadeToolStripMenu";
            this.modalidadeToolStripMenu.Size = new System.Drawing.Size(82, 20);
            this.modalidadeToolStripMenu.Text = "&Modalidade";
            // 
            // cadastrarModalidadeToolStripMenuItem
            // 
            this.cadastrarModalidadeToolStripMenuItem.Name = "cadastrarModalidadeToolStripMenuItem";
            this.cadastrarModalidadeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.cadastrarModalidadeToolStripMenuItem.Text = "Cadastrar modalidade";
            this.cadastrarModalidadeToolStripMenuItem.Click += new System.EventHandler(this.ShowCadastroModalidade);
            // 
            // consultarModalidadesToolStripMenuItem
            // 
            this.consultarModalidadesToolStripMenuItem.Name = "consultarModalidadesToolStripMenuItem";
            this.consultarModalidadesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.consultarModalidadesToolStripMenuItem.Text = "Consultar modalidades";
            this.consultarModalidadesToolStripMenuItem.Click += new System.EventHandler(this.ShowConsultarModalidades);
            // 
            // excluirModalidadeToolStripMenuItem
            // 
            this.excluirModalidadeToolStripMenuItem.Name = "excluirModalidadeToolStripMenuItem";
            this.excluirModalidadeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.excluirModalidadeToolStripMenuItem.Text = "Excluir modalidade";
            this.excluirModalidadeToolStripMenuItem.Click += new System.EventHandler(this.ShowExcluirModalidade);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtSenha);
            this.gbLogin.Controls.Add(this.txtLogin);
            this.gbLogin.Controls.Add(this.lblSenha);
            this.gbLogin.Controls.Add(this.lblLogin);
            this.gbLogin.Location = new System.Drawing.Point(12, 37);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(249, 111);
            this.gbLogin.TabIndex = 3;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Entrar";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(6, 83);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(237, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(65, 51);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(168, 20);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.Text = "senha";
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(65, 21);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(168, 20);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Text = "Pri";
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextControl);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(15, 54);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 1;
            this.lblSenha.Text = "Senha";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(15, 24);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // turmaToolStripMenuItem
            // 
            this.turmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarTurmaToolStripMenuItem});
            this.turmaToolStripMenuItem.Name = "turmaToolStripMenuItem";
            this.turmaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.turmaToolStripMenuItem.Text = "Turma";
            // 
            // cadastrarTurmaToolStripMenuItem
            // 
            this.cadastrarTurmaToolStripMenuItem.Name = "cadastrarTurmaToolStripMenuItem";
            this.cadastrarTurmaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarTurmaToolStripMenuItem.Text = "Cadastrar turma";
            this.cadastrarTurmaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarTurmaToolStripMenuItem_Click);
            // 
            // FrmEstudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 162);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmEstudio";
            this.Text = "Estúdio";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem opcoesToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ToolStripMenuItem cadastrarAlunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarUsuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarAlunoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarAlunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modalidadeToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem cadastrarModalidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarModalidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirModalidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarTurmaToolStripMenuItem;
    }
}


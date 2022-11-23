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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroModalidade));
            this.gbCadastro = new System.Windows.Forms.GroupBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.numPreco = new System.Windows.Forms.NumericUpDown();
            this.lblQntdAulas = new System.Windows.Forms.Label();
            this.lblQntdAlunos = new System.Windows.Forms.Label();
            this.numQntdAulas = new System.Windows.Forms.NumericUpDown();
            this.numQntdAlunos = new System.Windows.Forms.NumericUpDown();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.lblBusca = new System.Windows.Forms.Label();
            this.gbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAlunos)).BeginInit();
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
            resources.ApplyResources(this.gbCadastro, "gbCadastro");
            this.gbCadastro.Name = "gbCadastro";
            this.gbCadastro.TabStop = false;
            // 
            // lblPreco
            // 
            resources.ApplyResources(this.lblPreco, "lblPreco");
            this.lblPreco.Name = "lblPreco";
            // 
            // numPreco
            // 
            this.numPreco.DecimalPlaces = 2;
            resources.ApplyResources(this.numPreco, "numPreco");
            this.numPreco.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numPreco.Name = "numPreco";
            // 
            // lblQntdAulas
            // 
            resources.ApplyResources(this.lblQntdAulas, "lblQntdAulas");
            this.lblQntdAulas.Name = "lblQntdAulas";
            // 
            // lblQntdAlunos
            // 
            resources.ApplyResources(this.lblQntdAlunos, "lblQntdAlunos");
            this.lblQntdAlunos.Name = "lblQntdAlunos";
            // 
            // numQntdAulas
            // 
            resources.ApplyResources(this.numQntdAulas, "numQntdAulas");
            this.numQntdAulas.Name = "numQntdAulas";
            // 
            // numQntdAlunos
            // 
            resources.ApplyResources(this.numQntdAlunos, "numQntdAlunos");
            this.numQntdAlunos.Name = "numQntdAlunos";
            // 
            // lblDescricao
            // 
            resources.ApplyResources(this.lblDescricao, "lblDescricao");
            this.lblDescricao.Name = "lblDescricao";
            // 
            // txtDescricao
            // 
            resources.ApplyResources(this.txtDescricao, "txtDescricao");
            this.txtDescricao.Name = "txtDescricao";
            // 
            // btnCadastro
            // 
            resources.ApplyResources(this.btnCadastro, "btnCadastro");
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // cboBuscar
            // 
            this.cboBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBuscar.DisplayMember = "Descricao";
            this.cboBuscar.FormattingEnabled = true;
            resources.ApplyResources(this.cboBuscar, "cboBuscar");
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.SelectedIndexChanged += new System.EventHandler(this.cboBuscar_SelectedIndexChanged);
            // 
            // lblBusca
            // 
            resources.ApplyResources(this.lblBusca, "lblBusca");
            this.lblBusca.Name = "lblBusca";
            // 
            // FrmCadastroModalidade
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.cboBuscar);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.gbCadastro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCadastroModalidade";
            this.gbCadastro.ResumeLayout(false);
            this.gbCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntdAlunos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cboBuscar;
        private System.Windows.Forms.Label lblBusca;
    }
}
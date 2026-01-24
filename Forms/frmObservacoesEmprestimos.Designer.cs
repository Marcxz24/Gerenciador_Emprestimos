namespace Gerenciador_de_Emprestimos
{
    partial class frmObservacoesEmprestimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObservacoesEmprestimos));
            txtObservacoesEmprestimos = new TextBox();
            lblObservacoesEmprestimos = new Label();
            btnSalvarObservacoes = new Button();
            lblSalvarObservacao = new Label();
            SuspendLayout();
            // 
            // txtObservacoesEmprestimos
            // 
            txtObservacoesEmprestimos.BackColor = SystemColors.Control;
            txtObservacoesEmprestimos.Location = new Point(16, 73);
            txtObservacoesEmprestimos.Multiline = true;
            txtObservacoesEmprestimos.Name = "txtObservacoesEmprestimos";
            txtObservacoesEmprestimos.Size = new Size(772, 365);
            txtObservacoesEmprestimos.TabIndex = 5;
            // 
            // lblObservacoesEmprestimos
            // 
            lblObservacoesEmprestimos.AutoSize = true;
            lblObservacoesEmprestimos.BackColor = Color.Transparent;
            lblObservacoesEmprestimos.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservacoesEmprestimos.Location = new Point(183, 23);
            lblObservacoesEmprestimos.Name = "lblObservacoesEmprestimos";
            lblObservacoesEmprestimos.Size = new Size(429, 35);
            lblObservacoesEmprestimos.TabIndex = 6;
            lblObservacoesEmprestimos.Text = "Observações do Emprestimo";
            // 
            // btnSalvarObservacoes
            // 
            btnSalvarObservacoes.BackColor = Color.PaleGreen;
            btnSalvarObservacoes.FlatStyle = FlatStyle.Popup;
            btnSalvarObservacoes.Image = (Image)resources.GetObject("btnSalvarObservacoes.Image");
            btnSalvarObservacoes.Location = new Point(297, 451);
            btnSalvarObservacoes.Name = "btnSalvarObservacoes";
            btnSalvarObservacoes.Size = new Size(219, 61);
            btnSalvarObservacoes.TabIndex = 7;
            btnSalvarObservacoes.Text = "Salvar Observações";
            btnSalvarObservacoes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvarObservacoes.UseVisualStyleBackColor = false;
            btnSalvarObservacoes.Click += btnSalvarObservacoes_Click;
            // 
            // lblSalvarObservacao
            // 
            lblSalvarObservacao.AutoSize = true;
            lblSalvarObservacao.BackColor = Color.Transparent;
            lblSalvarObservacao.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalvarObservacao.Location = new Point(125, 473);
            lblSalvarObservacao.Name = "lblSalvarObservacao";
            lblSalvarObservacao.Size = new Size(166, 18);
            lblSalvarObservacao.TabIndex = 8;
            lblSalvarObservacao.Text = "Salvar Observação -->";
            // 
            // frmObservacoesEmprestimos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(800, 519);
            Controls.Add(lblSalvarObservacao);
            Controls.Add(btnSalvarObservacoes);
            Controls.Add(lblObservacoesEmprestimos);
            Controls.Add(txtObservacoesEmprestimos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmObservacoesEmprestimos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Observações";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtObservacoesEmprestimos;
        private Label lblObservacoesEmprestimos;
        private Button btnSalvarObservacoes;
        private Label lblSalvarObservacao;
    }
}
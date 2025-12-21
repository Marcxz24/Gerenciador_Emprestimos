namespace Gerenciador_de_Emprestimos
{
    partial class FormTelaIncial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTelaIncial));
            btnChamarFormEmprestimos = new Button();
            btnChamarFormCadastroCliente = new Button();
            lblTituloInicial = new Label();
            btnChmarFormPagamento = new Button();
            btnFecharAplicacao = new Button();
            btnVizualizarDebitos = new Button();
            SuspendLayout();
            // 
            // btnChamarFormEmprestimos
            // 
            resources.ApplyResources(btnChamarFormEmprestimos, "btnChamarFormEmprestimos");
            btnChamarFormEmprestimos.BackColor = Color.DarkTurquoise;
            btnChamarFormEmprestimos.Cursor = Cursors.Hand;
            btnChamarFormEmprestimos.ForeColor = Color.White;
            btnChamarFormEmprestimos.Name = "btnChamarFormEmprestimos";
            btnChamarFormEmprestimos.UseVisualStyleBackColor = false;
            btnChamarFormEmprestimos.Click += btnChamarFormEmprestimos_Click_1;
            // 
            // btnChamarFormCadastroCliente
            // 
            resources.ApplyResources(btnChamarFormCadastroCliente, "btnChamarFormCadastroCliente");
            btnChamarFormCadastroCliente.BackColor = Color.LightGreen;
            btnChamarFormCadastroCliente.Cursor = Cursors.Hand;
            btnChamarFormCadastroCliente.ForeColor = Color.White;
            btnChamarFormCadastroCliente.Name = "btnChamarFormCadastroCliente";
            btnChamarFormCadastroCliente.UseVisualStyleBackColor = false;
            btnChamarFormCadastroCliente.Click += btnChamarFormCadastroCliente_Click;
            // 
            // lblTituloInicial
            // 
            resources.ApplyResources(lblTituloInicial, "lblTituloInicial");
            lblTituloInicial.BackColor = Color.Transparent;
            lblTituloInicial.Name = "lblTituloInicial";
            // 
            // btnChmarFormPagamento
            // 
            resources.ApplyResources(btnChmarFormPagamento, "btnChmarFormPagamento");
            btnChmarFormPagamento.BackColor = Color.DarkTurquoise;
            btnChmarFormPagamento.Cursor = Cursors.Hand;
            btnChmarFormPagamento.ForeColor = Color.White;
            btnChmarFormPagamento.Name = "btnChmarFormPagamento";
            btnChmarFormPagamento.UseVisualStyleBackColor = false;
            // 
            // btnFecharAplicacao
            // 
            resources.ApplyResources(btnFecharAplicacao, "btnFecharAplicacao");
            btnFecharAplicacao.BackColor = Color.Red;
            btnFecharAplicacao.Cursor = Cursors.Hand;
            btnFecharAplicacao.ForeColor = SystemColors.ButtonHighlight;
            btnFecharAplicacao.Name = "btnFecharAplicacao";
            btnFecharAplicacao.UseVisualStyleBackColor = false;
            btnFecharAplicacao.Click += btnFecharAplicacao_Click;
            // 
            // btnVizualizarDebitos
            // 
            resources.ApplyResources(btnVizualizarDebitos, "btnVizualizarDebitos");
            btnVizualizarDebitos.BackColor = Color.DarkTurquoise;
            btnVizualizarDebitos.Cursor = Cursors.Hand;
            btnVizualizarDebitos.ForeColor = Color.White;
            btnVizualizarDebitos.Image = Properties.Resources.lupa;
            btnVizualizarDebitos.Name = "btnVizualizarDebitos";
            btnVizualizarDebitos.UseVisualStyleBackColor = false;
            btnVizualizarDebitos.Click += btnVizualizarDebitos_Click;
            // 
            // FormTelaIncial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gradience1;
            Controls.Add(btnVizualizarDebitos);
            Controls.Add(btnFecharAplicacao);
            Controls.Add(btnChmarFormPagamento);
            Controls.Add(btnChamarFormEmprestimos);
            Controls.Add(lblTituloInicial);
            Controls.Add(btnChamarFormCadastroCliente);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormTelaIncial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTituloInicial;
        private Button btnChamarFormCadastroCliente;
        private Button btnChamarFormEmprestimos;
        private Button btnChmarFormPagamento;
        private Button btnFecharAplicacao;
        private Button btnVizualizarDebitos;
    }
}

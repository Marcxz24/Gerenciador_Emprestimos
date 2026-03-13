namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmEstornarPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstornarPagamento));
            panel1 = new Panel();
            lblTituloFrm = new Label();
            dtGridListarPagamentos = new DataGridView();
            grpFiltrosPagamento = new GroupBox();
            txtNomeCliente = new TextBox();
            lblNomeCliente = new Label();
            btnBuscarParcela = new Button();
            txtCodigoCliente = new TextBox();
            lblCodigoCliente = new Label();
            lblCodigoEmprestimo = new Label();
            txtCodigoEmprestimo = new TextBox();
            grpConfirmarEstorno = new GroupBox();
            grpDadosEstorno = new GroupBox();
            txtValorPago = new TextBox();
            lblValorPago = new Label();
            txtValorParcela = new TextBox();
            lblValorParcela = new Label();
            lblNumeroParcela = new Label();
            txtNumeroParcela = new TextBox();
            txtCodigoUserLogado = new TextBox();
            lblCodigoUserLogado = new Label();
            txtValorEstornado = new TextBox();
            lblValorEstornado = new Label();
            txtCodigoParcelaEstorno = new TextBox();
            lblCodigoParcelaEstorno = new Label();
            lblCodigoEmprestimoEstorno = new Label();
            txtCodigoEmprestimoEstorno = new TextBox();
            btnLimparDados = new Button();
            lblConfirmacao = new Label();
            btnEstornar = new Button();
            txtMotivoEstorno = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridListarPagamentos).BeginInit();
            grpFiltrosPagamento.SuspendLayout();
            grpConfirmarEstorno.SuspendLayout();
            grpDadosEstorno.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(lblTituloFrm);
            panel1.Location = new Point(-4, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(975, 89);
            panel1.TabIndex = 0;
            // 
            // lblTituloFrm
            // 
            lblTituloFrm.AutoSize = true;
            lblTituloFrm.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloFrm.ForeColor = SystemColors.ControlLightLight;
            lblTituloFrm.Location = new Point(190, 24);
            lblTituloFrm.Name = "lblTituloFrm";
            lblTituloFrm.Size = new Size(596, 40);
            lblTituloFrm.TabIndex = 0;
            lblTituloFrm.Text = "Estorno de Rebimento de Empréstimo\r\n";
            // 
            // dtGridListarPagamentos
            // 
            dtGridListarPagamentos.AllowUserToAddRows = false;
            dtGridListarPagamentos.AllowUserToDeleteRows = false;
            dtGridListarPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridListarPagamentos.Location = new Point(12, 225);
            dtGridListarPagamentos.Name = "dtGridListarPagamentos";
            dtGridListarPagamentos.ReadOnly = true;
            dtGridListarPagamentos.RowHeadersWidth = 51;
            dtGridListarPagamentos.Size = new Size(942, 309);
            dtGridListarPagamentos.TabIndex = 1;
            dtGridListarPagamentos.CellDoubleClick += dtGridListarPagamentos_CellDoubleClick;
            // 
            // grpFiltrosPagamento
            // 
            grpFiltrosPagamento.BackColor = Color.Transparent;
            grpFiltrosPagamento.Controls.Add(txtNomeCliente);
            grpFiltrosPagamento.Controls.Add(lblNomeCliente);
            grpFiltrosPagamento.Controls.Add(btnBuscarParcela);
            grpFiltrosPagamento.Controls.Add(txtCodigoCliente);
            grpFiltrosPagamento.Controls.Add(lblCodigoCliente);
            grpFiltrosPagamento.Controls.Add(lblCodigoEmprestimo);
            grpFiltrosPagamento.Controls.Add(txtCodigoEmprestimo);
            grpFiltrosPagamento.Location = new Point(12, 94);
            grpFiltrosPagamento.Name = "grpFiltrosPagamento";
            grpFiltrosPagamento.Size = new Size(942, 125);
            grpFiltrosPagamento.TabIndex = 2;
            grpFiltrosPagamento.TabStop = false;
            grpFiltrosPagamento.Text = "Filtros do Empréstimo";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(366, 61);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(335, 27);
            txtNomeCliente.TabIndex = 6;
            txtNomeCliente.KeyDown += txtNomeCliente_KeyDown;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(366, 38);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(100, 20);
            lblNomeCliente.TabIndex = 5;
            lblNomeCliente.Text = "Nome Cliente";
            // 
            // btnBuscarParcela
            // 
            btnBuscarParcela.Image = Properties.Resources.lupa;
            btnBuscarParcela.Location = new Point(733, 38);
            btnBuscarParcela.Name = "btnBuscarParcela";
            btnBuscarParcela.Size = new Size(203, 59);
            btnBuscarParcela.TabIndex = 4;
            btnBuscarParcela.Text = "Buscar Pagamentos";
            btnBuscarParcela.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarParcela.UseVisualStyleBackColor = true;
            btnBuscarParcela.Click += btnBuscarParcela_Click;
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Location = new Point(195, 61);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.Size = new Size(153, 27);
            txtCodigoCliente.TabIndex = 3;
            txtCodigoCliente.KeyDown += txtCodigoCliente_KeyDown;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(195, 38);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(130, 20);
            lblCodigoCliente.TabIndex = 2;
            lblCodigoCliente.Text = "Código do Cliente";
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(6, 38);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(164, 20);
            lblCodigoEmprestimo.TabIndex = 1;
            lblCodigoEmprestimo.Text = "Código do Empréstimo";
            // 
            // txtCodigoEmprestimo
            // 
            txtCodigoEmprestimo.Location = new Point(6, 61);
            txtCodigoEmprestimo.Name = "txtCodigoEmprestimo";
            txtCodigoEmprestimo.Size = new Size(164, 27);
            txtCodigoEmprestimo.TabIndex = 0;
            // 
            // grpConfirmarEstorno
            // 
            grpConfirmarEstorno.BackColor = Color.Transparent;
            grpConfirmarEstorno.Controls.Add(grpDadosEstorno);
            grpConfirmarEstorno.Controls.Add(btnLimparDados);
            grpConfirmarEstorno.Controls.Add(lblConfirmacao);
            grpConfirmarEstorno.Controls.Add(btnEstornar);
            grpConfirmarEstorno.Controls.Add(txtMotivoEstorno);
            grpConfirmarEstorno.Location = new Point(12, 540);
            grpConfirmarEstorno.Name = "grpConfirmarEstorno";
            grpConfirmarEstorno.Size = new Size(942, 330);
            grpConfirmarEstorno.TabIndex = 3;
            grpConfirmarEstorno.TabStop = false;
            grpConfirmarEstorno.Text = "Confirmação e Auditoria";
            // 
            // grpDadosEstorno
            // 
            grpDadosEstorno.Controls.Add(txtValorPago);
            grpDadosEstorno.Controls.Add(lblValorPago);
            grpDadosEstorno.Controls.Add(txtValorParcela);
            grpDadosEstorno.Controls.Add(lblValorParcela);
            grpDadosEstorno.Controls.Add(lblNumeroParcela);
            grpDadosEstorno.Controls.Add(txtNumeroParcela);
            grpDadosEstorno.Controls.Add(txtCodigoUserLogado);
            grpDadosEstorno.Controls.Add(lblCodigoUserLogado);
            grpDadosEstorno.Controls.Add(txtValorEstornado);
            grpDadosEstorno.Controls.Add(lblValorEstornado);
            grpDadosEstorno.Controls.Add(txtCodigoParcelaEstorno);
            grpDadosEstorno.Controls.Add(lblCodigoParcelaEstorno);
            grpDadosEstorno.Controls.Add(lblCodigoEmprestimoEstorno);
            grpDadosEstorno.Controls.Add(txtCodigoEmprestimoEstorno);
            grpDadosEstorno.Location = new Point(6, 26);
            grpDadosEstorno.Name = "grpDadosEstorno";
            grpDadosEstorno.Size = new Size(930, 145);
            grpDadosEstorno.TabIndex = 7;
            grpDadosEstorno.TabStop = false;
            grpDadosEstorno.Text = "Dados do Estorno do Pagamento";
            // 
            // txtValorPago
            // 
            txtValorPago.Location = new Point(348, 98);
            txtValorPago.Name = "txtValorPago";
            txtValorPago.ReadOnly = true;
            txtValorPago.Size = new Size(153, 27);
            txtValorPago.TabIndex = 22;
            // 
            // lblValorPago
            // 
            lblValorPago.AutoSize = true;
            lblValorPago.Location = new Point(348, 75);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(80, 20);
            lblValorPago.TabIndex = 21;
            lblValorPago.Text = "Valor Pago";
            // 
            // txtValorParcela
            // 
            txtValorParcela.Location = new Point(190, 98);
            txtValorParcela.Name = "txtValorParcela";
            txtValorParcela.ReadOnly = true;
            txtValorParcela.Size = new Size(153, 27);
            txtValorParcela.TabIndex = 20;
            // 
            // lblValorParcela
            // 
            lblValorParcela.AutoSize = true;
            lblValorParcela.Location = new Point(190, 75);
            lblValorParcela.Name = "lblValorParcela";
            lblValorParcela.Size = new Size(115, 20);
            lblValorParcela.TabIndex = 19;
            lblValorParcela.Text = "Valor da Parcela";
            // 
            // lblNumeroParcela
            // 
            lblNumeroParcela.AutoSize = true;
            lblNumeroParcela.Location = new Point(20, 75);
            lblNumeroParcela.Name = "lblNumeroParcela";
            lblNumeroParcela.Size = new Size(135, 20);
            lblNumeroParcela.TabIndex = 18;
            lblNumeroParcela.Text = "Número da Parcela";
            // 
            // txtNumeroParcela
            // 
            txtNumeroParcela.Location = new Point(20, 98);
            txtNumeroParcela.Name = "txtNumeroParcela";
            txtNumeroParcela.ReadOnly = true;
            txtNumeroParcela.Size = new Size(164, 27);
            txtNumeroParcela.TabIndex = 17;
            // 
            // txtCodigoUserLogado
            // 
            txtCodigoUserLogado.Location = new Point(348, 41);
            txtCodigoUserLogado.Name = "txtCodigoUserLogado";
            txtCodigoUserLogado.ReadOnly = true;
            txtCodigoUserLogado.Size = new Size(153, 27);
            txtCodigoUserLogado.TabIndex = 16;
            // 
            // lblCodigoUserLogado
            // 
            lblCodigoUserLogado.AutoSize = true;
            lblCodigoUserLogado.Location = new Point(348, 18);
            lblCodigoUserLogado.Name = "lblCodigoUserLogado";
            lblCodigoUserLogado.Size = new Size(161, 20);
            lblCodigoUserLogado.TabIndex = 15;
            lblCodigoUserLogado.Text = "Código do Funcionário";
            // 
            // txtValorEstornado
            // 
            txtValorEstornado.Location = new Point(740, 68);
            txtValorEstornado.Name = "txtValorEstornado";
            txtValorEstornado.Size = new Size(153, 27);
            txtValorEstornado.TabIndex = 14;
            // 
            // lblValorEstornado
            // 
            lblValorEstornado.AutoSize = true;
            lblValorEstornado.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorEstornado.Location = new Point(585, 68);
            lblValorEstornado.Name = "lblValorEstornado";
            lblValorEstornado.Size = new Size(149, 22);
            lblValorEstornado.TabIndex = 13;
            lblValorEstornado.Text = "Valor Estornado --->";
            // 
            // txtCodigoParcelaEstorno
            // 
            txtCodigoParcelaEstorno.Location = new Point(190, 41);
            txtCodigoParcelaEstorno.Name = "txtCodigoParcelaEstorno";
            txtCodigoParcelaEstorno.ReadOnly = true;
            txtCodigoParcelaEstorno.Size = new Size(153, 27);
            txtCodigoParcelaEstorno.TabIndex = 12;
            // 
            // lblCodigoParcelaEstorno
            // 
            lblCodigoParcelaEstorno.AutoSize = true;
            lblCodigoParcelaEstorno.Location = new Point(190, 18);
            lblCodigoParcelaEstorno.Name = "lblCodigoParcelaEstorno";
            lblCodigoParcelaEstorno.Size = new Size(130, 20);
            lblCodigoParcelaEstorno.TabIndex = 11;
            lblCodigoParcelaEstorno.Text = "Código da Parcela";
            // 
            // lblCodigoEmprestimoEstorno
            // 
            lblCodigoEmprestimoEstorno.AutoSize = true;
            lblCodigoEmprestimoEstorno.Location = new Point(20, 18);
            lblCodigoEmprestimoEstorno.Name = "lblCodigoEmprestimoEstorno";
            lblCodigoEmprestimoEstorno.Size = new Size(164, 20);
            lblCodigoEmprestimoEstorno.TabIndex = 8;
            lblCodigoEmprestimoEstorno.Text = "Código do Empréstimo";
            // 
            // txtCodigoEmprestimoEstorno
            // 
            txtCodigoEmprestimoEstorno.Location = new Point(20, 41);
            txtCodigoEmprestimoEstorno.Name = "txtCodigoEmprestimoEstorno";
            txtCodigoEmprestimoEstorno.ReadOnly = true;
            txtCodigoEmprestimoEstorno.Size = new Size(164, 27);
            txtCodigoEmprestimoEstorno.TabIndex = 7;
            // 
            // btnLimparDados
            // 
            btnLimparDados.Location = new Point(796, 261);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(140, 45);
            btnLimparDados.TabIndex = 6;
            btnLimparDados.Text = "Limpar";
            btnLimparDados.UseVisualStyleBackColor = true;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // lblConfirmacao
            // 
            lblConfirmacao.AutoSize = true;
            lblConfirmacao.Location = new Point(15, 174);
            lblConfirmacao.Name = "lblConfirmacao";
            lblConfirmacao.Size = new Size(227, 20);
            lblConfirmacao.TabIndex = 5;
            lblConfirmacao.Text = "Motivo do Estorno (Obrigatório):";
            // 
            // btnEstornar
            // 
            btnEstornar.Location = new Point(639, 261);
            btnEstornar.Name = "btnEstornar";
            btnEstornar.Size = new Size(151, 45);
            btnEstornar.TabIndex = 2;
            btnEstornar.Text = "Estornar";
            btnEstornar.UseVisualStyleBackColor = true;
            btnEstornar.Click += btnEstornar_Click;
            // 
            // txtMotivoEstorno
            // 
            txtMotivoEstorno.Location = new Point(15, 197);
            txtMotivoEstorno.Multiline = true;
            txtMotivoEstorno.Name = "txtMotivoEstorno";
            txtMotivoEstorno.Size = new Size(618, 121);
            txtMotivoEstorno.TabIndex = 0;
            // 
            // frmEstornarPagamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(966, 882);
            Controls.Add(panel1);
            Controls.Add(grpConfirmarEstorno);
            Controls.Add(grpFiltrosPagamento);
            Controls.Add(dtGridListarPagamentos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEstornarPagamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estorno de Recebimento de Empréstimos";
            Load += frmEstornarPagamento_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridListarPagamentos).EndInit();
            grpFiltrosPagamento.ResumeLayout(false);
            grpFiltrosPagamento.PerformLayout();
            grpConfirmarEstorno.ResumeLayout(false);
            grpConfirmarEstorno.PerformLayout();
            grpDadosEstorno.ResumeLayout(false);
            grpDadosEstorno.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTituloFrm;
        private DataGridView dtGridListarPagamentos;
        private GroupBox grpFiltrosPagamento;
        private Label lblCodigoEmprestimo;
        private TextBox txtCodigoEmprestimo;
        private Label lblCodigoCliente;
        private TextBox txtCodigoCliente;
        private GroupBox grpConfirmarEstorno;
        private Button btnBuscarParcela;
        private TextBox txtMotivoEstorno;
        private Button btnEstornar;
        private Label lblConfirmacao;
        private Button btnLimparDados;
        private TextBox txtNomeCliente;
        private Label lblNomeCliente;
        private GroupBox grpDadosEstorno;
        private Label lblCodigoEmprestimoEstorno;
        private TextBox txtCodigoEmprestimoEstorno;
        private TextBox txtCodigoParcelaEstorno;
        private Label lblCodigoParcelaEstorno;
        private Label lblValorEstornado;
        private TextBox txtValorEstornado;
        private TextBox txtCodigoUserLogado;
        private Label lblCodigoUserLogado;
        private TextBox txtValorPago;
        private Label lblValorPago;
        private TextBox txtValorParcela;
        private Label lblValorParcela;
        private Label lblNumeroParcela;
        private TextBox txtNumeroParcela;
    }
}
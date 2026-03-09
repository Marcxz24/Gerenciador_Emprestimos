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
            btnBuscarParcela = new Button();
            txtCodigoCliente = new TextBox();
            lblCodigoCliente = new Label();
            lblCodigoEmprestimo = new Label();
            txtCodigoEmprestimo = new TextBox();
            grpConfirmarEstorno = new GroupBox();
            btnEstornar = new Button();
            btnCancelar = new Button();
            txtMotivoEstorno = new TextBox();
            lblConfirmacao = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridListarPagamentos).BeginInit();
            grpFiltrosPagamento.SuspendLayout();
            grpConfirmarEstorno.SuspendLayout();
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
            // 
            // grpFiltrosPagamento
            // 
            grpFiltrosPagamento.BackColor = Color.Transparent;
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
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Location = new Point(518, 55);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.Size = new Size(171, 27);
            txtCodigoCliente.TabIndex = 3;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(382, 58);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(130, 20);
            lblCodigoCliente.TabIndex = 2;
            lblCodigoCliente.Text = "Código do Cliente";
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(15, 58);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(164, 20);
            lblCodigoEmprestimo.TabIndex = 1;
            lblCodigoEmprestimo.Text = "Código do Empréstimo";
            // 
            // txtCodigoEmprestimo
            // 
            txtCodigoEmprestimo.Location = new Point(185, 55);
            txtCodigoEmprestimo.Name = "txtCodigoEmprestimo";
            txtCodigoEmprestimo.Size = new Size(172, 27);
            txtCodigoEmprestimo.TabIndex = 0;
            // 
            // grpConfirmarEstorno
            // 
            grpConfirmarEstorno.BackColor = Color.Transparent;
            grpConfirmarEstorno.Controls.Add(lblConfirmacao);
            grpConfirmarEstorno.Controls.Add(btnEstornar);
            grpConfirmarEstorno.Controls.Add(btnCancelar);
            grpConfirmarEstorno.Controls.Add(txtMotivoEstorno);
            grpConfirmarEstorno.Location = new Point(12, 540);
            grpConfirmarEstorno.Name = "grpConfirmarEstorno";
            grpConfirmarEstorno.Size = new Size(942, 181);
            grpConfirmarEstorno.TabIndex = 3;
            grpConfirmarEstorno.TabStop = false;
            grpConfirmarEstorno.Text = "Confirmação e Auditoria";
            // 
            // btnEstornar
            // 
            btnEstornar.Location = new Point(807, 118);
            btnEstornar.Name = "btnEstornar";
            btnEstornar.Size = new Size(113, 45);
            btnEstornar.TabIndex = 2;
            btnEstornar.Text = "Estornar";
            btnEstornar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(670, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 45);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtMotivoEstorno
            // 
            txtMotivoEstorno.Location = new Point(15, 54);
            txtMotivoEstorno.Multiline = true;
            txtMotivoEstorno.Name = "txtMotivoEstorno";
            txtMotivoEstorno.Size = new Size(594, 121);
            txtMotivoEstorno.TabIndex = 0;
            // 
            // lblConfirmacao
            // 
            lblConfirmacao.AutoSize = true;
            lblConfirmacao.Location = new Point(15, 31);
            lblConfirmacao.Name = "lblConfirmacao";
            lblConfirmacao.Size = new Size(227, 20);
            lblConfirmacao.TabIndex = 5;
            lblConfirmacao.Text = "Motivo do Estorno (Obrigatório):";
            // 
            // frmEstornarPagamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(966, 730);
            Controls.Add(panel1);
            Controls.Add(grpConfirmarEstorno);
            Controls.Add(grpFiltrosPagamento);
            Controls.Add(dtGridListarPagamentos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEstornarPagamento";
            Text = "Estorno de Recebimento de Empréstimos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridListarPagamentos).EndInit();
            grpFiltrosPagamento.ResumeLayout(false);
            grpFiltrosPagamento.PerformLayout();
            grpConfirmarEstorno.ResumeLayout(false);
            grpConfirmarEstorno.PerformLayout();
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
        private Button btnCancelar;
        private Label lblConfirmacao;
    }
}
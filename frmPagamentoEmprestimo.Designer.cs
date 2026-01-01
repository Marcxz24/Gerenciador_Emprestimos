namespace Gerenciador_de_Emprestimos
{
    partial class frmPagamentoEmprestimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentoEmprestimo));
            grpBoxDadosParcela = new GroupBox();
            lblStatusParcela = new Label();
            cmbBoxStatusParcela = new ComboBox();
            lblValorTotal = new Label();
            txtBoxValorTotal = new TextBox();
            lblValorParcela = new Label();
            txtBoxValorParcela = new TextBox();
            btnLimparDadosTela = new Button();
            btnLocalizarEmprestimo = new Button();
            btnLocalizarCliente = new Button();
            lblStatusEmprestimo = new Label();
            txtBoxValorJuros = new TextBox();
            lblCodigoEmprestimo = new Label();
            txtBoxCodigoEmprestimo = new TextBox();
            lblCliente = new Label();
            txtBoxCliente = new TextBox();
            lblCodigoCliente = new Label();
            txtBoxCodigoCliente = new TextBox();
            btnGerarPagamento = new Button();
            dataGridParcelasAbertas = new DataGridView();
            lblTotalPagar = new Label();
            txtBoxTotalPagar = new TextBox();
            grpBoxDadosPagamento = new GroupBox();
            grpBoxDadosParcela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridParcelasAbertas).BeginInit();
            grpBoxDadosPagamento.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxDadosParcela
            // 
            grpBoxDadosParcela.BackColor = Color.Transparent;
            grpBoxDadosParcela.Controls.Add(lblStatusParcela);
            grpBoxDadosParcela.Controls.Add(cmbBoxStatusParcela);
            grpBoxDadosParcela.Controls.Add(lblValorTotal);
            grpBoxDadosParcela.Controls.Add(txtBoxValorTotal);
            grpBoxDadosParcela.Controls.Add(lblValorParcela);
            grpBoxDadosParcela.Controls.Add(txtBoxValorParcela);
            grpBoxDadosParcela.Controls.Add(btnLimparDadosTela);
            grpBoxDadosParcela.Controls.Add(btnLocalizarEmprestimo);
            grpBoxDadosParcela.Controls.Add(btnLocalizarCliente);
            grpBoxDadosParcela.Controls.Add(lblStatusEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxValorJuros);
            grpBoxDadosParcela.Controls.Add(lblCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(lblCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCliente);
            grpBoxDadosParcela.Controls.Add(lblCodigoCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoCliente);
            grpBoxDadosParcela.Location = new Point(12, 12);
            grpBoxDadosParcela.Name = "grpBoxDadosParcela";
            grpBoxDadosParcela.Size = new Size(809, 259);
            grpBoxDadosParcela.TabIndex = 0;
            grpBoxDadosParcela.TabStop = false;
            grpBoxDadosParcela.Text = "Dados do Cliente e do Emprestimo";
            // 
            // lblStatusParcela
            // 
            lblStatusParcela.AutoSize = true;
            lblStatusParcela.Location = new Point(524, 142);
            lblStatusParcela.Name = "lblStatusParcela";
            lblStatusParcela.Size = new Size(124, 20);
            lblStatusParcela.TabIndex = 16;
            lblStatusParcela.Text = "Status da Parcela:";
            // 
            // cmbBoxStatusParcela
            // 
            cmbBoxStatusParcela.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxStatusParcela.FormattingEnabled = true;
            cmbBoxStatusParcela.Items.AddRange(new object[] { "ABERTA", "ATRASADA" });
            cmbBoxStatusParcela.Location = new Point(654, 139);
            cmbBoxStatusParcela.Name = "cmbBoxStatusParcela";
            cmbBoxStatusParcela.Size = new Size(151, 28);
            cmbBoxStatusParcela.TabIndex = 15;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(265, 142);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 20);
            lblValorTotal.TabIndex = 14;
            lblValorTotal.Text = "Valor Total:";
            // 
            // txtBoxValorTotal
            // 
            txtBoxValorTotal.Location = new Point(354, 139);
            txtBoxValorTotal.Name = "txtBoxValorTotal";
            txtBoxValorTotal.Size = new Size(164, 27);
            txtBoxValorTotal.TabIndex = 13;
            // 
            // lblValorParcela
            // 
            lblValorParcela.AutoSize = true;
            lblValorParcela.Location = new Point(0, 138);
            lblValorParcela.Name = "lblValorParcela";
            lblValorParcela.Size = new Size(118, 20);
            lblValorParcela.TabIndex = 12;
            lblValorParcela.Text = "Valor da Parcela:";
            // 
            // txtBoxValorParcela
            // 
            txtBoxValorParcela.Location = new Point(124, 135);
            txtBoxValorParcela.Name = "txtBoxValorParcela";
            txtBoxValorParcela.Size = new Size(135, 27);
            txtBoxValorParcela.TabIndex = 11;
            // 
            // btnLimparDadosTela
            // 
            btnLimparDadosTela.BackColor = Color.Salmon;
            btnLimparDadosTela.FlatStyle = FlatStyle.Popup;
            btnLimparDadosTela.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparDadosTela.Location = new Point(310, 203);
            btnLimparDadosTela.Name = "btnLimparDadosTela";
            btnLimparDadosTela.Size = new Size(220, 40);
            btnLimparDadosTela.TabIndex = 10;
            btnLimparDadosTela.Text = "Limpar Dados";
            btnLimparDadosTela.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDadosTela.UseVisualStyleBackColor = false;
            btnLimparDadosTela.Click += btnLimparDadosTela_Click;
            // 
            // btnLocalizarEmprestimo
            // 
            btnLocalizarEmprestimo.BackColor = Color.Aqua;
            btnLocalizarEmprestimo.FlatStyle = FlatStyle.Popup;
            btnLocalizarEmprestimo.Image = Properties.Resources.lupa;
            btnLocalizarEmprestimo.Location = new Point(545, 203);
            btnLocalizarEmprestimo.Name = "btnLocalizarEmprestimo";
            btnLocalizarEmprestimo.Size = new Size(220, 40);
            btnLocalizarEmprestimo.TabIndex = 9;
            btnLocalizarEmprestimo.Text = "Localizar Emprestimo";
            btnLocalizarEmprestimo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocalizarEmprestimo.UseVisualStyleBackColor = false;
            btnLocalizarEmprestimo.Click += btnLocalizarEmprestimo_Click;
            // 
            // btnLocalizarCliente
            // 
            btnLocalizarCliente.BackColor = Color.Aqua;
            btnLocalizarCliente.FlatStyle = FlatStyle.Popup;
            btnLocalizarCliente.Image = Properties.Resources.lupa;
            btnLocalizarCliente.Location = new Point(74, 203);
            btnLocalizarCliente.Name = "btnLocalizarCliente";
            btnLocalizarCliente.Size = new Size(220, 40);
            btnLocalizarCliente.TabIndex = 8;
            btnLocalizarCliente.Text = "Localizar Cliente";
            btnLocalizarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocalizarCliente.UseVisualStyleBackColor = false;
            btnLocalizarCliente.Click += btnLocalizarCliente_Click;
            // 
            // lblStatusEmprestimo
            // 
            lblStatusEmprestimo.AutoSize = true;
            lblStatusEmprestimo.Location = new Point(390, 96);
            lblStatusEmprestimo.Name = "lblStatusEmprestimo";
            lblStatusEmprestimo.Size = new Size(111, 20);
            lblStatusEmprestimo.TabIndex = 7;
            lblStatusEmprestimo.Text = "Valor dos Juros:";
            // 
            // txtBoxValorJuros
            // 
            txtBoxValorJuros.Location = new Point(507, 93);
            txtBoxValorJuros.Name = "txtBoxValorJuros";
            txtBoxValorJuros.Size = new Size(298, 27);
            txtBoxValorJuros.TabIndex = 6;
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(381, 48);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(167, 20);
            lblCodigoEmprestimo.TabIndex = 5;
            lblCodigoEmprestimo.Text = "Codigo do Emprestimo:";
            // 
            // txtBoxCodigoEmprestimo
            // 
            txtBoxCodigoEmprestimo.Location = new Point(551, 45);
            txtBoxCodigoEmprestimo.Name = "txtBoxCodigoEmprestimo";
            txtBoxCodigoEmprestimo.Size = new Size(254, 27);
            txtBoxCodigoEmprestimo.TabIndex = 4;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 93);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 3;
            lblCliente.Text = "Cliente:";
            // 
            // txtBoxCliente
            // 
            txtBoxCliente.Location = new Point(70, 93);
            txtBoxCliente.Name = "txtBoxCliente";
            txtBoxCliente.ReadOnly = true;
            txtBoxCliente.Size = new Size(305, 27);
            txtBoxCliente.TabIndex = 2;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(6, 42);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(61, 20);
            lblCodigoCliente.TabIndex = 1;
            lblCodigoCliente.Text = "Codigo:";
            // 
            // txtBoxCodigoCliente
            // 
            txtBoxCodigoCliente.Location = new Point(70, 42);
            txtBoxCodigoCliente.Name = "txtBoxCodigoCliente";
            txtBoxCodigoCliente.ReadOnly = true;
            txtBoxCodigoCliente.Size = new Size(305, 27);
            txtBoxCodigoCliente.TabIndex = 0;
            // 
            // btnGerarPagamento
            // 
            btnGerarPagamento.BackColor = Color.SpringGreen;
            btnGerarPagamento.FlatStyle = FlatStyle.Popup;
            btnGerarPagamento.Image = (Image)resources.GetObject("btnGerarPagamento.Image");
            btnGerarPagamento.Location = new Point(322, 752);
            btnGerarPagamento.Name = "btnGerarPagamento";
            btnGerarPagamento.Size = new Size(220, 72);
            btnGerarPagamento.TabIndex = 17;
            btnGerarPagamento.Text = "Gerar Pagamento";
            btnGerarPagamento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGerarPagamento.UseVisualStyleBackColor = false;
            btnGerarPagamento.Click += btnGerarPagamento_Click;
            // 
            // dataGridParcelasAbertas
            // 
            dataGridParcelasAbertas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridParcelasAbertas.Location = new Point(12, 277);
            dataGridParcelasAbertas.Name = "dataGridParcelasAbertas";
            dataGridParcelasAbertas.ReadOnly = true;
            dataGridParcelasAbertas.RowHeadersWidth = 51;
            dataGridParcelasAbertas.Size = new Size(809, 268);
            dataGridParcelasAbertas.TabIndex = 18;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.BackColor = Color.Transparent;
            lblTotalPagar.Location = new Point(6, 39);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(83, 20);
            lblTotalPagar.TabIndex = 19;
            lblTotalPagar.Text = "Valor Pago:";
            // 
            // txtBoxTotalPagar
            // 
            txtBoxTotalPagar.Location = new Point(95, 36);
            txtBoxTotalPagar.Name = "txtBoxTotalPagar";
            txtBoxTotalPagar.Size = new Size(127, 27);
            txtBoxTotalPagar.TabIndex = 20;
            // 
            // grpBoxDadosPagamento
            // 
            grpBoxDadosPagamento.BackColor = Color.Transparent;
            grpBoxDadosPagamento.Controls.Add(lblTotalPagar);
            grpBoxDadosPagamento.Controls.Add(txtBoxTotalPagar);
            grpBoxDadosPagamento.Location = new Point(12, 551);
            grpBoxDadosPagamento.Name = "grpBoxDadosPagamento";
            grpBoxDadosPagamento.Size = new Size(809, 195);
            grpBoxDadosPagamento.TabIndex = 21;
            grpBoxDadosPagamento.TabStop = false;
            grpBoxDadosPagamento.Text = "Dados do Pagamento";
            // 
            // frmPagamentoEmprestimo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(grpBoxDadosPagamento);
            Controls.Add(dataGridParcelasAbertas);
            Controls.Add(btnGerarPagamento);
            Controls.Add(grpBoxDadosParcela);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPagamentoEmprestimo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamento de Parcelas";
            grpBoxDadosParcela.ResumeLayout(false);
            grpBoxDadosParcela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridParcelasAbertas).EndInit();
            grpBoxDadosPagamento.ResumeLayout(false);
            grpBoxDadosPagamento.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxDadosParcela;
        private Label lblCodigoCliente;
        private TextBox txtBoxCodigoCliente;
        private Label lblCliente;
        private TextBox txtBoxCliente;
        private Label lblStatusEmprestimo;
        private TextBox txtBoxValorJuros;
        private Label lblCodigoEmprestimo;
        private TextBox txtBoxCodigoEmprestimo;
        private Button btnLocalizarCliente;
        private Button btnLocalizarEmprestimo;
        private Button btnLimparDadosTela;
        private Label lblValorParcela;
        private TextBox txtBoxValorParcela;
        private Label lblValorTotal;
        private TextBox txtBoxValorTotal;
        private Label lblStatusParcela;
        private ComboBox cmbBoxStatusParcela;
        private Button btnGerarPagamento;
        private DataGridView dataGridParcelasAbertas;
        private Label lblTotalPagar;
        private TextBox txtBoxTotalPagar;
        private GroupBox grpBoxDadosPagamento;
    }
}
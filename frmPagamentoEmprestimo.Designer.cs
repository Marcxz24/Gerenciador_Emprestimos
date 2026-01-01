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
            lblClienteNome = new Label();
            txtClienteNome = new TextBox();
            label1 = new Label();
            txtBoxParcela = new TextBox();
            lblStatusParce = new Label();
            lblValorJuros = new Label();
            txtValorJuros = new TextBox();
            lblValorEmprestimo = new Label();
            txtValorEmprestimo = new TextBox();
            lblNumeroParcela = new Label();
            txtBoxNumeroParcela = new TextBox();
            comboBoxParcelaStatus = new ComboBox();
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
            dataGridParcelasAbertas.CellDoubleClick += dataGridParcelasAbertas_CellDoubleClick;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.BackColor = Color.Transparent;
            lblTotalPagar.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPagar.Location = new Point(265, 158);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(87, 18);
            lblTotalPagar.TabIndex = 19;
            lblTotalPagar.Text = "Valor Pago:";
            // 
            // txtBoxTotalPagar
            // 
            txtBoxTotalPagar.Location = new Point(354, 153);
            txtBoxTotalPagar.Name = "txtBoxTotalPagar";
            txtBoxTotalPagar.Size = new Size(176, 27);
            txtBoxTotalPagar.TabIndex = 20;
            // 
            // grpBoxDadosPagamento
            // 
            grpBoxDadosPagamento.BackColor = Color.Transparent;
            grpBoxDadosPagamento.Controls.Add(comboBoxParcelaStatus);
            grpBoxDadosPagamento.Controls.Add(lblClienteNome);
            grpBoxDadosPagamento.Controls.Add(txtClienteNome);
            grpBoxDadosPagamento.Controls.Add(label1);
            grpBoxDadosPagamento.Controls.Add(txtBoxParcela);
            grpBoxDadosPagamento.Controls.Add(lblStatusParce);
            grpBoxDadosPagamento.Controls.Add(lblValorJuros);
            grpBoxDadosPagamento.Controls.Add(txtValorJuros);
            grpBoxDadosPagamento.Controls.Add(lblValorEmprestimo);
            grpBoxDadosPagamento.Controls.Add(txtValorEmprestimo);
            grpBoxDadosPagamento.Controls.Add(lblNumeroParcela);
            grpBoxDadosPagamento.Controls.Add(txtBoxNumeroParcela);
            grpBoxDadosPagamento.Controls.Add(lblTotalPagar);
            grpBoxDadosPagamento.Controls.Add(txtBoxTotalPagar);
            grpBoxDadosPagamento.Location = new Point(12, 551);
            grpBoxDadosPagamento.Name = "grpBoxDadosPagamento";
            grpBoxDadosPagamento.Size = new Size(809, 195);
            grpBoxDadosPagamento.TabIndex = 21;
            grpBoxDadosPagamento.TabStop = false;
            grpBoxDadosPagamento.Text = "Dados do Pagamento";
            // 
            // lblClienteNome
            // 
            lblClienteNome.AutoSize = true;
            lblClienteNome.Location = new Point(524, 92);
            lblClienteNome.Name = "lblClienteNome";
            lblClienteNome.Size = new Size(58, 20);
            lblClienteNome.TabIndex = 23;
            lblClienteNome.Text = "Cliente:";
            // 
            // txtClienteNome
            // 
            txtClienteNome.Location = new Point(588, 92);
            txtClienteNome.Name = "txtClienteNome";
            txtClienteNome.ReadOnly = true;
            txtClienteNome.Size = new Size(204, 27);
            txtClienteNome.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(293, 92);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 29;
            label1.Text = "Valor Parcela:";
            // 
            // txtBoxParcela
            // 
            txtBoxParcela.Location = new Point(391, 92);
            txtBoxParcela.Name = "txtBoxParcela";
            txtBoxParcela.ReadOnly = true;
            txtBoxParcela.Size = new Size(127, 27);
            txtBoxParcela.TabIndex = 30;
            // 
            // lblStatusParce
            // 
            lblStatusParce.AutoSize = true;
            lblStatusParce.Location = new Point(6, 95);
            lblStatusParce.Name = "lblStatusParce";
            lblStatusParce.Size = new Size(124, 20);
            lblStatusParce.TabIndex = 18;
            lblStatusParce.Text = "Status da Parcela:";
            // 
            // lblValorJuros
            // 
            lblValorJuros.AutoSize = true;
            lblValorJuros.BackColor = Color.Transparent;
            lblValorJuros.Location = new Point(571, 41);
            lblValorJuros.Name = "lblValorJuros";
            lblValorJuros.Size = new Size(105, 20);
            lblValorJuros.TabIndex = 25;
            lblValorJuros.Text = "Valor do Juros:";
            // 
            // txtValorJuros
            // 
            txtValorJuros.Location = new Point(682, 38);
            txtValorJuros.Name = "txtValorJuros";
            txtValorJuros.ReadOnly = true;
            txtValorJuros.Size = new Size(121, 27);
            txtValorJuros.TabIndex = 26;
            // 
            // lblValorEmprestimo
            // 
            lblValorEmprestimo.AutoSize = true;
            lblValorEmprestimo.BackColor = Color.Transparent;
            lblValorEmprestimo.Location = new Point(6, 41);
            lblValorEmprestimo.Name = "lblValorEmprestimo";
            lblValorEmprestimo.Size = new Size(152, 20);
            lblValorEmprestimo.TabIndex = 23;
            lblValorEmprestimo.Text = "Valor do Emprestimo:";
            // 
            // txtValorEmprestimo
            // 
            txtValorEmprestimo.Location = new Point(164, 38);
            txtValorEmprestimo.Name = "txtValorEmprestimo";
            txtValorEmprestimo.ReadOnly = true;
            txtValorEmprestimo.Size = new Size(127, 27);
            txtValorEmprestimo.TabIndex = 24;
            // 
            // lblNumeroParcela
            // 
            lblNumeroParcela.AutoSize = true;
            lblNumeroParcela.BackColor = Color.Transparent;
            lblNumeroParcela.Location = new Point(297, 41);
            lblNumeroParcela.Name = "lblNumeroParcela";
            lblNumeroParcela.Size = new Size(138, 20);
            lblNumeroParcela.TabIndex = 21;
            lblNumeroParcela.Text = "Numero da Parcela:";
            // 
            // txtBoxNumeroParcela
            // 
            txtBoxNumeroParcela.Location = new Point(438, 38);
            txtBoxNumeroParcela.Name = "txtBoxNumeroParcela";
            txtBoxNumeroParcela.ReadOnly = true;
            txtBoxNumeroParcela.Size = new Size(127, 27);
            txtBoxNumeroParcela.TabIndex = 22;
            // 
            // comboBoxParcelaStatus
            // 
            comboBoxParcelaStatus.FormattingEnabled = true;
            comboBoxParcelaStatus.Location = new Point(136, 89);
            comboBoxParcelaStatus.Name = "comboBoxParcelaStatus";
            comboBoxParcelaStatus.Size = new Size(151, 28);
            comboBoxParcelaStatus.TabIndex = 31;
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
        private Label lblNumeroParcela;
        private TextBox txtBoxNumeroParcela;
        private Label lblValorEmprestimo;
        private TextBox txtValorEmprestimo;
        private Label lblValorJuros;
        private TextBox txtValorJuros;
        private Label lblStatusParce;
        private Label label1;
        private TextBox txtBoxParcela;
        private Label lblClienteNome;
        private TextBox txtClienteNome;
        private ComboBox comboBoxParcelaStatus;
    }
}
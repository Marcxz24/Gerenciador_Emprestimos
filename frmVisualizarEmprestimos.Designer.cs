namespace Gerenciador_de_Emprestimos
{
    partial class frmVisualizarEmprestimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarEmprestimos));
            grpBoxCliente = new GroupBox();
            comboBoxSituacaoCliente = new ComboBox();
            lblSituacaoCadastral = new Label();
            txtCpfCnpjCliente = new TextBox();
            lblCpfCnpj = new Label();
            txtNomeCliente = new TextBox();
            lblNomeCliente = new Label();
            txtCodigoCliente = new TextBox();
            lblCodigoCliente = new Label();
            btnPesquisarCliente = new Button();
            dataGridEmprestimos = new DataGridView();
            grpBoxDadosEmprestimos = new GroupBox();
            txtValorJurosMonetario = new TextBox();
            lblValorJurosMonetario = new Label();
            txtValorJurosPercentual = new TextBox();
            lblValorJuros = new Label();
            txtValorEmprestado = new TextBox();
            lblValorEmprestado = new Label();
            comboBoxStatusEmprestimo = new ComboBox();
            lblStatusEmprestimo = new Label();
            grpFiltrosPesquisa = new GroupBox();
            btnVisualizarEmprestimos = new Button();
            grpBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmprestimos).BeginInit();
            grpBoxDadosEmprestimos.SuspendLayout();
            grpFiltrosPesquisa.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxCliente
            // 
            grpBoxCliente.BackColor = Color.Transparent;
            grpBoxCliente.Controls.Add(comboBoxSituacaoCliente);
            grpBoxCliente.Controls.Add(lblSituacaoCadastral);
            grpBoxCliente.Controls.Add(txtCpfCnpjCliente);
            grpBoxCliente.Controls.Add(lblCpfCnpj);
            grpBoxCliente.Controls.Add(txtNomeCliente);
            grpBoxCliente.Controls.Add(lblNomeCliente);
            grpBoxCliente.Controls.Add(txtCodigoCliente);
            grpBoxCliente.Controls.Add(lblCodigoCliente);
            grpBoxCliente.Location = new Point(6, 24);
            grpBoxCliente.Name = "grpBoxCliente";
            grpBoxCliente.Size = new Size(809, 125);
            grpBoxCliente.TabIndex = 0;
            grpBoxCliente.TabStop = false;
            grpBoxCliente.Text = "Dados do Cliente";
            // 
            // comboBoxSituacaoCliente
            // 
            comboBoxSituacaoCliente.Enabled = false;
            comboBoxSituacaoCliente.FormattingEnabled = true;
            comboBoxSituacaoCliente.Location = new Point(639, 71);
            comboBoxSituacaoCliente.Name = "comboBoxSituacaoCliente";
            comboBoxSituacaoCliente.Size = new Size(151, 25);
            comboBoxSituacaoCliente.TabIndex = 3;
            // 
            // lblSituacaoCadastral
            // 
            lblSituacaoCadastral.AutoSize = true;
            lblSituacaoCadastral.Location = new Point(638, 41);
            lblSituacaoCadastral.Name = "lblSituacaoCadastral";
            lblSituacaoCadastral.Size = new Size(149, 17);
            lblSituacaoCadastral.TabIndex = 6;
            lblSituacaoCadastral.Text = "Situação do Cliente";
            // 
            // txtCpfCnpjCliente
            // 
            txtCpfCnpjCliente.Location = new Point(452, 71);
            txtCpfCnpjCliente.Name = "txtCpfCnpjCliente";
            txtCpfCnpjCliente.ReadOnly = true;
            txtCpfCnpjCliente.Size = new Size(166, 25);
            txtCpfCnpjCliente.TabIndex = 5;
            // 
            // lblCpfCnpj
            // 
            lblCpfCnpj.AutoSize = true;
            lblCpfCnpj.Location = new Point(452, 41);
            lblCpfCnpj.Name = "lblCpfCnpj";
            lblCpfCnpj.Size = new Size(160, 17);
            lblCpfCnpj.TabIndex = 4;
            lblCpfCnpj.Text = "CPF/CNPJ do Cliente";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(148, 71);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.ReadOnly = true;
            txtNomeCliente.Size = new Size(294, 25);
            txtNomeCliente.TabIndex = 3;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(148, 41);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(127, 17);
            lblNomeCliente.TabIndex = 2;
            lblNomeCliente.Text = "Nome do Cliente";
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Location = new Point(10, 71);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.ReadOnly = true;
            txtCodigoCliente.Size = new Size(125, 25);
            txtCodigoCliente.TabIndex = 1;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(10, 41);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(114, 17);
            lblCodigoCliente.TabIndex = 0;
            lblCodigoCliente.Text = "Codigo Cliente";
            // 
            // btnPesquisarCliente
            // 
            btnPesquisarCliente.BackColor = Color.PaleTurquoise;
            btnPesquisarCliente.FlatStyle = FlatStyle.Popup;
            btnPesquisarCliente.Image = Properties.Resources.lupa;
            btnPesquisarCliente.Location = new Point(189, 359);
            btnPesquisarCliente.Name = "btnPesquisarCliente";
            btnPesquisarCliente.Size = new Size(193, 43);
            btnPesquisarCliente.TabIndex = 6;
            btnPesquisarCliente.Text = "Pesquisar Cliente";
            btnPesquisarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarCliente.UseVisualStyleBackColor = false;
            btnPesquisarCliente.Click += btnPesquisarCliente_Click;
            // 
            // dataGridEmprestimos
            // 
            dataGridEmprestimos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmprestimos.Location = new Point(12, 427);
            dataGridEmprestimos.Name = "dataGridEmprestimos";
            dataGridEmprestimos.RowHeadersWidth = 51;
            dataGridEmprestimos.Size = new Size(803, 355);
            dataGridEmprestimos.TabIndex = 1;
            // 
            // grpBoxDadosEmprestimos
            // 
            grpBoxDadosEmprestimos.BackColor = Color.Transparent;
            grpBoxDadosEmprestimos.Controls.Add(txtValorJurosMonetario);
            grpBoxDadosEmprestimos.Controls.Add(lblValorJurosMonetario);
            grpBoxDadosEmprestimos.Controls.Add(txtValorJurosPercentual);
            grpBoxDadosEmprestimos.Controls.Add(lblValorJuros);
            grpBoxDadosEmprestimos.Controls.Add(txtValorEmprestado);
            grpBoxDadosEmprestimos.Controls.Add(lblValorEmprestado);
            grpBoxDadosEmprestimos.Controls.Add(comboBoxStatusEmprestimo);
            grpBoxDadosEmprestimos.Controls.Add(lblStatusEmprestimo);
            grpBoxDadosEmprestimos.Location = new Point(6, 155);
            grpBoxDadosEmprestimos.Name = "grpBoxDadosEmprestimos";
            grpBoxDadosEmprestimos.Size = new Size(803, 158);
            grpBoxDadosEmprestimos.TabIndex = 2;
            grpBoxDadosEmprestimos.TabStop = false;
            grpBoxDadosEmprestimos.Text = "Dados do Emprestimo";
            // 
            // txtValorJurosMonetario
            // 
            txtValorJurosMonetario.Location = new Point(520, 62);
            txtValorJurosMonetario.Name = "txtValorJurosMonetario";
            txtValorJurosMonetario.Size = new Size(154, 25);
            txtValorJurosMonetario.TabIndex = 11;
            // 
            // lblValorJurosMonetario
            // 
            lblValorJurosMonetario.AutoSize = true;
            lblValorJurosMonetario.Location = new Point(520, 32);
            lblValorJurosMonetario.Name = "lblValorJurosMonetario";
            lblValorJurosMonetario.Size = new Size(157, 17);
            lblValorJurosMonetario.TabIndex = 10;
            lblValorJurosMonetario.Text = "Valor dos Juros (R$)";
            // 
            // txtValorJurosPercentual
            // 
            txtValorJurosPercentual.Location = new Point(349, 62);
            txtValorJurosPercentual.Name = "txtValorJurosPercentual";
            txtValorJurosPercentual.Size = new Size(154, 25);
            txtValorJurosPercentual.TabIndex = 9;
            // 
            // lblValorJuros
            // 
            lblValorJuros.AutoSize = true;
            lblValorJuros.Location = new Point(349, 32);
            lblValorJuros.Name = "lblValorJuros";
            lblValorJuros.Size = new Size(150, 17);
            lblValorJuros.TabIndex = 8;
            lblValorJuros.Text = "Valor dos Juros (%)";
            // 
            // txtValorEmprestado
            // 
            txtValorEmprestado.Location = new Point(183, 62);
            txtValorEmprestado.Name = "txtValorEmprestado";
            txtValorEmprestado.Size = new Size(154, 25);
            txtValorEmprestado.TabIndex = 7;
            // 
            // lblValorEmprestado
            // 
            lblValorEmprestado.AutoSize = true;
            lblValorEmprestado.Location = new Point(183, 32);
            lblValorEmprestado.Name = "lblValorEmprestado";
            lblValorEmprestado.Size = new Size(139, 17);
            lblValorEmprestado.TabIndex = 3;
            lblValorEmprestado.Text = "Valor Emprestado\r\n";
            // 
            // comboBoxStatusEmprestimo
            // 
            comboBoxStatusEmprestimo.FormattingEnabled = true;
            comboBoxStatusEmprestimo.Items.AddRange(new object[] { "ATIVO", "QUITADO" });
            comboBoxStatusEmprestimo.Location = new Point(10, 62);
            comboBoxStatusEmprestimo.Name = "comboBoxStatusEmprestimo";
            comboBoxStatusEmprestimo.Size = new Size(151, 25);
            comboBoxStatusEmprestimo.TabIndex = 2;
            // 
            // lblStatusEmprestimo
            // 
            lblStatusEmprestimo.AutoSize = true;
            lblStatusEmprestimo.Location = new Point(10, 32);
            lblStatusEmprestimo.Name = "lblStatusEmprestimo";
            lblStatusEmprestimo.Size = new Size(167, 17);
            lblStatusEmprestimo.TabIndex = 1;
            lblStatusEmprestimo.Text = "Status do Emprestimo";
            // 
            // grpFiltrosPesquisa
            // 
            grpFiltrosPesquisa.BackColor = Color.Transparent;
            grpFiltrosPesquisa.Controls.Add(btnVisualizarEmprestimos);
            grpFiltrosPesquisa.Controls.Add(btnPesquisarCliente);
            grpFiltrosPesquisa.Controls.Add(grpBoxCliente);
            grpFiltrosPesquisa.Controls.Add(grpBoxDadosEmprestimos);
            grpFiltrosPesquisa.Location = new Point(6, 12);
            grpFiltrosPesquisa.Name = "grpFiltrosPesquisa";
            grpFiltrosPesquisa.Size = new Size(825, 409);
            grpFiltrosPesquisa.TabIndex = 3;
            grpFiltrosPesquisa.TabStop = false;
            grpFiltrosPesquisa.Text = "Filtros de Pesquisa";
            // 
            // btnVisualizarEmprestimos
            // 
            btnVisualizarEmprestimos.BackColor = Color.PaleTurquoise;
            btnVisualizarEmprestimos.FlatStyle = FlatStyle.Popup;
            btnVisualizarEmprestimos.Image = Properties.Resources.lupa;
            btnVisualizarEmprestimos.Location = new Point(388, 359);
            btnVisualizarEmprestimos.Name = "btnVisualizarEmprestimos";
            btnVisualizarEmprestimos.Size = new Size(229, 43);
            btnVisualizarEmprestimos.TabIndex = 7;
            btnVisualizarEmprestimos.Text = "Visualizar Emprestimos";
            btnVisualizarEmprestimos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVisualizarEmprestimos.UseVisualStyleBackColor = false;
            btnVisualizarEmprestimos.Click += btnVisualizarEmprestimos_Click;
            // 
            // frmVisualizarEmprestimos
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(grpFiltrosPesquisa);
            Controls.Add(dataGridEmprestimos);
            Font = new Font("Arial Rounded MT Bold", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmVisualizarEmprestimos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizar Empréstimos";
            grpBoxCliente.ResumeLayout(false);
            grpBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmprestimos).EndInit();
            grpBoxDadosEmprestimos.ResumeLayout(false);
            grpBoxDadosEmprestimos.PerformLayout();
            grpFiltrosPesquisa.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxCliente;
        private TextBox txtCodigoCliente;
        private Label lblCodigoCliente;
        private TextBox txtNomeCliente;
        private Label lblNomeCliente;
        private DataGridView dataGridEmprestimos;
        private Label lblCpfCnpj;
        private TextBox txtCpfCnpjCliente;
        private Button btnPesquisarCliente;
        private GroupBox grpBoxDadosEmprestimos;
        private GroupBox grpFiltrosPesquisa;
        private Label lblStatusEmprestimo;
        private ComboBox comboBoxStatusEmprestimo;
        private Button btnVisualizarEmprestimos;
        private Label lblSituacaoCadastral;
        private ComboBox comboBoxSituacaoCliente;
        private Label lblValorEmprestado;
        private TextBox txtValorEmprestado;
        private Label lblValorJuros;
        private Label lblValorJurosMonetario;
        private TextBox txtValorJurosPercentual;
        private TextBox txtValorJurosMonetario;
    }
}
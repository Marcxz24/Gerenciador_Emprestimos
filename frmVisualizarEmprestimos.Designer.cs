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
            txtValorTotal = new TextBox();
            lblValorTotal = new Label();
            txtValorDaParcela = new TextBox();
            lblValorDaParcela = new Label();
            txtQtnParcela = new TextBox();
            lblQtnParcela = new Label();
            txtValorJurosMonetario = new TextBox();
            lblValorJurosMonetario = new Label();
            txtValorEmprestado = new TextBox();
            lblValorEmprestado = new Label();
            comboBoxStatusEmprestimo = new ComboBox();
            lblStatusEmprestimo = new Label();
            grpFiltrosPesquisa = new GroupBox();
            btnLimparDados = new Button();
            btnVisualizarEmprestimos = new Button();
            btnImprimir = new Button();
            btnFechar = new Button();
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
            btnPesquisarCliente.Location = new Point(189, 343);
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
            dataGridEmprestimos.ReadOnly = true;
            dataGridEmprestimos.RowHeadersWidth = 51;
            dataGridEmprestimos.Size = new Size(803, 355);
            dataGridEmprestimos.TabIndex = 1;
            // 
            // grpBoxDadosEmprestimos
            // 
            grpBoxDadosEmprestimos.BackColor = Color.Transparent;
            grpBoxDadosEmprestimos.Controls.Add(txtValorTotal);
            grpBoxDadosEmprestimos.Controls.Add(lblValorTotal);
            grpBoxDadosEmprestimos.Controls.Add(txtValorDaParcela);
            grpBoxDadosEmprestimos.Controls.Add(lblValorDaParcela);
            grpBoxDadosEmprestimos.Controls.Add(txtQtnParcela);
            grpBoxDadosEmprestimos.Controls.Add(lblQtnParcela);
            grpBoxDadosEmprestimos.Controls.Add(txtValorJurosMonetario);
            grpBoxDadosEmprestimos.Controls.Add(lblValorJurosMonetario);
            grpBoxDadosEmprestimos.Controls.Add(txtValorEmprestado);
            grpBoxDadosEmprestimos.Controls.Add(lblValorEmprestado);
            grpBoxDadosEmprestimos.Controls.Add(comboBoxStatusEmprestimo);
            grpBoxDadosEmprestimos.Controls.Add(lblStatusEmprestimo);
            grpBoxDadosEmprestimos.Location = new Point(6, 155);
            grpBoxDadosEmprestimos.Name = "grpBoxDadosEmprestimos";
            grpBoxDadosEmprestimos.Size = new Size(803, 173);
            grpBoxDadosEmprestimos.TabIndex = 2;
            grpBoxDadosEmprestimos.TabStop = false;
            grpBoxDadosEmprestimos.Text = "Filtro de Dados do Emprestimo";
            // 
            // txtValorTotal
            // 
            txtValorTotal.Location = new Point(217, 137);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.Size = new Size(183, 25);
            txtValorTotal.TabIndex = 17;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(217, 107);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(87, 17);
            lblValorTotal.TabIndex = 16;
            lblValorTotal.Text = "Valor Total";
            // 
            // txtValorDaParcela
            // 
            txtValorDaParcela.Location = new Point(15, 137);
            txtValorDaParcela.Name = "txtValorDaParcela";
            txtValorDaParcela.Size = new Size(183, 25);
            txtValorDaParcela.TabIndex = 15;
            // 
            // lblValorDaParcela
            // 
            lblValorDaParcela.AutoSize = true;
            lblValorDaParcela.Location = new Point(15, 107);
            lblValorDaParcela.Name = "lblValorDaParcela";
            lblValorDaParcela.Size = new Size(130, 17);
            lblValorDaParcela.TabIndex = 14;
            lblValorDaParcela.Text = "Valor da Parcela";
            // 
            // txtQtnParcela
            // 
            txtQtnParcela.Location = new Point(521, 62);
            txtQtnParcela.Name = "txtQtnParcela";
            txtQtnParcela.Size = new Size(183, 25);
            txtQtnParcela.TabIndex = 13;
            // 
            // lblQtnParcela
            // 
            lblQtnParcela.AutoSize = true;
            lblQtnParcela.Location = new Point(521, 32);
            lblQtnParcela.Name = "lblQtnParcela";
            lblQtnParcela.Size = new Size(183, 17);
            lblQtnParcela.TabIndex = 12;
            lblQtnParcela.Text = "Quantidade de Parcelas";
            // 
            // txtValorJurosMonetario
            // 
            txtValorJurosMonetario.Location = new Point(351, 62);
            txtValorJurosMonetario.Name = "txtValorJurosMonetario";
            txtValorJurosMonetario.Size = new Size(154, 25);
            txtValorJurosMonetario.TabIndex = 11;
            // 
            // lblValorJurosMonetario
            // 
            lblValorJurosMonetario.AutoSize = true;
            lblValorJurosMonetario.Location = new Point(351, 32);
            lblValorJurosMonetario.Name = "lblValorJurosMonetario";
            lblValorJurosMonetario.Size = new Size(157, 17);
            lblValorJurosMonetario.TabIndex = 10;
            lblValorJurosMonetario.Text = "Valor dos Juros (R$)";
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
            grpFiltrosPesquisa.Controls.Add(btnLimparDados);
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
            // btnLimparDados
            // 
            btnLimparDados.BackColor = Color.Salmon;
            btnLimparDados.FlatStyle = FlatStyle.Popup;
            btnLimparDados.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparDados.Location = new Point(623, 343);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(186, 43);
            btnLimparDados.TabIndex = 9;
            btnLimparDados.Text = "Limpar Dados";
            btnLimparDados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDados.UseVisualStyleBackColor = false;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // btnVisualizarEmprestimos
            // 
            btnVisualizarEmprestimos.BackColor = Color.Aqua;
            btnVisualizarEmprestimos.FlatStyle = FlatStyle.Popup;
            btnVisualizarEmprestimos.Image = Properties.Resources.lupa;
            btnVisualizarEmprestimos.Location = new Point(388, 343);
            btnVisualizarEmprestimos.Name = "btnVisualizarEmprestimos";
            btnVisualizarEmprestimos.Size = new Size(229, 43);
            btnVisualizarEmprestimos.TabIndex = 7;
            btnVisualizarEmprestimos.Text = "Visualizar Emprestimos";
            btnVisualizarEmprestimos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVisualizarEmprestimos.UseVisualStyleBackColor = false;
            btnVisualizarEmprestimos.Click += btnVisualizarEmprestimos_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.Gainsboro;
            btnImprimir.FlatStyle = FlatStyle.Popup;
            btnImprimir.Image = Properties.Resources.imprimir_sinal_de_ferramenta_de_interface_preenchida;
            btnImprimir.Location = new Point(497, 788);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(110, 43);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Salmon;
            btnFechar.FlatStyle = FlatStyle.Popup;
            btnFechar.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnFechar.Location = new Point(629, 788);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(186, 43);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar Tela\r\n";
            btnFechar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // frmVisualizarEmprestimos
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(btnFechar);
            Controls.Add(btnImprimir);
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
        private Label lblValorJurosMonetario;
        private TextBox txtValorJurosMonetario;
        private Button btnImprimir;
        private Button btnLimparDados;
        private TextBox txtQtnParcela;
        private Label lblQtnParcela;
        private TextBox txtValorDaParcela;
        private Label lblValorDaParcela;
        private Button btnFechar;
        private TextBox txtValorTotal;
        private Label lblValorTotal;
    }
}
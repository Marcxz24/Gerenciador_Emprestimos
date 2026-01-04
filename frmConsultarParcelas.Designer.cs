namespace Gerenciador_de_Emprestimos
{
    partial class frmConsultarParcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarParcelas));
            grpBoxDadosParcela = new GroupBox();
            txtBoxValorTotal = new TextBox();
            lblValorTotal = new Label();
            btnLimparDados = new Button();
            txtBoxNumeroParcela = new TextBox();
            lblNumeroParcela = new Label();
            btnPesquisarParcela = new Button();
            btnPesquisarCliente = new Button();
            txtBoxCodigoEmprestimo = new TextBox();
            lblCodigoEmprestimo = new Label();
            txtBoxValorParcela = new TextBox();
            lblValorParcela = new Label();
            cmbBoxStatusParcela = new ComboBox();
            lblStatusEmprestimo = new Label();
            txtBoxNomeCliente = new TextBox();
            lblNomeCliente = new Label();
            txtBoxCodigoCliente = new TextBox();
            lblCodigoCliente = new Label();
            dataGridConsultaParcela = new DataGridView();
            btnImprimir = new Button();
            grpBoxDadosParcela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridConsultaParcela).BeginInit();
            SuspendLayout();
            // 
            // grpBoxDadosParcela
            // 
            grpBoxDadosParcela.BackColor = Color.Transparent;
            grpBoxDadosParcela.Controls.Add(txtBoxValorTotal);
            grpBoxDadosParcela.Controls.Add(lblValorTotal);
            grpBoxDadosParcela.Controls.Add(btnLimparDados);
            grpBoxDadosParcela.Controls.Add(txtBoxNumeroParcela);
            grpBoxDadosParcela.Controls.Add(lblNumeroParcela);
            grpBoxDadosParcela.Controls.Add(btnPesquisarParcela);
            grpBoxDadosParcela.Controls.Add(btnPesquisarCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(lblCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxValorParcela);
            grpBoxDadosParcela.Controls.Add(lblValorParcela);
            grpBoxDadosParcela.Controls.Add(cmbBoxStatusParcela);
            grpBoxDadosParcela.Controls.Add(lblStatusEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxNomeCliente);
            grpBoxDadosParcela.Controls.Add(lblNomeCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoCliente);
            grpBoxDadosParcela.Controls.Add(lblCodigoCliente);
            grpBoxDadosParcela.Location = new Point(1, 3);
            grpBoxDadosParcela.Name = "grpBoxDadosParcela";
            grpBoxDadosParcela.Size = new Size(828, 215);
            grpBoxDadosParcela.TabIndex = 0;
            grpBoxDadosParcela.TabStop = false;
            grpBoxDadosParcela.Text = "Dados da Parcela";
            // 
            // txtBoxValorTotal
            // 
            txtBoxValorTotal.Location = new Point(594, 48);
            txtBoxValorTotal.Name = "txtBoxValorTotal";
            txtBoxValorTotal.Size = new Size(226, 27);
            txtBoxValorTotal.TabIndex = 16;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(505, 51);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 20);
            lblValorTotal.TabIndex = 15;
            lblValorTotal.Text = "Valor Total:";
            // 
            // btnLimparDados
            // 
            btnLimparDados.BackColor = Color.Salmon;
            btnLimparDados.FlatStyle = FlatStyle.Popup;
            btnLimparDados.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparDados.Location = new Point(15, 135);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(170, 43);
            btnLimparDados.TabIndex = 14;
            btnLimparDados.Text = "Limpar";
            btnLimparDados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDados.UseVisualStyleBackColor = false;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // txtBoxNumeroParcela
            // 
            txtBoxNumeroParcela.Location = new Point(679, 132);
            txtBoxNumeroParcela.Name = "txtBoxNumeroParcela";
            txtBoxNumeroParcela.Size = new Size(141, 27);
            txtBoxNumeroParcela.TabIndex = 13;
            // 
            // lblNumeroParcela
            // 
            lblNumeroParcela.AutoSize = true;
            lblNumeroParcela.Location = new Point(543, 135);
            lblNumeroParcela.Name = "lblNumeroParcela";
            lblNumeroParcela.Size = new Size(138, 20);
            lblNumeroParcela.TabIndex = 12;
            lblNumeroParcela.Text = "Numero da Parcela:";
            // 
            // btnPesquisarParcela
            // 
            btnPesquisarParcela.BackColor = Color.Cyan;
            btnPesquisarParcela.FlatStyle = FlatStyle.Popup;
            btnPesquisarParcela.Image = Properties.Resources.lupa;
            btnPesquisarParcela.Location = new Point(367, 135);
            btnPesquisarParcela.Name = "btnPesquisarParcela";
            btnPesquisarParcela.Size = new Size(170, 43);
            btnPesquisarParcela.TabIndex = 11;
            btnPesquisarParcela.Text = "Pesquisar Parcela";
            btnPesquisarParcela.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarParcela.UseVisualStyleBackColor = false;
            btnPesquisarParcela.Click += btnPesquisarParcela_Click;
            // 
            // btnPesquisarCliente
            // 
            btnPesquisarCliente.BackColor = Color.Cyan;
            btnPesquisarCliente.FlatStyle = FlatStyle.Popup;
            btnPesquisarCliente.Image = Properties.Resources.lupa;
            btnPesquisarCliente.Location = new Point(191, 135);
            btnPesquisarCliente.Name = "btnPesquisarCliente";
            btnPesquisarCliente.Size = new Size(170, 43);
            btnPesquisarCliente.TabIndex = 10;
            btnPesquisarCliente.Text = "Pesquisar Cliente";
            btnPesquisarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarCliente.UseVisualStyleBackColor = false;
            btnPesquisarCliente.Click += btnPesquisarCliente_Click;
            // 
            // txtBoxCodigoEmprestimo
            // 
            txtBoxCodigoEmprestimo.Location = new Point(363, 50);
            txtBoxCodigoEmprestimo.Name = "txtBoxCodigoEmprestimo";
            txtBoxCodigoEmprestimo.Size = new Size(125, 27);
            txtBoxCodigoEmprestimo.TabIndex = 9;
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(235, 51);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(126, 20);
            lblCodigoEmprestimo.TabIndex = 8;
            lblCodigoEmprestimo.Text = "Cód. Emprestimo:";
            // 
            // txtBoxValorParcela
            // 
            txtBoxValorParcela.Location = new Point(629, 91);
            txtBoxValorParcela.Name = "txtBoxValorParcela";
            txtBoxValorParcela.Size = new Size(191, 27);
            txtBoxValorParcela.TabIndex = 7;
            // 
            // lblValorParcela
            // 
            lblValorParcela.AutoSize = true;
            lblValorParcela.Location = new Point(505, 92);
            lblValorParcela.Name = "lblValorParcela";
            lblValorParcela.Size = new Size(118, 20);
            lblValorParcela.TabIndex = 6;
            lblValorParcela.Text = "Valor da Parcela:";
            // 
            // cmbBoxStatusParcela
            // 
            cmbBoxStatusParcela.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxStatusParcela.FormattingEnabled = true;
            cmbBoxStatusParcela.Items.AddRange(new object[] { "ABERTA", "PAGA", "ATRASADA" });
            cmbBoxStatusParcela.Location = new Point(669, 169);
            cmbBoxStatusParcela.Name = "cmbBoxStatusParcela";
            cmbBoxStatusParcela.Size = new Size(151, 28);
            cmbBoxStatusParcela.TabIndex = 5;
            // 
            // lblStatusEmprestimo
            // 
            lblStatusEmprestimo.AutoSize = true;
            lblStatusEmprestimo.Location = new Point(543, 172);
            lblStatusEmprestimo.Name = "lblStatusEmprestimo";
            lblStatusEmprestimo.Size = new Size(124, 20);
            lblStatusEmprestimo.TabIndex = 4;
            lblStatusEmprestimo.Text = "Status da Parcela:";
            // 
            // txtBoxNomeCliente
            // 
            txtBoxNomeCliente.Location = new Point(137, 89);
            txtBoxNomeCliente.Name = "txtBoxNomeCliente";
            txtBoxNomeCliente.ReadOnly = true;
            txtBoxNomeCliente.Size = new Size(351, 27);
            txtBoxNomeCliente.TabIndex = 3;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(6, 92);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(125, 20);
            lblNomeCliente.TabIndex = 2;
            lblNomeCliente.Text = "Nome do Cliente:";
            // 
            // txtBoxCodigoCliente
            // 
            txtBoxCodigoCliente.Location = new Point(104, 48);
            txtBoxCodigoCliente.Name = "txtBoxCodigoCliente";
            txtBoxCodigoCliente.ReadOnly = true;
            txtBoxCodigoCliente.Size = new Size(125, 27);
            txtBoxCodigoCliente.TabIndex = 1;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(6, 51);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(92, 20);
            lblCodigoCliente.TabIndex = 0;
            lblCodigoCliente.Text = "Cód. Cliente:";
            // 
            // dataGridConsultaParcela
            // 
            dataGridConsultaParcela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridConsultaParcela.Location = new Point(12, 224);
            dataGridConsultaParcela.Name = "dataGridConsultaParcela";
            dataGridConsultaParcela.ReadOnly = true;
            dataGridConsultaParcela.RowHeadersWidth = 51;
            dataGridConsultaParcela.Size = new Size(811, 540);
            dataGridConsultaParcela.TabIndex = 1;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.DarkGray;
            btnImprimir.FlatStyle = FlatStyle.Popup;
            btnImprimir.Image = Properties.Resources.imprimir_sinal_de_ferramenta_de_interface_preenchida;
            btnImprimir.Location = new Point(651, 781);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(170, 43);
            btnImprimir.TabIndex = 15;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // frmConsultarParcelas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(btnImprimir);
            Controls.Add(dataGridConsultaParcela);
            Controls.Add(grpBoxDadosParcela);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmConsultarParcelas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizar Parcelas";
            grpBoxDadosParcela.ResumeLayout(false);
            grpBoxDadosParcela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridConsultaParcela).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxDadosParcela;
        private TextBox txtBoxCodigoCliente;
        private Label lblCodigoCliente;
        private Label lblNomeCliente;
        private TextBox txtBoxNomeCliente;
        private Label lblStatusEmprestimo;
        private ComboBox cmbBoxStatusParcela;
        private TextBox txtBoxValorParcela;
        private Label lblValorParcela;
        private TextBox txtBoxCodigoEmprestimo;
        private Label lblCodigoEmprestimo;
        private DataGridView dataGridConsultaParcela;
        private Button btnPesquisarCliente;
        private Button btnPesquisarParcela;
        private TextBox txtBoxNumeroParcela;
        private Label lblNumeroParcela;
        private Button btnLimparDados;
        private TextBox txtBoxValorTotal;
        private Label lblValorTotal;
        private Button btnImprimir;
    }
}
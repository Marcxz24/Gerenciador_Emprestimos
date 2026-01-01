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
            grpBoxDadosParcela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridConsultaParcela).BeginInit();
            SuspendLayout();
            // 
            // grpBoxDadosParcela
            // 
            grpBoxDadosParcela.BackColor = Color.Transparent;
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
            grpBoxDadosParcela.Size = new Size(828, 189);
            grpBoxDadosParcela.TabIndex = 0;
            grpBoxDadosParcela.TabStop = false;
            grpBoxDadosParcela.Text = "Dados da Parcela";
            // 
            // txtBoxNumeroParcela
            // 
            txtBoxNumeroParcela.Location = new Point(707, 129);
            txtBoxNumeroParcela.Name = "txtBoxNumeroParcela";
            txtBoxNumeroParcela.Size = new Size(113, 27);
            txtBoxNumeroParcela.TabIndex = 13;
            // 
            // lblNumeroParcela
            // 
            lblNumeroParcela.AutoSize = true;
            lblNumeroParcela.Location = new Point(591, 131);
            lblNumeroParcela.Name = "lblNumeroParcela";
            lblNumeroParcela.Size = new Size(118, 20);
            lblNumeroParcela.TabIndex = 12;
            lblNumeroParcela.Text = "Valor da Parcela:";
            // 
            // btnPesquisarParcela
            // 
            btnPesquisarParcela.BackColor = Color.Cyan;
            btnPesquisarParcela.FlatStyle = FlatStyle.Popup;
            btnPesquisarParcela.Image = Properties.Resources.lupa;
            btnPesquisarParcela.Location = new Point(381, 131);
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
            btnPesquisarCliente.Location = new Point(118, 131);
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
            txtBoxCodigoEmprestimo.Location = new Point(467, 46);
            txtBoxCodigoEmprestimo.Name = "txtBoxCodigoEmprestimo";
            txtBoxCodigoEmprestimo.Size = new Size(125, 27);
            txtBoxCodigoEmprestimo.TabIndex = 9;
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(296, 49);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(167, 20);
            lblCodigoEmprestimo.TabIndex = 8;
            lblCodigoEmprestimo.Text = "Código do Emprestimo:";
            // 
            // txtBoxValorParcela
            // 
            txtBoxValorParcela.Location = new Point(707, 46);
            txtBoxValorParcela.Name = "txtBoxValorParcela";
            txtBoxValorParcela.Size = new Size(113, 27);
            txtBoxValorParcela.TabIndex = 7;
            // 
            // lblValorParcela
            // 
            lblValorParcela.AutoSize = true;
            lblValorParcela.Location = new Point(591, 48);
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
            cmbBoxStatusParcela.Location = new Point(668, 83);
            cmbBoxStatusParcela.Name = "cmbBoxStatusParcela";
            cmbBoxStatusParcela.Size = new Size(151, 28);
            cmbBoxStatusParcela.TabIndex = 5;
            // 
            // lblStatusEmprestimo
            // 
            lblStatusEmprestimo.AutoSize = true;
            lblStatusEmprestimo.Location = new Point(542, 86);
            lblStatusEmprestimo.Name = "lblStatusEmprestimo";
            lblStatusEmprestimo.Size = new Size(124, 20);
            lblStatusEmprestimo.TabIndex = 4;
            lblStatusEmprestimo.Text = "Status da Parcela:";
            // 
            // txtBoxNomeCliente
            // 
            txtBoxNomeCliente.Location = new Point(155, 86);
            txtBoxNomeCliente.Name = "txtBoxNomeCliente";
            txtBoxNomeCliente.ReadOnly = true;
            txtBoxNomeCliente.Size = new Size(381, 27);
            txtBoxNomeCliente.TabIndex = 3;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(24, 89);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(125, 20);
            lblNomeCliente.TabIndex = 2;
            lblNomeCliente.Text = "Nome do Cliente:";
            // 
            // txtBoxCodigoCliente
            // 
            txtBoxCodigoCliente.Location = new Point(163, 45);
            txtBoxCodigoCliente.Name = "txtBoxCodigoCliente";
            txtBoxCodigoCliente.ReadOnly = true;
            txtBoxCodigoCliente.Size = new Size(125, 27);
            txtBoxCodigoCliente.TabIndex = 1;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(24, 48);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(133, 20);
            lblCodigoCliente.TabIndex = 0;
            lblCodigoCliente.Text = "Código do Cliente:";
            // 
            // dataGridConsultaParcela
            // 
            dataGridConsultaParcela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridConsultaParcela.Location = new Point(12, 201);
            dataGridConsultaParcela.Name = "dataGridConsultaParcela";
            dataGridConsultaParcela.ReadOnly = true;
            dataGridConsultaParcela.RowHeadersWidth = 51;
            dataGridConsultaParcela.Size = new Size(811, 563);
            dataGridConsultaParcela.TabIndex = 1;
            // 
            // frmConsultarParcelas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(dataGridConsultaParcela);
            Controls.Add(grpBoxDadosParcela);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmConsultarParcelas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmConsultarParcelas";
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
    }
}
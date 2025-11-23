namespace Gerenciador_de_Emprestimos
{
    partial class frmSelecionarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionarCliente));
            lblCodigoClienteSelecionar = new Label();
            groupBoxFiltrosCliente = new GroupBox();
            txtNumeroResidencia = new TextBox();
            lblNumeroResidencia = new Label();
            txtEndereco = new TextBox();
            lblEndereco = new Label();
            txtBairro = new TextBox();
            lblBairro = new Label();
            comboBoxSituacaoCadastralSelecionar = new ComboBox();
            lblSituacaoCadastralSelecionar = new Label();
            maskedCpfCnpj = new MaskedTextBox();
            btnCnpjSelecionar = new RadioButton();
            btnCpfSelecionar = new RadioButton();
            maskedCelularSelecionar = new MaskedTextBox();
            lblCelularClienteSelecionar = new Label();
            comboBoxGeneroCliente = new ComboBox();
            lblGeneroCienteSelecionar = new Label();
            txtNomeCliente = new TextBox();
            lblNomeCliente = new Label();
            txtCodigoCliente = new TextBox();
            btnLimparDados = new Button();
            btnSelecionarCliente = new Button();
            btnFecharForm = new Button();
            dataGridClientes = new DataGridView();
            txtCidade = new TextBox();
            lblCidade = new Label();
            groupBoxFiltrosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            SuspendLayout();
            // 
            // lblCodigoClienteSelecionar
            // 
            lblCodigoClienteSelecionar.AutoSize = true;
            lblCodigoClienteSelecionar.BackColor = Color.Transparent;
            lblCodigoClienteSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigoClienteSelecionar.Location = new Point(7, 20);
            lblCodigoClienteSelecionar.Name = "lblCodigoClienteSelecionar";
            lblCodigoClienteSelecionar.Size = new Size(67, 22);
            lblCodigoClienteSelecionar.TabIndex = 1;
            lblCodigoClienteSelecionar.Text = "Código";
            // 
            // groupBoxFiltrosCliente
            // 
            groupBoxFiltrosCliente.BackColor = Color.Transparent;
            groupBoxFiltrosCliente.Controls.Add(lblCidade);
            groupBoxFiltrosCliente.Controls.Add(txtCidade);
            groupBoxFiltrosCliente.Controls.Add(txtNumeroResidencia);
            groupBoxFiltrosCliente.Controls.Add(lblNumeroResidencia);
            groupBoxFiltrosCliente.Controls.Add(txtEndereco);
            groupBoxFiltrosCliente.Controls.Add(lblEndereco);
            groupBoxFiltrosCliente.Controls.Add(txtBairro);
            groupBoxFiltrosCliente.Controls.Add(lblBairro);
            groupBoxFiltrosCliente.Controls.Add(comboBoxSituacaoCadastralSelecionar);
            groupBoxFiltrosCliente.Controls.Add(lblSituacaoCadastralSelecionar);
            groupBoxFiltrosCliente.Controls.Add(maskedCpfCnpj);
            groupBoxFiltrosCliente.Controls.Add(btnCnpjSelecionar);
            groupBoxFiltrosCliente.Controls.Add(btnCpfSelecionar);
            groupBoxFiltrosCliente.Controls.Add(maskedCelularSelecionar);
            groupBoxFiltrosCliente.Controls.Add(lblCelularClienteSelecionar);
            groupBoxFiltrosCliente.Controls.Add(comboBoxGeneroCliente);
            groupBoxFiltrosCliente.Controls.Add(lblGeneroCienteSelecionar);
            groupBoxFiltrosCliente.Controls.Add(txtNomeCliente);
            groupBoxFiltrosCliente.Controls.Add(lblNomeCliente);
            groupBoxFiltrosCliente.Controls.Add(txtCodigoCliente);
            groupBoxFiltrosCliente.Controls.Add(lblCodigoClienteSelecionar);
            groupBoxFiltrosCliente.Font = new Font("Arial Rounded MT Bold", 9F);
            groupBoxFiltrosCliente.Location = new Point(14, 10);
            groupBoxFiltrosCliente.Name = "groupBoxFiltrosCliente";
            groupBoxFiltrosCliente.Size = new Size(807, 188);
            groupBoxFiltrosCliente.TabIndex = 2;
            groupBoxFiltrosCliente.TabStop = false;
            // 
            // txtNumeroResidencia
            // 
            txtNumeroResidencia.Location = new Point(640, 152);
            txtNumeroResidencia.Name = "txtNumeroResidencia";
            txtNumeroResidencia.Size = new Size(129, 25);
            txtNumeroResidencia.TabIndex = 20;
            // 
            // lblNumeroResidencia
            // 
            lblNumeroResidencia.AutoSize = true;
            lblNumeroResidencia.BackColor = Color.Transparent;
            lblNumeroResidencia.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroResidencia.Location = new Point(640, 128);
            lblNumeroResidencia.Name = "lblNumeroResidencia";
            lblNumeroResidencia.Size = new Size(125, 22);
            lblNumeroResidencia.TabIndex = 19;
            lblNumeroResidencia.Text = "N° Residencia";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(337, 153);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(256, 25);
            txtEndereco.TabIndex = 18;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.BackColor = Color.Transparent;
            lblEndereco.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndereco.Location = new Point(337, 128);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(88, 22);
            lblEndereco.TabIndex = 17;
            lblEndereco.Text = "Endereço";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(7, 153);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(267, 25);
            txtBairro.TabIndex = 16;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.BackColor = Color.Transparent;
            lblBairro.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBairro.Location = new Point(7, 128);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(62, 22);
            lblBairro.TabIndex = 15;
            lblBairro.Text = "Bairro";
            // 
            // comboBoxSituacaoCadastralSelecionar
            // 
            comboBoxSituacaoCadastralSelecionar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSituacaoCadastralSelecionar.FormattingEnabled = true;
            comboBoxSituacaoCadastralSelecionar.Items.AddRange(new object[] { "ATIVO", "INATIVO", "TODOS" });
            comboBoxSituacaoCadastralSelecionar.Location = new Point(682, 40);
            comboBoxSituacaoCadastralSelecionar.Name = "comboBoxSituacaoCadastralSelecionar";
            comboBoxSituacaoCadastralSelecionar.Size = new Size(116, 25);
            comboBoxSituacaoCadastralSelecionar.TabIndex = 14;
            // 
            // lblSituacaoCadastralSelecionar
            // 
            lblSituacaoCadastralSelecionar.AutoSize = true;
            lblSituacaoCadastralSelecionar.BackColor = Color.Transparent;
            lblSituacaoCadastralSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSituacaoCadastralSelecionar.Location = new Point(682, 19);
            lblSituacaoCadastralSelecionar.Name = "lblSituacaoCadastralSelecionar";
            lblSituacaoCadastralSelecionar.Size = new Size(83, 22);
            lblSituacaoCadastralSelecionar.TabIndex = 13;
            lblSituacaoCadastralSelecionar.Text = "Situação";
            // 
            // maskedCpfCnpj
            // 
            maskedCpfCnpj.Location = new Point(321, 40);
            maskedCpfCnpj.Mask = "000,000,000-00";
            maskedCpfCnpj.Name = "maskedCpfCnpj";
            maskedCpfCnpj.Size = new Size(221, 25);
            maskedCpfCnpj.TabIndex = 12;
            maskedCpfCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // btnCnpjSelecionar
            // 
            btnCnpjSelecionar.AutoSize = true;
            btnCnpjSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold);
            btnCnpjSelecionar.Location = new Point(418, 16);
            btnCnpjSelecionar.Name = "btnCnpjSelecionar";
            btnCnpjSelecionar.Size = new Size(77, 26);
            btnCnpjSelecionar.TabIndex = 11;
            btnCnpjSelecionar.Text = "CNPJ";
            btnCnpjSelecionar.UseVisualStyleBackColor = true;
            btnCnpjSelecionar.CheckedChanged += btnCnpjSelecionar_CheckedChanged;
            // 
            // btnCpfSelecionar
            // 
            btnCpfSelecionar.AutoSize = true;
            btnCpfSelecionar.Checked = true;
            btnCpfSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold);
            btnCpfSelecionar.Location = new Point(337, 16);
            btnCpfSelecionar.Name = "btnCpfSelecionar";
            btnCpfSelecionar.Size = new Size(64, 26);
            btnCpfSelecionar.TabIndex = 10;
            btnCpfSelecionar.TabStop = true;
            btnCpfSelecionar.Text = "CPF";
            btnCpfSelecionar.UseVisualStyleBackColor = true;
            btnCpfSelecionar.CheckedChanged += btnCpfSelecionar_CheckedChanged;
            // 
            // maskedCelularSelecionar
            // 
            maskedCelularSelecionar.Location = new Point(548, 41);
            maskedCelularSelecionar.Mask = "(00) 00000-0000";
            maskedCelularSelecionar.Name = "maskedCelularSelecionar";
            maskedCelularSelecionar.Size = new Size(124, 25);
            maskedCelularSelecionar.TabIndex = 9;
            maskedCelularSelecionar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblCelularClienteSelecionar
            // 
            lblCelularClienteSelecionar.AutoSize = true;
            lblCelularClienteSelecionar.BackColor = Color.Transparent;
            lblCelularClienteSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCelularClienteSelecionar.Location = new Point(548, 19);
            lblCelularClienteSelecionar.Name = "lblCelularClienteSelecionar";
            lblCelularClienteSelecionar.Size = new Size(69, 22);
            lblCelularClienteSelecionar.TabIndex = 8;
            lblCelularClienteSelecionar.Text = "Celular";
            // 
            // comboBoxGeneroCliente
            // 
            comboBoxGeneroCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGeneroCliente.FormattingEnabled = true;
            comboBoxGeneroCliente.Items.AddRange(new object[] { "Masculino", "Feminino", "Outros", "Todos" });
            comboBoxGeneroCliente.Location = new Point(161, 41);
            comboBoxGeneroCliente.Name = "comboBoxGeneroCliente";
            comboBoxGeneroCliente.Size = new Size(141, 25);
            comboBoxGeneroCliente.TabIndex = 7;
            // 
            // lblGeneroCienteSelecionar
            // 
            lblGeneroCienteSelecionar.AutoSize = true;
            lblGeneroCienteSelecionar.BackColor = Color.Transparent;
            lblGeneroCienteSelecionar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGeneroCienteSelecionar.Location = new Point(161, 20);
            lblGeneroCienteSelecionar.Name = "lblGeneroCienteSelecionar";
            lblGeneroCienteSelecionar.Size = new Size(70, 22);
            lblGeneroCienteSelecionar.TabIndex = 5;
            lblGeneroCienteSelecionar.Text = "Gênero";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(7, 100);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(337, 25);
            txtNomeCliente.TabIndex = 4;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.BackColor = Color.Transparent;
            lblNomeCliente.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeCliente.Location = new Point(7, 79);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(122, 22);
            lblNomeCliente.TabIndex = 3;
            lblNomeCliente.Text = "Nome Cliente";
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Location = new Point(7, 41);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.Size = new Size(137, 25);
            txtCodigoCliente.TabIndex = 2;
            // 
            // btnLimparDados
            // 
            btnLimparDados.BackColor = Color.Turquoise;
            btnLimparDados.FlatStyle = FlatStyle.Popup;
            btnLimparDados.Image = (Image)resources.GetObject("btnLimparDados.Image");
            btnLimparDados.Location = new Point(125, 204);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(204, 48);
            btnLimparDados.TabIndex = 3;
            btnLimparDados.Text = "Limpar Dados";
            btnLimparDados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDados.UseVisualStyleBackColor = false;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // btnSelecionarCliente
            // 
            btnSelecionarCliente.BackColor = Color.Aquamarine;
            btnSelecionarCliente.FlatStyle = FlatStyle.Popup;
            btnSelecionarCliente.Image = Properties.Resources.lupa;
            btnSelecionarCliente.Location = new Point(482, 204);
            btnSelecionarCliente.Name = "btnSelecionarCliente";
            btnSelecionarCliente.Size = new Size(204, 48);
            btnSelecionarCliente.TabIndex = 4;
            btnSelecionarCliente.Text = "Selecionar Cliente";
            btnSelecionarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSelecionarCliente.UseVisualStyleBackColor = false;
            btnSelecionarCliente.Click += btnSelecionarCliente_Click;
            // 
            // btnFecharForm
            // 
            btnFecharForm.BackColor = Color.LightSalmon;
            btnFecharForm.FlatStyle = FlatStyle.Popup;
            btnFecharForm.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnFecharForm.Location = new Point(307, 757);
            btnFecharForm.Name = "btnFecharForm";
            btnFecharForm.Size = new Size(204, 48);
            btnFecharForm.TabIndex = 5;
            btnFecharForm.Text = "Fechar Tela";
            btnFecharForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFecharForm.UseVisualStyleBackColor = false;
            btnFecharForm.Click += btnFecharForm_Click;
            // 
            // dataGridClientes
            // 
            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(14, 273);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.ReadOnly = true;
            dataGridClientes.RowHeadersWidth = 51;
            dataGridClientes.Size = new Size(807, 456);
            dataGridClientes.TabIndex = 6;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(381, 100);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(337, 25);
            txtCidade.TabIndex = 21;
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.BackColor = Color.Transparent;
            lblCidade.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCidade.Location = new Point(381, 75);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(67, 22);
            lblCidade.TabIndex = 22;
            lblCidade.Text = "Cidade";
            // 
            // frmSelecionarCliente
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(dataGridClientes);
            Controls.Add(btnFecharForm);
            Controls.Add(btnSelecionarCliente);
            Controls.Add(btnLimparDados);
            Controls.Add(groupBoxFiltrosCliente);
            Font = new Font("Arial Rounded MT Bold", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSelecionarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selecionar Cliente";
            groupBoxFiltrosCliente.ResumeLayout(false);
            groupBoxFiltrosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblCodigoClienteSelecionar;
        private GroupBox groupBoxFiltrosCliente;
        private TextBox txtNomeCliente;
        private Label lblNomeCliente;
        private TextBox txtCodigoCliente;
        private Label lblGeneroCienteSelecionar;
        private ComboBox comboBoxGeneroCliente;
        private MaskedTextBox maskedCelularSelecionar;
        private Label lblCelularClienteSelecionar;
        private MaskedTextBox maskedCpfCnpj;
        private RadioButton btnCnpjSelecionar;
        private RadioButton btnCpfSelecionar;
        private ComboBox comboBoxSituacaoCadastralSelecionar;
        private Label lblSituacaoCadastralSelecionar;
        private Button btnLimparDados;
        private Button btnSelecionarCliente;
        private Button btnFecharForm;
        private DataGridView dataGridClientes;
        private TextBox txtEndereco;
        private Label lblEndereco;
        private TextBox txtBairro;
        private Label lblBairro;
        private TextBox txtNumeroResidencia;
        private Label lblNumeroResidencia;
        private Label lblCidade;
        private TextBox txtCidade;
    }
}
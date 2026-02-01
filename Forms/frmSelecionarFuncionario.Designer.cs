namespace Gerenciador_de_Emprestimos
{
    partial class frmSelecionarFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionarFuncionario));
            btnFecharForm = new Button();
            btnSelecionarFuncionario = new Button();
            btnLimparDados = new Button();
            grpBoxDadosFuncionario = new GroupBox();
            lblEstadoCivil = new Label();
            comboBoxEstadoCivil = new ComboBox();
            comboBoxSituacaoCadastralSelecionar = new ComboBox();
            lblSituacaoCadastralSelecionar = new Label();
            lblCidadeFuncionario = new Label();
            txtCidadeFuncionario = new TextBox();
            comboBoxGeneroCliente = new ComboBox();
            lblGeneroCienteSelecionar = new Label();
            lblTelefoneFuncionario = new Label();
            txtTelefoneFuncionario = new MaskedTextBox();
            txtCpfFuncionario = new MaskedTextBox();
            lblCpfFuncionario = new Label();
            lblNomeFuncionario = new Label();
            txtNomeFuncionario = new TextBox();
            lblCodigoFuncionario = new Label();
            txtCodigoFuncionario = new TextBox();
            dataGridFuncionarios = new DataGridView();
            grpBoxDadosFuncionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFuncionarios).BeginInit();
            SuspendLayout();
            // 
            // btnFecharForm
            // 
            btnFecharForm.BackColor = Color.LightSalmon;
            btnFecharForm.FlatStyle = FlatStyle.Popup;
            btnFecharForm.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnFecharForm.Location = new Point(315, 705);
            btnFecharForm.Name = "btnFecharForm";
            btnFecharForm.Size = new Size(230, 41);
            btnFecharForm.TabIndex = 6;
            btnFecharForm.Text = "Fechar Tela";
            btnFecharForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFecharForm.UseVisualStyleBackColor = false;
            btnFecharForm.Click += btnFecharForm_Click;
            // 
            // btnSelecionarFuncionario
            // 
            btnSelecionarFuncionario.BackColor = Color.Aquamarine;
            btnSelecionarFuncionario.FlatStyle = FlatStyle.Popup;
            btnSelecionarFuncionario.Image = Properties.Resources.lupa;
            btnSelecionarFuncionario.Location = new Point(458, 184);
            btnSelecionarFuncionario.Name = "btnSelecionarFuncionario";
            btnSelecionarFuncionario.Size = new Size(230, 41);
            btnSelecionarFuncionario.TabIndex = 7;
            btnSelecionarFuncionario.Text = "Selecionar Funcionário";
            btnSelecionarFuncionario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSelecionarFuncionario.UseVisualStyleBackColor = false;
            btnSelecionarFuncionario.Click += btnSelecionarFuncionario_Click;
            // 
            // btnLimparDados
            // 
            btnLimparDados.BackColor = Color.Turquoise;
            btnLimparDados.FlatStyle = FlatStyle.Popup;
            btnLimparDados.Image = (Image)resources.GetObject("btnLimparDados.Image");
            btnLimparDados.Location = new Point(153, 184);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(230, 41);
            btnLimparDados.TabIndex = 8;
            btnLimparDados.Text = "Limpar Dados";
            btnLimparDados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDados.UseVisualStyleBackColor = false;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // grpBoxDadosFuncionario
            // 
            grpBoxDadosFuncionario.BackColor = Color.Transparent;
            grpBoxDadosFuncionario.Controls.Add(lblEstadoCivil);
            grpBoxDadosFuncionario.Controls.Add(comboBoxEstadoCivil);
            grpBoxDadosFuncionario.Controls.Add(comboBoxSituacaoCadastralSelecionar);
            grpBoxDadosFuncionario.Controls.Add(lblSituacaoCadastralSelecionar);
            grpBoxDadosFuncionario.Controls.Add(lblCidadeFuncionario);
            grpBoxDadosFuncionario.Controls.Add(txtCidadeFuncionario);
            grpBoxDadosFuncionario.Controls.Add(comboBoxGeneroCliente);
            grpBoxDadosFuncionario.Controls.Add(lblGeneroCienteSelecionar);
            grpBoxDadosFuncionario.Controls.Add(lblTelefoneFuncionario);
            grpBoxDadosFuncionario.Controls.Add(txtTelefoneFuncionario);
            grpBoxDadosFuncionario.Controls.Add(txtCpfFuncionario);
            grpBoxDadosFuncionario.Controls.Add(lblCpfFuncionario);
            grpBoxDadosFuncionario.Controls.Add(lblNomeFuncionario);
            grpBoxDadosFuncionario.Controls.Add(txtNomeFuncionario);
            grpBoxDadosFuncionario.Controls.Add(lblCodigoFuncionario);
            grpBoxDadosFuncionario.Controls.Add(txtCodigoFuncionario);
            grpBoxDadosFuncionario.Font = new Font("Arial Rounded MT Bold", 9F);
            grpBoxDadosFuncionario.Location = new Point(16, 10);
            grpBoxDadosFuncionario.Name = "grpBoxDadosFuncionario";
            grpBoxDadosFuncionario.Size = new Size(805, 168);
            grpBoxDadosFuncionario.TabIndex = 9;
            grpBoxDadosFuncionario.TabStop = false;
            grpBoxDadosFuncionario.Text = "Dados do Funcionário";
            // 
            // lblEstadoCivil
            // 
            lblEstadoCivil.AutoSize = true;
            lblEstadoCivil.Location = new Point(612, 27);
            lblEstadoCivil.Name = "lblEstadoCivil";
            lblEstadoCivil.Size = new Size(93, 17);
            lblEstadoCivil.TabIndex = 18;
            lblEstadoCivil.Text = "Estado Civil";
            // 
            // comboBoxEstadoCivil
            // 
            comboBoxEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstadoCivil.FormattingEnabled = true;
            comboBoxEstadoCivil.Items.AddRange(new object[] { "Solteiro(a)", "Casado(a)", "Divorciado(a)", "Viúvo(a)" });
            comboBoxEstadoCivil.Location = new Point(602, 47);
            comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            comboBoxEstadoCivil.Size = new Size(170, 25);
            comboBoxEstadoCivil.TabIndex = 17;
            // 
            // comboBoxSituacaoCadastralSelecionar
            // 
            comboBoxSituacaoCadastralSelecionar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSituacaoCadastralSelecionar.FormattingEnabled = true;
            comboBoxSituacaoCadastralSelecionar.Items.AddRange(new object[] { "ATIVO", "INATIVO", "TODOS" });
            comboBoxSituacaoCadastralSelecionar.Location = new Point(519, 112);
            comboBoxSituacaoCadastralSelecionar.Name = "comboBoxSituacaoCadastralSelecionar";
            comboBoxSituacaoCadastralSelecionar.Size = new Size(116, 25);
            comboBoxSituacaoCadastralSelecionar.TabIndex = 16;
            // 
            // lblSituacaoCadastralSelecionar
            // 
            lblSituacaoCadastralSelecionar.AutoSize = true;
            lblSituacaoCadastralSelecionar.BackColor = Color.Transparent;
            lblSituacaoCadastralSelecionar.Font = new Font("Arial Rounded MT Bold", 9F);
            lblSituacaoCadastralSelecionar.Location = new Point(519, 91);
            lblSituacaoCadastralSelecionar.Name = "lblSituacaoCadastralSelecionar";
            lblSituacaoCadastralSelecionar.Size = new Size(72, 17);
            lblSituacaoCadastralSelecionar.TabIndex = 15;
            lblSituacaoCadastralSelecionar.Text = "Situação";
            // 
            // lblCidadeFuncionario
            // 
            lblCidadeFuncionario.AutoSize = true;
            lblCidadeFuncionario.Location = new Point(308, 91);
            lblCidadeFuncionario.Name = "lblCidadeFuncionario";
            lblCidadeFuncionario.Size = new Size(59, 17);
            lblCidadeFuncionario.TabIndex = 11;
            lblCidadeFuncionario.Text = "Cidade";
            // 
            // txtCidadeFuncionario
            // 
            txtCidadeFuncionario.Location = new Point(308, 111);
            txtCidadeFuncionario.Name = "txtCidadeFuncionario";
            txtCidadeFuncionario.Size = new Size(205, 25);
            txtCidadeFuncionario.TabIndex = 10;
            // 
            // comboBoxGeneroCliente
            // 
            comboBoxGeneroCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGeneroCliente.FormattingEnabled = true;
            comboBoxGeneroCliente.Items.AddRange(new object[] { "Masculino", "Feminino", "Outros", "Todos" });
            comboBoxGeneroCliente.Location = new Point(7, 109);
            comboBoxGeneroCliente.Name = "comboBoxGeneroCliente";
            comboBoxGeneroCliente.Size = new Size(119, 25);
            comboBoxGeneroCliente.TabIndex = 9;
            // 
            // lblGeneroCienteSelecionar
            // 
            lblGeneroCienteSelecionar.AutoSize = true;
            lblGeneroCienteSelecionar.BackColor = Color.Transparent;
            lblGeneroCienteSelecionar.Font = new Font("Arial Rounded MT Bold", 9F);
            lblGeneroCienteSelecionar.Location = new Point(7, 88);
            lblGeneroCienteSelecionar.Name = "lblGeneroCienteSelecionar";
            lblGeneroCienteSelecionar.Size = new Size(63, 17);
            lblGeneroCienteSelecionar.TabIndex = 8;
            lblGeneroCienteSelecionar.Text = "Gênero";
            // 
            // lblTelefoneFuncionario
            // 
            lblTelefoneFuncionario.AutoSize = true;
            lblTelefoneFuncionario.Location = new Point(133, 91);
            lblTelefoneFuncionario.Name = "lblTelefoneFuncionario";
            lblTelefoneFuncionario.Size = new Size(71, 17);
            lblTelefoneFuncionario.TabIndex = 7;
            lblTelefoneFuncionario.Text = "Telefone";
            // 
            // txtTelefoneFuncionario
            // 
            txtTelefoneFuncionario.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtTelefoneFuncionario.Location = new Point(133, 111);
            txtTelefoneFuncionario.Mask = "(00) 00000-0000";
            txtTelefoneFuncionario.Name = "txtTelefoneFuncionario";
            txtTelefoneFuncionario.Size = new Size(172, 25);
            txtTelefoneFuncionario.TabIndex = 6;
            // 
            // txtCpfFuncionario
            // 
            txtCpfFuncionario.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCpfFuncionario.Location = new Point(459, 47);
            txtCpfFuncionario.Mask = "000,000,000-00";
            txtCpfFuncionario.Name = "txtCpfFuncionario";
            txtCpfFuncionario.Size = new Size(126, 25);
            txtCpfFuncionario.TabIndex = 5;
            // 
            // lblCpfFuncionario
            // 
            lblCpfFuncionario.AutoSize = true;
            lblCpfFuncionario.Location = new Point(475, 27);
            lblCpfFuncionario.Name = "lblCpfFuncionario";
            lblCpfFuncionario.Size = new Size(38, 17);
            lblCpfFuncionario.TabIndex = 4;
            lblCpfFuncionario.Text = "CPF";
            // 
            // lblNomeFuncionario
            // 
            lblNomeFuncionario.AutoSize = true;
            lblNomeFuncionario.Location = new Point(154, 27);
            lblNomeFuncionario.Name = "lblNomeFuncionario";
            lblNomeFuncionario.Size = new Size(50, 17);
            lblNomeFuncionario.TabIndex = 3;
            lblNomeFuncionario.Text = "Nome";
            // 
            // txtNomeFuncionario
            // 
            txtNomeFuncionario.Location = new Point(154, 47);
            txtNomeFuncionario.Name = "txtNomeFuncionario";
            txtNomeFuncionario.Size = new Size(297, 25);
            txtNomeFuncionario.TabIndex = 2;
            // 
            // lblCodigoFuncionario
            // 
            lblCodigoFuncionario.AutoSize = true;
            lblCodigoFuncionario.Location = new Point(7, 27);
            lblCodigoFuncionario.Name = "lblCodigoFuncionario";
            lblCodigoFuncionario.Size = new Size(59, 17);
            lblCodigoFuncionario.TabIndex = 1;
            lblCodigoFuncionario.Text = "Código";
            // 
            // txtCodigoFuncionario
            // 
            txtCodigoFuncionario.Location = new Point(7, 47);
            txtCodigoFuncionario.Name = "txtCodigoFuncionario";
            txtCodigoFuncionario.Size = new Size(140, 25);
            txtCodigoFuncionario.TabIndex = 0;
            // 
            // dataGridFuncionarios
            // 
            dataGridFuncionarios.AllowUserToAddRows = false;
            dataGridFuncionarios.AllowUserToDeleteRows = false;
            dataGridFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFuncionarios.Location = new Point(10, 231);
            dataGridFuncionarios.Name = "dataGridFuncionarios";
            dataGridFuncionarios.ReadOnly = true;
            dataGridFuncionarios.RowHeadersWidth = 51;
            dataGridFuncionarios.Size = new Size(811, 462);
            dataGridFuncionarios.TabIndex = 10;
            dataGridFuncionarios.CellDoubleClick += dataGridFuncionarios_CellDoubleClick;
            // 
            // frmSelecionarFuncionario
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 757);
            Controls.Add(dataGridFuncionarios);
            Controls.Add(grpBoxDadosFuncionario);
            Controls.Add(btnLimparDados);
            Controls.Add(btnSelecionarFuncionario);
            Controls.Add(btnFecharForm);
            Font = new Font("Arial Rounded MT Bold", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmSelecionarFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selecionar Funcionário";
            grpBoxDadosFuncionario.ResumeLayout(false);
            grpBoxDadosFuncionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridFuncionarios).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnFecharForm;
        private Button btnSelecionarFuncionario;
        private Button btnLimparDados;
        private GroupBox grpBoxDadosFuncionario;
        private Label lblCodigoFuncionario;
        private TextBox txtCodigoFuncionario;
        private Label lblNomeFuncionario;
        private TextBox txtNomeFuncionario;
        private Label lblCpfFuncionario;
        private MaskedTextBox txtCpfFuncionario;
        private MaskedTextBox txtTelefoneFuncionario;
        private Label lblTelefoneFuncionario;
        private ComboBox comboBoxGeneroCliente;
        private Label lblGeneroCienteSelecionar;
        private Label lblCidadeFuncionario;
        private TextBox txtCidadeFuncionario;
        private ComboBox comboBoxSituacaoCadastralSelecionar;
        private Label lblSituacaoCadastralSelecionar;
        private Label lblEstadoCivil;
        private ComboBox comboBoxEstadoCivil;
        private DataGridView dataGridFuncionarios;
    }
}
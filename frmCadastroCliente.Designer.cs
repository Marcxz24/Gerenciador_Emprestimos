namespace Gerenciador_de_Emprestimos
{
    partial class FormCadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroCliente));
            lblNomeCliente = new Label();
            lblEndereco = new Label();
            lblEstadoCivil = new Label();
            lblBairroCliente = new Label();
            lblCidadeCliente = new Label();
            lblNumeroResidencia = new Label();
            txtNomeCliente = new TextBox();
            txtEnderecoCliente = new TextBox();
            txtBairroCliente = new TextBox();
            txtCidadeCliente = new TextBox();
            txtNumeroResidencia = new TextBox();
            lblCepCliente = new Label();
            lblEmailCliente = new Label();
            lblCelularCliente = new Label();
            txtEmailCliente = new TextBox();
            lblObservacoes = new Label();
            txtObservacoes = new TextBox();
            btnRadioGeneroOutros = new RadioButton();
            MaskedTxtCpfCnpjCliente = new MaskedTextBox();
            MaskedTxtCepCliente = new MaskedTextBox();
            MaskedTxtCelularCliente = new MaskedTextBox();
            lblEstadoCliente = new Label();
            btnRadioCpf = new RadioButton();
            btnRadioCnpj = new RadioButton();
            btnRadioFeminino = new RadioButton();
            btnRadioMasculino = new RadioButton();
            groupBoxGenero = new GroupBox();
            groupBoxEndereco = new GroupBox();
            comboBoxEstadoUF = new ComboBox();
            groupBoxContatos = new GroupBox();
            groupBoxEstadoCivil = new GroupBox();
            comboBoxEstadoCivil = new ComboBox();
            imagemCliente = new PictureBox();
            btnImagemCliente = new Button();
            btnRemoverImagem = new Button();
            btnFecharForm = new Button();
            btnSalvarCadastroCliente = new Button();
            btnEditarCadastro = new Button();
            groupBoxNomeCpfCnpj = new GroupBox();
            btnPesquisarCliente = new Button();
            btnNovoCadastro = new Button();
            lblCodigoCliente = new Label();
            btnCancelarCadastro = new Button();
            comboBoxSituacaoCadastral = new ComboBox();
            lblSituacaoCadastral = new Label();
            lblMostrarCodigoCliente = new Label();
            txtCodigoCliente = new TextBox();
            groupBoxGenero.SuspendLayout();
            groupBoxEndereco.SuspendLayout();
            groupBoxContatos.SuspendLayout();
            groupBoxEstadoCivil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagemCliente).BeginInit();
            groupBoxNomeCpfCnpj.SuspendLayout();
            SuspendLayout();
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.BackColor = Color.Transparent;
            lblNomeCliente.Location = new Point(6, 22);
            lblNomeCliente.Margin = new Padding(4, 0, 4, 0);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(139, 17);
            lblNomeCliente.TabIndex = 0;
            lblNomeCliente.Text = "*Nome do Cliente:";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.BackColor = Color.Transparent;
            lblEndereco.Location = new Point(20, 15);
            lblEndereco.Margin = new Padding(4, 0, 4, 0);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(91, 17);
            lblEndereco.TabIndex = 3;
            lblEndereco.Text = "*Endereço:";
            // 
            // lblEstadoCivil
            // 
            lblEstadoCivil.AutoSize = true;
            lblEstadoCivil.BackColor = Color.Transparent;
            lblEstadoCivil.Location = new Point(0, 0);
            lblEstadoCivil.Margin = new Padding(4, 0, 4, 0);
            lblEstadoCivil.Name = "lblEstadoCivil";
            lblEstadoCivil.Size = new Size(98, 17);
            lblEstadoCivil.TabIndex = 5;
            lblEstadoCivil.Text = "Estado Civil:";
            // 
            // lblBairroCliente
            // 
            lblBairroCliente.AutoSize = true;
            lblBairroCliente.BackColor = Color.Transparent;
            lblBairroCliente.Location = new Point(383, 15);
            lblBairroCliente.Margin = new Padding(4, 0, 4, 0);
            lblBairroCliente.Name = "lblBairroCliente";
            lblBairroCliente.Size = new Size(67, 17);
            lblBairroCliente.TabIndex = 6;
            lblBairroCliente.Text = "*Bairro:";
            // 
            // lblCidadeCliente
            // 
            lblCidadeCliente.AutoSize = true;
            lblCidadeCliente.BackColor = Color.Transparent;
            lblCidadeCliente.Location = new Point(24, 92);
            lblCidadeCliente.Margin = new Padding(4, 0, 4, 0);
            lblCidadeCliente.Name = "lblCidadeCliente";
            lblCidadeCliente.RightToLeft = RightToLeft.No;
            lblCidadeCliente.Size = new Size(71, 17);
            lblCidadeCliente.TabIndex = 7;
            lblCidadeCliente.Text = "*Cidade:";
            // 
            // lblNumeroResidencia
            // 
            lblNumeroResidencia.AutoSize = true;
            lblNumeroResidencia.BackColor = Color.Transparent;
            lblNumeroResidencia.Location = new Point(379, 92);
            lblNumeroResidencia.Margin = new Padding(4, 0, 4, 0);
            lblNumeroResidencia.Name = "lblNumeroResidencia";
            lblNumeroResidencia.Size = new Size(122, 17);
            lblNumeroResidencia.TabIndex = 8;
            lblNumeroResidencia.Text = "*N° Residencia:";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Font = new Font("Microsoft Sans Serif", 8.25F);
            txtNomeCliente.Location = new Point(6, 52);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.ReadOnly = true;
            txtNomeCliente.Size = new Size(284, 23);
            txtNomeCliente.TabIndex = 1;
            // 
            // txtEnderecoCliente
            // 
            txtEnderecoCliente.Location = new Point(20, 40);
            txtEnderecoCliente.Name = "txtEnderecoCliente";
            txtEnderecoCliente.ReadOnly = true;
            txtEnderecoCliente.Size = new Size(329, 25);
            txtEnderecoCliente.TabIndex = 7;
            // 
            // txtBairroCliente
            // 
            txtBairroCliente.Location = new Point(379, 40);
            txtBairroCliente.Name = "txtBairroCliente";
            txtBairroCliente.ReadOnly = true;
            txtBairroCliente.Size = new Size(413, 25);
            txtBairroCliente.TabIndex = 8;
            // 
            // txtCidadeCliente
            // 
            txtCidadeCliente.Location = new Point(20, 125);
            txtCidadeCliente.Name = "txtCidadeCliente";
            txtCidadeCliente.ReadOnly = true;
            txtCidadeCliente.Size = new Size(225, 25);
            txtCidadeCliente.TabIndex = 9;
            // 
            // txtNumeroResidencia
            // 
            txtNumeroResidencia.Location = new Point(379, 125);
            txtNumeroResidencia.Name = "txtNumeroResidencia";
            txtNumeroResidencia.ReadOnly = true;
            txtNumeroResidencia.Size = new Size(188, 25);
            txtNumeroResidencia.TabIndex = 11;
            // 
            // lblCepCliente
            // 
            lblCepCliente.AutoSize = true;
            lblCepCliente.BackColor = Color.Transparent;
            lblCepCliente.Location = new Point(586, 92);
            lblCepCliente.Margin = new Padding(4, 0, 4, 0);
            lblCepCliente.Name = "lblCepCliente";
            lblCepCliente.Size = new Size(51, 17);
            lblCepCliente.TabIndex = 18;
            lblCepCliente.Text = "*CEP:";
            // 
            // lblEmailCliente
            // 
            lblEmailCliente.AutoSize = true;
            lblEmailCliente.BackColor = Color.Transparent;
            lblEmailCliente.Location = new Point(291, 30);
            lblEmailCliente.Margin = new Padding(4, 0, 4, 0);
            lblEmailCliente.Name = "lblEmailCliente";
            lblEmailCliente.Size = new Size(58, 17);
            lblEmailCliente.TabIndex = 21;
            lblEmailCliente.Text = "E-mail:";
            // 
            // lblCelularCliente
            // 
            lblCelularCliente.AutoSize = true;
            lblCelularCliente.BackColor = Color.Transparent;
            lblCelularCliente.Location = new Point(24, 30);
            lblCelularCliente.Margin = new Padding(4, 0, 4, 0);
            lblCelularCliente.Name = "lblCelularCliente";
            lblCelularCliente.Size = new Size(66, 17);
            lblCelularCliente.TabIndex = 20;
            lblCelularCliente.Text = "Celular:";
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(291, 50);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.ReadOnly = true;
            txtEmailCliente.Size = new Size(501, 25);
            txtEmailCliente.TabIndex = 14;
            // 
            // lblObservacoes
            // 
            lblObservacoes.AutoSize = true;
            lblObservacoes.BackColor = Color.Transparent;
            lblObservacoes.Location = new Point(36, 533);
            lblObservacoes.Margin = new Padding(4, 0, 4, 0);
            lblObservacoes.Name = "lblObservacoes";
            lblObservacoes.Size = new Size(110, 17);
            lblObservacoes.TabIndex = 24;
            lblObservacoes.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(32, 575);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.ReadOnly = true;
            txtObservacoes.Size = new Size(772, 112);
            txtObservacoes.TabIndex = 4;
            // 
            // btnRadioGeneroOutros
            // 
            btnRadioGeneroOutros.AutoSize = true;
            btnRadioGeneroOutros.BackColor = Color.Transparent;
            btnRadioGeneroOutros.Enabled = false;
            btnRadioGeneroOutros.Location = new Point(229, 24);
            btnRadioGeneroOutros.Name = "btnRadioGeneroOutros";
            btnRadioGeneroOutros.Size = new Size(76, 21);
            btnRadioGeneroOutros.TabIndex = 5;
            btnRadioGeneroOutros.Text = "outros";
            btnRadioGeneroOutros.UseVisualStyleBackColor = false;
            // 
            // MaskedTxtCpfCnpjCliente
            // 
            MaskedTxtCpfCnpjCliente.BeepOnError = true;
            MaskedTxtCpfCnpjCliente.Location = new Point(314, 52);
            MaskedTxtCpfCnpjCliente.Mask = "000,000,000-00";
            MaskedTxtCpfCnpjCliente.Name = "MaskedTxtCpfCnpjCliente";
            MaskedTxtCpfCnpjCliente.ReadOnly = true;
            MaskedTxtCpfCnpjCliente.Size = new Size(249, 25);
            MaskedTxtCpfCnpjCliente.TabIndex = 3;
            MaskedTxtCpfCnpjCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // MaskedTxtCepCliente
            // 
            MaskedTxtCepCliente.Location = new Point(586, 125);
            MaskedTxtCepCliente.Mask = "00,000-000";
            MaskedTxtCepCliente.Name = "MaskedTxtCepCliente";
            MaskedTxtCepCliente.ReadOnly = true;
            MaskedTxtCepCliente.Size = new Size(206, 25);
            MaskedTxtCepCliente.TabIndex = 12;
            MaskedTxtCepCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // MaskedTxtCelularCliente
            // 
            MaskedTxtCelularCliente.Location = new Point(20, 50);
            MaskedTxtCelularCliente.Mask = "(00) 00000-0000";
            MaskedTxtCelularCliente.Name = "MaskedTxtCelularCliente";
            MaskedTxtCelularCliente.ReadOnly = true;
            MaskedTxtCelularCliente.Size = new Size(225, 25);
            MaskedTxtCelularCliente.TabIndex = 13;
            MaskedTxtCelularCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblEstadoCliente
            // 
            lblEstadoCliente.AutoSize = true;
            lblEstadoCliente.BackColor = Color.Transparent;
            lblEstadoCliente.ForeColor = SystemColors.ControlText;
            lblEstadoCliente.Location = new Point(263, 92);
            lblEstadoCliente.Name = "lblEstadoCliente";
            lblEstadoCliente.Size = new Size(40, 17);
            lblEstadoCliente.TabIndex = 34;
            lblEstadoCliente.Text = "*UF:";
            // 
            // btnRadioCpf
            // 
            btnRadioCpf.AutoSize = true;
            btnRadioCpf.BackColor = Color.Transparent;
            btnRadioCpf.Enabled = false;
            btnRadioCpf.Location = new Point(328, 18);
            btnRadioCpf.Name = "btnRadioCpf";
            btnRadioCpf.Size = new Size(66, 21);
            btnRadioCpf.TabIndex = 35;
            btnRadioCpf.Text = "*CPF";
            btnRadioCpf.UseVisualStyleBackColor = false;
            btnRadioCpf.CheckedChanged += btnRadioCpf_CheckedChanged;
            // 
            // btnRadioCnpj
            // 
            btnRadioCnpj.AutoSize = true;
            btnRadioCnpj.BackColor = Color.Transparent;
            btnRadioCnpj.Enabled = false;
            btnRadioCnpj.Location = new Point(396, 18);
            btnRadioCnpj.Name = "btnRadioCnpj";
            btnRadioCnpj.Size = new Size(77, 21);
            btnRadioCnpj.TabIndex = 36;
            btnRadioCnpj.Text = "*CNPJ";
            btnRadioCnpj.UseVisualStyleBackColor = false;
            btnRadioCnpj.CheckedChanged += btnRadioCnpj_CheckedChanged;
            // 
            // btnRadioFeminino
            // 
            btnRadioFeminino.AutoSize = true;
            btnRadioFeminino.BackColor = Color.Transparent;
            btnRadioFeminino.Enabled = false;
            btnRadioFeminino.Location = new Point(20, 24);
            btnRadioFeminino.Name = "btnRadioFeminino";
            btnRadioFeminino.Size = new Size(95, 21);
            btnRadioFeminino.TabIndex = 3;
            btnRadioFeminino.Text = "Feminino";
            btnRadioFeminino.UseVisualStyleBackColor = false;
            // 
            // btnRadioMasculino
            // 
            btnRadioMasculino.AutoSize = true;
            btnRadioMasculino.BackColor = Color.Transparent;
            btnRadioMasculino.Enabled = false;
            btnRadioMasculino.Location = new Point(119, 24);
            btnRadioMasculino.Name = "btnRadioMasculino";
            btnRadioMasculino.Size = new Size(102, 21);
            btnRadioMasculino.TabIndex = 4;
            btnRadioMasculino.Text = "Masculino";
            btnRadioMasculino.UseVisualStyleBackColor = false;
            // 
            // groupBoxGenero
            // 
            groupBoxGenero.BackColor = Color.Transparent;
            groupBoxGenero.Controls.Add(btnRadioMasculino);
            groupBoxGenero.Controls.Add(btnRadioFeminino);
            groupBoxGenero.Controls.Add(btnRadioGeneroOutros);
            groupBoxGenero.Location = new Point(247, 165);
            groupBoxGenero.Name = "groupBoxGenero";
            groupBoxGenero.Size = new Size(313, 59);
            groupBoxGenero.TabIndex = 1;
            groupBoxGenero.TabStop = false;
            groupBoxGenero.Text = "*Genêro:";
            // 
            // groupBoxEndereco
            // 
            groupBoxEndereco.BackColor = Color.Transparent;
            groupBoxEndereco.Controls.Add(comboBoxEstadoUF);
            groupBoxEndereco.Controls.Add(txtEnderecoCliente);
            groupBoxEndereco.Controls.Add(lblEndereco);
            groupBoxEndereco.Controls.Add(lblBairroCliente);
            groupBoxEndereco.Controls.Add(lblCidadeCliente);
            groupBoxEndereco.Controls.Add(lblEstadoCliente);
            groupBoxEndereco.Controls.Add(lblNumeroResidencia);
            groupBoxEndereco.Controls.Add(txtBairroCliente);
            groupBoxEndereco.Controls.Add(MaskedTxtCepCliente);
            groupBoxEndereco.Controls.Add(txtCidadeCliente);
            groupBoxEndereco.Controls.Add(txtNumeroResidencia);
            groupBoxEndereco.Controls.Add(lblCepCliente);
            groupBoxEndereco.Location = new Point(12, 237);
            groupBoxEndereco.Name = "groupBoxEndereco";
            groupBoxEndereco.Size = new Size(809, 162);
            groupBoxEndereco.TabIndex = 3;
            groupBoxEndereco.TabStop = false;
            // 
            // comboBoxEstadoUF
            // 
            comboBoxEstadoUF.DropDownHeight = 200;
            comboBoxEstadoUF.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstadoUF.Enabled = false;
            comboBoxEstadoUF.FormattingEnabled = true;
            comboBoxEstadoUF.IntegralHeight = false;
            comboBoxEstadoUF.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            comboBoxEstadoUF.Location = new Point(263, 125);
            comboBoxEstadoUF.Name = "comboBoxEstadoUF";
            comboBoxEstadoUF.Size = new Size(104, 25);
            comboBoxEstadoUF.TabIndex = 10;
            // 
            // groupBoxContatos
            // 
            groupBoxContatos.BackColor = Color.Transparent;
            groupBoxContatos.Controls.Add(MaskedTxtCelularCliente);
            groupBoxContatos.Controls.Add(lblCelularCliente);
            groupBoxContatos.Controls.Add(lblEmailCliente);
            groupBoxContatos.Controls.Add(txtEmailCliente);
            groupBoxContatos.Location = new Point(12, 405);
            groupBoxContatos.Name = "groupBoxContatos";
            groupBoxContatos.Size = new Size(809, 125);
            groupBoxContatos.TabIndex = 4;
            groupBoxContatos.TabStop = false;
            // 
            // groupBoxEstadoCivil
            // 
            groupBoxEstadoCivil.BackColor = Color.Transparent;
            groupBoxEstadoCivil.Controls.Add(comboBoxEstadoCivil);
            groupBoxEstadoCivil.Controls.Add(lblEstadoCivil);
            groupBoxEstadoCivil.Location = new Point(569, 165);
            groupBoxEstadoCivil.Name = "groupBoxEstadoCivil";
            groupBoxEstadoCivil.Size = new Size(252, 59);
            groupBoxEstadoCivil.TabIndex = 2;
            groupBoxEstadoCivil.TabStop = false;
            // 
            // comboBoxEstadoCivil
            // 
            comboBoxEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstadoCivil.Enabled = false;
            comboBoxEstadoCivil.FormattingEnabled = true;
            comboBoxEstadoCivil.Items.AddRange(new object[] { "Solteiro(a)", "Casado(a)", "Divorciado(a)", "Viúvo(a)" });
            comboBoxEstadoCivil.Location = new Point(21, 24);
            comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            comboBoxEstadoCivil.Size = new Size(214, 25);
            comboBoxEstadoCivil.TabIndex = 6;
            // 
            // imagemCliente
            // 
            imagemCliente.BackColor = Color.Transparent;
            imagemCliente.BackgroundImageLayout = ImageLayout.Stretch;
            imagemCliente.BorderStyle = BorderStyle.Fixed3D;
            imagemCliente.Image = Properties.Resources.avatar_1577909_1280;
            imagemCliente.Location = new Point(21, 12);
            imagemCliente.Name = "imagemCliente";
            imagemCliente.Size = new Size(196, 183);
            imagemCliente.SizeMode = PictureBoxSizeMode.StretchImage;
            imagemCliente.TabIndex = 43;
            imagemCliente.TabStop = false;
            // 
            // btnImagemCliente
            // 
            btnImagemCliente.BackColor = SystemColors.ButtonHighlight;
            btnImagemCliente.BackgroundImageLayout = ImageLayout.None;
            btnImagemCliente.Cursor = Cursors.Hand;
            btnImagemCliente.FlatStyle = FlatStyle.Popup;
            btnImagemCliente.Image = (Image)resources.GetObject("btnImagemCliente.Image");
            btnImagemCliente.Location = new Point(21, 201);
            btnImagemCliente.Name = "btnImagemCliente";
            btnImagemCliente.RightToLeft = RightToLeft.No;
            btnImagemCliente.Size = new Size(106, 34);
            btnImagemCliente.TabIndex = 44;
            btnImagemCliente.TabStop = false;
            btnImagemCliente.Text = "Imagem";
            btnImagemCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImagemCliente.UseVisualStyleBackColor = false;
            // 
            // btnRemoverImagem
            // 
            btnRemoverImagem.BackColor = SystemColors.ButtonHighlight;
            btnRemoverImagem.BackgroundImageLayout = ImageLayout.None;
            btnRemoverImagem.Cursor = Cursors.Hand;
            btnRemoverImagem.FlatStyle = FlatStyle.Popup;
            btnRemoverImagem.Image = (Image)resources.GetObject("btnRemoverImagem.Image");
            btnRemoverImagem.Location = new Point(133, 201);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.RightToLeft = RightToLeft.No;
            btnRemoverImagem.Size = new Size(84, 34);
            btnRemoverImagem.TabIndex = 45;
            btnRemoverImagem.TabStop = false;
            btnRemoverImagem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemoverImagem.UseVisualStyleBackColor = false;
            // 
            // btnFecharForm
            // 
            btnFecharForm.BackColor = Color.LightSalmon;
            btnFecharForm.BackgroundImageLayout = ImageLayout.None;
            btnFecharForm.Cursor = Cursors.Hand;
            btnFecharForm.FlatStyle = FlatStyle.Popup;
            btnFecharForm.Image = (Image)resources.GetObject("btnFecharForm.Image");
            btnFecharForm.Location = new Point(12, 770);
            btnFecharForm.Name = "btnFecharForm";
            btnFecharForm.RightToLeft = RightToLeft.No;
            btnFecharForm.Size = new Size(111, 42);
            btnFecharForm.TabIndex = 6;
            btnFecharForm.Text = "Fechar";
            btnFecharForm.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFecharForm.UseVisualStyleBackColor = false;
            btnFecharForm.Click += btnFecharForm_Click;
            // 
            // btnSalvarCadastroCliente
            // 
            btnSalvarCadastroCliente.BackColor = Color.PaleGreen;
            btnSalvarCadastroCliente.BackgroundImageLayout = ImageLayout.None;
            btnSalvarCadastroCliente.Cursor = Cursors.Hand;
            btnSalvarCadastroCliente.FlatStyle = FlatStyle.Popup;
            btnSalvarCadastroCliente.Image = (Image)resources.GetObject("btnSalvarCadastroCliente.Image");
            btnSalvarCadastroCliente.Location = new Point(275, 770);
            btnSalvarCadastroCliente.Name = "btnSalvarCadastroCliente";
            btnSalvarCadastroCliente.RightToLeft = RightToLeft.No;
            btnSalvarCadastroCliente.Size = new Size(161, 42);
            btnSalvarCadastroCliente.TabIndex = 5;
            btnSalvarCadastroCliente.Text = "Salvar";
            btnSalvarCadastroCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvarCadastroCliente.UseVisualStyleBackColor = false;
            btnSalvarCadastroCliente.Click += btnSalvarCadastroCliente_Click;
            // 
            // btnEditarCadastro
            // 
            btnEditarCadastro.BackColor = Color.Gold;
            btnEditarCadastro.BackgroundImageLayout = ImageLayout.None;
            btnEditarCadastro.Cursor = Cursors.Hand;
            btnEditarCadastro.FlatStyle = FlatStyle.Popup;
            btnEditarCadastro.Image = (Image)resources.GetObject("btnEditarCadastro.Image");
            btnEditarCadastro.Location = new Point(442, 770);
            btnEditarCadastro.Name = "btnEditarCadastro";
            btnEditarCadastro.RightToLeft = RightToLeft.No;
            btnEditarCadastro.Size = new Size(161, 42);
            btnEditarCadastro.TabIndex = 7;
            btnEditarCadastro.TabStop = false;
            btnEditarCadastro.Text = "Editar";
            btnEditarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditarCadastro.UseVisualStyleBackColor = false;
            // 
            // groupBoxNomeCpfCnpj
            // 
            groupBoxNomeCpfCnpj.BackColor = Color.Transparent;
            groupBoxNomeCpfCnpj.Controls.Add(txtNomeCliente);
            groupBoxNomeCpfCnpj.Controls.Add(lblNomeCliente);
            groupBoxNomeCpfCnpj.Controls.Add(MaskedTxtCpfCnpjCliente);
            groupBoxNomeCpfCnpj.Controls.Add(btnRadioCpf);
            groupBoxNomeCpfCnpj.Controls.Add(btnRadioCnpj);
            groupBoxNomeCpfCnpj.Location = new Point(247, 53);
            groupBoxNomeCpfCnpj.Name = "groupBoxNomeCpfCnpj";
            groupBoxNomeCpfCnpj.Size = new Size(574, 91);
            groupBoxNomeCpfCnpj.TabIndex = 0;
            groupBoxNomeCpfCnpj.TabStop = false;
            // 
            // btnPesquisarCliente
            // 
            btnPesquisarCliente.BackColor = Color.Turquoise;
            btnPesquisarCliente.BackgroundImageLayout = ImageLayout.None;
            btnPesquisarCliente.Cursor = Cursors.Hand;
            btnPesquisarCliente.FlatStyle = FlatStyle.Popup;
            btnPesquisarCliente.Image = (Image)resources.GetObject("btnPesquisarCliente.Image");
            btnPesquisarCliente.Location = new Point(698, 770);
            btnPesquisarCliente.Name = "btnPesquisarCliente";
            btnPesquisarCliente.RightToLeft = RightToLeft.No;
            btnPesquisarCliente.Size = new Size(123, 42);
            btnPesquisarCliente.TabIndex = 46;
            btnPesquisarCliente.Text = "Pesquisar";
            btnPesquisarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarCliente.UseVisualStyleBackColor = false;
            btnPesquisarCliente.Click += btnPesquisarCliente_Click;
            // 
            // btnNovoCadastro
            // 
            btnNovoCadastro.BackColor = Color.Turquoise;
            btnNovoCadastro.BackgroundImageLayout = ImageLayout.None;
            btnNovoCadastro.Cursor = Cursors.Hand;
            btnNovoCadastro.FlatStyle = FlatStyle.Popup;
            btnNovoCadastro.Image = (Image)resources.GetObject("btnNovoCadastro.Image");
            btnNovoCadastro.Location = new Point(275, 770);
            btnNovoCadastro.Name = "btnNovoCadastro";
            btnNovoCadastro.RightToLeft = RightToLeft.No;
            btnNovoCadastro.Size = new Size(161, 42);
            btnNovoCadastro.TabIndex = 48;
            btnNovoCadastro.Text = "Novo";
            btnNovoCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovoCadastro.UseVisualStyleBackColor = false;
            btnNovoCadastro.Click += btnNovoCadastro_Click;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.BackColor = Color.Transparent;
            lblCodigoCliente.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigoCliente.Location = new Point(253, 12);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(86, 23);
            lblCodigoCliente.TabIndex = 50;
            lblCodigoCliente.Text = "Código:";
            // 
            // btnCancelarCadastro
            // 
            btnCancelarCadastro.BackColor = Color.LightSalmon;
            btnCancelarCadastro.BackgroundImageLayout = ImageLayout.None;
            btnCancelarCadastro.Cursor = Cursors.Hand;
            btnCancelarCadastro.FlatStyle = FlatStyle.Popup;
            btnCancelarCadastro.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnCancelarCadastro.Location = new Point(442, 770);
            btnCancelarCadastro.Name = "btnCancelarCadastro";
            btnCancelarCadastro.RightToLeft = RightToLeft.No;
            btnCancelarCadastro.Size = new Size(161, 42);
            btnCancelarCadastro.TabIndex = 51;
            btnCancelarCadastro.TabStop = false;
            btnCancelarCadastro.Text = "Cancelar";
            btnCancelarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelarCadastro.UseVisualStyleBackColor = false;
            btnCancelarCadastro.Click += btnCancelarCadastro_Click;
            // 
            // comboBoxSituacaoCadastral
            // 
            comboBoxSituacaoCadastral.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSituacaoCadastral.Enabled = false;
            comboBoxSituacaoCadastral.FormattingEnabled = true;
            comboBoxSituacaoCadastral.Items.AddRange(new object[] { "ATIVO", "INATIVO" });
            comboBoxSituacaoCadastral.Location = new Point(670, 14);
            comboBoxSituacaoCadastral.Name = "comboBoxSituacaoCadastral";
            comboBoxSituacaoCadastral.Size = new Size(151, 25);
            comboBoxSituacaoCadastral.TabIndex = 52;
            // 
            // lblSituacaoCadastral
            // 
            lblSituacaoCadastral.AutoSize = true;
            lblSituacaoCadastral.BackColor = Color.Transparent;
            lblSituacaoCadastral.Location = new Point(590, 18);
            lblSituacaoCadastral.Margin = new Padding(4, 0, 4, 0);
            lblSituacaoCadastral.Name = "lblSituacaoCadastral";
            lblSituacaoCadastral.Size = new Size(77, 17);
            lblSituacaoCadastral.TabIndex = 37;
            lblSituacaoCadastral.Text = "Situação:";
            // 
            // lblMostrarCodigoCliente
            // 
            lblMostrarCodigoCliente.AutoSize = true;
            lblMostrarCodigoCliente.BackColor = Color.Transparent;
            lblMostrarCodigoCliente.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMostrarCodigoCliente.Location = new Point(345, 14);
            lblMostrarCodigoCliente.Name = "lblMostrarCodigoCliente";
            lblMostrarCodigoCliente.Size = new Size(0, 23);
            lblMostrarCodigoCliente.TabIndex = 53;
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Font = new Font("Microsoft Sans Serif", 8.25F);
            txtCodigoCliente.Location = new Point(345, 14);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.ReadOnly = true;
            txtCodigoCliente.Size = new Size(83, 23);
            txtCodigoCliente.TabIndex = 37;
            // 
            // FormCadastroCliente
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.gradience1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(833, 836);
            Controls.Add(txtCodigoCliente);
            Controls.Add(lblMostrarCodigoCliente);
            Controls.Add(lblSituacaoCadastral);
            Controls.Add(comboBoxSituacaoCadastral);
            Controls.Add(lblCodigoCliente);
            Controls.Add(btnPesquisarCliente);
            Controls.Add(groupBoxNomeCpfCnpj);
            Controls.Add(btnFecharForm);
            Controls.Add(btnRemoverImagem);
            Controls.Add(btnImagemCliente);
            Controls.Add(imagemCliente);
            Controls.Add(groupBoxEstadoCivil);
            Controls.Add(groupBoxContatos);
            Controls.Add(groupBoxEndereco);
            Controls.Add(groupBoxGenero);
            Controls.Add(txtObservacoes);
            Controls.Add(lblObservacoes);
            Controls.Add(btnNovoCadastro);
            Controls.Add(btnEditarCadastro);
            Controls.Add(btnSalvarCadastroCliente);
            Controls.Add(btnCancelarCadastro);
            DoubleBuffered = true;
            Font = new Font("Arial Rounded MT Bold", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormCadastroCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Cliente";
            groupBoxGenero.ResumeLayout(false);
            groupBoxGenero.PerformLayout();
            groupBoxEndereco.ResumeLayout(false);
            groupBoxEndereco.PerformLayout();
            groupBoxContatos.ResumeLayout(false);
            groupBoxContatos.PerformLayout();
            groupBoxEstadoCivil.ResumeLayout(false);
            groupBoxEstadoCivil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imagemCliente).EndInit();
            groupBoxNomeCpfCnpj.ResumeLayout(false);
            groupBoxNomeCpfCnpj.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeCliente;
        private Label lblCpf;
        private Label lblEndereco;
        private Label lblEstadoCivil;
        private Label lblBairroCliente;
        private Label lblCidadeCliente;
        private Label lblNumeroResidencia;
        private TextBox txtNomeCliente;
        private TextBox txtEnderecoCliente;
        private TextBox txtBairroCliente;
        private TextBox txtCidadeCliente;
        private TextBox txtNumeroResidencia;
        private Label lblCepCliente;
        private Label lblEmailCliente;
        private Label lblCelularCliente;
        private TextBox txtEmailCliente;
        private Label lblObservacoes;
        private TextBox txtObservacoes;
        private RadioButton btnGeneroMasc;
        private RadioButton btnGeneroFemi;
        private RadioButton btnRadioGeneroOutros;
        private MaskedTextBox MaskedTxtCpfCnpjCliente;
        private MaskedTextBox MaskedTxtCepCliente;
        private MaskedTextBox MaskedTxtCelularCliente;
        private Label lblEstadoCliente;
        private RadioButton btnRadioCpf;
        private RadioButton btnRadioCnpj;
        private RadioButton btnRadioFeminino;
        private RadioButton btnRadioMasculino;
        private GroupBox groupBoxGenero;
        private GroupBox groupBoxEndereco;
        private GroupBox groupBoxContatos;
        private ComboBox comboBoxEstadoUF;
        private GroupBox groupBoxEstadoCivil;
        private ComboBox comboBoxEstadoCivil;
        private PictureBox imagemCliente;
        private Button btnImagemCliente;
        private Button btnRemoverImagem;
        private Button btnFecharForm;
        private Button btnSalvarCadastroCliente;
        private Button btnEditarCadastro;
        private GroupBox groupBoxNomeCpfCnpj;
        private Button btnPesquisarCliente;
        private Button btnNovoCadastro;
        private Label lblCodigoCliente;
        private Button btnCancelarCadastro;
        private ComboBox comboBoxSituacaoCadastral;
        private Label lblSituacaoCadastral;
        private Label lblMostrarCodigoCliente;
        private TextBox txtCodigoCliente;
    }
}
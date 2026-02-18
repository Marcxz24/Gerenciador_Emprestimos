namespace Gerenciador_de_Emprestimos
{
    partial class frmCadastroFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFuncionario));
            lblCodigoFuncionario = new Label();
            lblNomeFuncionario = new Label();
            lblSituacaoFuncionario = new Label();
            txtBoxCodigo = new TextBox();
            txtBoxNomeFuncionario = new TextBox();
            comboBoxSituacao = new ComboBox();
            btnNovoCadastro = new Button();
            btnCancelar = new Button();
            btnSalvarCadastro = new Button();
            btnEditarCadastro = new Button();
            btnPesquisarFuncionario = new Button();
            tabPageLogin = new TabPage();
            lblLinkEditarSenha = new LinkLabel();
            txtBoxSenha = new TextBox();
            lblUsername = new Label();
            lblSenhaFuncionario = new Label();
            txtBoxUsername = new TextBox();
            tabPageCadastroFuncionario = new TabPage();
            grpBoxDadosPessoaisFuncionario = new GroupBox();
            label1 = new Label();
            txtBoxNumeroResidencia = new TextBox();
            lblUf = new Label();
            comboBoxUf = new ComboBox();
            lblCep = new Label();
            txtBoxCep = new MaskedTextBox();
            txtBoxBairro = new TextBox();
            lblBairro = new Label();
            txtBoxEndereco = new TextBox();
            lblEndereco = new Label();
            lblEstadoCivil = new Label();
            comboBoxEstadoCivil = new ComboBox();
            txtBoxCidadeFuncionario = new TextBox();
            lblCidadeFuncionario = new Label();
            lblSexoFuncionario = new Label();
            comboBoxSexoFuncionario = new ComboBox();
            lblCpfFuncionario = new Label();
            txtBoxCpfFuncionario = new MaskedTextBox();
            lblTelefone = new Label();
            txtBoxTelefoneFuncionario = new MaskedTextBox();
            tabCntrlCadastroFuncionario = new TabControl();
            tabPagePrivilegios = new TabPage();
            tabControlPrivilegios = new TabControl();
            tabPageCadastro = new TabPage();
            grpBoxCliente = new GroupBox();
            chkBoxAcessarCadastroCliente = new CheckBox();
            grpBoxEmpresa = new GroupBox();
            chkBoxCadastroFuncionario = new CheckBox();
            tabPageFinanceiro = new TabPage();
            grpBoxEmprestimos = new GroupBox();
            chkBoxPagamentoParcela = new CheckBox();
            chkBoxNovosEmprestimos = new CheckBox();
            tabPageRelatorios = new TabPage();
            grpBoxRelatorioEmprestimos = new GroupBox();
            chkBoxConsultarParcela = new CheckBox();
            chkBoxVizualizarEmprestimos = new CheckBox();
            tabPageLogin.SuspendLayout();
            tabPageCadastroFuncionario.SuspendLayout();
            grpBoxDadosPessoaisFuncionario.SuspendLayout();
            tabCntrlCadastroFuncionario.SuspendLayout();
            tabPagePrivilegios.SuspendLayout();
            tabControlPrivilegios.SuspendLayout();
            tabPageCadastro.SuspendLayout();
            grpBoxCliente.SuspendLayout();
            grpBoxEmpresa.SuspendLayout();
            tabPageFinanceiro.SuspendLayout();
            grpBoxEmprestimos.SuspendLayout();
            tabPageRelatorios.SuspendLayout();
            grpBoxRelatorioEmprestimos.SuspendLayout();
            SuspendLayout();
            // 
            // lblCodigoFuncionario
            // 
            lblCodigoFuncionario.AutoSize = true;
            lblCodigoFuncionario.BackColor = Color.Transparent;
            lblCodigoFuncionario.Location = new Point(24, 40);
            lblCodigoFuncionario.Name = "lblCodigoFuncionario";
            lblCodigoFuncionario.Size = new Size(61, 20);
            lblCodigoFuncionario.TabIndex = 0;
            lblCodigoFuncionario.Text = "Código:";
            // 
            // lblNomeFuncionario
            // 
            lblNomeFuncionario.AutoSize = true;
            lblNomeFuncionario.BackColor = Color.Transparent;
            lblNomeFuncionario.Location = new Point(196, 40);
            lblNomeFuncionario.Name = "lblNomeFuncionario";
            lblNomeFuncionario.Size = new Size(59, 20);
            lblNomeFuncionario.TabIndex = 1;
            lblNomeFuncionario.Text = "*Nome:";
            // 
            // lblSituacaoFuncionario
            // 
            lblSituacaoFuncionario.AutoSize = true;
            lblSituacaoFuncionario.BackColor = Color.Transparent;
            lblSituacaoFuncionario.Location = new Point(640, 40);
            lblSituacaoFuncionario.Name = "lblSituacaoFuncionario";
            lblSituacaoFuncionario.Size = new Size(75, 20);
            lblSituacaoFuncionario.TabIndex = 2;
            lblSituacaoFuncionario.Text = "*Situação:";
            // 
            // txtBoxCodigo
            // 
            txtBoxCodigo.Enabled = false;
            txtBoxCodigo.Location = new Point(91, 37);
            txtBoxCodigo.Name = "txtBoxCodigo";
            txtBoxCodigo.ReadOnly = true;
            txtBoxCodigo.Size = new Size(99, 27);
            txtBoxCodigo.TabIndex = 3;
            // 
            // txtBoxNomeFuncionario
            // 
            txtBoxNomeFuncionario.Location = new Point(261, 40);
            txtBoxNomeFuncionario.Name = "txtBoxNomeFuncionario";
            txtBoxNomeFuncionario.ReadOnly = true;
            txtBoxNomeFuncionario.Size = new Size(373, 27);
            txtBoxNomeFuncionario.TabIndex = 4;
            txtBoxNomeFuncionario.TextChanged += txtBoxNomeFuncionario_TextChanged;
            // 
            // comboBoxSituacao
            // 
            comboBoxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSituacao.Enabled = false;
            comboBoxSituacao.FormattingEnabled = true;
            comboBoxSituacao.Items.AddRange(new object[] { "ATIVO", "INATIVO" });
            comboBoxSituacao.Location = new Point(715, 37);
            comboBoxSituacao.Name = "comboBoxSituacao";
            comboBoxSituacao.Size = new Size(118, 28);
            comboBoxSituacao.TabIndex = 5;
            // 
            // btnNovoCadastro
            // 
            btnNovoCadastro.BackColor = Color.LightGreen;
            btnNovoCadastro.FlatStyle = FlatStyle.Popup;
            btnNovoCadastro.Image = (Image)resources.GetObject("btnNovoCadastro.Image");
            btnNovoCadastro.Location = new Point(208, 629);
            btnNovoCadastro.Name = "btnNovoCadastro";
            btnNovoCadastro.Size = new Size(182, 56);
            btnNovoCadastro.TabIndex = 8;
            btnNovoCadastro.Text = "Novo";
            btnNovoCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovoCadastro.UseVisualStyleBackColor = false;
            btnNovoCadastro.Click += btnNovoCadastro_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Salmon;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnCancelar.Location = new Point(396, 629);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(182, 56);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvarCadastro
            // 
            btnSalvarCadastro.BackColor = Color.SpringGreen;
            btnSalvarCadastro.FlatStyle = FlatStyle.Popup;
            btnSalvarCadastro.Image = (Image)resources.GetObject("btnSalvarCadastro.Image");
            btnSalvarCadastro.Location = new Point(208, 629);
            btnSalvarCadastro.Name = "btnSalvarCadastro";
            btnSalvarCadastro.Size = new Size(182, 56);
            btnSalvarCadastro.TabIndex = 10;
            btnSalvarCadastro.Text = "Salvar";
            btnSalvarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvarCadastro.UseVisualStyleBackColor = false;
            btnSalvarCadastro.Click += btnSalvarCadastro_Click;
            // 
            // btnEditarCadastro
            // 
            btnEditarCadastro.BackColor = Color.Gold;
            btnEditarCadastro.FlatStyle = FlatStyle.Popup;
            btnEditarCadastro.Image = (Image)resources.GetObject("btnEditarCadastro.Image");
            btnEditarCadastro.Location = new Point(396, 629);
            btnEditarCadastro.Name = "btnEditarCadastro";
            btnEditarCadastro.Size = new Size(182, 56);
            btnEditarCadastro.TabIndex = 11;
            btnEditarCadastro.Text = "Editar";
            btnEditarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditarCadastro.UseVisualStyleBackColor = false;
            btnEditarCadastro.Click += btnEditarCadastro_Click;
            // 
            // btnPesquisarFuncionario
            // 
            btnPesquisarFuncionario.BackColor = Color.Turquoise;
            btnPesquisarFuncionario.FlatStyle = FlatStyle.Popup;
            btnPesquisarFuncionario.Image = Properties.Resources.lupa;
            btnPesquisarFuncionario.Location = new Point(696, 629);
            btnPesquisarFuncionario.Name = "btnPesquisarFuncionario";
            btnPesquisarFuncionario.Size = new Size(182, 56);
            btnPesquisarFuncionario.TabIndex = 12;
            btnPesquisarFuncionario.Text = "Pesquisar";
            btnPesquisarFuncionario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarFuncionario.UseVisualStyleBackColor = false;
            btnPesquisarFuncionario.Click += btnPesquisarFuncionario_Click;
            // 
            // tabPageLogin
            // 
            tabPageLogin.Controls.Add(lblLinkEditarSenha);
            tabPageLogin.Controls.Add(txtBoxSenha);
            tabPageLogin.Controls.Add(lblUsername);
            tabPageLogin.Controls.Add(lblSenhaFuncionario);
            tabPageLogin.Controls.Add(txtBoxUsername);
            tabPageLogin.Location = new Point(4, 29);
            tabPageLogin.Name = "tabPageLogin";
            tabPageLogin.Padding = new Padding(3);
            tabPageLogin.Size = new Size(859, 469);
            tabPageLogin.TabIndex = 2;
            tabPageLogin.Text = "Login";
            tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // lblLinkEditarSenha
            // 
            lblLinkEditarSenha.AutoSize = true;
            lblLinkEditarSenha.Enabled = false;
            lblLinkEditarSenha.Location = new Point(358, 229);
            lblLinkEditarSenha.Name = "lblLinkEditarSenha";
            lblLinkEditarSenha.Size = new Size(113, 20);
            lblLinkEditarSenha.TabIndex = 11;
            lblLinkEditarSenha.TabStop = true;
            lblLinkEditarSenha.Text = "Redefinir Senha";
            lblLinkEditarSenha.LinkClicked += lblLinkEditarSenha_LinkClicked;
            // 
            // txtBoxSenha
            // 
            txtBoxSenha.Location = new Point(290, 199);
            txtBoxSenha.Name = "txtBoxSenha";
            txtBoxSenha.ReadOnly = true;
            txtBoxSenha.Size = new Size(268, 27);
            txtBoxSenha.TabIndex = 10;
            txtBoxSenha.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(199, 146);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 20);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "*Username:";
            // 
            // lblSenhaFuncionario
            // 
            lblSenhaFuncionario.AutoSize = true;
            lblSenhaFuncionario.BackColor = Color.Transparent;
            lblSenhaFuncionario.Location = new Point(225, 202);
            lblSenhaFuncionario.Name = "lblSenhaFuncionario";
            lblSenhaFuncionario.Size = new Size(58, 20);
            lblSenhaFuncionario.TabIndex = 9;
            lblSenhaFuncionario.Text = "*Senha:";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(289, 143);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.ReadOnly = true;
            txtBoxUsername.Size = new Size(268, 27);
            txtBoxUsername.TabIndex = 8;
            // 
            // tabPageCadastroFuncionario
            // 
            tabPageCadastroFuncionario.Controls.Add(grpBoxDadosPessoaisFuncionario);
            tabPageCadastroFuncionario.Location = new Point(4, 29);
            tabPageCadastroFuncionario.Name = "tabPageCadastroFuncionario";
            tabPageCadastroFuncionario.Padding = new Padding(3);
            tabPageCadastroFuncionario.Size = new Size(859, 469);
            tabPageCadastroFuncionario.TabIndex = 0;
            tabPageCadastroFuncionario.Text = "Dados do Funcionário";
            tabPageCadastroFuncionario.UseVisualStyleBackColor = true;
            // 
            // grpBoxDadosPessoaisFuncionario
            // 
            grpBoxDadosPessoaisFuncionario.BackColor = Color.Transparent;
            grpBoxDadosPessoaisFuncionario.Controls.Add(label1);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxNumeroResidencia);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblUf);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxUf);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCep);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCep);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxBairro);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblBairro);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxEndereco);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblEndereco);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblEstadoCivil);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxEstadoCivil);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCidadeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCidadeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblSexoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxSexoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCpfFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCpfFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblTelefone);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxTelefoneFuncionario);
            grpBoxDadosPessoaisFuncionario.Location = new Point(3, 6);
            grpBoxDadosPessoaisFuncionario.Name = "grpBoxDadosPessoaisFuncionario";
            grpBoxDadosPessoaisFuncionario.Size = new Size(820, 362);
            grpBoxDadosPessoaisFuncionario.TabIndex = 7;
            grpBoxDadosPessoaisFuncionario.TabStop = false;
            grpBoxDadosPessoaisFuncionario.Text = "Dados do Funcionário (Obrigatórios)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(512, 265);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 28;
            label1.Text = "N° Residencia:";
            // 
            // txtBoxNumeroResidencia
            // 
            txtBoxNumeroResidencia.Location = new Point(617, 260);
            txtBoxNumeroResidencia.Name = "txtBoxNumeroResidencia";
            txtBoxNumeroResidencia.ReadOnly = true;
            txtBoxNumeroResidencia.Size = new Size(152, 27);
            txtBoxNumeroResidencia.TabIndex = 27;
            // 
            // lblUf
            // 
            lblUf.AutoSize = true;
            lblUf.BackColor = Color.Transparent;
            lblUf.Location = new Point(314, 265);
            lblUf.Name = "lblUf";
            lblUf.Size = new Size(35, 20);
            lblUf.TabIndex = 26;
            lblUf.Text = "*UF:";
            // 
            // comboBoxUf
            // 
            comboBoxUf.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUf.Enabled = false;
            comboBoxUf.FormattingEnabled = true;
            comboBoxUf.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            comboBoxUf.Location = new Point(355, 262);
            comboBoxUf.Name = "comboBoxUf";
            comboBoxUf.Size = new Size(151, 28);
            comboBoxUf.TabIndex = 25;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.BackColor = Color.Transparent;
            lblCep.Location = new Point(354, 156);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(43, 20);
            lblCep.TabIndex = 24;
            lblCep.Text = "*CEP:";
            // 
            // txtBoxCep
            // 
            txtBoxCep.Location = new Point(403, 153);
            txtBoxCep.Mask = "00,000-000";
            txtBoxCep.Name = "txtBoxCep";
            txtBoxCep.ReadOnly = true;
            txtBoxCep.Size = new Size(206, 27);
            txtBoxCep.TabIndex = 23;
            txtBoxCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtBoxCep.Leave += txtBoxCep_Leave;
            // 
            // txtBoxBairro
            // 
            txtBoxBairro.Location = new Point(90, 258);
            txtBoxBairro.Name = "txtBoxBairro";
            txtBoxBairro.ReadOnly = true;
            txtBoxBairro.Size = new Size(196, 27);
            txtBoxBairro.TabIndex = 22;
            txtBoxBairro.TextChanged += txtBoxBairro_TextChanged;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.BackColor = Color.Transparent;
            lblBairro.Location = new Point(32, 258);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(58, 20);
            lblBairro.TabIndex = 21;
            lblBairro.Text = "*Bairro:";
            // 
            // txtBoxEndereco
            // 
            txtBoxEndereco.Location = new Point(101, 200);
            txtBoxEndereco.Name = "txtBoxEndereco";
            txtBoxEndereco.ReadOnly = true;
            txtBoxEndereco.Size = new Size(209, 27);
            txtBoxEndereco.TabIndex = 20;
            txtBoxEndereco.TextChanged += txtBoxEndereco_TextChanged;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.BackColor = Color.Transparent;
            lblEndereco.Location = new Point(15, 203);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(80, 20);
            lblEndereco.TabIndex = 19;
            lblEndereco.Text = "*Endereço:";
            // 
            // lblEstadoCivil
            // 
            lblEstadoCivil.AutoSize = true;
            lblEstadoCivil.BackColor = Color.Transparent;
            lblEstadoCivil.Location = new Point(258, 100);
            lblEstadoCivil.Name = "lblEstadoCivil";
            lblEstadoCivil.Size = new Size(95, 20);
            lblEstadoCivil.TabIndex = 18;
            lblEstadoCivil.Text = "*Estado Civil:";
            // 
            // comboBoxEstadoCivil
            // 
            comboBoxEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstadoCivil.Enabled = false;
            comboBoxEstadoCivil.FormattingEnabled = true;
            comboBoxEstadoCivil.Items.AddRange(new object[] { "Solteiro(a)", "Casado(a)", "Divorciado(a)", "Viúvo(a)" });
            comboBoxEstadoCivil.Location = new Point(359, 95);
            comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            comboBoxEstadoCivil.Size = new Size(151, 28);
            comboBoxEstadoCivil.TabIndex = 17;
            // 
            // txtBoxCidadeFuncionario
            // 
            txtBoxCidadeFuncionario.Location = new Point(397, 200);
            txtBoxCidadeFuncionario.Name = "txtBoxCidadeFuncionario";
            txtBoxCidadeFuncionario.ReadOnly = true;
            txtBoxCidadeFuncionario.Size = new Size(373, 27);
            txtBoxCidadeFuncionario.TabIndex = 16;
            txtBoxCidadeFuncionario.TextChanged += txtBoxCidadeFuncionario_TextChanged;
            // 
            // lblCidadeFuncionario
            // 
            lblCidadeFuncionario.AutoSize = true;
            lblCidadeFuncionario.BackColor = Color.Transparent;
            lblCidadeFuncionario.Location = new Point(332, 200);
            lblCidadeFuncionario.Name = "lblCidadeFuncionario";
            lblCidadeFuncionario.Size = new Size(65, 20);
            lblCidadeFuncionario.TabIndex = 15;
            lblCidadeFuncionario.Text = "*Cidade:";
            // 
            // lblSexoFuncionario
            // 
            lblSexoFuncionario.AutoSize = true;
            lblSexoFuncionario.BackColor = Color.Transparent;
            lblSexoFuncionario.Location = new Point(45, 100);
            lblSexoFuncionario.Name = "lblSexoFuncionario";
            lblSexoFuncionario.Size = new Size(50, 20);
            lblSexoFuncionario.TabIndex = 13;
            lblSexoFuncionario.Text = "*Sexo:";
            // 
            // comboBoxSexoFuncionario
            // 
            comboBoxSexoFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSexoFuncionario.Enabled = false;
            comboBoxSexoFuncionario.FormattingEnabled = true;
            comboBoxSexoFuncionario.Items.AddRange(new object[] { "Masculino", "Feminino", "Indefinido" });
            comboBoxSexoFuncionario.Location = new Point(101, 96);
            comboBoxSexoFuncionario.Name = "comboBoxSexoFuncionario";
            comboBoxSexoFuncionario.Size = new Size(151, 28);
            comboBoxSexoFuncionario.TabIndex = 12;
            // 
            // lblCpfFuncionario
            // 
            lblCpfFuncionario.AutoSize = true;
            lblCpfFuncionario.BackColor = Color.Transparent;
            lblCpfFuncionario.Location = new Point(522, 98);
            lblCpfFuncionario.Name = "lblCpfFuncionario";
            lblCpfFuncionario.Size = new Size(42, 20);
            lblCpfFuncionario.TabIndex = 11;
            lblCpfFuncionario.Text = "*CPF:";
            // 
            // txtBoxCpfFuncionario
            // 
            txtBoxCpfFuncionario.Location = new Point(570, 95);
            txtBoxCpfFuncionario.Mask = "000,000,000-00";
            txtBoxCpfFuncionario.Name = "txtBoxCpfFuncionario";
            txtBoxCpfFuncionario.ReadOnly = true;
            txtBoxCpfFuncionario.Size = new Size(195, 27);
            txtBoxCpfFuncionario.TabIndex = 10;
            txtBoxCpfFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.BackColor = Color.Transparent;
            lblTelefone.Location = new Point(15, 152);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(75, 20);
            lblTelefone.TabIndex = 7;
            lblTelefone.Text = "*Telefone:";
            // 
            // txtBoxTelefoneFuncionario
            // 
            txtBoxTelefoneFuncionario.Location = new Point(90, 149);
            txtBoxTelefoneFuncionario.Mask = "(00) 00000-0000";
            txtBoxTelefoneFuncionario.Name = "txtBoxTelefoneFuncionario";
            txtBoxTelefoneFuncionario.ReadOnly = true;
            txtBoxTelefoneFuncionario.Size = new Size(210, 27);
            txtBoxTelefoneFuncionario.TabIndex = 6;
            txtBoxTelefoneFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // tabCntrlCadastroFuncionario
            // 
            tabCntrlCadastroFuncionario.Controls.Add(tabPageCadastroFuncionario);
            tabCntrlCadastroFuncionario.Controls.Add(tabPageLogin);
            tabCntrlCadastroFuncionario.Controls.Add(tabPagePrivilegios);
            tabCntrlCadastroFuncionario.Location = new Point(11, 96);
            tabCntrlCadastroFuncionario.Name = "tabCntrlCadastroFuncionario";
            tabCntrlCadastroFuncionario.SelectedIndex = 0;
            tabCntrlCadastroFuncionario.Size = new Size(867, 502);
            tabCntrlCadastroFuncionario.TabIndex = 13;
            // 
            // tabPagePrivilegios
            // 
            tabPagePrivilegios.Controls.Add(tabControlPrivilegios);
            tabPagePrivilegios.Location = new Point(4, 29);
            tabPagePrivilegios.Name = "tabPagePrivilegios";
            tabPagePrivilegios.Padding = new Padding(3);
            tabPagePrivilegios.Size = new Size(859, 469);
            tabPagePrivilegios.TabIndex = 3;
            tabPagePrivilegios.Text = "Privilégios";
            tabPagePrivilegios.UseVisualStyleBackColor = true;
            // 
            // tabControlPrivilegios
            // 
            tabControlPrivilegios.Controls.Add(tabPageCadastro);
            tabControlPrivilegios.Controls.Add(tabPageFinanceiro);
            tabControlPrivilegios.Controls.Add(tabPageRelatorios);
            tabControlPrivilegios.Location = new Point(3, 6);
            tabControlPrivilegios.Name = "tabControlPrivilegios";
            tabControlPrivilegios.SelectedIndex = 0;
            tabControlPrivilegios.Size = new Size(850, 460);
            tabControlPrivilegios.TabIndex = 0;
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(grpBoxCliente);
            tabPageCadastro.Controls.Add(grpBoxEmpresa);
            tabPageCadastro.Location = new Point(4, 29);
            tabPageCadastro.Name = "tabPageCadastro";
            tabPageCadastro.Padding = new Padding(3);
            tabPageCadastro.Size = new Size(842, 427);
            tabPageCadastro.TabIndex = 0;
            tabPageCadastro.Text = "Cadastro";
            tabPageCadastro.UseVisualStyleBackColor = true;
            // 
            // grpBoxCliente
            // 
            grpBoxCliente.Controls.Add(chkBoxAcessarCadastroCliente);
            grpBoxCliente.Location = new Point(6, 3);
            grpBoxCliente.Name = "grpBoxCliente";
            grpBoxCliente.Size = new Size(383, 186);
            grpBoxCliente.TabIndex = 4;
            grpBoxCliente.TabStop = false;
            grpBoxCliente.Text = "Cliente";
            // 
            // chkBoxAcessarCadastroCliente
            // 
            chkBoxAcessarCadastroCliente.AutoSize = true;
            chkBoxAcessarCadastroCliente.Enabled = false;
            chkBoxAcessarCadastroCliente.Location = new Point(20, 35);
            chkBoxAcessarCadastroCliente.Name = "chkBoxAcessarCadastroCliente";
            chkBoxAcessarCadastroCliente.Size = new Size(142, 24);
            chkBoxAcessarCadastroCliente.TabIndex = 0;
            chkBoxAcessarCadastroCliente.Tag = "1";
            chkBoxAcessarCadastroCliente.Text = "Acessar cadastro";
            chkBoxAcessarCadastroCliente.UseVisualStyleBackColor = true;
            // 
            // grpBoxEmpresa
            // 
            grpBoxEmpresa.Controls.Add(chkBoxCadastroFuncionario);
            grpBoxEmpresa.Location = new Point(395, 3);
            grpBoxEmpresa.Name = "grpBoxEmpresa";
            grpBoxEmpresa.Size = new Size(441, 188);
            grpBoxEmpresa.TabIndex = 3;
            grpBoxEmpresa.TabStop = false;
            grpBoxEmpresa.Text = "Empresa";
            // 
            // chkBoxCadastroFuncionario
            // 
            chkBoxCadastroFuncionario.AutoSize = true;
            chkBoxCadastroFuncionario.Enabled = false;
            chkBoxCadastroFuncionario.Location = new Point(16, 35);
            chkBoxCadastroFuncionario.Name = "chkBoxCadastroFuncionario";
            chkBoxCadastroFuncionario.Size = new Size(108, 24);
            chkBoxCadastroFuncionario.TabIndex = 1;
            chkBoxCadastroFuncionario.Tag = "2";
            chkBoxCadastroFuncionario.Text = "Funcionário";
            chkBoxCadastroFuncionario.UseVisualStyleBackColor = true;
            // 
            // tabPageFinanceiro
            // 
            tabPageFinanceiro.Controls.Add(grpBoxEmprestimos);
            tabPageFinanceiro.Location = new Point(4, 29);
            tabPageFinanceiro.Name = "tabPageFinanceiro";
            tabPageFinanceiro.Padding = new Padding(3);
            tabPageFinanceiro.Size = new Size(842, 427);
            tabPageFinanceiro.TabIndex = 1;
            tabPageFinanceiro.Text = "Financeiro";
            tabPageFinanceiro.UseVisualStyleBackColor = true;
            // 
            // grpBoxEmprestimos
            // 
            grpBoxEmprestimos.Controls.Add(chkBoxPagamentoParcela);
            grpBoxEmprestimos.Controls.Add(chkBoxNovosEmprestimos);
            grpBoxEmprestimos.Location = new Point(6, 6);
            grpBoxEmprestimos.Name = "grpBoxEmprestimos";
            grpBoxEmprestimos.Size = new Size(830, 186);
            grpBoxEmprestimos.TabIndex = 0;
            grpBoxEmprestimos.TabStop = false;
            grpBoxEmprestimos.Text = "Emprestimos";
            // 
            // chkBoxPagamentoParcela
            // 
            chkBoxPagamentoParcela.AutoSize = true;
            chkBoxPagamentoParcela.Enabled = false;
            chkBoxPagamentoParcela.Location = new Point(20, 66);
            chkBoxPagamentoParcela.Name = "chkBoxPagamentoParcela";
            chkBoxPagamentoParcela.Size = new Size(184, 24);
            chkBoxPagamentoParcela.TabIndex = 1;
            chkBoxPagamentoParcela.Tag = "5";
            chkBoxPagamentoParcela.Text = "Pagamento de Parcelas";
            chkBoxPagamentoParcela.UseVisualStyleBackColor = true;
            // 
            // chkBoxNovosEmprestimos
            // 
            chkBoxNovosEmprestimos.AutoSize = true;
            chkBoxNovosEmprestimos.Enabled = false;
            chkBoxNovosEmprestimos.Location = new Point(20, 26);
            chkBoxNovosEmprestimos.Name = "chkBoxNovosEmprestimos";
            chkBoxNovosEmprestimos.Size = new Size(163, 24);
            chkBoxNovosEmprestimos.TabIndex = 0;
            chkBoxNovosEmprestimos.Tag = "4";
            chkBoxNovosEmprestimos.Text = "Novos Emprestimos";
            chkBoxNovosEmprestimos.UseVisualStyleBackColor = true;
            // 
            // tabPageRelatorios
            // 
            tabPageRelatorios.Controls.Add(grpBoxRelatorioEmprestimos);
            tabPageRelatorios.Location = new Point(4, 29);
            tabPageRelatorios.Name = "tabPageRelatorios";
            tabPageRelatorios.Padding = new Padding(3);
            tabPageRelatorios.Size = new Size(842, 427);
            tabPageRelatorios.TabIndex = 2;
            tabPageRelatorios.Text = "Relatórios";
            tabPageRelatorios.UseVisualStyleBackColor = true;
            // 
            // grpBoxRelatorioEmprestimos
            // 
            grpBoxRelatorioEmprestimos.Controls.Add(chkBoxConsultarParcela);
            grpBoxRelatorioEmprestimos.Controls.Add(chkBoxVizualizarEmprestimos);
            grpBoxRelatorioEmprestimos.Location = new Point(6, 3);
            grpBoxRelatorioEmprestimos.Name = "grpBoxRelatorioEmprestimos";
            grpBoxRelatorioEmprestimos.Size = new Size(830, 200);
            grpBoxRelatorioEmprestimos.TabIndex = 0;
            grpBoxRelatorioEmprestimos.TabStop = false;
            grpBoxRelatorioEmprestimos.Text = "Relatório Emprestimos";
            // 
            // chkBoxConsultarParcela
            // 
            chkBoxConsultarParcela.AutoSize = true;
            chkBoxConsultarParcela.Enabled = false;
            chkBoxConsultarParcela.Location = new Point(25, 36);
            chkBoxConsultarParcela.Name = "chkBoxConsultarParcela";
            chkBoxConsultarParcela.Size = new Size(144, 24);
            chkBoxConsultarParcela.TabIndex = 1;
            chkBoxConsultarParcela.Tag = "3";
            chkBoxConsultarParcela.Text = "Consultar Parcela";
            chkBoxConsultarParcela.UseVisualStyleBackColor = true;
            // 
            // chkBoxVizualizarEmprestimos
            // 
            chkBoxVizualizarEmprestimos.AutoSize = true;
            chkBoxVizualizarEmprestimos.Enabled = false;
            chkBoxVizualizarEmprestimos.Location = new Point(25, 80);
            chkBoxVizualizarEmprestimos.Name = "chkBoxVizualizarEmprestimos";
            chkBoxVizualizarEmprestimos.Size = new Size(184, 24);
            chkBoxVizualizarEmprestimos.TabIndex = 0;
            chkBoxVizualizarEmprestimos.Tag = "6";
            chkBoxVizualizarEmprestimos.Text = "Visualizar Emprestimos";
            chkBoxVizualizarEmprestimos.UseVisualStyleBackColor = true;
            // 
            // frmCadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(891, 708);
            Controls.Add(btnPesquisarFuncionario);
            Controls.Add(btnEditarCadastro);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovoCadastro);
            Controls.Add(btnSalvarCadastro);
            Controls.Add(txtBoxCodigo);
            Controls.Add(lblSituacaoFuncionario);
            Controls.Add(lblNomeFuncionario);
            Controls.Add(comboBoxSituacao);
            Controls.Add(lblCodigoFuncionario);
            Controls.Add(txtBoxNomeFuncionario);
            Controls.Add(tabCntrlCadastroFuncionario);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmCadastroFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Funcionário";
            tabPageLogin.ResumeLayout(false);
            tabPageLogin.PerformLayout();
            tabPageCadastroFuncionario.ResumeLayout(false);
            grpBoxDadosPessoaisFuncionario.ResumeLayout(false);
            grpBoxDadosPessoaisFuncionario.PerformLayout();
            tabCntrlCadastroFuncionario.ResumeLayout(false);
            tabPagePrivilegios.ResumeLayout(false);
            tabControlPrivilegios.ResumeLayout(false);
            tabPageCadastro.ResumeLayout(false);
            grpBoxCliente.ResumeLayout(false);
            grpBoxCliente.PerformLayout();
            grpBoxEmpresa.ResumeLayout(false);
            grpBoxEmpresa.PerformLayout();
            tabPageFinanceiro.ResumeLayout(false);
            grpBoxEmprestimos.ResumeLayout(false);
            grpBoxEmprestimos.PerformLayout();
            tabPageRelatorios.ResumeLayout(false);
            grpBoxRelatorioEmprestimos.ResumeLayout(false);
            grpBoxRelatorioEmprestimos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigoFuncionario;
        private Label lblNomeFuncionario;
        private Label lblSituacaoFuncionario;
        private TextBox txtBoxCodigo;
        private TextBox txtBoxNomeFuncionario;
        private ComboBox comboBoxSituacao;
        private TextBox txtBoxEmailFuncionario;
        private Label lblEmailFuncionario;
        private Button btnNovoCadastro;
        private Button btnCancelar;
        private Button btnSalvarCadastro;
        private Button btnEditarCadastro;
        private Button btnPesquisarFuncionario;
        private TabPage tabPageLogin;
        private LinkLabel lblLinkEditarSenha;
        private TextBox txtBoxSenha;
        private Label lblUsername;
        private Label lblSenhaFuncionario;
        private TextBox txtBoxUsername;
        private TabPage tabPageCadastroFuncionario;
        private GroupBox grpBoxDadosPessoaisFuncionario;
        private Label lblEstadoCivil;
        private ComboBox comboBoxEstadoCivil;
        private TextBox txtBoxCidadeFuncionario;
        private Label lblCidadeFuncionario;
        private Label lblSexoFuncionario;
        private ComboBox comboBoxSexoFuncionario;
        private Label lblCpfFuncionario;
        private MaskedTextBox txtBoxCpfFuncionario;
        private Label lblTelefone;
        private MaskedTextBox txtBoxTelefoneFuncionario;
        private TabControl tabCntrlCadastroFuncionario;
        private TabPage tabPagePrivilegios;
        private TabControl tabControlPrivilegios;
        private TabPage tabPageCadastro;
        private TabPage tabPageFinanceiro;
        private TabPage tabPageRelatorios;
        private CheckBox chkBoxAcessarCadastroCliente;
        private GroupBox grpBoxEmpresa;
        private CheckBox chkBoxCadastroFuncionario;
        private GroupBox grpBoxEmprestimos;
        private CheckBox chkBoxPagamentoParcela;
        private CheckBox chkBoxNovosEmprestimos;
        private GroupBox grpBoxCliente;
        private GroupBox grpBoxRelatorioEmprestimos;
        private CheckBox chkBoxVizualizarEmprestimos;
        private CheckBox chkBoxConsultarParcela;
        private TextBox txtBoxEndereco;
        private Label lblEndereco;
        private TextBox txtBoxBairro;
        private Label lblBairro;
        private Label lblCep;
        private MaskedTextBox txtBoxCep;
        private Label lblUf;
        private ComboBox comboBoxUf;
        private TextBox txtBoxNumeroResidencia;
        private Label label1;
    }
}
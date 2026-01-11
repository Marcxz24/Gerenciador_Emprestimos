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
            txtBoxSenha = new TextBox();
            lblSenhaFuncionario = new Label();
            txtBoxUsername = new TextBox();
            lblUsername = new Label();
            grpBoxDadosPessoaisFuncionario = new GroupBox();
            lblEstadoCivil = new Label();
            comboBoxEstadoCivil = new ComboBox();
            txtBoxCidadeFuncionario = new TextBox();
            lblCidadeFuncionario = new Label();
            grpBoxDadosLogin = new GroupBox();
            lblSexoFuncionario = new Label();
            comboBoxSexoFuncionario = new ComboBox();
            lblCpfFuncionario = new Label();
            txtBoxCpfFuncionario = new MaskedTextBox();
            lblTelefone = new Label();
            txtBoxTelefoneFuncionario = new MaskedTextBox();
            btnNovoCadastro = new Button();
            btnCancelar = new Button();
            btnSalvarCadastro = new Button();
            btnEditarCadastro = new Button();
            btnPesquisarFuncionario = new Button();
            grpBoxDadosPessoaisFuncionario.SuspendLayout();
            grpBoxDadosLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblCodigoFuncionario
            // 
            lblCodigoFuncionario.AutoSize = true;
            lblCodigoFuncionario.BackColor = Color.Transparent;
            lblCodigoFuncionario.Location = new Point(0, 26);
            lblCodigoFuncionario.Name = "lblCodigoFuncionario";
            lblCodigoFuncionario.Size = new Size(61, 20);
            lblCodigoFuncionario.TabIndex = 0;
            lblCodigoFuncionario.Text = "Código:";
            // 
            // lblNomeFuncionario
            // 
            lblNomeFuncionario.AutoSize = true;
            lblNomeFuncionario.BackColor = Color.Transparent;
            lblNomeFuncionario.Location = new Point(172, 26);
            lblNomeFuncionario.Name = "lblNomeFuncionario";
            lblNomeFuncionario.Size = new Size(59, 20);
            lblNomeFuncionario.TabIndex = 1;
            lblNomeFuncionario.Text = "*Nome:";
            // 
            // lblSituacaoFuncionario
            // 
            lblSituacaoFuncionario.AutoSize = true;
            lblSituacaoFuncionario.BackColor = Color.Transparent;
            lblSituacaoFuncionario.Location = new Point(616, 26);
            lblSituacaoFuncionario.Name = "lblSituacaoFuncionario";
            lblSituacaoFuncionario.Size = new Size(75, 20);
            lblSituacaoFuncionario.TabIndex = 2;
            lblSituacaoFuncionario.Text = "*Situação:";
            // 
            // txtBoxCodigo
            // 
            txtBoxCodigo.Enabled = false;
            txtBoxCodigo.Location = new Point(67, 23);
            txtBoxCodigo.Name = "txtBoxCodigo";
            txtBoxCodigo.ReadOnly = true;
            txtBoxCodigo.Size = new Size(99, 27);
            txtBoxCodigo.TabIndex = 3;
            // 
            // txtBoxNomeFuncionario
            // 
            txtBoxNomeFuncionario.Location = new Point(237, 26);
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
            comboBoxSituacao.Location = new Point(691, 23);
            comboBoxSituacao.Name = "comboBoxSituacao";
            comboBoxSituacao.Size = new Size(118, 28);
            comboBoxSituacao.TabIndex = 5;
            // 
            // txtBoxSenha
            // 
            txtBoxSenha.Location = new Point(460, 54);
            txtBoxSenha.Name = "txtBoxSenha";
            txtBoxSenha.ReadOnly = true;
            txtBoxSenha.Size = new Size(268, 27);
            txtBoxSenha.TabIndex = 10;
            txtBoxSenha.UseSystemPasswordChar = true;
            // 
            // lblSenhaFuncionario
            // 
            lblSenhaFuncionario.AutoSize = true;
            lblSenhaFuncionario.BackColor = Color.Transparent;
            lblSenhaFuncionario.Location = new Point(395, 57);
            lblSenhaFuncionario.Name = "lblSenhaFuncionario";
            lblSenhaFuncionario.Size = new Size(58, 20);
            lblSenhaFuncionario.TabIndex = 9;
            lblSenhaFuncionario.Text = "*Senha:";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(104, 54);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.ReadOnly = true;
            txtBoxUsername.Size = new Size(268, 27);
            txtBoxUsername.TabIndex = 8;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(14, 57);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 20);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "*Username:";
            // 
            // grpBoxDadosPessoaisFuncionario
            // 
            grpBoxDadosPessoaisFuncionario.BackColor = Color.Transparent;
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblEstadoCivil);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxEstadoCivil);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCidadeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCidadeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(grpBoxDadosLogin);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblSexoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxSexoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCpfFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCpfFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblTelefone);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxTelefoneFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxNomeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblCodigoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(comboBoxSituacao);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblNomeFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(lblSituacaoFuncionario);
            grpBoxDadosPessoaisFuncionario.Controls.Add(txtBoxCodigo);
            grpBoxDadosPessoaisFuncionario.Location = new Point(12, 12);
            grpBoxDadosPessoaisFuncionario.Name = "grpBoxDadosPessoaisFuncionario";
            grpBoxDadosPessoaisFuncionario.Size = new Size(809, 362);
            grpBoxDadosPessoaisFuncionario.TabIndex = 7;
            grpBoxDadosPessoaisFuncionario.TabStop = false;
            grpBoxDadosPessoaisFuncionario.Text = "Dados do Funcionário (Obrigatórios)";
            // 
            // lblEstadoCivil
            // 
            lblEstadoCivil.AutoSize = true;
            lblEstadoCivil.BackColor = Color.Transparent;
            lblEstadoCivil.Location = new Point(531, 85);
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
            comboBoxEstadoCivil.Location = new Point(632, 80);
            comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            comboBoxEstadoCivil.Size = new Size(151, 28);
            comboBoxEstadoCivil.TabIndex = 17;
            // 
            // txtBoxCidadeFuncionario
            // 
            txtBoxCidadeFuncionario.Location = new Point(384, 151);
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
            lblCidadeFuncionario.Location = new Point(319, 151);
            lblCidadeFuncionario.Name = "lblCidadeFuncionario";
            lblCidadeFuncionario.Size = new Size(65, 20);
            lblCidadeFuncionario.TabIndex = 15;
            lblCidadeFuncionario.Text = "*Cidade:";
            // 
            // grpBoxDadosLogin
            // 
            grpBoxDadosLogin.Controls.Add(lblUsername);
            grpBoxDadosLogin.Controls.Add(txtBoxSenha);
            grpBoxDadosLogin.Controls.Add(txtBoxUsername);
            grpBoxDadosLogin.Controls.Add(lblSenhaFuncionario);
            grpBoxDadosLogin.Location = new Point(20, 217);
            grpBoxDadosLogin.Name = "grpBoxDadosLogin";
            grpBoxDadosLogin.Size = new Size(755, 125);
            grpBoxDadosLogin.TabIndex = 14;
            grpBoxDadosLogin.TabStop = false;
            grpBoxDadosLogin.Text = "Dados do Login";
            // 
            // lblSexoFuncionario
            // 
            lblSexoFuncionario.AutoSize = true;
            lblSexoFuncionario.BackColor = Color.Transparent;
            lblSexoFuncionario.Location = new Point(299, 85);
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
            comboBoxSexoFuncionario.Location = new Point(355, 81);
            comboBoxSexoFuncionario.Name = "comboBoxSexoFuncionario";
            comboBoxSexoFuncionario.Size = new Size(151, 28);
            comboBoxSexoFuncionario.TabIndex = 12;
            // 
            // lblCpfFuncionario
            // 
            lblCpfFuncionario.AutoSize = true;
            lblCpfFuncionario.BackColor = Color.Transparent;
            lblCpfFuncionario.Location = new Point(19, 88);
            lblCpfFuncionario.Name = "lblCpfFuncionario";
            lblCpfFuncionario.Size = new Size(42, 20);
            lblCpfFuncionario.TabIndex = 11;
            lblCpfFuncionario.Text = "*CPF:";
            // 
            // txtBoxCpfFuncionario
            // 
            txtBoxCpfFuncionario.Location = new Point(67, 85);
            txtBoxCpfFuncionario.Mask = "000,000,000-00";
            txtBoxCpfFuncionario.Name = "txtBoxCpfFuncionario";
            txtBoxCpfFuncionario.ReadOnly = true;
            txtBoxCpfFuncionario.Size = new Size(207, 27);
            txtBoxCpfFuncionario.TabIndex = 10;
            txtBoxCpfFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.BackColor = Color.Transparent;
            lblTelefone.Location = new Point(20, 151);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(75, 20);
            lblTelefone.TabIndex = 7;
            lblTelefone.Text = "*Telefone:";
            // 
            // txtBoxTelefoneFuncionario
            // 
            txtBoxTelefoneFuncionario.Location = new Point(95, 148);
            txtBoxTelefoneFuncionario.Mask = "(00) 00000-0000";
            txtBoxTelefoneFuncionario.Name = "txtBoxTelefoneFuncionario";
            txtBoxTelefoneFuncionario.ReadOnly = true;
            txtBoxTelefoneFuncionario.Size = new Size(207, 27);
            txtBoxTelefoneFuncionario.TabIndex = 6;
            txtBoxTelefoneFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // btnNovoCadastro
            // 
            btnNovoCadastro.BackColor = Color.LightGreen;
            btnNovoCadastro.FlatStyle = FlatStyle.Popup;
            btnNovoCadastro.Image = (Image)resources.GetObject("btnNovoCadastro.Image");
            btnNovoCadastro.Location = new Point(208, 406);
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
            btnCancelar.Location = new Point(396, 406);
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
            btnSalvarCadastro.Location = new Point(208, 406);
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
            btnEditarCadastro.Location = new Point(396, 406);
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
            btnPesquisarFuncionario.Location = new Point(639, 406);
            btnPesquisarFuncionario.Name = "btnPesquisarFuncionario";
            btnPesquisarFuncionario.Size = new Size(182, 56);
            btnPesquisarFuncionario.TabIndex = 12;
            btnPesquisarFuncionario.Text = "Pesquisar";
            btnPesquisarFuncionario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarFuncionario.UseVisualStyleBackColor = false;
            btnPesquisarFuncionario.Click += btnPesquisarFuncionario_Click;
            // 
            // frmCadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 484);
            Controls.Add(btnPesquisarFuncionario);
            Controls.Add(btnEditarCadastro);
            Controls.Add(btnCancelar);
            Controls.Add(grpBoxDadosPessoaisFuncionario);
            Controls.Add(btnNovoCadastro);
            Controls.Add(btnSalvarCadastro);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmCadastroFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Funcionário";
            grpBoxDadosPessoaisFuncionario.ResumeLayout(false);
            grpBoxDadosPessoaisFuncionario.PerformLayout();
            grpBoxDadosLogin.ResumeLayout(false);
            grpBoxDadosLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCodigoFuncionario;
        private Label lblNomeFuncionario;
        private Label lblSituacaoFuncionario;
        private TextBox txtBoxCodigo;
        private TextBox txtBoxNomeFuncionario;
        private ComboBox comboBoxSituacao;
        private TextBox txtBoxUsername;
        private Label lblUsername;
        private TextBox txtBoxSenha;
        private Label lblSenhaFuncionario;
        private GroupBox grpBoxDadosPessoaisFuncionario;
        private Label lblTelefone;
        private MaskedTextBox txtBoxTelefoneFuncionario;
        private TextBox txtBoxEmailFuncionario;
        private Label lblEmailFuncionario;
        private Label lblCpfFuncionario;
        private MaskedTextBox txtBoxCpfFuncionario;
        private Button btnNovoCadastro;
        private Label lblSexoFuncionario;
        private ComboBox comboBoxSexoFuncionario;
        private Button btnCancelar;
        private Button btnSalvarCadastro;
        private Button btnEditarCadastro;
        private GroupBox grpBoxDadosLogin;
        private TextBox txtBoxCidadeFuncionario;
        private Label lblCidadeFuncionario;
        private Label lblEstadoCivil;
        private ComboBox comboBoxEstadoCivil;
        private Button btnPesquisarFuncionario;
    }
}
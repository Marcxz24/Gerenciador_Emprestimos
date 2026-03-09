namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmCadastroClientePJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroClientePJ));
            grpDadosEmpresa = new GroupBox();
            lblSituacao = new Label();
            cmbSituacao = new ComboBox();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            lblTipoIE = new Label();
            cmbTipoIE = new ComboBox();
            txtIncricaoEstadual = new TextBox();
            lblInscricaoEstadual = new Label();
            txtCnpj = new MaskedTextBox();
            lblCnpj = new Label();
            txtNomeFantasia = new TextBox();
            txtRazaoSocial = new TextBox();
            lblNomeFantasia = new Label();
            lblRazaoSocial = new Label();
            grpEnderecoEmpresa = new GroupBox();
            txtNumeroEmpresa = new TextBox();
            lblNumeroCasa = new Label();
            txtBairro = new TextBox();
            lblBairro = new Label();
            txtEndereco = new TextBox();
            lblEndereco = new Label();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            txtCidade = new TextBox();
            lblCep = new Label();
            lblCidade = new Label();
            txtCep = new MaskedTextBox();
            btnSalvarCadastro = new Button();
            btnNovoCadastro = new Button();
            btnEditarCadastro = new Button();
            btnCancelarCadastro = new Button();
            btnPesquisarCliente = new Button();
            lblObservacoes = new Label();
            txtObservacoes = new TextBox();
            txtCelularEmpresa = new MaskedTextBox();
            lblEmailEmpresa = new Label();
            lblCelularEmpresa = new Label();
            txtEmailEmpresa = new TextBox();
            grpDadosEmpresa.SuspendLayout();
            grpEnderecoEmpresa.SuspendLayout();
            SuspendLayout();
            // 
            // grpDadosEmpresa
            // 
            grpDadosEmpresa.BackColor = Color.Transparent;
            grpDadosEmpresa.Controls.Add(lblSituacao);
            grpDadosEmpresa.Controls.Add(cmbSituacao);
            grpDadosEmpresa.Controls.Add(txtCodigo);
            grpDadosEmpresa.Controls.Add(lblCodigo);
            grpDadosEmpresa.Controls.Add(lblTipoIE);
            grpDadosEmpresa.Controls.Add(cmbTipoIE);
            grpDadosEmpresa.Controls.Add(txtIncricaoEstadual);
            grpDadosEmpresa.Controls.Add(lblInscricaoEstadual);
            grpDadosEmpresa.Controls.Add(txtCnpj);
            grpDadosEmpresa.Controls.Add(lblCnpj);
            grpDadosEmpresa.Controls.Add(txtNomeFantasia);
            grpDadosEmpresa.Controls.Add(txtRazaoSocial);
            grpDadosEmpresa.Controls.Add(lblNomeFantasia);
            grpDadosEmpresa.Controls.Add(lblRazaoSocial);
            grpDadosEmpresa.Location = new Point(12, 12);
            grpDadosEmpresa.Name = "grpDadosEmpresa";
            grpDadosEmpresa.Size = new Size(776, 219);
            grpDadosEmpresa.TabIndex = 0;
            grpDadosEmpresa.TabStop = false;
            grpDadosEmpresa.Text = "Dados da Empresa";
            // 
            // lblSituacao
            // 
            lblSituacao.AutoSize = true;
            lblSituacao.Location = new Point(612, 72);
            lblSituacao.Name = "lblSituacao";
            lblSituacao.Size = new Size(72, 20);
            lblSituacao.TabIndex = 13;
            lblSituacao.Text = "*Situação";
            // 
            // cmbSituacao
            // 
            cmbSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSituacao.Enabled = false;
            cmbSituacao.FormattingEnabled = true;
            cmbSituacao.Items.AddRange(new object[] { "ATIVO", "INATIVO" });
            cmbSituacao.Location = new Point(612, 94);
            cmbSituacao.Name = "cmbSituacao";
            cmbSituacao.Size = new Size(151, 28);
            cmbSituacao.TabIndex = 12;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(120, 30);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(99, 27);
            txtCodigo.TabIndex = 11;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(20, 30);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(94, 28);
            lblCodigo.TabIndex = 10;
            lblCodigo.Text = "Código:";
            // 
            // lblTipoIE
            // 
            lblTipoIE.AutoSize = true;
            lblTipoIE.Location = new Point(236, 143);
            lblTipoIE.Name = "lblTipoIE";
            lblTipoIE.Size = new Size(61, 20);
            lblTipoIE.TabIndex = 9;
            lblTipoIE.Text = "*Tipo IE";
            // 
            // cmbTipoIE
            // 
            cmbTipoIE.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoIE.Enabled = false;
            cmbTipoIE.FormattingEnabled = true;
            cmbTipoIE.Items.AddRange(new object[] { "NAO CONTRIBUINTE", "CONTRIBUINTE" });
            cmbTipoIE.Location = new Point(236, 165);
            cmbTipoIE.Name = "cmbTipoIE";
            cmbTipoIE.Size = new Size(165, 28);
            cmbTipoIE.TabIndex = 8;
            // 
            // txtIncricaoEstadual
            // 
            txtIncricaoEstadual.Location = new Point(419, 166);
            txtIncricaoEstadual.Name = "txtIncricaoEstadual";
            txtIncricaoEstadual.ReadOnly = true;
            txtIncricaoEstadual.Size = new Size(344, 27);
            txtIncricaoEstadual.TabIndex = 7;
            // 
            // lblInscricaoEstadual
            // 
            lblInscricaoEstadual.AutoSize = true;
            lblInscricaoEstadual.Location = new Point(419, 143);
            lblInscricaoEstadual.Name = "lblInscricaoEstadual";
            lblInscricaoEstadual.Size = new Size(127, 20);
            lblInscricaoEstadual.TabIndex = 6;
            lblInscricaoEstadual.Text = "Inscrição Estadual";
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(20, 166);
            txtCnpj.Mask = "00,000,000/0000-00";
            txtCnpj.Name = "txtCnpj";
            txtCnpj.ReadOnly = true;
            txtCnpj.Size = new Size(199, 27);
            txtCnpj.TabIndex = 5;
            txtCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCnpj.Leave += txtCnpj_Leave;
            // 
            // lblCnpj
            // 
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(20, 143);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.Size = new Size(47, 20);
            lblCnpj.TabIndex = 4;
            lblCnpj.Text = "*CNPJ";
            // 
            // txtNomeFantasia
            // 
            txtNomeFantasia.Location = new Point(369, 95);
            txtNomeFantasia.Name = "txtNomeFantasia";
            txtNomeFantasia.ReadOnly = true;
            txtNomeFantasia.Size = new Size(238, 27);
            txtNomeFantasia.TabIndex = 3;
            txtNomeFantasia.TextChanged += txtNomeFantasia_TextChanged;
            // 
            // txtRazaoSocial
            // 
            txtRazaoSocial.Location = new Point(20, 95);
            txtRazaoSocial.Name = "txtRazaoSocial";
            txtRazaoSocial.ReadOnly = true;
            txtRazaoSocial.Size = new Size(331, 27);
            txtRazaoSocial.TabIndex = 1;
            txtRazaoSocial.TextChanged += txtRazaoSocial_TextChanged;
            // 
            // lblNomeFantasia
            // 
            lblNomeFantasia.AutoSize = true;
            lblNomeFantasia.Location = new Point(369, 72);
            lblNomeFantasia.Name = "lblNomeFantasia";
            lblNomeFantasia.Size = new Size(113, 20);
            lblNomeFantasia.TabIndex = 2;
            lblNomeFantasia.Text = "*Nome Fantasia";
            // 
            // lblRazaoSocial
            // 
            lblRazaoSocial.AutoSize = true;
            lblRazaoSocial.Location = new Point(20, 72);
            lblRazaoSocial.Name = "lblRazaoSocial";
            lblRazaoSocial.Size = new Size(100, 20);
            lblRazaoSocial.TabIndex = 0;
            lblRazaoSocial.Text = "*Razão Social";
            // 
            // grpEnderecoEmpresa
            // 
            grpEnderecoEmpresa.BackColor = Color.Transparent;
            grpEnderecoEmpresa.Controls.Add(txtNumeroEmpresa);
            grpEnderecoEmpresa.Controls.Add(lblNumeroCasa);
            grpEnderecoEmpresa.Controls.Add(txtBairro);
            grpEnderecoEmpresa.Controls.Add(lblBairro);
            grpEnderecoEmpresa.Controls.Add(txtEndereco);
            grpEnderecoEmpresa.Controls.Add(lblEndereco);
            grpEnderecoEmpresa.Controls.Add(lblEstado);
            grpEnderecoEmpresa.Controls.Add(cmbEstado);
            grpEnderecoEmpresa.Controls.Add(txtCidade);
            grpEnderecoEmpresa.Controls.Add(lblCep);
            grpEnderecoEmpresa.Controls.Add(lblCidade);
            grpEnderecoEmpresa.Controls.Add(txtCep);
            grpEnderecoEmpresa.Location = new Point(12, 237);
            grpEnderecoEmpresa.Name = "grpEnderecoEmpresa";
            grpEnderecoEmpresa.Size = new Size(776, 159);
            grpEnderecoEmpresa.TabIndex = 1;
            grpEnderecoEmpresa.TabStop = false;
            grpEnderecoEmpresa.Text = "Endereço da Empresa";
            // 
            // txtNumeroEmpresa
            // 
            txtNumeroEmpresa.Location = new Point(546, 116);
            txtNumeroEmpresa.Name = "txtNumeroEmpresa";
            txtNumeroEmpresa.ReadOnly = true;
            txtNumeroEmpresa.Size = new Size(201, 27);
            txtNumeroEmpresa.TabIndex = 23;
            // 
            // lblNumeroCasa
            // 
            lblNumeroCasa.AutoSize = true;
            lblNumeroCasa.Location = new Point(548, 93);
            lblNumeroCasa.Name = "lblNumeroCasa";
            lblNumeroCasa.Size = new Size(108, 20);
            lblNumeroCasa.TabIndex = 22;
            lblNumeroCasa.Text = "N° da Empresa";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(278, 116);
            txtBairro.Name = "txtBairro";
            txtBairro.ReadOnly = true;
            txtBairro.Size = new Size(252, 27);
            txtBairro.TabIndex = 21;
            txtBairro.TextChanged += txtBairro_TextChanged;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(280, 93);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(49, 20);
            lblBairro.TabIndex = 20;
            lblBairro.Text = "Bairro";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(18, 116);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.ReadOnly = true;
            txtEndereco.Size = new Size(252, 27);
            txtEndereco.TabIndex = 19;
            txtEndereco.TextChanged += txtEndereco_TextChanged;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(20, 93);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(71, 20);
            lblEndereco.TabIndex = 18;
            lblEndereco.Text = "Endereço";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(179, 22);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(26, 20);
            lblEstado.TabIndex = 17;
            lblEstado.Text = "UF";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Enabled = false;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            cmbEstado.Location = new Point(179, 45);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(151, 28);
            cmbEstado.TabIndex = 16;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(347, 45);
            txtCidade.Name = "txtCidade";
            txtCidade.ReadOnly = true;
            txtCidade.Size = new Size(366, 27);
            txtCidade.TabIndex = 15;
            txtCidade.TextChanged += txtCidade_TextChanged;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Location = new Point(20, 23);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(34, 20);
            lblCep.TabIndex = 14;
            lblCep.Text = "CEP";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(355, 22);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(56, 20);
            lblCidade.TabIndex = 14;
            lblCidade.Text = "Cidade";
            // 
            // txtCep
            // 
            txtCep.Location = new Point(20, 46);
            txtCep.Mask = "00,000-000";
            txtCep.Name = "txtCep";
            txtCep.ReadOnly = true;
            txtCep.Size = new Size(144, 27);
            txtCep.TabIndex = 0;
            txtCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCep.Leave += txtCep_Leave;
            // 
            // btnSalvarCadastro
            // 
            btnSalvarCadastro.BackColor = Color.LightGreen;
            btnSalvarCadastro.FlatStyle = FlatStyle.Popup;
            btnSalvarCadastro.Image = Properties.Resources.ImagemNovoCadastro;
            btnSalvarCadastro.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvarCadastro.Location = new Point(248, 773);
            btnSalvarCadastro.Name = "btnSalvarCadastro";
            btnSalvarCadastro.Size = new Size(140, 46);
            btnSalvarCadastro.TabIndex = 2;
            btnSalvarCadastro.Text = "Salvar";
            btnSalvarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvarCadastro.UseVisualStyleBackColor = false;
            btnSalvarCadastro.Click += btnSalvarCadastro_Click;
            // 
            // btnNovoCadastro
            // 
            btnNovoCadastro.BackColor = Color.SpringGreen;
            btnNovoCadastro.FlatStyle = FlatStyle.Popup;
            btnNovoCadastro.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovoCadastro.Location = new Point(248, 773);
            btnNovoCadastro.Name = "btnNovoCadastro";
            btnNovoCadastro.Size = new Size(140, 46);
            btnNovoCadastro.TabIndex = 3;
            btnNovoCadastro.Text = "Novo";
            btnNovoCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovoCadastro.UseVisualStyleBackColor = false;
            btnNovoCadastro.Click += btnNovoCadastro_Click;
            // 
            // btnEditarCadastro
            // 
            btnEditarCadastro.BackColor = Color.Yellow;
            btnEditarCadastro.FlatStyle = FlatStyle.Popup;
            btnEditarCadastro.Image = Properties.Resources.ImagemEditar;
            btnEditarCadastro.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditarCadastro.Location = new Point(402, 773);
            btnEditarCadastro.Name = "btnEditarCadastro";
            btnEditarCadastro.Size = new Size(140, 46);
            btnEditarCadastro.TabIndex = 4;
            btnEditarCadastro.Text = "Editar";
            btnEditarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditarCadastro.UseVisualStyleBackColor = false;
            btnEditarCadastro.Click += btnEditarCadastro_Click;
            // 
            // btnCancelarCadastro
            // 
            btnCancelarCadastro.BackColor = Color.Salmon;
            btnCancelarCadastro.FlatStyle = FlatStyle.Popup;
            btnCancelarCadastro.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnCancelarCadastro.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelarCadastro.Location = new Point(402, 773);
            btnCancelarCadastro.Name = "btnCancelarCadastro";
            btnCancelarCadastro.Size = new Size(140, 46);
            btnCancelarCadastro.TabIndex = 5;
            btnCancelarCadastro.Text = "Cancelar";
            btnCancelarCadastro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelarCadastro.UseVisualStyleBackColor = false;
            btnCancelarCadastro.Click += btnCancelarCadastro_Click;
            // 
            // btnPesquisarCliente
            // 
            btnPesquisarCliente.BackColor = Color.Turquoise;
            btnPesquisarCliente.FlatStyle = FlatStyle.Popup;
            btnPesquisarCliente.Image = Properties.Resources.lupa;
            btnPesquisarCliente.ImageAlign = ContentAlignment.MiddleLeft;
            btnPesquisarCliente.Location = new Point(648, 773);
            btnPesquisarCliente.Name = "btnPesquisarCliente";
            btnPesquisarCliente.Size = new Size(140, 46);
            btnPesquisarCliente.TabIndex = 6;
            btnPesquisarCliente.Text = "Pesquisar";
            btnPesquisarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarCliente.UseVisualStyleBackColor = false;
            btnPesquisarCliente.Click += btnPesquisarCliente_Click;
            // 
            // lblObservacoes
            // 
            lblObservacoes.AutoSize = true;
            lblObservacoes.BackColor = Color.Transparent;
            lblObservacoes.Location = new Point(12, 471);
            lblObservacoes.Name = "lblObservacoes";
            lblObservacoes.Size = new Size(93, 20);
            lblObservacoes.TabIndex = 24;
            lblObservacoes.Text = "Observações";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(12, 494);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.ReadOnly = true;
            txtObservacoes.Size = new Size(774, 252);
            txtObservacoes.TabIndex = 24;
            // 
            // txtCelularEmpresa
            // 
            txtCelularEmpresa.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCelularEmpresa.Location = new Point(85, 428);
            txtCelularEmpresa.Mask = "(00) 00000-0000";
            txtCelularEmpresa.Name = "txtCelularEmpresa";
            txtCelularEmpresa.ReadOnly = true;
            txtCelularEmpresa.Size = new Size(247, 27);
            txtCelularEmpresa.TabIndex = 25;
            // 
            // lblEmailEmpresa
            // 
            lblEmailEmpresa.AutoSize = true;
            lblEmailEmpresa.BackColor = Color.Transparent;
            lblEmailEmpresa.Location = new Point(381, 405);
            lblEmailEmpresa.Name = "lblEmailEmpresa";
            lblEmailEmpresa.Size = new Size(134, 20);
            lblEmailEmpresa.TabIndex = 26;
            lblEmailEmpresa.Text = "E-mail da Empresa";
            // 
            // lblCelularEmpresa
            // 
            lblCelularEmpresa.AutoSize = true;
            lblCelularEmpresa.BackColor = Color.Transparent;
            lblCelularEmpresa.Location = new Point(80, 405);
            lblCelularEmpresa.Name = "lblCelularEmpresa";
            lblCelularEmpresa.Size = new Size(137, 20);
            lblCelularEmpresa.TabIndex = 27;
            lblCelularEmpresa.Text = "Celular da Empresa";
            // 
            // txtEmailEmpresa
            // 
            txtEmailEmpresa.Location = new Point(381, 428);
            txtEmailEmpresa.Name = "txtEmailEmpresa";
            txtEmailEmpresa.ReadOnly = true;
            txtEmailEmpresa.Size = new Size(394, 27);
            txtEmailEmpresa.TabIndex = 24;
            // 
            // frmCadastroClientePJ
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(800, 831);
            Controls.Add(txtEmailEmpresa);
            Controls.Add(lblCelularEmpresa);
            Controls.Add(lblEmailEmpresa);
            Controls.Add(txtCelularEmpresa);
            Controls.Add(txtObservacoes);
            Controls.Add(lblObservacoes);
            Controls.Add(btnPesquisarCliente);
            Controls.Add(grpEnderecoEmpresa);
            Controls.Add(grpDadosEmpresa);
            Controls.Add(btnEditarCadastro);
            Controls.Add(btnCancelarCadastro);
            Controls.Add(btnNovoCadastro);
            Controls.Add(btnSalvarCadastro);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCadastroClientePJ";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Pessoa Jurídica";
            grpDadosEmpresa.ResumeLayout(false);
            grpDadosEmpresa.PerformLayout();
            grpEnderecoEmpresa.ResumeLayout(false);
            grpEnderecoEmpresa.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDadosEmpresa;
        private Label lblRazaoSocial;
        private TextBox txtRazaoSocial;
        private TextBox txtNomeFantasia;
        private Label lblNomeFantasia;
        private MaskedTextBox txtCnpj;
        private Label lblCnpj;
        private TextBox txtIncricaoEstadual;
        private Label lblInscricaoEstadual;
        private Label lblTipoIE;
        private ComboBox cmbTipoIE;
        private TextBox txtCodigo;
        private Label lblCodigo;
        private Label lblSituacao;
        private ComboBox cmbSituacao;
        private GroupBox grpEnderecoEmpresa;
        private MaskedTextBox txtCep;
        private Label lblCep;
        private TextBox txtCidade;
        private Label lblCidade;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private TextBox txtEndereco;
        private Label lblEndereco;
        private TextBox txtBairro;
        private Label lblBairro;
        private TextBox txtNumeroEmpresa;
        private Label lblNumeroCasa;
        private Button btnSalvarCadastro;
        private Button btnNovoCadastro;
        private Button btnEditarCadastro;
        private Button btnCancelarCadastro;
        private Button btnPesquisarCliente;
        private Label lblObservacoes;
        private TextBox txtObservacoes;
        private MaskedTextBox txtCelularEmpresa;
        private Label lblEmailEmpresa;
        private Label lblCelularEmpresa;
        private TextBox txtEmailEmpresa;
    }
}
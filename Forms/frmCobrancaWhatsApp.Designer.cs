namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmCobrancaWhatsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrancaWhatsApp));
            grpBoxCliente = new GroupBox();
            txtNomeCliente = new TextBox();
            txtCodigoCliente = new TextBox();
            lblCodigoCliente = new Label();
            lblNomeCliente = new Label();
            lblTelefoneCliente = new Label();
            txtTelefoneCliente = new MaskedTextBox();
            grpBoxEnvioMensagem = new GroupBox();
            txtBoxValorVencido = new TextBox();
            lblValorVencido = new Label();
            btnLimparTela = new Button();
            btnEnvioMensagem = new Button();
            txtMensagemCobranca = new TextBox();
            lblMensagemCobranca = new Label();
            txtModeloMsg = new TextBox();
            lblModeloMensagem = new Label();
            txtCodigoModeloMsg = new TextBox();
            grpBoxCliente.SuspendLayout();
            grpBoxEnvioMensagem.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxCliente
            // 
            grpBoxCliente.Controls.Add(txtNomeCliente);
            grpBoxCliente.Controls.Add(txtCodigoCliente);
            grpBoxCliente.Controls.Add(lblCodigoCliente);
            grpBoxCliente.Controls.Add(lblNomeCliente);
            grpBoxCliente.Location = new Point(12, 12);
            grpBoxCliente.Name = "grpBoxCliente";
            grpBoxCliente.Size = new Size(776, 144);
            grpBoxCliente.TabIndex = 0;
            grpBoxCliente.TabStop = false;
            grpBoxCliente.Text = "Dados do Cliente";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(325, 64);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(247, 27);
            txtNomeCliente.TabIndex = 3;
            txtNomeCliente.KeyDown += txtNomeCliente_KeyDown;
            // 
            // txtCodigoCliente
            // 
            txtCodigoCliente.Location = new Point(206, 64);
            txtCodigoCliente.Name = "txtCodigoCliente";
            txtCodigoCliente.Size = new Size(97, 27);
            txtCodigoCliente.TabIndex = 2;
            txtCodigoCliente.KeyDown += txtCodigoCliente_KeyDown;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(206, 41);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(58, 20);
            lblCodigoCliente.TabIndex = 1;
            lblCodigoCliente.Text = "Código";
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(325, 41);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(53, 20);
            lblNomeCliente.TabIndex = 0;
            lblNomeCliente.Text = "Nome:";
            // 
            // lblTelefoneCliente
            // 
            lblTelefoneCliente.AutoSize = true;
            lblTelefoneCliente.Location = new Point(340, 34);
            lblTelefoneCliente.Name = "lblTelefoneCliente";
            lblTelefoneCliente.Size = new Size(72, 20);
            lblTelefoneCliente.TabIndex = 5;
            lblTelefoneCliente.Text = "*Telefone";
            // 
            // txtTelefoneCliente
            // 
            txtTelefoneCliente.Location = new Point(340, 57);
            txtTelefoneCliente.Mask = "(00) 00000-0000";
            txtTelefoneCliente.Name = "txtTelefoneCliente";
            txtTelefoneCliente.Size = new Size(200, 27);
            txtTelefoneCliente.TabIndex = 4;
            txtTelefoneCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // grpBoxEnvioMensagem
            // 
            grpBoxEnvioMensagem.Controls.Add(txtBoxValorVencido);
            grpBoxEnvioMensagem.Controls.Add(lblValorVencido);
            grpBoxEnvioMensagem.Controls.Add(lblTelefoneCliente);
            grpBoxEnvioMensagem.Controls.Add(txtTelefoneCliente);
            grpBoxEnvioMensagem.Controls.Add(btnLimparTela);
            grpBoxEnvioMensagem.Controls.Add(btnEnvioMensagem);
            grpBoxEnvioMensagem.Controls.Add(txtMensagemCobranca);
            grpBoxEnvioMensagem.Controls.Add(lblMensagemCobranca);
            grpBoxEnvioMensagem.Controls.Add(txtModeloMsg);
            grpBoxEnvioMensagem.Controls.Add(lblModeloMensagem);
            grpBoxEnvioMensagem.Controls.Add(txtCodigoModeloMsg);
            grpBoxEnvioMensagem.Location = new Point(12, 182);
            grpBoxEnvioMensagem.Name = "grpBoxEnvioMensagem";
            grpBoxEnvioMensagem.Size = new Size(776, 566);
            grpBoxEnvioMensagem.TabIndex = 1;
            grpBoxEnvioMensagem.TabStop = false;
            grpBoxEnvioMensagem.Text = "Envio de Mensagem";
            // 
            // txtBoxValorVencido
            // 
            txtBoxValorVencido.Location = new Point(578, 57);
            txtBoxValorVencido.Name = "txtBoxValorVencido";
            txtBoxValorVencido.Size = new Size(143, 27);
            txtBoxValorVencido.TabIndex = 8;
            txtBoxValorVencido.KeyDown += txtBoxValorVencido_KeyDown;
            txtBoxValorVencido.Leave += txtBoxValorVencido_Leave;
            // 
            // lblValorVencido
            // 
            lblValorVencido.AutoSize = true;
            lblValorVencido.Location = new Point(578, 34);
            lblValorVencido.Name = "lblValorVencido";
            lblValorVencido.Size = new Size(134, 20);
            lblValorVencido.TabIndex = 7;
            lblValorVencido.Text = "Valor Vencido (R$):";
            // 
            // btnLimparTela
            // 
            btnLimparTela.BackColor = Color.Salmon;
            btnLimparTela.FlatStyle = FlatStyle.Flat;
            btnLimparTela.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparTela.Location = new Point(584, 492);
            btnLimparTela.Name = "btnLimparTela";
            btnLimparTela.Size = new Size(177, 59);
            btnLimparTela.TabIndex = 6;
            btnLimparTela.Text = "Limpar Tela";
            btnLimparTela.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparTela.UseVisualStyleBackColor = false;
            btnLimparTela.Click += btnLimparTela_Click;
            // 
            // btnEnvioMensagem
            // 
            btnEnvioMensagem.BackColor = Color.LimeGreen;
            btnEnvioMensagem.FlatStyle = FlatStyle.Flat;
            btnEnvioMensagem.Image = (Image)resources.GetObject("btnEnvioMensagem.Image");
            btnEnvioMensagem.Location = new Point(293, 492);
            btnEnvioMensagem.Name = "btnEnvioMensagem";
            btnEnvioMensagem.Size = new Size(177, 59);
            btnEnvioMensagem.TabIndex = 5;
            btnEnvioMensagem.Text = "Enviar Mensagem";
            btnEnvioMensagem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEnvioMensagem.UseVisualStyleBackColor = false;
            btnEnvioMensagem.Click += btnEnvioMensagem_Click;
            // 
            // txtMensagemCobranca
            // 
            txtMensagemCobranca.Location = new Point(15, 143);
            txtMensagemCobranca.Multiline = true;
            txtMensagemCobranca.Name = "txtMensagemCobranca";
            txtMensagemCobranca.Size = new Size(746, 343);
            txtMensagemCobranca.TabIndex = 4;
            // 
            // lblMensagemCobranca
            // 
            lblMensagemCobranca.AutoSize = true;
            lblMensagemCobranca.Location = new Point(15, 107);
            lblMensagemCobranca.Name = "lblMensagemCobranca";
            lblMensagemCobranca.Size = new Size(173, 20);
            lblMensagemCobranca.TabIndex = 3;
            lblMensagemCobranca.Text = "Mensagem de Cobrança:";
            // 
            // txtModeloMsg
            // 
            txtModeloMsg.Location = new Point(82, 57);
            txtModeloMsg.Name = "txtModeloMsg";
            txtModeloMsg.Size = new Size(248, 27);
            txtModeloMsg.TabIndex = 2;
            txtModeloMsg.KeyDown += txtModeloMsg_KeyDown;
            // 
            // lblModeloMensagem
            // 
            lblModeloMensagem.AutoSize = true;
            lblModeloMensagem.Location = new Point(15, 34);
            lblModeloMensagem.Name = "lblModeloMensagem";
            lblModeloMensagem.Size = new Size(162, 20);
            lblModeloMensagem.TabIndex = 1;
            lblModeloMensagem.Text = "Modelo de Mensagem:";
            // 
            // txtCodigoModeloMsg
            // 
            txtCodigoModeloMsg.Location = new Point(15, 57);
            txtCodigoModeloMsg.Name = "txtCodigoModeloMsg";
            txtCodigoModeloMsg.Size = new Size(61, 27);
            txtCodigoModeloMsg.TabIndex = 0;
            txtCodigoModeloMsg.KeyDown += txtCodigoModeloMsg_KeyDown;
            // 
            // frmCobrancaWhatsApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 760);
            Controls.Add(grpBoxEnvioMensagem);
            Controls.Add(grpBoxCliente);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCobrancaWhatsApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cobrança";
            grpBoxCliente.ResumeLayout(false);
            grpBoxCliente.PerformLayout();
            grpBoxEnvioMensagem.ResumeLayout(false);
            grpBoxEnvioMensagem.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxCliente;
        private Label lblCodigoCliente;
        private Label lblNomeCliente;
        private TextBox txtCodigoCliente;
        private TextBox txtNomeCliente;
        private Label lblTelefoneCliente;
        private MaskedTextBox txtTelefoneCliente;
        private GroupBox grpBoxEnvioMensagem;
        private Label lblModeloMensagem;
        private TextBox txtCodigoModeloMsg;
        private TextBox txtModeloMsg;
        private Label lblMensagemCobranca;
        private TextBox txtMensagemCobranca;
        private Button btnEnvioMensagem;
        private Button btnLimparTela;
        private TextBox txtBoxValorVencido;
        private Label lblValorVencido;
    }
}
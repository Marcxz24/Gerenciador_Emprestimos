namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmCadastroMensagemCobranca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroMensagemCobranca));
            txtCodigoModeloMsg = new TextBox();
            txtDescricaoModeloMsg = new TextBox();
            cmbBoxSituacaoModeloMsg = new ComboBox();
            lblCodigoModeloMensagem = new Label();
            lblDescricaoModeloMsg = new Label();
            label1 = new Label();
            txtMensagemEnviar = new TextBox();
            grpBoxModeloMsg = new GroupBox();
            btnNovo = new Button();
            btnEditar = new Button();
            btnPesquisar = new Button();
            btnCancelar = new Button();
            btnSalvar = new Button();
            grpBoxModeloMsg.SuspendLayout();
            SuspendLayout();
            // 
            // txtCodigoModeloMsg
            // 
            txtCodigoModeloMsg.Location = new Point(12, 51);
            txtCodigoModeloMsg.Name = "txtCodigoModeloMsg";
            txtCodigoModeloMsg.ReadOnly = true;
            txtCodigoModeloMsg.Size = new Size(93, 27);
            txtCodigoModeloMsg.TabIndex = 0;
            // 
            // txtDescricaoModeloMsg
            // 
            txtDescricaoModeloMsg.Location = new Point(111, 51);
            txtDescricaoModeloMsg.Name = "txtDescricaoModeloMsg";
            txtDescricaoModeloMsg.ReadOnly = true;
            txtDescricaoModeloMsg.Size = new Size(406, 27);
            txtDescricaoModeloMsg.TabIndex = 1;
            txtDescricaoModeloMsg.TextChanged += txtDescricaoModeloMsg_TextChanged;
            // 
            // cmbBoxSituacaoModeloMsg
            // 
            cmbBoxSituacaoModeloMsg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxSituacaoModeloMsg.Enabled = false;
            cmbBoxSituacaoModeloMsg.FormattingEnabled = true;
            cmbBoxSituacaoModeloMsg.Items.AddRange(new object[] { "ATIVO", "INATIVO" });
            cmbBoxSituacaoModeloMsg.Location = new Point(526, 51);
            cmbBoxSituacaoModeloMsg.Name = "cmbBoxSituacaoModeloMsg";
            cmbBoxSituacaoModeloMsg.Size = new Size(151, 28);
            cmbBoxSituacaoModeloMsg.TabIndex = 2;
            // 
            // lblCodigoModeloMensagem
            // 
            lblCodigoModeloMensagem.AutoSize = true;
            lblCodigoModeloMensagem.Location = new Point(12, 28);
            lblCodigoModeloMensagem.Name = "lblCodigoModeloMensagem";
            lblCodigoModeloMensagem.Size = new Size(61, 20);
            lblCodigoModeloMensagem.TabIndex = 3;
            lblCodigoModeloMensagem.Text = "Código:";
            // 
            // lblDescricaoModeloMsg
            // 
            lblDescricaoModeloMsg.AutoSize = true;
            lblDescricaoModeloMsg.Location = new Point(111, 28);
            lblDescricaoModeloMsg.Name = "lblDescricaoModeloMsg";
            lblDescricaoModeloMsg.Size = new Size(77, 20);
            lblDescricaoModeloMsg.TabIndex = 4;
            lblDescricaoModeloMsg.Text = "Descrição:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(526, 28);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 5;
            label1.Text = "Situação:";
            // 
            // txtMensagemEnviar
            // 
            txtMensagemEnviar.Location = new Point(5, 26);
            txtMensagemEnviar.Multiline = true;
            txtMensagemEnviar.Name = "txtMensagemEnviar";
            txtMensagemEnviar.ReadOnly = true;
            txtMensagemEnviar.Size = new Size(659, 315);
            txtMensagemEnviar.TabIndex = 6;
            // 
            // grpBoxModeloMsg
            // 
            grpBoxModeloMsg.Controls.Add(txtMensagemEnviar);
            grpBoxModeloMsg.Location = new Point(7, 126);
            grpBoxModeloMsg.Name = "grpBoxModeloMsg";
            grpBoxModeloMsg.Size = new Size(670, 366);
            grpBoxModeloMsg.TabIndex = 7;
            grpBoxModeloMsg.TabStop = false;
            grpBoxModeloMsg.Text = "Modelo da Mensagem";
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.LightGreen;
            btnNovo.FlatStyle = FlatStyle.Popup;
            btnNovo.Image = (Image)resources.GetObject("btnNovo.Image");
            btnNovo.Location = new Point(199, 513);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(131, 44);
            btnNovo.TabIndex = 8;
            btnNovo.Text = "Novo";
            btnNovo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Gold;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.Location = new Point(336, 513);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(131, 44);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.Aqua;
            btnPesquisar.FlatStyle = FlatStyle.Popup;
            btnPesquisar.Image = Properties.Resources.lupa;
            btnPesquisar.Location = new Point(546, 513);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(131, 44);
            btnPesquisar.TabIndex = 10;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Salmon;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnCancelar.Location = new Point(336, 513);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 44);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.LightGreen;
            btnSalvar.FlatStyle = FlatStyle.Popup;
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.Location = new Point(199, 513);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(131, 44);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // frmCadastroMensagemCobranca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 569);
            Controls.Add(btnPesquisar);
            Controls.Add(btnEditar);
            Controls.Add(grpBoxModeloMsg);
            Controls.Add(label1);
            Controls.Add(lblDescricaoModeloMsg);
            Controls.Add(lblCodigoModeloMensagem);
            Controls.Add(cmbBoxSituacaoModeloMsg);
            Controls.Add(txtDescricaoModeloMsg);
            Controls.Add(txtCodigoModeloMsg);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnSalvar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCadastroMensagemCobranca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro - Mensagem (WhatsApp)";
            grpBoxModeloMsg.ResumeLayout(false);
            grpBoxModeloMsg.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigoModeloMsg;
        private TextBox txtDescricaoModeloMsg;
        private ComboBox cmbBoxSituacaoModeloMsg;
        private Label lblCodigoModeloMensagem;
        private Label lblDescricaoModeloMsg;
        private Label label1;
        private TextBox txtMensagemEnviar;
        private GroupBox grpBoxModeloMsg;
        private Button btnNovo;
        private Button btnEditar;
        private Button btnPesquisar;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}
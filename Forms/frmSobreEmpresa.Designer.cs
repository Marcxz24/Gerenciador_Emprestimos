namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmSobreEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSobreEmpresa));
            panel1 = new Panel();
            lblNomeSistema = new Label();
            lblVersaoSistema = new Label();
            lblNomeDesenvolvedor = new Label();
            lblObjetivoSistema = new Label();
            lblIndicaTelefones = new Label();
            lblTelefones = new Label();
            linkLblGitHub = new LinkLabel();
            btnOkFecharTela = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(3, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 297);
            panel1.TabIndex = 1;
            // 
            // lblNomeSistema
            // 
            lblNomeSistema.AutoSize = true;
            lblNomeSistema.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeSistema.Location = new Point(145, 9);
            lblNomeSistema.Name = "lblNomeSistema";
            lblNomeSistema.Size = new Size(524, 50);
            lblNomeSistema.TabIndex = 2;
            lblNomeSistema.Text = "Gerenciador de Emprestimos";
            // 
            // lblVersaoSistema
            // 
            lblVersaoSistema.AutoSize = true;
            lblVersaoSistema.Location = new Point(340, 59);
            lblVersaoSistema.Name = "lblVersaoSistema";
            lblVersaoSistema.Size = new Size(138, 28);
            lblVersaoSistema.TabIndex = 3;
            lblVersaoSistema.Text = "Versão: 2.1.0";
            // 
            // lblNomeDesenvolvedor
            // 
            lblNomeDesenvolvedor.AutoSize = true;
            lblNomeDesenvolvedor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeDesenvolvedor.Location = new Point(312, 155);
            lblNomeDesenvolvedor.Name = "lblNomeDesenvolvedor";
            lblNomeDesenvolvedor.Size = new Size(460, 28);
            lblNomeDesenvolvedor.TabIndex = 4;
            lblNomeDesenvolvedor.Text = "Desenvolvido por Marco Antônio Queiroz Ribeiro";
            // 
            // lblObjetivoSistema
            // 
            lblObjetivoSistema.AutoSize = true;
            lblObjetivoSistema.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObjetivoSistema.Location = new Point(312, 231);
            lblObjetivoSistema.Name = "lblObjetivoSistema";
            lblObjetivoSistema.Size = new Size(178, 23);
            lblObjetivoSistema.TabIndex = 5;
            lblObjetivoSistema.Text = "Objetivo do Sistema:";
            // 
            // lblIndicaTelefones
            // 
            lblIndicaTelefones.AutoSize = true;
            lblIndicaTelefones.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblIndicaTelefones.Location = new Point(312, 398);
            lblIndicaTelefones.Name = "lblIndicaTelefones";
            lblIndicaTelefones.Size = new Size(89, 23);
            lblIndicaTelefones.TabIndex = 9;
            lblIndicaTelefones.Text = "Telefones:";
            // 
            // lblTelefones
            // 
            lblTelefones.AutoSize = true;
            lblTelefones.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefones.Location = new Point(312, 421);
            lblTelefones.Name = "lblTelefones";
            lblTelefones.Size = new Size(282, 23);
            lblTelefones.TabIndex = 10;
            lblTelefones.Text = "(38) 99942-4821 ou (38) 99133-4465";
            // 
            // linkLblGitHub
            // 
            linkLblGitHub.AutoSize = true;
            linkLblGitHub.Font = new Font("Segoe UI", 10.2F);
            linkLblGitHub.Location = new Point(407, 195);
            linkLblGitHub.Name = "linkLblGitHub";
            linkLblGitHub.Size = new Size(233, 23);
            linkLblGitHub.TabIndex = 11;
            linkLblGitHub.TabStop = true;
            linkLblGitHub.Text = "https://github.com/Marcxz24";
            linkLblGitHub.LinkClicked += linkLblGitHub_LinkClicked;
            // 
            // btnOkFecharTela
            // 
            btnOkFecharTela.FlatStyle = FlatStyle.Flat;
            btnOkFecharTela.Location = new Point(286, 460);
            btnOkFecharTela.Name = "btnOkFecharTela";
            btnOkFecharTela.Size = new Size(233, 58);
            btnOkFecharTela.TabIndex = 12;
            btnOkFecharTela.Text = "OK";
            btnOkFecharTela.UseVisualStyleBackColor = true;
            btnOkFecharTela.Click += btnOkFecharTela_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(312, 254);
            label1.Name = "label1";
            label1.Size = new Size(480, 92);
            label1.TabIndex = 13;
            label1.Text = "Automatizar e otimizar o controle de empréstimos e clientes, \r\ngarantindo maior segurança, agilidade e precisão \r\nno acompanhamento de parcelas, \r\npagamentos e relatórios financeiros.\r\n";
            // 
            // frmSobreEmpresa
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 530);
            Controls.Add(label1);
            Controls.Add(btnOkFecharTela);
            Controls.Add(linkLblGitHub);
            Controls.Add(lblTelefones);
            Controls.Add(lblIndicaTelefones);
            Controls.Add(lblObjetivoSistema);
            Controls.Add(lblNomeDesenvolvedor);
            Controls.Add(lblVersaoSistema);
            Controls.Add(lblNomeSistema);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSobreEmpresa";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sobre";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblNomeSistema;
        private Label lblVersaoSistema;
        private Label lblNomeDesenvolvedor;
        private Label lblObjetivoSistema;
        private Label lblIndicaTelefones;
        private Label lblTelefones;
        private LinkLabel linkLblGitHub;
        private Button btnOkFecharTela;
        private Label label1;
    }
}
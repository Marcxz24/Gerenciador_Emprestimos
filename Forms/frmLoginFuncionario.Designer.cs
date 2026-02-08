namespace Gerenciador_de_Emprestimos
{
    partial class frmLoginFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginFuncionario));
            lblLoginFunconario = new Label();
            lblUsername = new Label();
            lblSenha = new Label();
            txtBoxUsername = new TextBox();
            txtBoxSenha = new TextBox();
            btnLogarUsuario = new Button();
            picBoxLogoLogin = new PictureBox();
            panelLogoSistem = new Panel();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoLogin).BeginInit();
            panelLogoSistem.SuspendLayout();
            SuspendLayout();
            // 
            // lblLoginFunconario
            // 
            lblLoginFunconario.AutoSize = true;
            lblLoginFunconario.BackColor = Color.Transparent;
            lblLoginFunconario.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginFunconario.Location = new Point(142, 29);
            lblLoginFunconario.Name = "lblLoginFunconario";
            lblLoginFunconario.Size = new Size(301, 33);
            lblLoginFunconario.TabIndex = 0;
            lblLoginFunconario.Text = "Login de Funcionário";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(8, 360);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(67, 18);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Usuário:";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.BackColor = Color.Transparent;
            lblSenha.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSenha.Location = new Point(18, 405);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(57, 18);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha:";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(81, 354);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.Size = new Size(421, 27);
            txtBoxUsername.TabIndex = 3;
            txtBoxUsername.Leave += txtBoxUsername_Leave;
            // 
            // txtBoxSenha
            // 
            txtBoxSenha.Location = new Point(81, 399);
            txtBoxSenha.Name = "txtBoxSenha";
            txtBoxSenha.Size = new Size(421, 27);
            txtBoxSenha.TabIndex = 4;
            txtBoxSenha.UseSystemPasswordChar = true;
            // 
            // btnLogarUsuario
            // 
            btnLogarUsuario.BackColor = Color.PaleTurquoise;
            btnLogarUsuario.Location = new Point(131, 437);
            btnLogarUsuario.Name = "btnLogarUsuario";
            btnLogarUsuario.Size = new Size(301, 77);
            btnLogarUsuario.TabIndex = 5;
            btnLogarUsuario.Text = "Logar com Usuário";
            btnLogarUsuario.UseVisualStyleBackColor = false;
            btnLogarUsuario.Click += btnLogarUsuario_Click;
            // 
            // picBoxLogoLogin
            // 
            picBoxLogoLogin.BackColor = Color.Transparent;
            picBoxLogoLogin.Dock = DockStyle.Fill;
            picBoxLogoLogin.Image = Properties.Resources.emprestimo_seguro;
            picBoxLogoLogin.Location = new Point(0, 0);
            picBoxLogoLogin.Name = "picBoxLogoLogin";
            picBoxLogoLogin.Size = new Size(274, 283);
            picBoxLogoLogin.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxLogoLogin.TabIndex = 6;
            picBoxLogoLogin.TabStop = false;
            // 
            // panelLogoSistem
            // 
            panelLogoSistem.BackColor = Color.Transparent;
            panelLogoSistem.Controls.Add(picBoxLogoLogin);
            panelLogoSistem.Location = new Point(142, 65);
            panelLogoSistem.Name = "panelLogoSistem";
            panelLogoSistem.Size = new Size(274, 283);
            panelLogoSistem.TabIndex = 7;
            // 
            // frmLoginFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(532, 549);
            Controls.Add(panelLogoSistem);
            Controls.Add(btnLogarUsuario);
            Controls.Add(txtBoxSenha);
            Controls.Add(txtBoxUsername);
            Controls.Add(lblSenha);
            Controls.Add(lblUsername);
            Controls.Add(lblLoginFunconario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLoginFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Gerenciador de Emprestimos";
            TopMost = true;
            Load += frmLoginFuncionario_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxLogoLogin).EndInit();
            panelLogoSistem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginFunconario;
        private Label lblUsername;
        private Label lblSenha;
        private TextBox txtBoxUsername;
        private TextBox txtBoxSenha;
        private Button btnLogarUsuario;
        private PictureBox picBoxLogoLogin;
        private Panel panelLogoSistem;
    }
}
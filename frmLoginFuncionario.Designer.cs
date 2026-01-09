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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblLoginFunconario
            // 
            lblLoginFunconario.AutoSize = true;
            lblLoginFunconario.BackColor = Color.Transparent;
            lblLoginFunconario.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginFunconario.Location = new Point(186, 29);
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
            lblUsername.Location = new Point(63, 326);
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
            lblSenha.Location = new Point(73, 371);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(57, 18);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha:";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Location = new Point(136, 321);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.Size = new Size(421, 27);
            txtBoxUsername.TabIndex = 3;
            // 
            // txtBoxSenha
            // 
            txtBoxSenha.Location = new Point(136, 366);
            txtBoxSenha.Name = "txtBoxSenha";
            txtBoxSenha.Size = new Size(421, 27);
            txtBoxSenha.TabIndex = 4;
            // 
            // btnLogarUsuario
            // 
            btnLogarUsuario.BackColor = Color.PaleTurquoise;
            btnLogarUsuario.Location = new Point(186, 444);
            btnLogarUsuario.Name = "btnLogarUsuario";
            btnLogarUsuario.Size = new Size(301, 77);
            btnLogarUsuario.TabIndex = 5;
            btnLogarUsuario.Text = "Logar com Usuário";
            btnLogarUsuario.UseVisualStyleBackColor = false;
            btnLogarUsuario.Click += btnLogarUsuario_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.emprestimo_seguro;
            pictureBox1.Location = new Point(232, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 250);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // frmLoginFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(704, 551);
            Controls.Add(pictureBox1);
            Controls.Add(btnLogarUsuario);
            Controls.Add(txtBoxSenha);
            Controls.Add(txtBoxUsername);
            Controls.Add(lblSenha);
            Controls.Add(lblUsername);
            Controls.Add(lblLoginFunconario);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLoginFuncionario";
            Text = "Login - Gerenciador de Emprestimos";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
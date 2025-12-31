namespace Gerenciador_de_Emprestimos
{
    partial class frmPagamentoEmprestimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentoEmprestimo));
            grpBoxDadosParcela = new GroupBox();
            btnLimparDadosTela = new Button();
            btnLocalizarEmprestimo = new Button();
            btnLocalizarCliente = new Button();
            lblStatusEmprestimo = new Label();
            txtBoxStatusEmprestimo = new TextBox();
            lblCodigoEmprestimo = new Label();
            txtBoxCodigoEmprestimo = new TextBox();
            lblCliente = new Label();
            txtBoxCliente = new TextBox();
            lblCodigoCliente = new Label();
            txtBoxCodigoCliente = new TextBox();
            grpBoxDadosParcela.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxDadosParcela
            // 
            grpBoxDadosParcela.BackColor = Color.Transparent;
            grpBoxDadosParcela.Controls.Add(btnLimparDadosTela);
            grpBoxDadosParcela.Controls.Add(btnLocalizarEmprestimo);
            grpBoxDadosParcela.Controls.Add(btnLocalizarCliente);
            grpBoxDadosParcela.Controls.Add(lblStatusEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxStatusEmprestimo);
            grpBoxDadosParcela.Controls.Add(lblCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoEmprestimo);
            grpBoxDadosParcela.Controls.Add(lblCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCliente);
            grpBoxDadosParcela.Controls.Add(lblCodigoCliente);
            grpBoxDadosParcela.Controls.Add(txtBoxCodigoCliente);
            grpBoxDadosParcela.Location = new Point(12, 12);
            grpBoxDadosParcela.Name = "grpBoxDadosParcela";
            grpBoxDadosParcela.Size = new Size(809, 178);
            grpBoxDadosParcela.TabIndex = 0;
            grpBoxDadosParcela.TabStop = false;
            // 
            // btnLimparDadosTela
            // 
            btnLimparDadosTela.BackColor = Color.Salmon;
            btnLimparDadosTela.FlatStyle = FlatStyle.Popup;
            btnLimparDadosTela.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparDadosTela.Location = new Point(307, 132);
            btnLimparDadosTela.Name = "btnLimparDadosTela";
            btnLimparDadosTela.Size = new Size(220, 40);
            btnLimparDadosTela.TabIndex = 10;
            btnLimparDadosTela.Text = "Limpar Dados";
            btnLimparDadosTela.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDadosTela.UseVisualStyleBackColor = false;
            btnLimparDadosTela.Click += btnLimparDadosTela_Click;
            // 
            // btnLocalizarEmprestimo
            // 
            btnLocalizarEmprestimo.BackColor = Color.Aqua;
            btnLocalizarEmprestimo.FlatStyle = FlatStyle.Popup;
            btnLocalizarEmprestimo.Image = Properties.Resources.lupa;
            btnLocalizarEmprestimo.Location = new Point(542, 132);
            btnLocalizarEmprestimo.Name = "btnLocalizarEmprestimo";
            btnLocalizarEmprestimo.Size = new Size(220, 40);
            btnLocalizarEmprestimo.TabIndex = 9;
            btnLocalizarEmprestimo.Text = "Localizar Emprestimo";
            btnLocalizarEmprestimo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocalizarEmprestimo.UseVisualStyleBackColor = false;
            btnLocalizarEmprestimo.Click += btnLocalizarEmprestimo_Click;
            // 
            // btnLocalizarCliente
            // 
            btnLocalizarCliente.BackColor = Color.Aqua;
            btnLocalizarCliente.FlatStyle = FlatStyle.Popup;
            btnLocalizarCliente.Image = Properties.Resources.lupa;
            btnLocalizarCliente.Location = new Point(71, 132);
            btnLocalizarCliente.Name = "btnLocalizarCliente";
            btnLocalizarCliente.Size = new Size(220, 40);
            btnLocalizarCliente.TabIndex = 8;
            btnLocalizarCliente.Text = "Localizar Cliente";
            btnLocalizarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLocalizarCliente.UseVisualStyleBackColor = false;
            btnLocalizarCliente.Click += btnLocalizarCliente_Click;
            // 
            // lblStatusEmprestimo
            // 
            lblStatusEmprestimo.AutoSize = true;
            lblStatusEmprestimo.Location = new Point(390, 96);
            lblStatusEmprestimo.Name = "lblStatusEmprestimo";
            lblStatusEmprestimo.Size = new Size(158, 20);
            lblStatusEmprestimo.TabIndex = 7;
            lblStatusEmprestimo.Text = "Status do Emprestimo:";
            // 
            // txtBoxStatusEmprestimo
            // 
            txtBoxStatusEmprestimo.Location = new Point(551, 93);
            txtBoxStatusEmprestimo.Name = "txtBoxStatusEmprestimo";
            txtBoxStatusEmprestimo.ReadOnly = true;
            txtBoxStatusEmprestimo.Size = new Size(254, 27);
            txtBoxStatusEmprestimo.TabIndex = 6;
            // 
            // lblCodigoEmprestimo
            // 
            lblCodigoEmprestimo.AutoSize = true;
            lblCodigoEmprestimo.Location = new Point(381, 48);
            lblCodigoEmprestimo.Name = "lblCodigoEmprestimo";
            lblCodigoEmprestimo.Size = new Size(167, 20);
            lblCodigoEmprestimo.TabIndex = 5;
            lblCodigoEmprestimo.Text = "Codigo do Emprestimo:";
            // 
            // txtBoxCodigoEmprestimo
            // 
            txtBoxCodigoEmprestimo.Location = new Point(551, 45);
            txtBoxCodigoEmprestimo.Name = "txtBoxCodigoEmprestimo";
            txtBoxCodigoEmprestimo.ReadOnly = true;
            txtBoxCodigoEmprestimo.Size = new Size(254, 27);
            txtBoxCodigoEmprestimo.TabIndex = 4;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 93);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 3;
            lblCliente.Text = "Cliente:";
            // 
            // txtBoxCliente
            // 
            txtBoxCliente.Location = new Point(70, 93);
            txtBoxCliente.Name = "txtBoxCliente";
            txtBoxCliente.ReadOnly = true;
            txtBoxCliente.Size = new Size(305, 27);
            txtBoxCliente.TabIndex = 2;
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(6, 42);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(61, 20);
            lblCodigoCliente.TabIndex = 1;
            lblCodigoCliente.Text = "Codigo:";
            // 
            // txtBoxCodigoCliente
            // 
            txtBoxCodigoCliente.Location = new Point(70, 42);
            txtBoxCodigoCliente.Name = "txtBoxCodigoCliente";
            txtBoxCodigoCliente.ReadOnly = true;
            txtBoxCodigoCliente.Size = new Size(305, 27);
            txtBoxCodigoCliente.TabIndex = 0;
            // 
            // frmPagamentoEmprestimo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            ClientSize = new Size(833, 836);
            Controls.Add(grpBoxDadosParcela);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPagamentoEmprestimo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamento de Parcelas";
            grpBoxDadosParcela.ResumeLayout(false);
            grpBoxDadosParcela.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxDadosParcela;
        private Label lblCodigoCliente;
        private TextBox txtBoxCodigoCliente;
        private Label lblCliente;
        private TextBox txtBoxCliente;
        private Label lblStatusEmprestimo;
        private TextBox txtBoxStatusEmprestimo;
        private Label lblCodigoEmprestimo;
        private TextBox txtBoxCodigoEmprestimo;
        private Button btnLocalizarCliente;
        private Button btnLocalizarEmprestimo;
        private Button btnLimparDadosTela;
    }
}
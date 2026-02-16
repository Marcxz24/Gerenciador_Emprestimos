namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmNovoLembrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovoLembrete));
            txtDescricao = new TextBox();
            lblTutuloLembrete = new Label();
            txtTitulo = new TextBox();
            lblDescricaoLembrete = new Label();
            btnSalvarLembrete = new Button();
            SuspendLayout();
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(3, 67);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(433, 350);
            txtDescricao.TabIndex = 0;
            // 
            // lblTutuloLembrete
            // 
            lblTutuloLembrete.AutoSize = true;
            lblTutuloLembrete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTutuloLembrete.Location = new Point(3, 9);
            lblTutuloLembrete.Name = "lblTutuloLembrete";
            lblTutuloLembrete.Size = new Size(54, 20);
            lblTutuloLembrete.TabIndex = 1;
            lblTutuloLembrete.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(59, 6);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(377, 27);
            txtTitulo.TabIndex = 2;
            // 
            // lblDescricaoLembrete
            // 
            lblDescricaoLembrete.AutoSize = true;
            lblDescricaoLembrete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescricaoLembrete.Location = new Point(3, 44);
            lblDescricaoLembrete.Name = "lblDescricaoLembrete";
            lblDescricaoLembrete.Size = new Size(93, 20);
            lblDescricaoLembrete.TabIndex = 3;
            lblDescricaoLembrete.Text = "Descrição: ⬇️";
            // 
            // btnSalvarLembrete
            // 
            btnSalvarLembrete.FlatStyle = FlatStyle.Popup;
            btnSalvarLembrete.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarLembrete.Image = Properties.Resources.salvar;
            btnSalvarLembrete.Location = new Point(152, 423);
            btnSalvarLembrete.Name = "btnSalvarLembrete";
            btnSalvarLembrete.Size = new Size(119, 37);
            btnSalvarLembrete.TabIndex = 4;
            btnSalvarLembrete.Text = "Salvar";
            btnSalvarLembrete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalvarLembrete.UseVisualStyleBackColor = true;
            btnSalvarLembrete.Click += btnSalvarLembrete_Click;
            // 
            // frmNovoLembrete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(437, 464);
            Controls.Add(btnSalvarLembrete);
            Controls.Add(lblDescricaoLembrete);
            Controls.Add(txtTitulo);
            Controls.Add(lblTutuloLembrete);
            Controls.Add(txtDescricao);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNovoLembrete";
            Text = "Lembretes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescricao;
        private Label lblTutuloLembrete;
        private TextBox txtTitulo;
        private Label lblDescricaoLembrete;
        private Button btnSalvarLembrete;
    }
}
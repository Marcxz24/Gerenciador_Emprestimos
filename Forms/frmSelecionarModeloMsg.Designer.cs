namespace Gerenciador_de_Emprestimos.Forms
{
    partial class frmSelecionarModeloMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionarModeloMsg));
            txtCodigoModMsg = new TextBox();
            grpFiltrosPesquisa = new GroupBox();
            btnPesquisarModMsg = new Button();
            cmbBoxSituacaoModMsg = new ComboBox();
            lblSituacaoModMsg = new Label();
            lblDescricaoModMsg = new Label();
            txtDescricaoModMsg = new TextBox();
            lblCodigoModMsg = new Label();
            dtGridModeloMsg = new DataGridView();
            btnLimparDados = new Button();
            grpFiltrosPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridModeloMsg).BeginInit();
            SuspendLayout();
            // 
            // txtCodigoModMsg
            // 
            txtCodigoModMsg.Location = new Point(21, 58);
            txtCodigoModMsg.Name = "txtCodigoModMsg";
            txtCodigoModMsg.Size = new Size(125, 27);
            txtCodigoModMsg.TabIndex = 0;
            // 
            // grpFiltrosPesquisa
            // 
            grpFiltrosPesquisa.Controls.Add(btnPesquisarModMsg);
            grpFiltrosPesquisa.Controls.Add(cmbBoxSituacaoModMsg);
            grpFiltrosPesquisa.Controls.Add(lblSituacaoModMsg);
            grpFiltrosPesquisa.Controls.Add(lblDescricaoModMsg);
            grpFiltrosPesquisa.Controls.Add(txtDescricaoModMsg);
            grpFiltrosPesquisa.Controls.Add(lblCodigoModMsg);
            grpFiltrosPesquisa.Controls.Add(txtCodigoModMsg);
            grpFiltrosPesquisa.Location = new Point(12, 12);
            grpFiltrosPesquisa.Name = "grpFiltrosPesquisa";
            grpFiltrosPesquisa.Size = new Size(642, 176);
            grpFiltrosPesquisa.TabIndex = 1;
            grpFiltrosPesquisa.TabStop = false;
            grpFiltrosPesquisa.Text = "Filtros de Pesquisa";
            // 
            // btnPesquisarModMsg
            // 
            btnPesquisarModMsg.BackColor = Color.Turquoise;
            btnPesquisarModMsg.FlatStyle = FlatStyle.Popup;
            btnPesquisarModMsg.Image = Properties.Resources.lupa;
            btnPesquisarModMsg.Location = new Point(212, 106);
            btnPesquisarModMsg.Name = "btnPesquisarModMsg";
            btnPesquisarModMsg.Size = new Size(191, 49);
            btnPesquisarModMsg.TabIndex = 6;
            btnPesquisarModMsg.Text = "Pesquisar";
            btnPesquisarModMsg.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisarModMsg.UseVisualStyleBackColor = false;
            btnPesquisarModMsg.Click += btnPesquisarModMsg_Click;
            // 
            // cmbBoxSituacaoModMsg
            // 
            cmbBoxSituacaoModMsg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxSituacaoModMsg.FormattingEnabled = true;
            cmbBoxSituacaoModMsg.Items.AddRange(new object[] { "ATIVO", "INATIVO", "TODOS" });
            cmbBoxSituacaoModMsg.Location = new Point(479, 57);
            cmbBoxSituacaoModMsg.Name = "cmbBoxSituacaoModMsg";
            cmbBoxSituacaoModMsg.Size = new Size(151, 28);
            cmbBoxSituacaoModMsg.TabIndex = 5;
            // 
            // lblSituacaoModMsg
            // 
            lblSituacaoModMsg.AutoSize = true;
            lblSituacaoModMsg.Location = new Point(479, 35);
            lblSituacaoModMsg.Name = "lblSituacaoModMsg";
            lblSituacaoModMsg.Size = new Size(66, 20);
            lblSituacaoModMsg.TabIndex = 4;
            lblSituacaoModMsg.Text = "Situação";
            // 
            // lblDescricaoModMsg
            // 
            lblDescricaoModMsg.AutoSize = true;
            lblDescricaoModMsg.Location = new Point(152, 35);
            lblDescricaoModMsg.Name = "lblDescricaoModMsg";
            lblDescricaoModMsg.Size = new Size(74, 20);
            lblDescricaoModMsg.TabIndex = 3;
            lblDescricaoModMsg.Text = "Descrição";
            // 
            // txtDescricaoModMsg
            // 
            txtDescricaoModMsg.Location = new Point(152, 58);
            txtDescricaoModMsg.Name = "txtDescricaoModMsg";
            txtDescricaoModMsg.Size = new Size(314, 27);
            txtDescricaoModMsg.TabIndex = 2;
            // 
            // lblCodigoModMsg
            // 
            lblCodigoModMsg.AutoSize = true;
            lblCodigoModMsg.Location = new Point(21, 35);
            lblCodigoModMsg.Name = "lblCodigoModMsg";
            lblCodigoModMsg.Size = new Size(58, 20);
            lblCodigoModMsg.TabIndex = 1;
            lblCodigoModMsg.Text = "Código";
            // 
            // dtGridModeloMsg
            // 
            dtGridModeloMsg.AllowUserToAddRows = false;
            dtGridModeloMsg.AllowUserToDeleteRows = false;
            dtGridModeloMsg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridModeloMsg.Location = new Point(12, 194);
            dtGridModeloMsg.Name = "dtGridModeloMsg";
            dtGridModeloMsg.ReadOnly = true;
            dtGridModeloMsg.RowHeadersWidth = 51;
            dtGridModeloMsg.Size = new Size(642, 385);
            dtGridModeloMsg.TabIndex = 2;
            dtGridModeloMsg.CellDoubleClick += dtGridModeloMsg_CellDoubleClick;
            // 
            // btnLimparDados
            // 
            btnLimparDados.BackColor = Color.Salmon;
            btnLimparDados.FlatStyle = FlatStyle.Popup;
            btnLimparDados.Image = Properties.Resources.close_256_icon_icons_com_75990;
            btnLimparDados.Location = new Point(224, 585);
            btnLimparDados.Name = "btnLimparDados";
            btnLimparDados.Size = new Size(191, 49);
            btnLimparDados.TabIndex = 7;
            btnLimparDados.Text = "Limpar";
            btnLimparDados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimparDados.UseVisualStyleBackColor = false;
            btnLimparDados.Click += btnLimparDados_Click;
            // 
            // frmSelecionarModeloMsg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 646);
            Controls.Add(btnLimparDados);
            Controls.Add(dtGridModeloMsg);
            Controls.Add(grpFiltrosPesquisa);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelecionarModeloMsg";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selecionar Modelo de Mensagem";
            grpFiltrosPesquisa.ResumeLayout(false);
            grpFiltrosPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridModeloMsg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCodigoModMsg;
        private GroupBox grpFiltrosPesquisa;
        private Label lblCodigoModMsg;
        private Label lblDescricaoModMsg;
        private TextBox txtDescricaoModMsg;
        private Label lblSituacaoModMsg;
        private ComboBox cmbBoxSituacaoModMsg;
        private Button btnPesquisarModMsg;
        private DataGridView dtGridModeloMsg;
        private Button btnLimparDados;
    }
}
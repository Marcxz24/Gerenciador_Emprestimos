namespace Gerenciador_de_Emprestimos
{
    partial class FormEmprestimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmprestimos));
            groupBoxClienteEmprestimo = new GroupBox();
            btnBuscarCliente = new Button();
            lblCpfCnpjCliente = new Label();
            maskTxtCpfCnpjCliente = new MaskedTextBox();
            txtBoxNomeCliente = new TextBox();
            lblNomeCliente = new Label();
            lblCodigoCliente = new Label();
            txtBoxCodigoCliente = new TextBox();
            groupBoxDadosEmprestimos = new GroupBox();
            maskTxtDataEmprestimo = new MaskedTextBox();
            lblDataEmprestimo = new Label();
            txtBoxTaxaJuros = new TextBox();
            lblTaxaJuros = new Label();
            lblValorEmprestado = new Label();
            txtBoxValorEmprestado = new TextBox();
            groupBoxCalculo = new GroupBox();
            txtBoxTotalPagar = new TextBox();
            lblTotalPagar = new Label();
            lblValorJuros = new Label();
            txtBoxValorJuros = new TextBox();
            btnCalcularEmprestimo = new Button();
            btnCancelar = new Button();
            btnGerarEmprestimos = new Button();
            groupBoxClienteEmprestimo.SuspendLayout();
            groupBoxDadosEmprestimos.SuspendLayout();
            groupBoxCalculo.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxClienteEmprestimo
            // 
            groupBoxClienteEmprestimo.BackColor = Color.Transparent;
            groupBoxClienteEmprestimo.Controls.Add(btnBuscarCliente);
            groupBoxClienteEmprestimo.Controls.Add(lblCpfCnpjCliente);
            groupBoxClienteEmprestimo.Controls.Add(maskTxtCpfCnpjCliente);
            groupBoxClienteEmprestimo.Controls.Add(txtBoxNomeCliente);
            groupBoxClienteEmprestimo.Controls.Add(lblNomeCliente);
            groupBoxClienteEmprestimo.Controls.Add(lblCodigoCliente);
            groupBoxClienteEmprestimo.Controls.Add(txtBoxCodigoCliente);
            groupBoxClienteEmprestimo.Location = new Point(12, 12);
            groupBoxClienteEmprestimo.Name = "groupBoxClienteEmprestimo";
            groupBoxClienteEmprestimo.Size = new Size(809, 156);
            groupBoxClienteEmprestimo.TabIndex = 0;
            groupBoxClienteEmprestimo.TabStop = false;
            groupBoxClienteEmprestimo.Text = "Cliente";
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.PaleTurquoise;
            btnBuscarCliente.FlatStyle = FlatStyle.Popup;
            btnBuscarCliente.Image = (Image)resources.GetObject("btnBuscarCliente.Image");
            btnBuscarCliente.Location = new Point(378, 20);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(252, 44);
            btnBuscarCliente.TabIndex = 6;
            btnBuscarCliente.Text = "        Buscar";
            btnBuscarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // lblCpfCnpjCliente
            // 
            lblCpfCnpjCliente.AutoSize = true;
            lblCpfCnpjCliente.Location = new Point(457, 88);
            lblCpfCnpjCliente.Name = "lblCpfCnpjCliente";
            lblCpfCnpjCliente.Size = new Size(105, 20);
            lblCpfCnpjCliente.TabIndex = 5;
            lblCpfCnpjCliente.Text = "CPF do Cliente";
            // 
            // maskTxtCpfCnpjCliente
            // 
            maskTxtCpfCnpjCliente.Location = new Point(568, 88);
            maskTxtCpfCnpjCliente.Mask = "000,000,000-00";
            maskTxtCpfCnpjCliente.Name = "maskTxtCpfCnpjCliente";
            maskTxtCpfCnpjCliente.ReadOnly = true;
            maskTxtCpfCnpjCliente.Size = new Size(210, 27);
            maskTxtCpfCnpjCliente.TabIndex = 4;
            // 
            // txtBoxNomeCliente
            // 
            txtBoxNomeCliente.Location = new Point(142, 85);
            txtBoxNomeCliente.Name = "txtBoxNomeCliente";
            txtBoxNomeCliente.ReadOnly = true;
            txtBoxNomeCliente.Size = new Size(296, 27);
            txtBoxNomeCliente.TabIndex = 3;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Location = new Point(6, 88);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(122, 20);
            lblNomeCliente.TabIndex = 2;
            lblNomeCliente.Text = "Nome do Cliente";
            // 
            // lblCodigoCliente
            // 
            lblCodigoCliente.AutoSize = true;
            lblCodigoCliente.Location = new Point(6, 29);
            lblCodigoCliente.Name = "lblCodigoCliente";
            lblCodigoCliente.Size = new Size(130, 20);
            lblCodigoCliente.TabIndex = 1;
            lblCodigoCliente.Text = "Código do Cliente";
            // 
            // txtBoxCodigoCliente
            // 
            txtBoxCodigoCliente.Location = new Point(142, 22);
            txtBoxCodigoCliente.Name = "txtBoxCodigoCliente";
            txtBoxCodigoCliente.ReadOnly = true;
            txtBoxCodigoCliente.Size = new Size(125, 27);
            txtBoxCodigoCliente.TabIndex = 0;
            // 
            // groupBoxDadosEmprestimos
            // 
            groupBoxDadosEmprestimos.BackColor = Color.Transparent;
            groupBoxDadosEmprestimos.Controls.Add(maskTxtDataEmprestimo);
            groupBoxDadosEmprestimos.Controls.Add(lblDataEmprestimo);
            groupBoxDadosEmprestimos.Controls.Add(txtBoxTaxaJuros);
            groupBoxDadosEmprestimos.Controls.Add(lblTaxaJuros);
            groupBoxDadosEmprestimos.Controls.Add(lblValorEmprestado);
            groupBoxDadosEmprestimos.Controls.Add(txtBoxValorEmprestado);
            groupBoxDadosEmprestimos.Location = new Point(12, 190);
            groupBoxDadosEmprestimos.Name = "groupBoxDadosEmprestimos";
            groupBoxDadosEmprestimos.Size = new Size(809, 222);
            groupBoxDadosEmprestimos.TabIndex = 1;
            groupBoxDadosEmprestimos.TabStop = false;
            groupBoxDadosEmprestimos.Text = "Dados do Empréstimo";
            // 
            // maskTxtDataEmprestimo
            // 
            maskTxtDataEmprestimo.Location = new Point(168, 159);
            maskTxtDataEmprestimo.Mask = "00/00/0000";
            maskTxtDataEmprestimo.Name = "maskTxtDataEmprestimo";
            maskTxtDataEmprestimo.Size = new Size(210, 27);
            maskTxtDataEmprestimo.TabIndex = 7;
            // 
            // lblDataEmprestimo
            // 
            lblDataEmprestimo.AutoSize = true;
            lblDataEmprestimo.Location = new Point(15, 162);
            lblDataEmprestimo.Name = "lblDataEmprestimo";
            lblDataEmprestimo.Size = new Size(147, 20);
            lblDataEmprestimo.TabIndex = 12;
            lblDataEmprestimo.Text = "Data do Emprestimo";
            // 
            // txtBoxTaxaJuros
            // 
            txtBoxTaxaJuros.Location = new Point(168, 96);
            txtBoxTaxaJuros.Name = "txtBoxTaxaJuros";
            txtBoxTaxaJuros.Size = new Size(394, 27);
            txtBoxTaxaJuros.TabIndex = 10;
            // 
            // lblTaxaJuros
            // 
            lblTaxaJuros.AutoSize = true;
            lblTaxaJuros.Location = new Point(6, 99);
            lblTaxaJuros.Name = "lblTaxaJuros";
            lblTaxaJuros.Size = new Size(161, 20);
            lblTaxaJuros.TabIndex = 9;
            lblTaxaJuros.Text = "Percentual de Juros (%)";
            // 
            // lblValorEmprestado
            // 
            lblValorEmprestado.AutoSize = true;
            lblValorEmprestado.Location = new Point(32, 38);
            lblValorEmprestado.Name = "lblValorEmprestado";
            lblValorEmprestado.Size = new Size(127, 20);
            lblValorEmprestado.TabIndex = 8;
            lblValorEmprestado.Text = "Valor Emprestado";
            // 
            // txtBoxValorEmprestado
            // 
            txtBoxValorEmprestado.Location = new Point(168, 31);
            txtBoxValorEmprestado.Name = "txtBoxValorEmprestado";
            txtBoxValorEmprestado.Size = new Size(394, 27);
            txtBoxValorEmprestado.TabIndex = 7;
            // 
            // groupBoxCalculo
            // 
            groupBoxCalculo.BackColor = Color.Transparent;
            groupBoxCalculo.Controls.Add(txtBoxTotalPagar);
            groupBoxCalculo.Controls.Add(lblTotalPagar);
            groupBoxCalculo.Controls.Add(lblValorJuros);
            groupBoxCalculo.Controls.Add(txtBoxValorJuros);
            groupBoxCalculo.Location = new Point(12, 523);
            groupBoxCalculo.Name = "groupBoxCalculo";
            groupBoxCalculo.Size = new Size(809, 177);
            groupBoxCalculo.TabIndex = 2;
            groupBoxCalculo.TabStop = false;
            groupBoxCalculo.Text = "Cálculo";
            // 
            // txtBoxTotalPagar
            // 
            txtBoxTotalPagar.Location = new Point(151, 100);
            txtBoxTotalPagar.Name = "txtBoxTotalPagar";
            txtBoxTotalPagar.ReadOnly = true;
            txtBoxTotalPagar.Size = new Size(394, 27);
            txtBoxTotalPagar.TabIndex = 4;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Location = new Point(34, 103);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(95, 20);
            lblTotalPagar.TabIndex = 3;
            lblTotalPagar.Text = "Total a Pagar";
            // 
            // lblValorJuros
            // 
            lblValorJuros.AutoSize = true;
            lblValorJuros.Location = new Point(17, 36);
            lblValorJuros.Name = "lblValorJuros";
            lblValorJuros.Size = new Size(128, 20);
            lblValorJuros.TabIndex = 2;
            lblValorJuros.Text = "Valor do Juros (%)";
            // 
            // txtBoxValorJuros
            // 
            txtBoxValorJuros.Location = new Point(151, 29);
            txtBoxValorJuros.Name = "txtBoxValorJuros";
            txtBoxValorJuros.ReadOnly = true;
            txtBoxValorJuros.Size = new Size(394, 27);
            txtBoxValorJuros.TabIndex = 0;
            // 
            // btnCalcularEmprestimo
            // 
            btnCalcularEmprestimo.BackColor = Color.FromArgb(192, 255, 192);
            btnCalcularEmprestimo.FlatStyle = FlatStyle.Popup;
            btnCalcularEmprestimo.Image = (Image)resources.GetObject("btnCalcularEmprestimo.Image");
            btnCalcularEmprestimo.Location = new Point(214, 440);
            btnCalcularEmprestimo.Name = "btnCalcularEmprestimo";
            btnCalcularEmprestimo.Size = new Size(394, 63);
            btnCalcularEmprestimo.TabIndex = 5;
            btnCalcularEmprestimo.Text = "                  Calcular";
            btnCalcularEmprestimo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalcularEmprestimo.UseVisualStyleBackColor = false;
            btnCalcularEmprestimo.Click += btnCalcularEmprestimo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Salmon;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Arial", 7.8F, FontStyle.Bold);
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(447, 745);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(212, 79);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "       Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGerarEmprestimos
            // 
            btnGerarEmprestimos.BackColor = Color.LightSeaGreen;
            btnGerarEmprestimos.Cursor = Cursors.Hand;
            btnGerarEmprestimos.FlatStyle = FlatStyle.Popup;
            btnGerarEmprestimos.Font = new Font("Arial", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGerarEmprestimos.Image = (Image)resources.GetObject("btnGerarEmprestimos.Image");
            btnGerarEmprestimos.ImageAlign = ContentAlignment.TopLeft;
            btnGerarEmprestimos.Location = new Point(183, 745);
            btnGerarEmprestimos.Name = "btnGerarEmprestimos";
            btnGerarEmprestimos.Size = new Size(207, 79);
            btnGerarEmprestimos.TabIndex = 8;
            btnGerarEmprestimos.Text = "Gerar Emprestimo";
            btnGerarEmprestimos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGerarEmprestimos.UseVisualStyleBackColor = false;
            btnGerarEmprestimos.Click += btnGerarEmprestimos_Click;
            // 
            // FormEmprestimos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.gradience;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(833, 836);
            Controls.Add(btnCalcularEmprestimo);
            Controls.Add(btnGerarEmprestimos);
            Controls.Add(btnCancelar);
            Controls.Add(groupBoxCalculo);
            Controls.Add(groupBoxDadosEmprestimos);
            Controls.Add(groupBoxClienteEmprestimo);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEmprestimos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de Emprestimos";
            groupBoxClienteEmprestimo.ResumeLayout(false);
            groupBoxClienteEmprestimo.PerformLayout();
            groupBoxDadosEmprestimos.ResumeLayout(false);
            groupBoxDadosEmprestimos.PerformLayout();
            groupBoxCalculo.ResumeLayout(false);
            groupBoxCalculo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxClienteEmprestimo;
        private Label lblCodigoCliente;
        private TextBox txtBoxCodigoCliente;
        private TextBox txtBoxNomeCliente;
        private Label lblNomeCliente;
        private MaskedTextBox maskTxtCpfCnpjCliente;
        private Label lblCpfCnpjCliente;
        private Button btnBuscarCliente;
        private GroupBox groupBoxDadosEmprestimos;
        private Label lblValorEmprestado;
        private TextBox txtBoxValorEmprestado;
        private Label lblDataEmprestimo;
        private TextBox txtBoxTaxaJuros;
        private Label lblTaxaJuros;
        private MaskedTextBox maskTxtDataEmprestimo;
        private GroupBox groupBoxCalculo;
        private Label lblValorJuros;
        private TextBox txtBoxValorJuros;
        private TextBox txtBoxTotalPagar;
        private Label lblTotalPagar;
        private Button btnCalcularEmprestimo;
        private Button btnCancelar;
        private Button btnGerarEmprestimos;
    }
}
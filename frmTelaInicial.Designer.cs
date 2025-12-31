namespace Gerenciador_de_Emprestimos
{
    partial class FormTelaIncial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTelaIncial));
            lblTituloInicial = new Label();
            stsStripSistemVersion = new StatusStrip();
            toolStsStripSistemVersion = new ToolStripStatusLabel();
            MenuStripMenusSistema = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            sairDoSistemaToolStripMenuItem = new ToolStripMenuItem();
            MenuStripCadastro = new ToolStripMenuItem();
            MenuStripCliente = new ToolStripMenuItem();
            MenuStripCadastroCliente = new ToolStripMenuItem();
            MenuStripFinanceiro = new ToolStripMenuItem();
            MenuStripEmprestimos = new ToolStripMenuItem();
            MenuStripNovosEmprestimos = new ToolStripMenuItem();
            recebimentoDeParcelaToolStripMenuItem = new ToolStripMenuItem();
            visualizarEmprestimosToolStripMenuItem = new ToolStripMenuItem();
            MenuStripRelatorios = new ToolStripMenuItem();
            MenuStripRelatoriosEmprestimos = new ToolStripMenuItem();
            MenuStripRelatoriosVisuEmprestimos = new ToolStripMenuItem();
            imageListSistemaGerenciadorEmprestimos = new ImageList(components);
            picBoxTelaInicialSistema = new PictureBox();
            pictureBox1 = new PictureBox();
            lblTituloSistemas = new Label();
            stsStripSistemVersion.SuspendLayout();
            MenuStripMenusSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxTelaInicialSistema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTituloInicial
            // 
            resources.ApplyResources(lblTituloInicial, "lblTituloInicial");
            lblTituloInicial.BackColor = Color.Transparent;
            lblTituloInicial.Name = "lblTituloInicial";
            // 
            // stsStripSistemVersion
            // 
            resources.ApplyResources(stsStripSistemVersion, "stsStripSistemVersion");
            stsStripSistemVersion.ImageScalingSize = new Size(20, 20);
            stsStripSistemVersion.Items.AddRange(new ToolStripItem[] { toolStsStripSistemVersion });
            stsStripSistemVersion.Name = "stsStripSistemVersion";
            // 
            // toolStsStripSistemVersion
            // 
            resources.ApplyResources(toolStsStripSistemVersion, "toolStsStripSistemVersion");
            toolStsStripSistemVersion.Name = "toolStsStripSistemVersion";
            toolStsStripSistemVersion.Spring = true;
            // 
            // MenuStripMenusSistema
            // 
            resources.ApplyResources(MenuStripMenusSistema, "MenuStripMenusSistema");
            MenuStripMenusSistema.ImageScalingSize = new Size(20, 20);
            MenuStripMenusSistema.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, MenuStripCadastro, MenuStripFinanceiro, MenuStripRelatorios });
            MenuStripMenusSistema.Name = "MenuStripMenusSistema";
            // 
            // arquivoToolStripMenuItem
            // 
            resources.ApplyResources(arquivoToolStripMenuItem, "arquivoToolStripMenuItem");
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sairDoSistemaToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            // 
            // sairDoSistemaToolStripMenuItem
            // 
            resources.ApplyResources(sairDoSistemaToolStripMenuItem, "sairDoSistemaToolStripMenuItem");
            sairDoSistemaToolStripMenuItem.Name = "sairDoSistemaToolStripMenuItem";
            sairDoSistemaToolStripMenuItem.Click += sairDoSistemaToolStripMenuItem_Click;
            // 
            // MenuStripCadastro
            // 
            resources.ApplyResources(MenuStripCadastro, "MenuStripCadastro");
            MenuStripCadastro.DropDownItems.AddRange(new ToolStripItem[] { MenuStripCliente });
            MenuStripCadastro.Name = "MenuStripCadastro";
            // 
            // MenuStripCliente
            // 
            resources.ApplyResources(MenuStripCliente, "MenuStripCliente");
            MenuStripCliente.DropDownItems.AddRange(new ToolStripItem[] { MenuStripCadastroCliente });
            MenuStripCliente.Name = "MenuStripCliente";
            // 
            // MenuStripCadastroCliente
            // 
            resources.ApplyResources(MenuStripCadastroCliente, "MenuStripCadastroCliente");
            MenuStripCadastroCliente.Name = "MenuStripCadastroCliente";
            MenuStripCadastroCliente.Click += clienteToolStripMenuItem1_Click;
            // 
            // MenuStripFinanceiro
            // 
            resources.ApplyResources(MenuStripFinanceiro, "MenuStripFinanceiro");
            MenuStripFinanceiro.DropDownItems.AddRange(new ToolStripItem[] { MenuStripEmprestimos });
            MenuStripFinanceiro.Name = "MenuStripFinanceiro";
            // 
            // MenuStripEmprestimos
            // 
            resources.ApplyResources(MenuStripEmprestimos, "MenuStripEmprestimos");
            MenuStripEmprestimos.DropDownItems.AddRange(new ToolStripItem[] { MenuStripNovosEmprestimos, recebimentoDeParcelaToolStripMenuItem, visualizarEmprestimosToolStripMenuItem });
            MenuStripEmprestimos.Name = "MenuStripEmprestimos";
            // 
            // MenuStripNovosEmprestimos
            // 
            resources.ApplyResources(MenuStripNovosEmprestimos, "MenuStripNovosEmprestimos");
            MenuStripNovosEmprestimos.Name = "MenuStripNovosEmprestimos";
            MenuStripNovosEmprestimos.Click += novosEmprestimosToolStripMenuItem_Click;
            // 
            // recebimentoDeParcelaToolStripMenuItem
            // 
            resources.ApplyResources(recebimentoDeParcelaToolStripMenuItem, "recebimentoDeParcelaToolStripMenuItem");
            recebimentoDeParcelaToolStripMenuItem.Name = "recebimentoDeParcelaToolStripMenuItem";
            recebimentoDeParcelaToolStripMenuItem.Click += recebimentoDeParcelaToolStripMenuItem_Click;
            // 
            // visualizarEmprestimosToolStripMenuItem
            // 
            resources.ApplyResources(visualizarEmprestimosToolStripMenuItem, "visualizarEmprestimosToolStripMenuItem");
            visualizarEmprestimosToolStripMenuItem.Name = "visualizarEmprestimosToolStripMenuItem";
            visualizarEmprestimosToolStripMenuItem.Click += visualizarEmprestimosToolStripMenuItem_Click;
            // 
            // MenuStripRelatorios
            // 
            resources.ApplyResources(MenuStripRelatorios, "MenuStripRelatorios");
            MenuStripRelatorios.DropDownItems.AddRange(new ToolStripItem[] { MenuStripRelatoriosEmprestimos });
            MenuStripRelatorios.Name = "MenuStripRelatorios";
            // 
            // MenuStripRelatoriosEmprestimos
            // 
            resources.ApplyResources(MenuStripRelatoriosEmprestimos, "MenuStripRelatoriosEmprestimos");
            MenuStripRelatoriosEmprestimos.DropDownItems.AddRange(new ToolStripItem[] { MenuStripRelatoriosVisuEmprestimos });
            MenuStripRelatoriosEmprestimos.Name = "MenuStripRelatoriosEmprestimos";
            // 
            // MenuStripRelatoriosVisuEmprestimos
            // 
            resources.ApplyResources(MenuStripRelatoriosVisuEmprestimos, "MenuStripRelatoriosVisuEmprestimos");
            MenuStripRelatoriosVisuEmprestimos.Name = "MenuStripRelatoriosVisuEmprestimos";
            MenuStripRelatoriosVisuEmprestimos.Click += visualizarEmprestimosToolStripMenuItem1_Click;
            // 
            // imageListSistemaGerenciadorEmprestimos
            // 
            imageListSistemaGerenciadorEmprestimos.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListSistemaGerenciadorEmprestimos, "imageListSistemaGerenciadorEmprestimos");
            imageListSistemaGerenciadorEmprestimos.TransparentColor = Color.Transparent;
            // 
            // picBoxTelaInicialSistema
            // 
            resources.ApplyResources(picBoxTelaInicialSistema, "picBoxTelaInicialSistema");
            picBoxTelaInicialSistema.BackColor = Color.Transparent;
            picBoxTelaInicialSistema.Name = "picBoxTelaInicialSistema";
            picBoxTelaInicialSistema.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lblTituloSistemas
            // 
            resources.ApplyResources(lblTituloSistemas, "lblTituloSistemas");
            lblTituloSistemas.BackColor = Color.Transparent;
            lblTituloSistemas.Name = "lblTituloSistemas";
            // 
            // FormTelaIncial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gradience1;
            Controls.Add(picBoxTelaInicialSistema);
            Controls.Add(lblTituloSistemas);
            Controls.Add(lblTituloInicial);
            Controls.Add(pictureBox1);
            Controls.Add(stsStripSistemVersion);
            Controls.Add(MenuStripMenusSistema);
            DoubleBuffered = true;
            MainMenuStrip = MenuStripMenusSistema;
            Name = "FormTelaIncial";
            WindowState = FormWindowState.Maximized;
            stsStripSistemVersion.ResumeLayout(false);
            stsStripSistemVersion.PerformLayout();
            MenuStripMenusSistema.ResumeLayout(false);
            MenuStripMenusSistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxTelaInicialSistema).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTituloInicial;
        private StatusStrip stsStripSistemVersion;
        private ToolStripStatusLabel toolStsStripSistemVersion;
        private MenuStrip MenuStripMenusSistema;
        private ToolStripMenuItem MenuStripCadastro;
        private ToolStripMenuItem MenuStripCliente;
        private ToolStripMenuItem MenuStripCadastroCliente;
        private ToolStripMenuItem MenuStripFinanceiro;
        private ToolStripMenuItem MenuStripEmprestimos;
        private ToolStripMenuItem MenuStripNovosEmprestimos;
        private ToolStripMenuItem visualizarEmprestimosToolStripMenuItem;
        private ImageList imageListSistemaGerenciadorEmprestimos;
        private PictureBox picBoxTelaInicialSistema;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem sairDoSistemaToolStripMenuItem;
        private ToolStripMenuItem MenuStripRelatorios;
        private ToolStripMenuItem MenuStripRelatoriosEmprestimos;
        private ToolStripMenuItem MenuStripRelatoriosVisuEmprestimos;
        private PictureBox pictureBox1;
        private Label lblTituloSistemas;
        private ToolStripMenuItem recebimentoDeParcelaToolStripMenuItem;
    }
}

namespace Gerenciador_de_Emprestimos
{
    partial class frmTelaIncial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaIncial));
            lblTituloInicial = new Label();
            stsStripSistemVersion = new StatusStrip();
            toolStripUserName = new ToolStripStatusLabel();
            toolStsStripSistemVersion = new ToolStripStatusLabel();
            MenuStripMenusSistema = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            loginToolStripMenuItem = new ToolStripMenuItem();
            logoffToolStripMenuItem = new ToolStripMenuItem();
            sairDoSistemaToolStripMenuItem = new ToolStripMenuItem();
            MenuStripCadastro = new ToolStripMenuItem();
            MenuStripCliente = new ToolStripMenuItem();
            MenuStripCadastroCliente = new ToolStripMenuItem();
            empresaToolStripMenuItem = new ToolStripMenuItem();
            funcionárioToolStripMenuItem = new ToolStripMenuItem();
            MenuStripFinanceiro = new ToolStripMenuItem();
            MenuStripEmprestimos = new ToolStripMenuItem();
            MenuStripNovosEmprestimos = new ToolStripMenuItem();
            pagamentoDeParcelaToolStripMenuItem = new ToolStripMenuItem();
            MenuStripRelatorios = new ToolStripMenuItem();
            MenuStripRelatoriosEmprestimos = new ToolStripMenuItem();
            MenuStripRelatoriosVisuEmprestimos = new ToolStripMenuItem();
            visualizarParcelasToolStripMenuItem = new ToolStripMenuItem();
            imageListSistemaGerenciadorEmprestimos = new ImageList(components);
            picBoxLogoSistema2 = new PictureBox();
            picBoxLogoSistema = new PictureBox();
            lblTituloSistemas = new Label();
            stsStripSistemVersion.SuspendLayout();
            MenuStripMenusSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).BeginInit();
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
            stsStripSistemVersion.BackColor = SystemColors.MenuBar;
            stsStripSistemVersion.ImageScalingSize = new Size(20, 20);
            stsStripSistemVersion.Items.AddRange(new ToolStripItem[] { toolStripUserName, toolStsStripSistemVersion });
            stsStripSistemVersion.Name = "stsStripSistemVersion";
            // 
            // toolStripUserName
            // 
            resources.ApplyResources(toolStripUserName, "toolStripUserName");
            toolStripUserName.BackColor = SystemColors.Window;
            toolStripUserName.Name = "toolStripUserName";
            // 
            // toolStsStripSistemVersion
            // 
            resources.ApplyResources(toolStsStripSistemVersion, "toolStsStripSistemVersion");
            toolStsStripSistemVersion.BackColor = SystemColors.Window;
            toolStsStripSistemVersion.Name = "toolStsStripSistemVersion";
            toolStsStripSistemVersion.Spring = true;
            // 
            // MenuStripMenusSistema
            // 
            resources.ApplyResources(MenuStripMenusSistema, "MenuStripMenusSistema");
            MenuStripMenusSistema.BackColor = SystemColors.ButtonFace;
            MenuStripMenusSistema.ImageScalingSize = new Size(20, 20);
            MenuStripMenusSistema.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, MenuStripCadastro, MenuStripFinanceiro, MenuStripRelatorios });
            MenuStripMenusSistema.Name = "MenuStripMenusSistema";
            // 
            // arquivoToolStripMenuItem
            // 
            resources.ApplyResources(arquivoToolStripMenuItem, "arquivoToolStripMenuItem");
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loginToolStripMenuItem, logoffToolStripMenuItem, sairDoSistemaToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            // 
            // loginToolStripMenuItem
            // 
            resources.ApplyResources(loginToolStripMenuItem, "loginToolStripMenuItem");
            loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            loginToolStripMenuItem.Click += loginToolStripMenuItem_Click;
            // 
            // logoffToolStripMenuItem
            // 
            resources.ApplyResources(logoffToolStripMenuItem, "logoffToolStripMenuItem");
            logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            logoffToolStripMenuItem.Click += logoffToolStripMenuItem_Click;
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
            MenuStripCadastro.DropDownItems.AddRange(new ToolStripItem[] { MenuStripCliente, empresaToolStripMenuItem });
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
            // empresaToolStripMenuItem
            // 
            resources.ApplyResources(empresaToolStripMenuItem, "empresaToolStripMenuItem");
            empresaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { funcionárioToolStripMenuItem });
            empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            // 
            // funcionárioToolStripMenuItem
            // 
            resources.ApplyResources(funcionárioToolStripMenuItem, "funcionárioToolStripMenuItem");
            funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            funcionárioToolStripMenuItem.Click += funcionárioToolStripMenuItem_Click;
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
            MenuStripEmprestimos.DropDownItems.AddRange(new ToolStripItem[] { MenuStripNovosEmprestimos, pagamentoDeParcelaToolStripMenuItem });
            MenuStripEmprestimos.Name = "MenuStripEmprestimos";
            // 
            // MenuStripNovosEmprestimos
            // 
            resources.ApplyResources(MenuStripNovosEmprestimos, "MenuStripNovosEmprestimos");
            MenuStripNovosEmprestimos.Name = "MenuStripNovosEmprestimos";
            MenuStripNovosEmprestimos.Click += novosEmprestimosToolStripMenuItem_Click;
            // 
            // pagamentoDeParcelaToolStripMenuItem
            // 
            resources.ApplyResources(pagamentoDeParcelaToolStripMenuItem, "pagamentoDeParcelaToolStripMenuItem");
            pagamentoDeParcelaToolStripMenuItem.Name = "pagamentoDeParcelaToolStripMenuItem";
            pagamentoDeParcelaToolStripMenuItem.Click += pagamentoDeParcelaToolStripMenuItem_Click;
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
            MenuStripRelatoriosEmprestimos.DropDownItems.AddRange(new ToolStripItem[] { MenuStripRelatoriosVisuEmprestimos, visualizarParcelasToolStripMenuItem });
            MenuStripRelatoriosEmprestimos.Name = "MenuStripRelatoriosEmprestimos";
            // 
            // MenuStripRelatoriosVisuEmprestimos
            // 
            resources.ApplyResources(MenuStripRelatoriosVisuEmprestimos, "MenuStripRelatoriosVisuEmprestimos");
            MenuStripRelatoriosVisuEmprestimos.Name = "MenuStripRelatoriosVisuEmprestimos";
            MenuStripRelatoriosVisuEmprestimos.Click += visualizarEmprestimosToolStripMenuItem1_Click;
            // 
            // visualizarParcelasToolStripMenuItem
            // 
            resources.ApplyResources(visualizarParcelasToolStripMenuItem, "visualizarParcelasToolStripMenuItem");
            visualizarParcelasToolStripMenuItem.Name = "visualizarParcelasToolStripMenuItem";
            visualizarParcelasToolStripMenuItem.Click += visualizarParcelasToolStripMenuItem_Click;
            // 
            // imageListSistemaGerenciadorEmprestimos
            // 
            imageListSistemaGerenciadorEmprestimos.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListSistemaGerenciadorEmprestimos, "imageListSistemaGerenciadorEmprestimos");
            imageListSistemaGerenciadorEmprestimos.TransparentColor = Color.Transparent;
            // 
            // picBoxLogoSistema2
            // 
            resources.ApplyResources(picBoxLogoSistema2, "picBoxLogoSistema2");
            picBoxLogoSistema2.BackColor = Color.Transparent;
            picBoxLogoSistema2.Name = "picBoxLogoSistema2";
            picBoxLogoSistema2.TabStop = false;
            // 
            // picBoxLogoSistema
            // 
            resources.ApplyResources(picBoxLogoSistema, "picBoxLogoSistema");
            picBoxLogoSistema.BackColor = Color.Transparent;
            picBoxLogoSistema.Image = Properties.Resources.emprestimo_seguro;
            picBoxLogoSistema.Name = "picBoxLogoSistema";
            picBoxLogoSistema.TabStop = false;
            // 
            // lblTituloSistemas
            // 
            resources.ApplyResources(lblTituloSistemas, "lblTituloSistemas");
            lblTituloSistemas.BackColor = Color.Transparent;
            lblTituloSistemas.Name = "lblTituloSistemas";
            // 
            // frmTelaIncial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            Controls.Add(picBoxLogoSistema2);
            Controls.Add(lblTituloSistemas);
            Controls.Add(lblTituloInicial);
            Controls.Add(picBoxLogoSistema);
            Controls.Add(stsStripSistemVersion);
            Controls.Add(MenuStripMenusSistema);
            DoubleBuffered = true;
            MainMenuStrip = MenuStripMenusSistema;
            Name = "frmTelaIncial";
            WindowState = FormWindowState.Maximized;
            Load += frmTelaIncial_Load;
            stsStripSistemVersion.ResumeLayout(false);
            stsStripSistemVersion.PerformLayout();
            MenuStripMenusSistema.ResumeLayout(false);
            MenuStripMenusSistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).EndInit();
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
        private ImageList imageListSistemaGerenciadorEmprestimos;
        private PictureBox picBoxLogoSistema2;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem sairDoSistemaToolStripMenuItem;
        private ToolStripMenuItem MenuStripRelatorios;
        private ToolStripMenuItem MenuStripRelatoriosEmprestimos;
        private ToolStripMenuItem MenuStripRelatoriosVisuEmprestimos;
        private PictureBox picBoxLogoSistema;
        private Label lblTituloSistemas;
        private ToolStripMenuItem visualizarParcelasToolStripMenuItem;
        private ToolStripMenuItem pagamentoDeParcelaToolStripMenuItem;
        private ToolStripMenuItem empresaToolStripMenuItem;
        private ToolStripMenuItem funcionárioToolStripMenuItem;
        private ToolStripMenuItem logoffToolStripMenuItem;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripStatusLabel toolStripUserName;
    }
}

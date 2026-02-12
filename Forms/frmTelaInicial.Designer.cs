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
            statusLabelUsername = new ToolStripStatusLabel();
            toolStripUserName = new ToolStripStatusLabel();
            lblEspacoVazio = new ToolStripStatusLabel();
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
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            chamadoToolStripMenuItem = new ToolStripMenuItem();
            novoToolStripMenuItem = new ToolStripMenuItem();
            imageListSistemaGerenciadorEmprestimos = new ImageList(components);
            picBoxLogoSistema2 = new PictureBox();
            picBoxLogoSistema = new PictureBox();
            lblTituloSistemas = new Label();
            painelLogoSistema = new Panel();
            stsStripSistemVersion.SuspendLayout();
            MenuStripMenusSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).BeginInit();
            painelLogoSistema.SuspendLayout();
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
            stsStripSistemVersion.BackColor = SystemColors.Window;
            stsStripSistemVersion.ImageScalingSize = new Size(20, 20);
            stsStripSistemVersion.Items.AddRange(new ToolStripItem[] { statusLabelUsername, toolStripUserName, lblEspacoVazio, toolStsStripSistemVersion });
            stsStripSistemVersion.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            stsStripSistemVersion.Name = "stsStripSistemVersion";
            // 
            // statusLabelUsername
            // 
            resources.ApplyResources(statusLabelUsername, "statusLabelUsername");
            statusLabelUsername.BackColor = SystemColors.Window;
            statusLabelUsername.Name = "statusLabelUsername";
            // 
            // toolStripUserName
            // 
            resources.ApplyResources(toolStripUserName, "toolStripUserName");
            toolStripUserName.BackColor = SystemColors.Window;
            toolStripUserName.Name = "toolStripUserName";
            // 
            // lblEspacoVazio
            // 
            resources.ApplyResources(lblEspacoVazio, "lblEspacoVazio");
            lblEspacoVazio.Name = "lblEspacoVazio";
            lblEspacoVazio.Spring = true;
            // 
            // toolStsStripSistemVersion
            // 
            resources.ApplyResources(toolStsStripSistemVersion, "toolStsStripSistemVersion");
            toolStsStripSistemVersion.AutoToolTip = true;
            toolStsStripSistemVersion.BackColor = SystemColors.Window;
            toolStsStripSistemVersion.Name = "toolStsStripSistemVersion";
            toolStsStripSistemVersion.Padding = new Padding(0, 0, 10, 0);
            toolStsStripSistemVersion.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // MenuStripMenusSistema
            // 
            resources.ApplyResources(MenuStripMenusSistema, "MenuStripMenusSistema");
            MenuStripMenusSistema.BackColor = SystemColors.ButtonFace;
            MenuStripMenusSistema.ImageScalingSize = new Size(20, 20);
            MenuStripMenusSistema.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, MenuStripCadastro, MenuStripFinanceiro, MenuStripRelatorios, ajudaToolStripMenuItem });
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
            // ajudaToolStripMenuItem
            // 
            resources.ApplyResources(ajudaToolStripMenuItem, "ajudaToolStripMenuItem");
            ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chamadoToolStripMenuItem });
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            // 
            // chamadoToolStripMenuItem
            // 
            resources.ApplyResources(chamadoToolStripMenuItem, "chamadoToolStripMenuItem");
            chamadoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoToolStripMenuItem });
            chamadoToolStripMenuItem.Name = "chamadoToolStripMenuItem";
            // 
            // novoToolStripMenuItem
            // 
            resources.ApplyResources(novoToolStripMenuItem, "novoToolStripMenuItem");
            novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            novoToolStripMenuItem.Click += novoToolStripMenuItem_Click;
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
            // painelLogoSistema
            // 
            resources.ApplyResources(painelLogoSistema, "painelLogoSistema");
            painelLogoSistema.BackColor = Color.Transparent;
            painelLogoSistema.Controls.Add(picBoxLogoSistema2);
            painelLogoSistema.Controls.Add(lblTituloInicial);
            painelLogoSistema.Controls.Add(lblTituloSistemas);
            painelLogoSistema.Controls.Add(picBoxLogoSistema);
            painelLogoSistema.Name = "painelLogoSistema";
            // 
            // frmTelaIncial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            Controls.Add(painelLogoSistema);
            Controls.Add(stsStripSistemVersion);
            Controls.Add(MenuStripMenusSistema);
            DoubleBuffered = true;
            MainMenuStrip = MenuStripMenusSistema;
            Name = "frmTelaIncial";
            WindowState = FormWindowState.Maximized;
            Load += frmTelaIncial_Load;
            KeyDown += frmTelaIncial_KeyDown;
            Resize += frmTelaIncial_Resize;
            stsStripSistemVersion.ResumeLayout(false);
            stsStripSistemVersion.PerformLayout();
            MenuStripMenusSistema.ResumeLayout(false);
            MenuStripMenusSistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).EndInit();
            painelLogoSistema.ResumeLayout(false);
            painelLogoSistema.PerformLayout();
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
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem chamadoToolStripMenuItem;
        private ToolStripMenuItem novoToolStripMenuItem;
        private ToolStripStatusLabel statusLabelUsername;
        private Panel painelLogoSistema;
        private ToolStripStatusLabel lblEspacoVazio;
    }
}

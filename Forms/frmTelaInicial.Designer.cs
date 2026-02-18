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
            funçõesOperacionaisToolStripMenuItem = new ToolStripMenuItem();
            backUpDoBancoDeDadosToolStripMenuItem = new ToolStripMenuItem();
            MenuStripRelatorios = new ToolStripMenuItem();
            MenuStripRelatoriosEmprestimos = new ToolStripMenuItem();
            MenuStripRelatoriosVisuEmprestimos = new ToolStripMenuItem();
            visualizarParcelasToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            chamadoToolStripMenuItem = new ToolStripMenuItem();
            novoToolStripMenuItem = new ToolStripMenuItem();
            imageListSistemaGerenciadorEmprestimos = new ImageList(components);
            painelLogoSistema = new Panel();
            lblTituloInicial = new Label();
            lblTituloSistemas = new Label();
            picBoxLogoSistema2 = new PictureBox();
            picBoxLogoSistema = new PictureBox();
            btnListaEmprestimos = new Button();
            dataGridListaEmprestimos = new DataGridView();
            codigo_emprestimo = new DataGridViewTextBoxColumn();
            codigo_cliente = new DataGridViewTextBoxColumn();
            nome_cliente = new DataGridViewTextBoxColumn();
            valor_emprestado_total = new DataGridViewTextBoxColumn();
            percentual_juros = new DataGridViewTextBoxColumn();
            data_pagar = new DataGridViewTextBoxColumn();
            Obeservacoes = new DataGridViewTextBoxColumn();
            status_emprestimo = new DataGridViewTextBoxColumn();
            lblListaEmprestimos = new Label();
            btnAtualizarLista = new Button();
            btnLembretes = new Button();
            btnNovoLembrete = new Button();
            panelDataGridListarEmprestimos = new Panel();
            stsStripSistemVersion.SuspendLayout();
            MenuStripMenusSistema.SuspendLayout();
            painelLogoSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridListaEmprestimos).BeginInit();
            panelDataGridListarEmprestimos.SuspendLayout();
            SuspendLayout();
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
            MenuStripMenusSistema.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, MenuStripCadastro, MenuStripFinanceiro, funçõesOperacionaisToolStripMenuItem, MenuStripRelatorios, ajudaToolStripMenuItem });
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
            // funçõesOperacionaisToolStripMenuItem
            // 
            resources.ApplyResources(funçõesOperacionaisToolStripMenuItem, "funçõesOperacionaisToolStripMenuItem");
            funçõesOperacionaisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backUpDoBancoDeDadosToolStripMenuItem });
            funçõesOperacionaisToolStripMenuItem.Name = "funçõesOperacionaisToolStripMenuItem";
            // 
            // backUpDoBancoDeDadosToolStripMenuItem
            // 
            resources.ApplyResources(backUpDoBancoDeDadosToolStripMenuItem, "backUpDoBancoDeDadosToolStripMenuItem");
            backUpDoBancoDeDadosToolStripMenuItem.Name = "backUpDoBancoDeDadosToolStripMenuItem";
            backUpDoBancoDeDadosToolStripMenuItem.Click += backUpDoBancoDeDadosToolStripMenuItem_Click;
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
            // painelLogoSistema
            // 
            resources.ApplyResources(painelLogoSistema, "painelLogoSistema");
            painelLogoSistema.BackColor = Color.Transparent;
            painelLogoSistema.Controls.Add(lblTituloInicial);
            painelLogoSistema.Controls.Add(lblTituloSistemas);
            painelLogoSistema.Controls.Add(picBoxLogoSistema2);
            painelLogoSistema.Controls.Add(picBoxLogoSistema);
            painelLogoSistema.Name = "painelLogoSistema";
            // 
            // lblTituloInicial
            // 
            resources.ApplyResources(lblTituloInicial, "lblTituloInicial");
            lblTituloInicial.BackColor = Color.Transparent;
            lblTituloInicial.Name = "lblTituloInicial";
            // 
            // lblTituloSistemas
            // 
            resources.ApplyResources(lblTituloSistemas, "lblTituloSistemas");
            lblTituloSistemas.BackColor = Color.Transparent;
            lblTituloSistemas.Name = "lblTituloSistemas";
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
            // btnListaEmprestimos
            // 
            resources.ApplyResources(btnListaEmprestimos, "btnListaEmprestimos");
            btnListaEmprestimos.Name = "btnListaEmprestimos";
            btnListaEmprestimos.UseVisualStyleBackColor = true;
            btnListaEmprestimos.Click += btnListaEmprestimos_Click;
            // 
            // dataGridListaEmprestimos
            // 
            resources.ApplyResources(dataGridListaEmprestimos, "dataGridListaEmprestimos");
            dataGridListaEmprestimos.AllowUserToAddRows = false;
            dataGridListaEmprestimos.AllowUserToDeleteRows = false;
            dataGridListaEmprestimos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridListaEmprestimos.Columns.AddRange(new DataGridViewColumn[] { codigo_emprestimo, codigo_cliente, nome_cliente, valor_emprestado_total, percentual_juros, data_pagar, Obeservacoes, status_emprestimo });
            dataGridListaEmprestimos.Name = "dataGridListaEmprestimos";
            dataGridListaEmprestimos.ReadOnly = true;
            dataGridListaEmprestimos.CellDoubleClick += dataGridListaEmprestimos_CellDoubleClick;
            // 
            // codigo_emprestimo
            // 
            codigo_emprestimo.DataPropertyName = "CodigoEmprestimo";
            resources.ApplyResources(codigo_emprestimo, "codigo_emprestimo");
            codigo_emprestimo.Name = "codigo_emprestimo";
            codigo_emprestimo.ReadOnly = true;
            // 
            // codigo_cliente
            // 
            codigo_cliente.DataPropertyName = "CodigoCliente";
            resources.ApplyResources(codigo_cliente, "codigo_cliente");
            codigo_cliente.Name = "codigo_cliente";
            codigo_cliente.ReadOnly = true;
            // 
            // nome_cliente
            // 
            nome_cliente.DataPropertyName = "NomeCliente";
            resources.ApplyResources(nome_cliente, "nome_cliente");
            nome_cliente.Name = "nome_cliente";
            nome_cliente.ReadOnly = true;
            // 
            // valor_emprestado_total
            // 
            valor_emprestado_total.DataPropertyName = "ValorTotal";
            resources.ApplyResources(valor_emprestado_total, "valor_emprestado_total");
            valor_emprestado_total.Name = "valor_emprestado_total";
            valor_emprestado_total.ReadOnly = true;
            // 
            // percentual_juros
            // 
            percentual_juros.DataPropertyName = "Juros";
            resources.ApplyResources(percentual_juros, "percentual_juros");
            percentual_juros.Name = "percentual_juros";
            percentual_juros.ReadOnly = true;
            // 
            // data_pagar
            // 
            data_pagar.DataPropertyName = "DataPagamento";
            resources.ApplyResources(data_pagar, "data_pagar");
            data_pagar.Name = "data_pagar";
            data_pagar.ReadOnly = true;
            // 
            // Obeservacoes
            // 
            Obeservacoes.DataPropertyName = "Observacoes";
            resources.ApplyResources(Obeservacoes, "Obeservacoes");
            Obeservacoes.Name = "Obeservacoes";
            Obeservacoes.ReadOnly = true;
            // 
            // status_emprestimo
            // 
            status_emprestimo.DataPropertyName = "Status";
            resources.ApplyResources(status_emprestimo, "status_emprestimo");
            status_emprestimo.Name = "status_emprestimo";
            status_emprestimo.ReadOnly = true;
            // 
            // lblListaEmprestimos
            // 
            resources.ApplyResources(lblListaEmprestimos, "lblListaEmprestimos");
            lblListaEmprestimos.BackColor = Color.Transparent;
            lblListaEmprestimos.ForeColor = SystemColors.MenuText;
            lblListaEmprestimos.Name = "lblListaEmprestimos";
            // 
            // btnAtualizarLista
            // 
            resources.ApplyResources(btnAtualizarLista, "btnAtualizarLista");
            btnAtualizarLista.ForeColor = SystemColors.HotTrack;
            btnAtualizarLista.Name = "btnAtualizarLista";
            btnAtualizarLista.UseVisualStyleBackColor = true;
            btnAtualizarLista.Click += btnAtualizarLista_Click;
            // 
            // btnLembretes
            // 
            resources.ApplyResources(btnLembretes, "btnLembretes");
            btnLembretes.Name = "btnLembretes";
            btnLembretes.UseVisualStyleBackColor = true;
            btnLembretes.Click += btnNovoLembrete_Click;
            // 
            // btnNovoLembrete
            // 
            resources.ApplyResources(btnNovoLembrete, "btnNovoLembrete");
            btnNovoLembrete.Image = Properties.Resources.alfinete;
            btnNovoLembrete.Name = "btnNovoLembrete";
            btnNovoLembrete.UseVisualStyleBackColor = true;
            // 
            // panelDataGridListarEmprestimos
            // 
            resources.ApplyResources(panelDataGridListarEmprestimos, "panelDataGridListarEmprestimos");
            panelDataGridListarEmprestimos.BackColor = Color.Transparent;
            panelDataGridListarEmprestimos.Controls.Add(dataGridListaEmprestimos);
            panelDataGridListarEmprestimos.Name = "panelDataGridListarEmprestimos";
            // 
            // frmTelaIncial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gra_cad_cliente;
            Controls.Add(panelDataGridListarEmprestimos);
            Controls.Add(btnLembretes);
            Controls.Add(btnAtualizarLista);
            Controls.Add(lblListaEmprestimos);
            Controls.Add(btnListaEmprestimos);
            Controls.Add(painelLogoSistema);
            Controls.Add(stsStripSistemVersion);
            Controls.Add(MenuStripMenusSistema);
            Controls.Add(btnNovoLembrete);
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
            painelLogoSistema.ResumeLayout(false);
            painelLogoSistema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLogoSistema).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridListaEmprestimos).EndInit();
            panelDataGridListarEmprestimos.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem sairDoSistemaToolStripMenuItem;
        private ToolStripMenuItem MenuStripRelatorios;
        private ToolStripMenuItem MenuStripRelatoriosEmprestimos;
        private ToolStripMenuItem MenuStripRelatoriosVisuEmprestimos;
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
        private ToolStripStatusLabel lblEspacoVazio;
        private ToolStripMenuItem funçõesOperacionaisToolStripMenuItem;
        private ToolStripMenuItem backUpDoBancoDeDadosToolStripMenuItem;
        private Panel painelLogoSistema;
        private PictureBox picBoxLogoSistema2;
        private Label lblTituloInicial;
        private Label lblTituloSistemas;
        private PictureBox picBoxLogoSistema;
        private Button btnListaEmprestimos;
        private DataGridView dataGridListaEmprestimos;
        private Label lblListaEmprestimos;
        private Button btnAtualizarLista;
        private Button btnLembretes;
        private DataGridViewTextBoxColumn codigo_emprestimo;
        private DataGridViewTextBoxColumn codigo_cliente;
        private DataGridViewTextBoxColumn nome_cliente;
        private DataGridViewTextBoxColumn valor_emprestado_total;
        private DataGridViewTextBoxColumn percentual_juros;
        private DataGridViewTextBoxColumn data_pagar;
        private DataGridViewTextBoxColumn Obeservacoes;
        private DataGridViewTextBoxColumn status_emprestimo;
        private Button btnNovoLembrete;
        private Panel panelDataGridListarEmprestimos;
    }
}

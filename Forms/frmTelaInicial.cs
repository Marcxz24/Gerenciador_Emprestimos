using System;
using System.Windows.Forms;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmTelaIncial : Form
    {
        // --- CONSTRUTOR DA TELA PRINCIPAL ---
        public frmTelaIncial()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que o formulário capture eventos de teclado antes dos componentes

            // Inicia o sistema com os menus bloqueados
            ConfigurarAcesso(false);

            // Instancia e configura a tela de login como a primeira interação
            frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();
            loginFuncionario.Owner = this; // Define esta tela como "dona" para permitir comunicação
            loginFuncionario.StartPosition = FormStartPosition.CenterScreen;
            loginFuncionario.Show();
        }

        // --- EVENTO: Load do Formulário ---
        private void frmTelaIncial_Load(object sender, EventArgs e)
        {
            // 1. Garante que o acesso esteja bloqueado
            ConfigurarAcesso(false);
        }

        // --- MÉTODO: Atualiza o nome do funcionário no rodapé (StatusStrip) ---
        public void AtualizarUsuarioLogado(string nomeFuncionario)
        {
            statusLabelUsername.Text = $"Usuário: {nomeFuncionario}";
        }

        // --- MÉTODO: Controla a visibilidade e permissão de todos os menus e elementos visuais ---
        // Este método é chamado tanto no Login (true) quanto no Logoff (false)
        public void ConfigurarAcesso(bool logado)
        {
            // Menus Principais
            MenuStripCadastro.Enabled = logado;
            MenuStripCadastro.Visible = logado;

            MenuStripFinanceiro.Enabled = logado;
            MenuStripFinanceiro.Visible = logado;

            MenuStripRelatorios.Enabled = logado;
            MenuStripRelatorios.Visible = logado;

            ajudaToolStripMenuItem.Enabled = logado;
            ajudaToolStripMenuItem.Visible = logado;

            // Controle de Login/Logoff
            loginToolStripMenuItem.Enabled = !logado; // Só aparece se NÃO estiver logado
            loginToolStripMenuItem.Visible = !logado;

            logoffToolStripMenuItem.Enabled = logado; // Só aparece se ESTIVER logado
            logoffToolStripMenuItem.Visible = logado;

            // Elementos Visuais e Logotipos
            picBoxLogoSistema.Visible = logado;
            picBoxLogoSistema2.Visible = logado;

            lblTituloInicial.Visible = logado;
            lblTituloInicial.BringToFront(); // Garante que o título fique sobre outros elementos
            lblTituloSistemas.Visible = logado;
        }

        // --- EVENTOS DE CLIQUE: Abertura dos Formulários do Sistema ---

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmCadastroCliente"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmCadastroCliente formularioCadastroCliente = new frmCadastroCliente();
            formularioCadastroCliente.ShowDialog();
        }

        private void novosEmprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmNovosEmprestimos"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmNovosEmprestimos formularioEmprestimos = new frmNovosEmprestimos();
            formularioEmprestimos.ShowDialog();
        }

        private void visualizarEmprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmVisualizarEmprestimos"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmVisualizarEmprestimos frmVisualizarEmprestimos = new frmVisualizarEmprestimos();
            frmVisualizarEmprestimos.Show();
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // Encerra completamente o processo da aplicação
        }

        private void visualizarEmprestimosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmVisualizarEmprestimos"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmVisualizarEmprestimos frmVisualizarEmprestimos = new frmVisualizarEmprestimos();
            frmVisualizarEmprestimos.Show();
        }

        private void recebimentoDeParcelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmPagamentoEmprestimo"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmPagamentoEmprestimo frmPagamentoParcela = new frmPagamentoEmprestimo();
            frmPagamentoParcela.ShowDialog();
        }

        private void visualizarParcelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmConsultarParcelas"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmConsultarParcelas frmConsultaParcela = new frmConsultarParcelas();
            frmConsultaParcela.Show();
        }

        private void pagamentoDeParcelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmPagamentoEmprestimo"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmPagamentoEmprestimo frmPagamento = new frmPagamentoEmprestimo();
            frmPagamento.ShowDialog();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ControleAcesso.PodeAcessar("frmCadastroFuncionario"))
            {
                Funcoes.MensagemWarning("Você não tem Privilégio para Realizar esta operação.");
                return;
            }

            frmCadastroFuncionario frmCadastroFuncionario = new frmCadastroFuncionario();
            frmCadastroFuncionario.ShowDialog();
        }

        // --- EVENTOS DE SESSÃO: Login e Logoff ---

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente fazer logoff do sistema?\nAs tarefas não concluídas serão interrompidas.", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Se o usuário confirmar ou prosseguir, executa o método de limpeza de sessão
            RealizarLogoff();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();
            loginFuncionario.Owner = this;
            loginFuncionario.Show();
        }

        // --- EVENTO: Suporte Técnico ---
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupportService.AbrirChatWhatsApp(); // Abre o link externo de suporte
        }

        // --- MÉTODO: Reseta o estado do sistema e volta para a tela de login ---
        private void RealizarLogoff()
        {
            ConfigurarAcesso(false); // Bloqueia menus
            statusLabelUsername.Text = ""; // Limpa nome do usuário no rodapé
            frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();
            loginFuncionario.Owner = this;
            loginFuncionario.Show();
        }

        // --- EVENTO: Atalhos de Teclado (Tecla HOME) ---
        private void frmTelaIncial_KeyDown(object sender, KeyEventArgs e)
        {
            // Se a tecla pressionada não for HOME, ignora
            if (e.KeyCode != Keys.Home)
                return;

            // Verifica se a tela de login já está aberta para evitar múltiplas instâncias
            bool loginAberto = Application.OpenForms.OfType<frmLoginFuncionario>().Any();

            if (loginAberto)
                return;

            var resultado = MessageBox.Show("Deseja realmente fazer logoff do sistema?\nAs tarefas não concluídas serão interrompidas.", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                RealizarLogoff();
            }
        }

        private void frmTelaIncial_Resize(object sender, EventArgs e)
        {
            painelLogoSistema.Left = this.ClientSize.Width - painelLogoSistema.Width - 20; // 20 de margem da direita
            painelLogoSistema.Top = this.ClientSize.Height - painelLogoSistema.Height - stsStripSistemVersion.Height - 10; // 10 acima da barra
        }
    }
}

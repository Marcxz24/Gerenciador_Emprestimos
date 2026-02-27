using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Security;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using System.Data;
using System.Runtime.InteropServices;

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

            // 1. Força o layout da barra para aceitar o empilhamento correto
            this.stsStripSistemVersion.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;

            // 2. Configura o Usuário (Esquerda)
            this.statusLabelUsername.Spring = false;
            this.statusLabelUsername.AutoSize = true;

            // 3. Configura o Espaçador (Meio)
            // Se você não tiver nomeado ele, use o índice (ex: Items[1]) ou dê um nome no Designer
            this.lblEspacoVazio.Spring = true;
            this.lblEspacoVazio.Text = "";

            // 4. Configura a Versão (Direita)
            this.toolStsStripSistemVersion.Spring = false;
            this.toolStsStripSistemVersion.AutoSize = true;
            this.toolStsStripSistemVersion.TextAlign = ContentAlignment.MiddleRight;

            // TRUQUE EXTRA: Define o alinhamento do ITEM na barra, não só do texto
            this.toolStsStripSistemVersion.Alignment = ToolStripItemAlignment.Right;
        }

        // --- MÉTODO: Atualiza o nome do funcionário no rodapé (StatusStrip) ---
        public void AtualizarUsuarioLogado(int codigoLogado, string nomeFuncionario)
        {
            toolStriCodUsuarioLogado.Text = $"Código de Usuário: {codigoLogado}";
            statusLabelUsername.Text = $"Nome de Usuário: {nomeFuncionario}";

            Sessao.CodigoFuncionarioLogado = codigoLogado;
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

            funçõesOperacionaisToolStripMenuItem.Enabled = logado;
            funçõesOperacionaisToolStripMenuItem.Visible = logado;

            // Botões de Lista de Empréstimos e Novo Lembrete
            btnListaEmprestimos.Visible = logado;
            btnLembretes.Visible = logado;
            btnNovoLembrete.Visible = logado;

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

            if (logado)
            {
                AtualizarMural(); // Atualiza o mural de lembretes ao fazer login
            }
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
            dataGridListaEmprestimos.Visible = false; // Esconde a lista de empréstimos
            lblListaEmprestimos.Visible = false; // Esconde o rótulo da lista de empréstimos
            btnAtualizarLista.Visible = false; // Esconde o botão de atualizar lista
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

        private void backUpDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Você realmente deseja realizar o BackUp do Banco de Dados?",
                "Atenção!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Backup SQL|*.sql";
                sfd.FileName = $"backup_emprestimos_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    BackUpService serviceBkp = new BackUpService();

                    if (serviceBkp.RealizarBackup(sfd.FileName))
                    {
                        Funcoes.MensagemInformation("BackUp Realizado com Sucesso!");
                    }
                    else
                    {
                        Funcoes.MensagemErro("Ocorreu um erro ao realizar o backup. Verifique as permissões de acesso ao local selecionado e tente novamente.");
                    }
                }
            }
        }

        private void AlternarVisualizacao(bool mostrarLista)
        {
            // Elementos da Lista (Grid)
            lblListaEmprestimos.Visible = mostrarLista;
            btnAtualizarLista.Visible = mostrarLista;
            dataGridListaEmprestimos.Visible = mostrarLista;

            // Elementos do Mural (Cards)
            btnNovoLembrete.Visible = !mostrarLista; // O '!' inverte o valor
            flwMuralLembretes.Visible = !mostrarLista;
        }

        private void btnListaEmprestimos_Click(object sender, EventArgs e)
        {
            AlternarVisualizacao(true);
        }

        private void btnNovoLembrete_Click(object sender, EventArgs e)
        {
            AlternarVisualizacao(false);
        }

        private void btnAtualizarLista_Click(object sender, EventArgs e)
        {
            try
            {
                ListarEmprestimoService emprestimoLisa = new ListarEmprestimoService();

                dataGridListaEmprestimos.DataSource = emprestimoLisa.ListarEmprestimos();
            }
            catch (Exception ex)
            {
                Funcoes.MensagemWarning("Ocorreu um erro ao carregar a lista de empréstimos. Tente novamente mais tarde.\nDetalhes do erro: " + ex.Message);
                Serilog.Log.Error("Erro ao atualizar a lista de empréstimos: " + ex.Message);
            }
        }

        private void dataGridListaEmprestimos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var emprestimoSelecionado = (EmprestimosListaDTO)dataGridListaEmprestimos.Rows[e.RowIndex].DataBoundItem;

                if (emprestimoSelecionado.Status == "ATIVO")
                {
                    frmPagamentoEmprestimo frmPagamento = new frmPagamentoEmprestimo();

                    frmPagamento.codigoEmprestimo = emprestimoSelecionado.CodigoEmprestimo;

                    frmPagamento.CarregarDadosParcela(emprestimoSelecionado.CodigoEmprestimo);

                    frmPagamento.ShowDialog();

                    btnAtualizarLista.PerformClick(); // Atualiza a lista após fechar o formulário de pagamento
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemWarning("Ocorreu um erro ao tentar acessar os detalhes do empréstimo. Tente novamente mais tarde.\nDetalhes do erro: " + ex.Message);
                Serilog.Log.Error("Erro ao acessar detalhes do empréstimo: " + ex.Message);
                return;
            }
        }

        private void btnNovoLembrete_Click_1(object sender, EventArgs e)
        {
            Lembrete novoLembrete = new Lembrete();

            novoLembrete.CodigoFuncionario = Sessao.CodigoFuncionarioLogado;

            try
            {
                string tituloPadrao = "Titulo do lembrete";
                novoLembrete.Titulo = tituloPadrao;

                novoLembrete.CriarLembrete();
                AtualizarMural(); // Atualiza o mural para mostrar o novo lembrete

                if (flwMuralLembretes.Controls.Count > 0)
                {
                    flwMuralLembretes.ScrollControlIntoView(flwMuralLembretes.Controls[flwMuralLembretes.Controls.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("Ocorreu um erro ao criar o lembrete. Tente novamente mais tarde.\nDetalhes do erro: " + ex.Message);
                Serilog.Log.Error("Erro ao criar novo lembrete: " + ex.Message);
            }
        }

        private void AtualizarMural()
        {
            flwMuralLembretes.Controls.Clear();

            Lembrete lembrete = new Lembrete();

            int codigoLogado = Sessao.CodigoFuncionarioLogado;

            var listaDeLembretes = lembrete.ListarLembretes(codigoLogado);

            foreach (var item in listaDeLembretes)
            {
                Panel card = new Panel();
                card.Tag = item.Codigo;
                card.Size = new Size(250, 140);
                card.BackColor = Color.LightYellow;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10);

                // 1. Barrinha do Título
                Panel pnlHeader = new Panel();
                pnlHeader.BackColor = Color.Khaki;
                pnlHeader.Dock = DockStyle.Top;
                pnlHeader.Height = 30;

                // 2. Título Editável (TextBox)
                TextBox txtTitulo = new TextBox();
                txtTitulo.Text = item.Titulo;
                txtTitulo.Font = new Font("Arial", 9, FontStyle.Bold);
                txtTitulo.BackColor = Color.Khaki; // Mesma cor da barrinha
                txtTitulo.BorderStyle = BorderStyle.None; // Tira a borda de "caixa"
                txtTitulo.Dock = DockStyle.Fill;
                txtTitulo.Multiline = false;
                // Centralizar verticalmente no header
                txtTitulo.Margin = new Padding(5, 7, 0, 0);

                // 3. Botões (Mantendo o que fizemos antes)
                Button btnExcluir = new Button { Text = "X", Size = new Size(25, 25), Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat };
                btnExcluir.FlatAppearance.BorderSize = 0;

                Button btnSalvar = new Button { Text = "S", Size = new Size(25, 25), Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat };
                btnSalvar.FlatAppearance.BorderSize = 0;

                // 4. Descrição Editável (TextBox Multiline)
                TextBox txtDesc = new TextBox();
                txtDesc.Text = item.Descricao;
                txtDesc.Font = new Font("Arial", 9, FontStyle.Regular);
                txtDesc.BackColor = Color.LightYellow; // Cor do fundo do card
                txtDesc.BorderStyle = BorderStyle.None; // Fica invisível, parece apenas texto
                txtDesc.Multiline = true; // Permite várias linhas
                txtDesc.Dock = DockStyle.Fill;
                txtDesc.ScrollBars = ScrollBars.None; // Opcional: tira a barra lateral

                // --- MONTAGEM ---
                pnlHeader.Controls.Add(txtTitulo);
                pnlHeader.Controls.Add(btnSalvar);
                pnlHeader.Controls.Add(btnExcluir);

                card.Controls.Add(txtDesc);
                card.Controls.Add(pnlHeader);

                flwMuralLembretes.Controls.Add(card);

                // EVENTO DE SALVAR: Captura o que foi digitado
                btnSalvar.Click += (s, e) =>
                {
                    try
                    {
                        // 1. Atualizamos o objeto 'item' com o que está escrito nos campos agora
                        item.Titulo = txtTitulo.Text;
                        item.Descricao = txtDesc.Text;

                        // 2. Chamamos o método que você acabou de criar
                        item.EditarLembrete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnExcluir.Click += (s, e) =>
                {
                    var confirmacao = MessageBox.Show("Deseja realmente excluir este lembrete?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacao == DialogResult.Yes)
                    {
                        try
                        {
                            item.ExcluirLembrete();
                            flwMuralLembretes.Controls.Remove(card); // Remove o card da interface
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
            }
        }

        private void BtnExcluir_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnLimparListaEmprestimos_Click(object sender, EventArgs e)
        {
            // 1. Garante que ele não invente colunas novas
            dataGridListaEmprestimos.AutoGenerateColumns = false;

            // 2. Desvincula o gerenciador de dados
            dataGridListaEmprestimos.BindingContext = new BindingContext();

            // 3. Atribui uma lista vazia
            dataGridListaEmprestimos.DataSource = null;
        }
    }
}

using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using System.Globalization;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmNovosEmprestimos : Form
    {
        // Camadas da Arquitetura v1.6.1
        private EmprestimoServices _service = new EmprestimoServices();
        private EmprestimoDAO _dao = new EmprestimoDAO();
        private EmprestimoDTO _dto = new EmprestimoDTO(); // DTO que manterá o estado da tela

        // Objeto global que carrega a lógica de negócio e cálculos financeira
        EmprestimoServices emprestimo = new EmprestimoServices();

        public frmNovosEmprestimos()
        {
            InitializeComponent();

            // --- RESTRIÇÕES DE TECLADO ---
            // Aplica as funções utilitárias para garantir que cada campo aceite apenas o tipo de dado correto
            txtBoxCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxTaxaJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorEmprestado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxQuantidadeParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            maskTxtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // --- MÉTODO: Centraliza todas as regras que impedem um empréstimo inválido ---
        private bool ValidacoesEmprestimo()
        {
            try
            {
                // 1. Verificação de Campos Vazios
                if (string.IsNullOrEmpty(txtBoxNomeCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Nome do Cliente");
                    return true;
                }

                if (string.IsNullOrEmpty(maskTxtCpfCnpjCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF do Cliente");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxValorEmprestado.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Valor Emprestado");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxTaxaJuros.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Percentual dos Juros");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxQuantidadeParcela.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Quantidade das Parcelas");
                    return true;
                }

                // 2. Proteção contra erro matemático (Divisão por zero)
                if (txtBoxQuantidadeParcela.Text == "0")
                {
                    Funcoes.MensagemErro("Tentativa de Divisão por Zero!\n\nSe o cliente não parcelou, informe 1 no campo da Parcela.");
                    return true;
                }

                // 3. Validação de Data de Pagamento
                DateOnly dataPagamento;

                if (!maskTxtDataPagamento.MaskCompleted)
                {
                    Funcoes.MensagemWarning("Preecha a Data completa!");
                    return true;
                }

                // Tenta converter o texto da máscara para uma data real brasileira
                if (!DateOnly.TryParseExact(maskTxtDataPagamento.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out dataPagamento))
                {
                    Funcoes.MensagemWarning("Data de Pagamento Inválida!\n\npreencha no formato dd/MM/yyyy");
                    return true;
                }

                // Regra de retroatividade (Não aceita datas muito antigas ou passadas)
                if (dataPagamento < new DateOnly(2025, 1, 1))
                {
                    Funcoes.MensagemErro("Data de Emprestimo inválida! Por favor Preencha uma Data Válida!");
                    return true;
                }

                if (dataPagamento < DateOnly.FromDateTime(DateTime.Today))
                {
                    Funcoes.MensagemWarning("A Data do Empréstimo não pode ser Menor que a Data Atual!\n\nPor favor, verifique a Data do Empréstimo.");
                    return true;
                }

                // Validação para verificar se o tipo de emprestimo está selecionado.
                if (cmbBoxTipoJuros.SelectedIndex == -1)
                {
                    Funcoes.MensagemWarning("Selecione o tipo de emprestimo antes de realizar o calculo ou salvar.");
                    return true;
                }

                // 4. Regras de Negócio no Banco de Dados
                // Impede que um cliente pegue dois empréstimos ao mesmo tempo
                if (_dao.ValidarClienteEmprestimo(txtBoxCodigoCliente.Text))
                {
                    Funcoes.MensagemWarning("Este Cliente Já está com um Emprestimo 'ATIVO'");
                    return true;
                }

                // Impede que clientes bloqueados/inativos operem
                if (_dao.validarClienteInativo(txtBoxCodigoCliente.Text))
                {
                    Funcoes.MensagemWarning("Não é possível realizar emprestimos para Clientes 'INATIVOS'");
                    return true;
                }

                return false; // Se passar por tudo, retorna falso (não há erros)
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro durante as validações do empréstimo.\n\nDetalhes: " + ex.Message);
                return true; // Retorna true para indicar que houve um erro
            }
        }

        // --- MÉTODO: Abre a busca de clientes e popula os campos com o retorno ---
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var frmSelecionarCliente = new frmSelecionarCliente())
            {
                if (frmSelecionarCliente.ShowDialog() == DialogResult.OK)
                {
                    var cliente = frmSelecionarCliente.ClienteSelecionado;

                    txtBoxCodigoCliente.Text = cliente.codigo.ToString();
                    txtBoxNomeCliente.Text = cliente.nome_cliente;
                    maskTxtCpfCnpjCliente.Text = cliente.cpf_cnpj.ToString();
                    ComboBoxSituacaoCadastral.Text = cliente.situacao_cadastral;
                }
            }
        }

        // --- MÉTODO: Limpa todos os campos do formulário (Reset) ---
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBoxCodigoCliente.Clear();
            txtBoxNomeCliente.Clear();
            maskTxtCpfCnpjCliente.Clear();
            txtBoxTaxaJuros.Clear();
            txtBoxValorEmprestado.Clear();
            txtBoxValorEmpresto.Clear();
            txtBoxValorJuros.Clear();
            maskTxtDataPagamento.Clear();
            txtBoxTotalPagar.Clear();
            txtBoxQuantidadeParcela.Clear();
            txtBoxValorParcela.Clear();
            ComboBoxSituacaoCadastral.Text = "";
        }

        // --- MÉTODO: Finaliza e grava o empréstimo no banco ---
        private void btnGerarEmprestimos_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo()) return;

            // Garante que o cálculo mais recente esteja no DTO
            btnCalcularEmprestimo_Click(sender, e);

            // Adiciona as informações de identificação e datas
            _dto.CodigoCliente = int.Parse(txtBoxCodigoCliente.Text);
            _dto.DataVencimentoInicial = DateOnly.ParseExact(maskTxtDataPagamento.Text, "dd/MM/yyyy");

            // Lógica das Observações (Mantendo a sua regra)
            var resultadoObs = MessageBox.Show("Deseja informar uma Observação?", "Observações", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultadoObs == DialogResult.Yes)
            {
                using (var frmObersvacoes = new frmObservacoesEmprestimos())
                {
                    frmObersvacoes.ShowDialog();
                    _dto.ObservacoesEmprestimos = frmObersvacoes.AdquirirDadosObservacoes(null);
                }
            }

            // Prepara Status e Data de Emissão via Service
            _service.PrepararAtivacao(_dto);

            // Persistência via DAO
            if (_dao.InserirDadosEmprestimo(_dto))
            {
                Funcoes.MensagemInformation($"Empréstimo n° {_dto.Codigo} gerado com sucesso!");
            }
        }

        // --- MÉTODO: Realiza os cálculos financeiros em memória e exibe nos campos ---
        private void btnCalcularEmprestimo_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo()) return;

            try
            {
                // 1. Alimenta o DTO com os dados atuais da tela
                _dto.ValorEmprestado = decimal.Parse(txtBoxValorEmprestado.Text);
                _dto.ValorJurosPercentual = decimal.Parse(txtBoxTaxaJuros.Text);
                _dto.QuantidadeParcela = int.Parse(txtBoxQuantidadeParcela.Text);
                _dto.TipoJuros = cmbBoxTipoJuros.Text;

                // 2. Chama o Service para processar os cálculos matemáticos
                _service.CalcularEmprestimoCompleto(_dto);

                // 3. Atualiza a tela com os resultados que o Service gravou no DTO
                txtBoxValorEmprestado.Text = _dto.ValorEmprestado.ToString("F2");
                txtBoxValorEmpresto.Text = _dto.ValorEmprestado.ToString("F2");
                txtBoxValorJuros.Text = _dto.ValorJurosMonetario.ToString("F2");
                txtBoxTotalPagar.Text = _dto.ValorTotal.ToString("F2");
                txtBoxValorParcela.Text = _dto.ValorParcela.ToString("F2");
            }
            catch (Exception ex) 
            {
                Funcoes.MensagemErro("Erro ao calcular: Verifique se os valores numéricos estão corretos.");
                Serilog.Log.Error(ex, "Erro no cálculo do empréstimo" + ex);
            }
        }
    }
}

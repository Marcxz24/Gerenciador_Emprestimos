using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Utils;
using System.Globalization;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmNovosEmprestimos : Form
    {
        // Objeto global que carrega a lógica de negócio e cálculos financeira
        Emprestimos emprestimo = new Emprestimos();

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
            if (emprestimo.ValidarClienteEmprestimo(txtBoxCodigoCliente.Text))
            {
                Funcoes.MensagemWarning("Este Cliente Já está com um Emprestimo 'ATIVO'");
                return true;
            }

            // Impede que clientes bloqueados/inativos operem
            if (emprestimo.validarClienteInativo(txtBoxCodigoCliente.Text))
            {
                Funcoes.MensagemWarning("Não é possível realizar emprestimos para Clientes 'INATIVOS'");
                return true;
            }

            return false; // Se passar por tudo, retorna falso (não há erros)
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
            if (ValidacoesEmprestimo() == true) return;

            // Tenta converter o código para garantir integridade antes de enviar para a classe
            if (int.TryParse(txtBoxCodigoCliente.Text, out int codigoCliente))
            {
                emprestimo.CodigoCliente = codigoCliente;
            }
            else
            {
                Funcoes.MensagemErro("Código do Cliente inválido. Verifique e tente novamente.");
                return;
            }

            // Define a data de vencimento da primeira parcela
            if (DateOnly.TryParseExact(maskTxtDataPagamento.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out DateOnly dataPagamento))
            {
                emprestimo.DataVencimentoInicial = dataPagamento;
            }

            string mensagem = "Você deseja informar uma Obersvação ao Emprestimo?";
            var resultado = MessageBox.Show(mensagem, "Observações", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                frmObservacoesEmprestimos frmObersvacoes = new frmObservacoesEmprestimos();
                frmObersvacoes.ShowDialog();

                string? obsEmprestimos = null;
                obsEmprestimos = frmObersvacoes.AdquirirDadosObservacoes(obsEmprestimos);

                emprestimo.ObservacoesEmprestimos = obsEmprestimos;
            }

            emprestimo.AtivarEmprestimo(); // Define Status e Data de hoje
            emprestimo.InserirDadosEmorestimo(); // Executa a transação no SQL
        }

        // --- MÉTODO: Realiza os cálculos financeiros em memória e exibe nos campos ---
        private void btnCalcularEmprestimo_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo()) return;

            // Envia os dados digitados para as propriedades da classe EmprestimosCliente
            if (decimal.TryParse(txtBoxValorEmprestado.Text, out decimal valorEmprestado))
            {
                emprestimo.ValorEmprestado = valorEmprestado;
            }

            if (decimal.TryParse(txtBoxTaxaJuros.Text, out decimal taxaPercentualJuros))
            {
                emprestimo.ValorJurosPercentual = taxaPercentualJuros;
            }

            if (int.TryParse(txtBoxQuantidadeParcela.Text, out int qtnParcela))
            {
                emprestimo.QuantidadeParcela = qtnParcela;
            }

            // Executa os cálculos matemáticos na classe de negócio
            emprestimo.TipoJuros = cmbBoxTipoJuros.Text;
            emprestimo.SomarJurosAoTotal();
            emprestimo.DividirParcelas();

            // Devolve os resultados calculados para a interface, formatados como moeda ("F2")
            txtBoxValorEmprestado.Text = emprestimo.ValorEmprestado.ToString("F2");
            txtBoxValorEmpresto.Text = emprestimo.ValorEmprestado.ToString("F2");
            txtBoxValorJuros.Text = emprestimo.ValorJurosMonetario.ToString("F2");
            txtBoxTotalPagar.Text = emprestimo.ValorTotal.ToString("F2");
            txtBoxValorParcela.Text = emprestimo.ValorParcela.ToString("F2");
        }
    }
}

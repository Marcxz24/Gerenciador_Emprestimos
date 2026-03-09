using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmPagamentoEmprestimo : Form
    {
        // Variáveis globais para persistir os dados da parcela selecionada via Grid
        public int codigoEmprestimo = 0;
        private int numeroParcela = 0;
        private int codigoParcela;
        private decimal valorParcela = 0;
        private string? observacoes;

        public frmPagamentoEmprestimo()
        {
            InitializeComponent();

            // --- CONFIGURAÇÃO DE MÁSCARAS E VALIDAÇÕES ---
            // Garante que o usuário digite apenas caracteres válidos em campos numéricos e decimais
            txtBoxTotalPagar.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxCodigoEmprestimo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxTotalPagar.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
        }

        // --- PESQUISA DE PARCELAS ---
        private void btnLocalizarEmprestimo_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoParcelaConsulta parcelaConsulta = new PagamentoParcelaConsulta();

                int codigoCliente = 0;
                int codigoEmprestimo = 0;
                decimal valorJuros = 0;
                decimal valorTotal = 0;
                decimal valorParcela = 0;

                // Captura e converte filtros dos campos de texto (se preenchidos)
                if (!string.IsNullOrWhiteSpace(txtBoxCodigoCliente.Text) && int.TryParse(txtBoxCodigoCliente.Text, out int codCliente))
                    codigoCliente = codCliente;

                if (!string.IsNullOrWhiteSpace(txtBoxCodigoEmprestimo.Text) && int.TryParse(txtBoxCodigoEmprestimo.Text, out int codEmprestimos))
                    codigoEmprestimo = codEmprestimos;

                if (!string.IsNullOrWhiteSpace(txtBoxValorJuros.Text) && decimal.TryParse(txtBoxValorJuros.Text, out decimal valueJuros))
                    valorJuros = valueJuros;

                if (!string.IsNullOrWhiteSpace(txtBoxValorTotal.Text) && decimal.TryParse(txtBoxValorTotal.Text, out decimal valueTotal))
                    valorTotal = valueTotal;

                if (!string.IsNullOrWhiteSpace(txtBoxValorParcela.Text) && decimal.TryParse(txtBoxValorParcela.Text, out decimal valueParcela))
                    valorParcela = valueParcela;

                // Executa a consulta e vincula o resultado ao DataGridView
                DataTable dateTable = parcelaConsulta.ConsultaClienteEmprestimo(codigoCliente, codigoEmprestimo, valorJuros, valorTotal, valorParcela);
                dataGridParcelasAbertas.DataSource = dateTable;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao pesquisar as Parcelas.\n\nDetalhes: " + ex.Message);
            }
        }

        // --- SELEÇÃO DE CLIENTE EXTERNA ---
        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frmSelecionarCliente = new frmSelecionarCliente())
                {
                    if (frmSelecionarCliente.ShowDialog() == DialogResult.OK)
                    {
                        var cliente = frmSelecionarCliente.ClienteSelecionado;
                        txtBoxCodigoCliente.Text = cliente.codigo.ToString();
                        txtBoxCliente.Text = cliente.nome_cliente;
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao abrir a tela de seleção de Cliente.\n\nDetalhes: " + ex.Message);
            }
        }

        // --- REGRAS DE VALIDAÇÃO DO FORMULÁRIO ---
        private bool ValidacoesCampos()
        {
            try
            {
                // Impede processamento sem um cliente carregado
                if (string.IsNullOrEmpty(txtClienteNome.Text))
                {
                    Funcoes.MensagemWarning("Não é possivel realizar um pagamento sem um Cliente Selecionado!");
                    return true;
                }

                // Bloqueia tentativas de pagar parcelas que já estão com status 'PAGA' no Grid
                if (comboBoxParcelaStatus.Text == "PAGA")
                {
                    Funcoes.MensagemWarning("Não é possível Receber pagamento de uma Parcela já Paga!");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxTotalPagar.Text))
                {
                    Funcoes.MensagemWarning("Campo obrigátorio vazio! Por favor preencha!\n\nCampo: Valor Pago");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro inesperado durante a Validação dos Campos de Pagamento.\n\nDetalhes: " + ex.Message);
                return true; // Retorna true indicando que houve erro na validação
            }
        }

        // --- RESET DA INTERFACE ---
        private void LimparTela()
        {
            txtBoxCodigoCliente.Clear();
            txtBoxCliente.Clear();
            txtBoxCodigoEmprestimo.Clear();
            txtBoxValorJuros.Clear();
            txtBoxValorTotal.Clear();
            txtBoxValorParcela.Clear();
            txtBoxTotalPagar.Clear();
            txtValorEmprestimo.Clear();
            txtBoxNumeroParcela.Clear();
            txtValorJuros.Clear();
            txtBoxParcela.Clear();
            txtClienteNome.Clear();
            comboBoxParcelaStatus.Text = "";
            txtCodigoEmprestimo.Clear();
            txtCodigoParcela.Clear();
            txtCodCliente.Clear();
            dataGridParcelasAbertas.DataSource = null;
        }

        private void btnLimparDadosTela_Click(object sender, EventArgs e) => LimparTela();

        // --- FLUXO DE PAGAMENTO: INÍCIO ---
        private void btnGerarPagamento_Click(object sender, EventArgs e)
        {
            // Prepara o modo de edição: habilita campos e troca visibilidade dos botões
            txtBoxTotalPagar.ReadOnly = false;
            btnGerarPagamento.Visible = false;
            btnSalvarPagamento.Visible = true;
            lblInserindoDados.Visible = true;
            btnCancelar.Visible = true;
        }

        // --- SELEÇÃO DE REGISTRO NO GRID ---
        private void dataGridParcelasAbertas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return; // Evita erro ao clicar no cabeçalho

                int SelectdCodigoParcela = Convert.ToInt32(dataGridParcelasAbertas.Rows[e.RowIndex].Cells["codigo_parcela"].Value);

                // Usa o DAO diretamente como você pediu
                ParcelaDAO parcelaDao = new ParcelaDAO();
                ParcelaDTO parcela = parcelaDao.GetParcela(SelectdCodigoParcela);

                if (parcela != null)
                {
                    DateTime referencia = parcela.DataUltimoCalculoJuros.HasValue
                        ? parcela.DataUltimoCalculoJuros.Value.ToDateTime(TimeOnly.MinValue)
                        : parcela.DataVencimento.ToDateTime(TimeOnly.MinValue);

                    if (DateTime.Today > referencia.Date)
                    {
                        var mensagemRecalculo = "A parcela selecionada está em atraso. Deseja recalcular os juros antes de prosseguir com o pagamento?\n\nO calculo do percentual (%) Será calculado em cima do valor da Parcela";
                        var resultado = MessageBox.Show(mensagemRecalculo, "Recalcular Juros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            bool atualizado = false;

                            try
                            {
                                // Recalcula juros aqui no form e persiste via DAO
                                DateTime novaDataUltimoCalculo;
                                decimal taxa = parcela.PercentualJuros / 100m;
                                decimal novoValor;

                                if (parcela.TipoJuros == "DIARIO")
                                {
                                    novaDataUltimoCalculo = referencia.AddDays(1);
                                    novoValor = Math.Round(parcela.ValorParcela * (1m + taxa), 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    novaDataUltimoCalculo = referencia.AddMonths(1);
                                    novoValor = Math.Round(parcela.ValorParcela * (1m + taxa), 2, MidpointRounding.AwayFromZero);
                                }

                                int linhas = parcelaDao.UpdateParcelaValorJuros(SelectdCodigoParcela, novoValor, novaDataUltimoCalculo);
                                atualizado = linhas > 0;
                            }
                            catch (Exception ex)
                            {
                                Funcoes.MensagemErro("Erro ao Recalcular Juros: " + ex.Message);
                                Serilog.Log.Error("Erro ao Recalcular Juros da Parcela Código " + SelectdCodigoParcela + ": " + ex.Message);
                                return;
                            }

                            if (atualizado)
                            {
                                parcela = parcelaDao.GetParcela(SelectdCodigoParcela);

                                var linhasAtualizarComJuros = dataGridParcelasAbertas.Rows[e.RowIndex];

                                if (dataGridParcelasAbertas.Columns["valor_parcela"] != null)
                                    linhasAtualizarComJuros.Cells["valor_parcela"].Value = parcela.ValorParcela.ToString("F2");

                                if (dataGridParcelasAbertas.Columns["status_parcela"] != null)
                                    linhasAtualizarComJuros.Cells["status_parcela"].Value = parcela.StatusParcela ?? "ATRASADA";

                                if (dataGridParcelasAbertas.Columns["data_ultimo_calculo_juros"] != null)
                                    linhasAtualizarComJuros.Cells["data_ultimo_calculo_juros"].Value = (parcela.DataUltimoCalculoJuros.HasValue ? parcela.DataUltimoCalculoJuros.Value.ToString("yyyy/MM/dd") : "");

                                // Atualiza os campos do formulário.
                                txtBoxParcela.Text = parcela.ValorParcela.ToString("F2");
                                txtValorJuros.Text = parcela.PercentualJuros.ToString("F2");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao selecionar a parcela: " + ex.Message);
                return;
            }

            var linha = dataGridParcelasAbertas.Rows[e.RowIndex];

            // Mapeia os dados da linha para as variáveis e campos do formulário
            codigoParcela = Convert.ToInt32(linha.Cells["codigo_parcela"].Value);
            codigoEmprestimo = Convert.ToInt32(linha.Cells["codigo_emprestimo"].Value);
            numeroParcela = Convert.ToInt32(linha.Cells["numero_parcela"].Value);

            // Campos auxiliares para a Lista de Empréstimos.
            txtCodigoEmprestimo.Text = linha.Cells["codigo_emprestimo"].Value.ToString();
            txtCodigoParcela.Text = linha.Cells["codigo_parcela"].Value.ToString();
            txtCodCliente.Text = linha.Cells["codigo_cliente"].Value.ToString();

            txtValorEmprestimo.Text = linha.Cells["valor_contrato"].Value.ToString();
            comboBoxParcelaStatus.Text = linha.Cells["status_parcela"].Value.ToString();
            txtBoxNumeroParcela.Text = linha.Cells["numero_parcela"].Value.ToString();
            txtValorJuros.Text = linha.Cells["valor_juros"].Value.ToString();
            txtBoxParcela.Text = linha.Cells["valor_parcela"].Value.ToString();
            txtClienteNome.Text = linha.Cells["nome_cliente"].Value.ToString();
        }

        // --- FLUXO DE PAGAMENTO: SALVAMENTO ---
        private void btnSalvarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacoesCampos()) return;

                if (!int.TryParse(txtCodigoParcela.Text, out codigoParcela))
                {
                    return;
                }

                // Valida o valor pago digitado
                if (!decimal.TryParse(txtBoxTotalPagar.Text, out decimal valorPago))
                {
                    Funcoes.MensagemWarning("Valor inválido.");
                    return;
                }

                // Recupera o valor nominal da parcela para envio à classe de serviço
                if (decimal.TryParse(txtBoxParcela.Text, out decimal valueParcela))
                    valorParcela = valueParcela;
                else
                {
                    Funcoes.MensagemWarning("Não foi possivel localizar o valor da parcela!");
                    return;
                }

                if (int.TryParse(txtBoxNumeroParcela.Text, out int numParcelas))
                    numeroParcela = numParcelas;

                // Usa o DAO diretamente conforme solicitado
                ParcelaDAO parcelaDao = new ParcelaDAO();

                // Pergunta se deseja adicionar observações
                string mensagemYesOrNo = "Você deseja informar uma Obersvação ao Emprestimo?";
                var resultado = MessageBox.Show(mensagemYesOrNo, "Observações", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    frmObservacoesEmprestimos frmObservacoes = new frmObservacoesEmprestimos();
                    frmObservacoes.ShowDialog();
                    observacoes = frmObservacoes.ObsercacoesEmprestimos;
                    parcelaDao.AddObservacoes(codigoParcela, observacoes);
                }

                // Validações replicadas do serviço:
                if (parcelaDao.IsParcelaPaga(codigoParcela))
                {
                    Funcoes.MensagemWarning("Esta parcela já foi Paga");
                    return;
                }

                if (parcelaDao.CountParcelasAnterioresAbertas(codigoEmprestimo, numeroParcela) > 0)
                {
                    Funcoes.MensagemWarning("Existem parcelas anteriores em aberto. Efetue o pagamento das parcelas anteriores antes de pagar esta parcela.");
                    return;
                }

                decimal valorPagoAtual = parcelaDao.GetValorPago(codigoParcela);
                decimal novoTotal = valorPagoAtual + valorPago;

                if (novoTotal > valorParcela)
                {
                    Funcoes.MensagemWarning("O valor informado não pode ser maior que o valor da parcela.");
                    return;
                }

                if (novoTotal < valorParcela)
                {
                    parcelaDao.UpdateValorPagoPartial(codigoParcela, novoTotal);
                }
                else
                {
                    int linhas = parcelaDao.MarkParcelaPaga(codigoParcela, novoTotal);
                    if (linhas == 0)
                    {
                        Funcoes.MensagemWarning("Esta parcela já foi quitada por outro processo.");
                        return;
                    }

                    if (parcelaDao.CountParcelasAbertas(codigoEmprestimo) == 0)
                    {
                        EmprestimoDAO emprestimoDAO = new EmprestimoDAO();
                        emprestimoDAO.QuitarEmprestimo(codigoEmprestimo);
                    }
                }

                Funcoes.MensagemInformation("Pagamento realizado com sucesso!");

                // Retorna a interface ao estado de visualização original
                txtBoxTotalPagar.ReadOnly = true;
                btnSalvarPagamento.Visible = false;
                btnGerarPagamento.Visible = true;
                btnCancelar.Visible = false;
                lblInserindoDados.Visible = false;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro inesperado ao tentar salvar o pagamento da parcela.\n\nDetalhes: " + ex.Message);
                return;
            }
        }

        // --- CANCELAR OPERAÇÃO ---
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTela();
            txtBoxTotalPagar.ReadOnly = true;
            btnSalvarPagamento.Visible = false;
            btnGerarPagamento.Visible = true;
            btnCancelar.Visible = false;
            lblInserindoDados.Visible = false;
        }

        public void CarregarDadosParcela(int codigoParcela)
        {
            EmprestimoDAO emprestimoDAO = new EmprestimoDAO();

            var parcela = emprestimoDAO.BuscarMenorParcelaAberta(codigoEmprestimo);

            if (parcela != null)
            {
                txtCodigoEmprestimo.Text = parcela.CodigoEmprestimo.ToString();
                txtCodigoParcela.Text = parcela.Codigo.ToString();
                txtCodCliente.Text = parcela.CodigoCliente.ToString();

                txtBoxNumeroParcela.Text = parcela.NumeroParcela.ToString();
                txtValorEmprestimo.Text = parcela.ValorEmprestimo.ToString("F2");
                txtValorJuros.Text = parcela.ValorJuros.ToString("F2");

                comboBoxParcelaStatus.Text = parcela.StatusParcela;
                txtBoxParcela.Text = parcela.ValorParcela.ToString("F2");

                txtClienteNome.Text = parcela.NomeCliente;
            }
        }
    }
}

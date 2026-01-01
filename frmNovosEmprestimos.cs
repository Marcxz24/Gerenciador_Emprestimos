using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    public partial class FormEmprestimos : Form
    {
        // criado um objeto global para a classe EmprestimosCliente.
        EmprestimosCliente emprestimo = new EmprestimosCliente();

        public FormEmprestimos()
        {
            InitializeComponent();
            txtBoxCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxTaxaJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorEmprestado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxQuantidadeParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            maskTxtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private bool ValidacoesEmprestimo()
        {
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

            // Adição da validação para evitar Divisão por Zero.
            if (txtBoxQuantidadeParcela.Text == "0")
            {
                Funcoes.MensagemErro("Tentativa de Divisão por Zero!\n\nSe o cliente não parcelou, informe 1 no campo da Parcela.");
                return true;
            }

            DateTime dataPagamento;

            if (!maskTxtDataPagamento.MaskCompleted)
            {
                Funcoes.MensagemWarning("Preecha a Data completa!");
                return true;
            }

            if (!DateTime.TryParseExact(maskTxtDataPagamento.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out dataPagamento))
            { 
                Funcoes.MensagemWarning("Data de Pagamento Inválida!\n\npreencha no formato dd/MM/yyyy");
                return true;
            }

            if (dataPagamento < new DateTime(2025, 1, 1))
            {
                Funcoes.MensagemErro("Data de Emprestimo inválida! Por favor Preencha uma Data Válida!");
                return true;
            }

            if (dataPagamento < DateTime.Today)
            {
                Funcoes.MensagemWarning("A Data do Empréstimo não pode ser Menor que a Data Atual!\n\nPor favor, verifique a Data do Empréstimo.");
                return true;
            }
            
            if (emprestimo.ValidarClienteEmprestimo(txtBoxCodigoCliente.Text))
            {
                Funcoes.MensagemWarning("Este Cliente Já está com um Emprestimo 'ATIVO'");
                return true;
            }

            if (emprestimo.validarClienteInativo(txtBoxCodigoCliente.Text))
            {
                Funcoes.MensagemWarning("Não é possível realizar emprestimos para Clientes 'INATIVOS'");
                return true;
            }

            return false;
        }

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

        private void btnGerarEmprestimos_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo() == true)
            {
                return;
            }

            if (int.TryParse(txtBoxCodigoCliente.Text, out int codigoCliente))
            {
                emprestimo.CodigoCliente = codigoCliente;
            }
            else
            {
                Funcoes.MensagemErro("Código do Cliente inválido. Verifique e tente novamente.");
                return;
            }

            if (DateTime.TryParseExact(maskTxtDataPagamento.Text, "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out DateTime dataPagamento))
            {
                emprestimo.DataVencimentoInicial = dataPagamento;
            }

            emprestimo.AtivarEmprestimo();

            emprestimo.InserirDadosEmorestimo();
        }

        private void btnCalcularEmprestimo_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo() == true)
            {
                return;
            }

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

            emprestimo.SomarJurosAoTotal();
            emprestimo.DividirParcelas();

            txtBoxValorEmprestado.Text = emprestimo.ValorEmprestado.ToString("F2");
            txtBoxValorEmpresto.Text = emprestimo.ValorEmprestado.ToString("F2");
            txtBoxValorJuros.Text = emprestimo.ValorJurosMonetario.ToString("F2");
            txtBoxTotalPagar.Text = emprestimo.ValorTotal.ToString("F2");
            txtBoxValorParcela.Text = emprestimo.ValorParcela.ToString("F2");
        }
    }
}

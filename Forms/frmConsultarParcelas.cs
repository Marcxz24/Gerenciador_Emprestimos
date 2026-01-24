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
    public partial class frmConsultarParcelas : Form
    {
        public frmConsultarParcelas()
        {
            InitializeComponent();

            // --- VINCULAÇÃO DE EVENTOS DE VALIDAÇÃO ---
            // Utiliza a classe 'Funcoes' para garantir que o usuário não digite letras em campos numéricos
            txtBoxCodigoEmprestimo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxNumeroParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // --- MÉTODO: Pesquisa as parcelas com base nos filtros preenchidos ---
        private void btnPesquisarParcela_Click(object sender, EventArgs e)
        {
            ParcelaConsulta parcelaConsulta = new ParcelaConsulta();

            // Inicializa variáveis nulas para filtros opcionais
            int? CodigoEmprestimo = null;
            int? CodigoCliente = null;
            string? NomeCliente = null;
            string? StatusParcela = null;
            decimal ValorTotal = 0;
            decimal ValorParcela = 0;
            int? NumeroParcela = null;

            // --- BLOCO DE CAPTURA E CONVERSÃO DE FILTROS ---
            // Tenta converter os textos dos campos apenas se não estiverem vazios
            if (!string.IsNullOrWhiteSpace(txtBoxCodigoEmprestimo.Text) && int.TryParse(txtBoxCodigoEmprestimo.Text, out int emprestimoCod))
            {
                CodigoEmprestimo = emprestimoCod;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxCodigoCliente.Text) && int.TryParse(txtBoxCodigoCliente.Text, out int clienteCod))
            {
                CodigoCliente = clienteCod;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxNomeCliente.Text))
            {
                NomeCliente = txtBoxNomeCliente.Text;
            }

            if (!string.IsNullOrWhiteSpace(cmbBoxStatusParcela.Text))
            {
                StatusParcela = cmbBoxStatusParcela.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxValorParcela.Text) && decimal.TryParse(txtBoxValorParcela.Text, out decimal valueParcela))
            {
                ValorParcela = valueParcela;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxValorTotal.Text) && decimal.TryParse(txtBoxValorTotal.Text, out decimal valueTotal))
            {
                ValorTotal = valueTotal;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxNumeroParcela.Text) && int.TryParse(txtBoxNumeroParcela.Text, out int numParcela))
            {
                NumeroParcela = numParcela;
            }

            // Chama o método de consulta enviando todos os filtros capturados
            DataTable dataTable = parcelaConsulta.ConsultaParcela(CodigoEmprestimo, CodigoCliente, NomeCliente, StatusParcela, ValorTotal, ValorParcela, NumeroParcela);

            // Exibe o resultado na grade (DataGrid)
            dataGridConsultaParcela.DataSource = dataTable;
        }

        // --- MÉTODO: Abre a tela de seleção de cliente para preencher os campos automaticamente ---
        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            using (var formSelecionarCliente = new frmSelecionarCliente())
            {
                // Abre como caixa de diálogo (bloqueia a tela de trás)
                if (formSelecionarCliente.ShowDialog() == DialogResult.OK)
                {
                    // Se o usuário selecionou um cliente, recupera o objeto e preenche os campos
                    var cliente = formSelecionarCliente.ClienteSelecionado;

                    txtBoxCodigoCliente.Text = cliente.codigo.ToString();
                    txtBoxNomeCliente.Text = cliente.nome_cliente;
                }
            }
        }

        // --- MÉTODO: Valida se o DataGrid possui dados antes de gerar relatórios ---
        private bool ValidacaoDataGrid()
        {
            if (dataGridConsultaParcela.Rows.Count == 0 || (dataGridConsultaParcela.Rows.Count == 1 && dataGridConsultaParcela.Rows[0].IsNewRow))
            {
                Funcoes.MensagemWarning("Não é possível gerar um relatório com o DataGrid em Branco!");
                return true; // Retorna verdadeiro indicando que está vazio/inválido
            }

            return false;
        }

        // --- MÉTODO: Reseta a tela para o estado inicial ---
        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            dataGridConsultaParcela.DataSource = null;
            txtBoxCodigoCliente.Clear();
            txtBoxCodigoEmprestimo.Clear();
            txtBoxNomeCliente.Clear();
            txtBoxNumeroParcela.Clear();
            txtBoxValorParcela.Clear();
            txtBoxValorTotal.Clear();
            cmbBoxStatusParcela.SelectedItem = null;
        }

        // --- MÉTODO: Gera e abre o relatório PDF com base no que está na grade ---
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidacaoDataGrid())
            {
                return; // Interrompe se não houver dados
            }

            // Obtém o DataTable que está vinculado ao DataGrid
            DataTable dataTable = (DataTable)dataGridConsultaParcela.DataSource;

            GeradorRelatorio relatorio = new GeradorRelatorio();

            // Calcula estatísticas para o rodapé do relatório
            int totalDeLinhas = dataGridConsultaParcela.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
            decimal ValorTotalParcela = 0;

            // Soma o valor de todas as parcelas visíveis na grade
            foreach (DataGridViewRow row in dataGridConsultaParcela.Rows)
            {
                if (!row.IsNewRow)
                {
                    ValorTotalParcela += Convert.ToDecimal(row.Cells["valor_parcela"].Value);
                }
            }

            // Alimenta as propriedades da classe de relatório
            relatorio.ValorTotalReceber = ValorTotalParcela;
            relatorio.NumeroDeRegistros = totalDeLinhas;

            // Gera o PDF
            relatorio.RelatorioParcelas(dataTable);
        }
    }
}

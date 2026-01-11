using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmVisualizarEmprestimos : Form
    {
        // Propriedade para armazenar o ID do empréstimo selecionado via duplo clique
        public int CodigoEmprestimoSelecionado { get; set; }

        public frmVisualizarEmprestimos()
        {
            InitializeComponent();

            // --- RESTRIÇÕES DE ENTRADA ---
            // Aplica validações de teclado para garantir a integridade dos dados numéricos e decimais
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorEmprestado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtValorJurosMonetario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtQtnParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorDaParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtValorTotal.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
        }

        // --- EVENTO: Busca e popula os campos de cliente através de uma tela de seleção ---
        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            using (var frmSelecionarCliente = new frmSelecionarCliente())
            {
                if (frmSelecionarCliente.ShowDialog() == DialogResult.OK)
                {
                    var cliente = frmSelecionarCliente.ClienteSelecionado;

                    txtCodigoCliente.Text = cliente.codigo.ToString();
                    txtNomeCliente.Text = cliente.nome_cliente;
                    txtCpfCnpjCliente.Text = cliente.cpf_cnpj.ToString();
                }
            }
        }

        // --- MÉTODO: Valida se existem dados na grade antes de processar relatórios ---
        private bool ValidacaoDataGridVazio()
        {
            if (dataGridEmprestimos.Rows.Count == 0 || (dataGridEmprestimos.Rows.Count == 1 && dataGridEmprestimos.Rows[0].IsNewRow))
            {
                Funcoes.MensagemWarning("Não é possível gerar um relatório com o DataGrid em Branco!");
                return true;
            }

            return false;
        }

        // --- EVENTO: Realiza a pesquisa de empréstimos com base nos filtros preenchidos ---
        private void btnVisualizarEmprestimos_Click(object sender, EventArgs e)
        {
            EmprestimosConsulta consultaEmprestimos = new EmprestimosConsulta();

            // Variáveis de apoio para os filtros
            int? CodigoCliente = null;
            string? NomeCliente = null;
            int? QtnParcela = null;
            decimal ValorEmprestado = 0;
            decimal ValorParcela = 0;
            decimal ValorJurosMonetario = 0;
            decimal ValorTotal = 0;
            string StatusEmprestimo = string.Empty;

            // Conversão dos campos de texto para os tipos de dados da consulta
            if (!string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
                CodigoCliente = int.Parse(txtCodigoCliente.Text);

            if (!string.IsNullOrWhiteSpace(txtNomeCliente.Text))
                NomeCliente = txtNomeCliente.Text;

            if (!string.IsNullOrWhiteSpace(txtQtnParcela.Text))
                QtnParcela = int.Parse(txtQtnParcela.Text);

            if (!string.IsNullOrWhiteSpace(txtValorEmprestado.Text))
                ValorEmprestado = decimal.Parse(txtValorEmprestado.Text);

            if (!string.IsNullOrWhiteSpace(txtValorJurosMonetario.Text))
                ValorJurosMonetario = decimal.Parse(txtValorJurosMonetario.Text);

            if (!string.IsNullOrWhiteSpace(txtValorDaParcela.Text))
                ValorParcela = decimal.Parse(txtValorDaParcela.Text);

            if (!string.IsNullOrWhiteSpace(txtValorTotal.Text))
                ValorTotal = decimal.Parse(txtValorTotal.Text);

            if (!string.IsNullOrWhiteSpace(comboBoxStatusEmprestimo.Text))
                StatusEmprestimo = comboBoxStatusEmprestimo.Text;

            // Executa a busca no banco e vincula ao DataGrid
            DataTable dataTable = consultaEmprestimos.ConsultaEmprestimos(CodigoCliente, NomeCliente, StatusEmprestimo, ValorEmprestado, ValorParcela, ValorJurosMonetario, QtnParcela, ValorTotal);
            dataGridEmprestimos.DataSource = dataTable;
        }

        private void btnFechar_Click(object sender, EventArgs e) => Close();

        // --- EVENTO: Reseta todos os campos de filtro e limpa a grade ---
        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Clear();
            txtNomeCliente.Clear();
            txtCpfCnpjCliente.Clear();
            comboBoxSituacaoCliente.Text = "";
            comboBoxStatusEmprestimo.Text = "";
            txtValorTotal.Clear();
            txtQtnParcela.Clear();
            txtValorDaParcela.Clear();
            txtValorJurosMonetario.Clear();
            txtValorEmprestado.Clear();
            dataGridEmprestimos.DataSource = null;
        }

        // --- EVENTO: Consolida os dados da grade e gera um relatório em PDF ---
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidacaoDataGridVazio()) return;

            DataTable tabela = (DataTable)dataGridEmprestimos.DataSource;
            GeradorRelatorio relatorio = new GeradorRelatorio();

            // Cálculos de somatória para o rodapé do relatório
            int totalDeLinhas = dataGridEmprestimos.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
            decimal somarValorTotal = 0;
            decimal somarValorEmprestado = 0;

            foreach (DataGridViewRow row in dataGridEmprestimos.Rows)
            {
                if (!row.IsNewRow)
                {
                    somarValorTotal += Convert.ToDecimal(row.Cells["valor_total"].Value);
                    somarValorEmprestado += Convert.ToDecimal(row.Cells["valor_emprestado"].Value);
                }
            }

            // Passa os valores consolidados para a classe de relatório
            relatorio.ValorTotalReceber = somarValorTotal;
            relatorio.NumeroDeRegistros = totalDeLinhas;
            relatorio.ValorTotalEmprestado = somarValorEmprestado;

            // Gera o arquivo final
            relatorio.RelatorioEmprestimoPdf(tabela);
        }

        // --- EVENTO: Captura o código do empréstimo selecionado e fecha com sucesso ---
        private void dataGridEmprestimos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CodigoEmprestimoSelecionado = Convert.ToInt32(dataGridEmprestimos.CurrentRow.Cells["codigo"].Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

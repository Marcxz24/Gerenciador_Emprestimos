using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmVisualizarEmprestimos : Form
    {
        public int CodigoEmprestimoSelecionado { get; set; }

        public frmVisualizarEmprestimos()
        {
            InitializeComponent();
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorEmprestado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtValorJurosMonetario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtQtnParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorDaParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtValorTotal.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
        }

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

        private bool ValidacaoDataGridVazio()
        {
            if (dataGridEmprestimos.Rows.Count == 0 || (dataGridEmprestimos.Rows.Count == 1 && dataGridEmprestimos.Rows[0].IsNewRow))
            {
                Funcoes.MensagemWarning("Não é possível gerar um relatório com o DataGrid em Branco!");
                return true;
            }

            return false;
        }

        private void btnVisualizarEmprestimos_Click(object sender, EventArgs e)
        {
            EmprestimosConsulta consultaEmprestimos = new EmprestimosConsulta();

            int? CodigoCliente = null;
            string? NomeCliente = null;
            int? QtnParcela = null;
            decimal ValorEmprestado = 0;
            decimal ValorParcela = 0;
            decimal ValorJurosMonetario = 0;
            decimal ValorTotal = 0;
            string StatusEmprestimo = string.Empty;

            if (!string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                CodigoCliente = int.Parse(txtCodigoCliente.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                NomeCliente = txtNomeCliente.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtQtnParcela.Text))
            {
                QtnParcela = int.Parse(txtQtnParcela.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtValorEmprestado.Text))
            {
                ValorEmprestado = decimal.Parse(txtValorEmprestado.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtValorJurosMonetario.Text))
            {
                ValorJurosMonetario = decimal.Parse(txtValorJurosMonetario.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtValorDaParcela.Text))
            {
                ValorParcela = decimal.Parse(txtValorDaParcela.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtValorTotal.Text))
            {
                ValorTotal = decimal.Parse(txtValorTotal.Text);
            }

            if (!string.IsNullOrWhiteSpace(comboBoxStatusEmprestimo.Text))
            {
                StatusEmprestimo = comboBoxStatusEmprestimo.Text;
            }

            DataTable dataTable = consultaEmprestimos.ConsultaEmprestimos(CodigoCliente, NomeCliente, StatusEmprestimo, ValorEmprestado, ValorParcela, ValorJurosMonetario, QtnParcela, ValorTotal);

            dataGridEmprestimos.DataSource = dataTable;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidacaoDataGridVazio())
            {
                return;
            }

            DataTable tabela = (DataTable)dataGridEmprestimos.DataSource;

            GeradorRelatorio relatorio = new GeradorRelatorio();

            int totalDeLinhas = dataGridEmprestimos.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);

            decimal somarValorTotal = 0;
            decimal somarValorEmprestado = 0;

            foreach (DataGridViewRow row in dataGridEmprestimos.Rows)
            {
                if (!row.IsNewRow)
                {
                    somarValorTotal += Convert.ToDecimal(row.Cells["valor_emprestado_total"].Value);
                    somarValorEmprestado += Convert.ToDecimal(row.Cells["valor_emprestado"].Value);
                }
            }

            relatorio.ValorTotalReceber = somarValorTotal;
            relatorio.NumeroDeRegistros = totalDeLinhas;
            relatorio.ValorTotalEmprestado = somarValorEmprestado;

            relatorio.RelatorioEmprestimoPdf(tabela);
        }

        private void dataGridEmprestimos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CodigoEmprestimoSelecionado = Convert.ToInt32(dataGridEmprestimos.CurrentRow.Cells["codigo"].Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

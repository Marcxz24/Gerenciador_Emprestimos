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
            txtBoxCodigoEmprestimo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxNumeroParcela.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private void btnPesquisarParcela_Click(object sender, EventArgs e)
        {
            ParcelaConsulta parcelaConsulta = new ParcelaConsulta();

            int? CodigoEmprestimo = null;
            int? CodigoCliente = null;
            string? NomeCliente = null;
            string? StatusParcela = null;
            decimal ValorTotal = 0;
            decimal ValorParcela = 0;
            int? NumeroParcela = null;

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

            DataTable dataTable = parcelaConsulta.ConsultaParcela(CodigoEmprestimo, CodigoCliente, NomeCliente, StatusParcela, ValorTotal , ValorParcela, NumeroParcela);

            dataGridConsultaParcela.DataSource = dataTable;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            using (var formSelecionarCliente = new frmSelecionarCliente())
            {
                if (formSelecionarCliente.ShowDialog() == DialogResult.OK)
                {
                    var cliente = formSelecionarCliente.ClienteSelecionado;

                    txtBoxCodigoCliente.Text = cliente.codigo.ToString();
                    txtBoxNomeCliente.Text = cliente.nome_cliente;
                }
            }
        }

        private bool ValidacaoDataGrid()
        {
            if (dataGridConsultaParcela.Rows.Count == 0 || (dataGridConsultaParcela.Rows.Count == 1 && dataGridConsultaParcela.Rows[0].IsNewRow))
            {
                Funcoes.MensagemWarning("Não é possível gerar um relatório com o DataGrid em Branco!");
                return true;
            }

            return false;
        }

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidacaoDataGrid())
            {
                return;
            }

            DataTable dataTable = (DataTable)dataGridConsultaParcela.DataSource;

            GeradorRelatorio relatorio = new GeradorRelatorio();

            int totalDeLinhas = dataGridConsultaParcela.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);

            decimal ValorTotalParcela = 0;

            foreach (DataGridViewRow row in dataGridConsultaParcela.Rows)
            {
                if (!row.IsNewRow)
                {
                    ValorTotalParcela += Convert.ToDecimal(row.Cells["valor_parcela"].Value);
                }
            }

            relatorio.ValorTotalReceber = ValorTotalParcela;
            relatorio.NumeroDeRegistros = totalDeLinhas;

            relatorio.RelatorioParcelas(dataTable);
        }
    }
}

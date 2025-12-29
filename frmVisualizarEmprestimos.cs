using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmVisualizarEmprestimos : Form
    {
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
            frmSelecionarCliente pesquisarCliente = new frmSelecionarCliente();
            pesquisarCliente.ShowDialog();

            string codigo = pesquisarCliente.codigoSelecionado;

            CarregarDadosCliente(codigo);
        }

        private void CarregarDadosCliente(string codigo)
        {
            string clienteSql = "SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            {
                MySqlCommand sqlComando = new MySqlCommand(clienteSql, conexao);
                sqlComando.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader Reader = sqlComando.ExecuteReader();

                if (Reader.Read())
                {
                    txtCodigoCliente.Text = Reader["codigo"].ToString();
                    txtNomeCliente.Text = Reader["nome_cliente"].ToString();
                    txtCpfCnpjCliente.Text = Reader["cpf_cnpj"].ToString();
                    comboBoxSituacaoCliente.Text = Reader["situacao_cadastral"].ToString();
                }
            }
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

        }
    }
}

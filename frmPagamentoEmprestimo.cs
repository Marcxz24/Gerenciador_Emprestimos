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
        public frmPagamentoEmprestimo()
        {
            InitializeComponent();
            txtBoxTotalPagar.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxCodigoEmprestimo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtBoxValorJuros.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
        }

        private void btnLocalizarEmprestimo_Click(object sender, EventArgs e)
        {
            PagamentoParcelaConsulta parcelaConsulta = new PagamentoParcelaConsulta();

            int codigoCliente = 0;
            int codigoEmprestimo = 0;
            decimal valorJuros = 0;
            decimal valorTotal = 0;
            decimal valorParcela = 0;

            if (!string.IsNullOrWhiteSpace(txtBoxCodigoCliente.Text) && int.TryParse(txtBoxCodigoCliente.Text, out int codCliente))
            {
                codigoCliente = codCliente;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxCodigoEmprestimo.Text) && int.TryParse(txtBoxCodigoEmprestimo.Text, out int codEmprestimos))
            {
                codigoEmprestimo = codEmprestimos;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxValorJuros.Text) && decimal.TryParse(txtBoxValorJuros.Text, out decimal valueJuros))
            {
                valorJuros = valueJuros;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxValorTotal.Text) && decimal.TryParse(txtBoxValorTotal.Text, out decimal valueTotal))
            {
                valorTotal = valueTotal;
            }

            if (!string.IsNullOrWhiteSpace(txtBoxValorParcela.Text) && decimal.TryParse(txtBoxValorParcela.Text, out decimal valueParcela))
            {
                valorParcela = valueParcela;
            }

            DataTable dateTable = parcelaConsulta.ConsultaClienteEmprestimo(codigoCliente, codigoEmprestimo, valorJuros, valorTotal, valorParcela);

            dataGridParcelasAbertas.DataSource = dateTable;
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
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

        private bool ValidacoesCampos()
        {
            if (string.IsNullOrEmpty(txtBoxCodigoCliente.Text) && string.IsNullOrEmpty(txtBoxCliente.Text))
            {
                Funcoes.MensagemWarning("Não é possivel realizar um pagamento sem um Cliente Selecionado, Por favor Preencha!\n\nCampo: Código e Nome do Cliente!");
                return false;
            }

            return true;
        }

        private void btnLimparDadosTela_Click(object sender, EventArgs e)
        {
            txtBoxCodigoCliente.Clear();
            txtBoxCliente.Clear();
            txtBoxCodigoEmprestimo.Clear();
            txtBoxValorJuros.Clear();
            txtBoxValorTotal.Clear();
            txtBoxValorParcela.Clear();
            dataGridParcelasAbertas.DataSource = null;
        }

        private void btnGerarPagamento_Click(object sender, EventArgs e)
        {
            if (ValidacoesCampos())
            {
                return;
            }
        }
    }
}

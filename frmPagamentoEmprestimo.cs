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
        private int _codigoEmprestimo;

        public frmPagamentoEmprestimo()
        {
            InitializeComponent();
        }

        private void CarregarDadosEmprestimos(int codigoEmprestimo)
        {
            var consulta = new EmprestimosConsulta();

            DataTable dataTable = consulta.ConsultaEmprestimosPorCodigo(codigoEmprestimo);

            if (dataTable.Rows.Count == 0)
            {
                Funcoes.MensagemWarning("Empréstimo não Encontrado.");
                return;
            }

            DataRow linha = dataTable.Rows[0];

            txtBoxCodigoEmprestimo.Text = linha["codigo"].ToString();
            txtBoxStatusEmprestimo.Text = linha["status_emprestimo"].ToString();
        }

        private void CarregarDadosCliente(int CodigoCliente)
        {
            var consulta = new SelecionarCliente();

            DataTable dataTable = consulta.ConsultarClientePorCodigo(CodigoCliente);

            if (dataTable.Rows.Count == 0)
            {
                Funcoes.MensagemWarning("Cliente Não Encontrado!");
                return;
            }

            DataRow row = dataTable.Rows[0];

            txtBoxCodigoCliente.Text = row["codigo"].ToString();
            txtBoxCliente.Text = row["nome_cliente"].ToString();
        }

        private void btnLocalizarEmprestimo_Click(object sender, EventArgs e)
        {
            using (var formVisualizarEmprestimos = new frmVisualizarEmprestimos())
            {
                if (formVisualizarEmprestimos.ShowDialog() == DialogResult.OK)
                {
                    int codigoEmprestimos = formVisualizarEmprestimos.CodigoEmprestimoSelecionado;

                    CarregarDadosEmprestimos(codigoEmprestimos);
                }
            }
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            using (var formVisualizarCliente = new frmSelecionarCliente())
            {
                if (formVisualizarCliente.ShowDialog() == DialogResult.OK)
                {
                    int codigoCliente = Convert.ToInt32(formVisualizarCliente.codigoSelecionado);

                    CarregarDadosCliente(codigoCliente);
                }
            }
        }

        private void btnLimparDadosTela_Click(object sender, EventArgs e)
        {
            txtBoxCodigoCliente.Clear();
            txtBoxCliente.Clear();
            txtBoxCodigoEmprestimo.Clear();
            txtBoxStatusEmprestimo.Clear();
        }
    }
}

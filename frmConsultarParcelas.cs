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
            decimal ValorParcela = 0;
            int? NumeroParcela = null;

            if (CodigoEmprestimo.HasValue)
            {
                CodigoEmprestimo = int.Parse(txtBoxCodigoEmprestimo.Text);
            }

            if (CodigoCliente.HasValue)
            {
                CodigoCliente = int.Parse(txtBoxCodigoCliente.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtBoxNomeCliente.Text))
            {
                NomeCliente = txtBoxNomeCliente.Text;
            }

            if (!string.IsNullOrWhiteSpace(cmbBoxStatusParcela.Text))
            {
                StatusParcela = cmbBoxStatusParcela.Text;
            }

            if (ValorParcela > 0)
            {
                ValorParcela = decimal.Parse(txtBoxValorParcela.Text);
            }

            if (NumeroParcela > 0)
            {
                NumeroParcela = int.Parse(txtBoxNumeroParcela.Text);
            }

            DataTable dataTable = parcelaConsulta.ConsultaParcela(CodigoEmprestimo, CodigoCliente, NomeCliente, StatusParcela, ValorParcela, NumeroParcela);

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
    }
}

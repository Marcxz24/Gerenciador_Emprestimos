using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
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
    public partial class FormEmprestimos : Form
    {
        public FormEmprestimos()
        {
            InitializeComponent();
            txtBoxCodigoCliente.KeyPress += SomenteNumeros_KeyPress;
            txtBoxTaxaJuros.KeyPress += SomenteNumeros_KeyPress;
            txtBoxValorEmprestado.KeyPress += SomenteNumeros_KeyPress;
            txtBoxValorJuros.KeyPress += SomenteNumeros_KeyPress;
            maskTxtCpfCnpjCliente.KeyPress += SomenteNumeros_KeyPress;
        }

        private void SomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void ValidacoesEmprestimo()
        {
            if (string.IsNullOrEmpty(txtBoxNomeCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Nome do Cliente");
                return;
            }

            if (string.IsNullOrEmpty(maskTxtCpfCnpjCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF do Cliente");
                return;
            }

            if (string.IsNullOrEmpty(txtBoxValorEmprestado.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Valor Emprestado");
                return;
            }

            if (string.IsNullOrEmpty(txtBoxTaxaJuros.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Percentual dos Juros");
                return;
            }

            if (string.IsNullOrEmpty(maskTxtDataEmprestimo.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Data do Emprestimo");
                return;
            }
        }

        private void CarregarDadosCliente(string codigo)
        {
            string sqlSelect = $"SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            {
                MySqlCommand sqlCommando = new MySqlCommand(sqlSelect, conexao);
                sqlCommando.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = sqlCommando.ExecuteReader();

                if (reader.Read())
                {
                    txtBoxCodigoCliente.Text = reader["codigo"].ToString();
                    txtBoxNomeCliente.Text = reader["nome_cliente"].ToString();
                    maskTxtCpfCnpjCliente.Text = reader["cpf_cnpj"].ToString();
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmSelecionarCliente formPesquisarCliente = new frmSelecionarCliente();
            formPesquisarCliente.ShowDialog();

            string codigo = formPesquisarCliente.codigoSelecionado;

            CarregarDadosCliente(codigo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBoxCodigoCliente.Clear();
            txtBoxNomeCliente.Clear();
            maskTxtCpfCnpjCliente.Clear();
            txtBoxTaxaJuros.Clear();
            txtBoxValorEmprestado.Clear();
            txtBoxValorJuros.Clear();
            maskTxtDataEmprestimo.Clear();
            txtBoxTotalPagar.Clear();
        }

        private void btnGerarEmprestimos_Click(object sender, EventArgs e)
        {
            ValidacoesEmprestimo();
        }

        private void btnCalcularEmprestimo_Click(object sender, EventArgs e)
        {
            ValidacoesEmprestimo();

            try
            {
                EmprestimosCliente emprestimo = new EmprestimosCliente();

                emprestimo.ValorEmprestado = decimal.Parse(txtBoxValorEmprestado.Text);
                emprestimo.TaxaJuros = decimal.Parse(txtBoxTaxaJuros.Text);
                decimal valorTotal = emprestimo.CalcularValorTotal();

                txtBoxValorJuros.Text = emprestimo.TaxaJuros.ToString("F2");
                txtBoxTotalPagar.Text = emprestimo.ValorTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

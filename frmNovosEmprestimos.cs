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
            txtBoxQuantidadeParcela.KeyPress += SomenteNumeros_KeyPress;
            txtBoxValorParcela.KeyPress += SomenteNumeros_KeyPress;
            maskTxtCpfCnpjCliente.KeyPress += SomenteNumeros_KeyPress;
        }

        private void SomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
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

            // Validação de Data do Empréstimo
            DateTime dataEmprestimo;

            if (!DateTime.TryParse(maskTxtDataEmprestimo.Text, out dataEmprestimo))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Data do Emprestimo");
                return true;
            }

            if (DateTime.TryParse(maskTxtDataEmprestimo.Text, out dataEmprestimo))
            {
                if (dataEmprestimo > DateTime.Now)
                {
                    Funcoes.MensagemWarning("A Data do Empréstimo não pode ser maior que a Data Atual!\n\nPor favor, verifique a Data do Empréstimo.");
                    return true;
                }

                if (dataEmprestimo < new DateTime(2000, 1, 1))
                {
                    Funcoes.MensagemErro("Data de Emprestimo inválida! Por favor Preencha uma Data Válida!");
                    return true;
                }
            }

            return false;
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
            txtBoxValorEmpresto.Clear();
            txtBoxValorJuros.Clear();
            maskTxtDataEmprestimo.Clear();
            txtBoxTotalPagar.Clear();
            txtBoxQuantidadeParcela.Clear();
            txtBoxValorParcela.Clear();
        }

        private void btnGerarEmprestimos_Click(object sender, EventArgs e)
        {
            ValidacoesEmprestimo();
        }

        private void btnCalcularEmprestimo_Click(object sender, EventArgs e)
        {
            if (ValidacoesEmprestimo() == true)
            {
                return;
            }

            EmprestimosCliente emprestimo = new EmprestimosCliente();

            // Retirado o uso do Método Try Catch, para testar com o comportamento do TryParse...
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

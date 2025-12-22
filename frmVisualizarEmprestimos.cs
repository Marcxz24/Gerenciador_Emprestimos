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
    public partial class frmVisualizarEmprestimos : Form
    {
        public frmVisualizarEmprestimos()
        {
            InitializeComponent();
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorEmprestado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtValorJurosPercentual.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
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

            DataTable dataTable = consultaEmprestimos.ConsultaEmprestimos();

            dataGridEmprestimos.DataSource = dataTable;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            dataGridEmprestimos.DataSource = null;
        }
    }
}

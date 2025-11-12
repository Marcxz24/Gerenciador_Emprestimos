using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Gerenciador_de_Emprestimos
{
    public partial class formSelecionarCliente : Form
    {
        public formSelecionarCliente()
        {
            InitializeComponent();
        }

        // Oque seria essas implementações dos campos de filtrar cliente?

        // Dificuldade para entender o processo de SELECT no programa, sem implementar no DataGrid e como chamar.
        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            string selectBd = $"SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj FROM emprestimosbd.cliente;";

            var conexao = ConexaoBancoDeDados.Conectar();

            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }

            using (var dataAdapter = new MySqlDataAdapter(selectBd, conexao))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridClientes.DataSource = dataTable;
            }
        }

        private void btnCpfSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCpfSelecionar.Checked == true)
            {
                maskedCpfCnpj.Mask = "000,000,000-00";
            }
        }

        private void btnCnpjSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCnpjSelecionar.Checked == true)
            {
                maskedCpfCnpj.Mask = "00,000,000/0000-00";
            }
        }

        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Clear();
            txtNomeCliente.Clear();
            maskedCelularSelecionar.Clear();
            maskedCpfCnpj.Clear();
            comboBoxGeneroCliente.Items.Clear();
            comboBoxSituacaoCadastralSelecionar.Items.Clear();
            btnCpfSelecionar.Checked = false;
            btnCnpjSelecionar.Checked = false;
        }
    }
}

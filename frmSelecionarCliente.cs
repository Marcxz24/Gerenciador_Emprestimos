using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmSelecionarCliente : Form
    {
        public frmSelecionarCliente()
        {
            InitializeComponent();
            txtCodigoCliente.KeyPress += SomenteNumeros_KeyPress;
            maskedCelularSelecionar.KeyPress += SomenteNumeros_KeyPress;
            maskedCpfCnpj.KeyPress += SomenteNumeros_KeyPress;
        }

        private void SomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            string selectBd = $"SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj FROM emprestimosbd.cliente LIMIT 10;";

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
            maskedCpfCnpj.Clear();

            if (btnCpfSelecionar.Checked == true)
            {
                maskedCpfCnpj.Mask = "000,000,000-00";
            }
        }

        private void btnCnpjSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            maskedCpfCnpj.Clear();

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
            comboBoxGeneroCliente.SelectedIndex = -1;
            comboBoxSituacaoCadastralSelecionar.SelectedIndex = -1;
            btnCpfSelecionar.Checked = true;
            btnCnpjSelecionar.Checked = false;
        }
    }
}

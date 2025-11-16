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
        
        private string QuerySelecionarCliente(MySqlCommand Filtrar)
        {
            string filtrosPesquisa = "WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                filtrosPesquisa += " AND codigo = @codigo";
                Filtrar.Parameters.AddWithValue("@codigo", txtCodigoCliente.Text);
            }

            if(!string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                filtrosPesquisa += " AND nome_cliente LIKE @nome_cliente";
                Filtrar.Parameters.AddWithValue("@nome_cliente", "%" + txtNomeCliente.Text + "%");
            }

            if (!string.IsNullOrEmpty(comboBoxGeneroCliente.Text))
            {
                filtrosPesquisa += " AND genero = @genero";
                Filtrar.Parameters.AddWithValue("@genero", comboBoxGeneroCliente.Text);
            }

            if (!string.IsNullOrEmpty(maskedCelularSelecionar.Text))
            {
                filtrosPesquisa += " AND celular = @celular";
                Filtrar.Parameters.AddWithValue("@celular", maskedCelularSelecionar.Text);
            }

            if (!string.IsNullOrEmpty(comboBoxSituacaoCadastralSelecionar.Text))
            {
                filtrosPesquisa += " AND situacao_cadastral = @situacao_cadastral";
                Filtrar.Parameters.AddWithValue("@situacao_cadastral", comboBoxSituacaoCadastralSelecionar.Text);
            }

            if (!string.IsNullOrEmpty(maskedCpfCnpj.Text))
            {
                filtrosPesquisa += " AND cpf_cnpj = @cpf_cnpj";
                Filtrar.Parameters.AddWithValue("@cpf_cnpj", maskedCpfCnpj.Text);
            }

            return filtrosPesquisa;
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        { 
            var conexao = ConexaoBancoDeDados.Conectar();

            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }

            MySqlCommand comando = conexao.CreateCommand();
            string filtrosPesquisa = QuerySelecionarCliente(comando);

            string selectBd = $"SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj FROM emprestimosbd.cliente {filtrosPesquisa} LIMIT 10;";

            comando.CommandText = selectBd;

            using (var dataAdapter = new MySqlDataAdapter(comando))
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

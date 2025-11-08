using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class formSelecionarCliente : Form
    {
        DataTable dataTable = new DataTable();

        public formSelecionarCliente()
        {
            InitializeComponent();
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            dataTable = SelecionarCliente.GetClientes(true);
            dataGridClientes.DataSource = dataTable;
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

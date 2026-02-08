using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;
using Mysqlx;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmSelecionarCliente : Form
    {
        // Propriedades para disponibilizar o resultado da seleção para outros formulários
        public string codigoSelecionado { get; private set; }
        public SelecionarCliente ClienteSelecionado { get; private set; }

        public frmSelecionarCliente()
        {
            InitializeComponent();
            // Vinculação de eventos para restringir a entrada de dados apenas a números
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            maskedCelularSelecionar.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            maskedCpfCnpj.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtNumeroResidencia.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // --- EVENTO: Executa a busca de clientes no banco de dados ---
        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                SelecionarCliente selecionarCliente = new SelecionarCliente();

                int codigoCliente = string.IsNullOrWhiteSpace(txtCodigoCliente.Text) ? 0 : int.Parse(txtCodigoCliente.Text);
                string nomeCliente = txtNomeCliente.Text.Trim();
                string bairro = txtBairro.Text.Trim();
                string endereco = txtEndereco.Text.Trim();
                int numeroResidencia = string.IsNullOrWhiteSpace(txtNumeroResidencia.Text) ? 0 : int.Parse(txtNumeroResidencia.Text);
                string celular = maskedCelularSelecionar.Text.Replace(",", "").Trim();
                string cpfCnpj = maskedCpfCnpj.Text.Replace(",", "").Replace("-", "").Replace("/", "").Trim();  
                string genero = comboBoxGeneroCliente.SelectedItem?.ToString() ?? string.Empty; 
                string situacaoCadastral = comboBoxSituacaoCadastralSelecionar.SelectedItem?.ToString() ?? string.Empty;
                string uf = ComboBoxUF.SelectedItem?.ToString() ?? string.Empty;

                dataGridClientes.DataSource = selecionarCliente.ListarClientes();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao Selecionar cliente.\n\nDetalhes: " + ex.Message);
            }
        }

        // --- EVENTO: Altera a máscara do campo para formato de CPF ---
        private void btnCpfSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            maskedCpfCnpj.Clear();

            if (btnCpfSelecionar.Checked == true)
            {
                maskedCpfCnpj.Mask = "000,000,000-00";
            }
        }

        // --- EVENTO: Altera a máscara do campo para formato de CNPJ ---
        private void btnCnpjSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            maskedCpfCnpj.Clear();

            if (btnCnpjSelecionar.Checked == true)
            {
                maskedCpfCnpj.Mask = "00,000,000/0000-00";
            }
        }

        // --- EVENTO: Fecha o formulário ---
        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        // --- EVENTO: Limpa todos os filtros e a grade de resultados ---
        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Clear();
            txtNomeCliente.Clear();
            txtBairro.Clear();
            txtEndereco.Clear();
            txtNumeroResidencia.Clear();
            maskedCelularSelecionar.Clear();
            maskedCpfCnpj.Clear();
            comboBoxGeneroCliente.SelectedIndex = -1;
            comboBoxSituacaoCadastralSelecionar.SelectedIndex = -1;
            btnCpfSelecionar.Checked = true;
            btnCnpjSelecionar.Checked = false;
            dataGridClientes.DataSource = null;
            ComboBoxUF.SelectedIndex = -1;
        }

        // --- EVENTO: Seleciona o cliente com duplo clique, retornando o objeto para o formulário chamador ---
        private void dataGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                // Captura o código da linha selecionada
                int codigo = Convert.ToInt32(dataGridClientes.Rows[e.RowIndex].Cells["codigo"].Value);

                var service = new SelecionarCliente();

                // Busca os dados completos do cliente e preenche a propriedade pública
                ClienteSelecionado = service.BuscarClientePorCodigo(codigo);

                // Define o resultado como OK para sinalizar ao formulário pai que houve seleção
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao selecionar o cliente.\n\nDetalhes: " + ex.Message);
            }
        }
    }
}

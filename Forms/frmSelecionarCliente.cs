using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
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
        public ClienteDTO ClienteSelecionado { get; private set; }

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
                ClienteDAO selecionarCliente = new ClienteDAO();

                int.TryParse(txtCodigoCliente.Text, out int codigoConvertido);
                int.TryParse(txtNumeroResidencia.Text, out int numeroRes);

                ClienteDTO cliente = new ClienteDTO
                {
                    codigo = codigoConvertido,
                    nome_cliente = txtNomeCliente.Text,
                    bairro = txtBairro.Text,
                    endereco = txtEndereco.Text,
                    cidade = txtCidade.Text,
                    uf = ComboBoxUF.Text,
                    genero = comboBoxGeneroCliente.Text,
                    numero_residencia = numeroRes
                };

                dataGridClientes.DataSource = selecionarCliente.ListarClientes(cliente);

                if (dataGridClientes.Columns.Count > 0)
                {
                    dataGridClientes.Columns["codigo"].HeaderText = "CÓDIGO";
                    dataGridClientes.Columns["nome_cliente"].HeaderText = "NOME DO CLIENTE";
                    dataGridClientes.Columns["nome_fantasia"].HeaderText = "NOME FANTASIA";
                    dataGridClientes.Columns["genero"].HeaderText = "GÊNERO";
                    dataGridClientes.Columns["celular"].HeaderText = "CONTATO";
                    dataGridClientes.Columns["situacao_cadastral"].HeaderText = "STATUS";
                    dataGridClientes.Columns["cpf_cnpj"].HeaderText = "CPF / CNPJ";
                }
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

                var clienteDAO = new ClienteDAO();

                // Busca os dados completos do cliente e preenche a propriedade pública
                this.ClienteSelecionado = clienteDAO.BuscarClientePorCodigo(codigo);

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

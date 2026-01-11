using Gerenciador_de_Emprestimos.Database;
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
            var conexao = ConexaoBancoDeDados.Conectar();

            // Garante que a conexão esteja aberta antes de prosseguir
            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }

            MySqlCommand comando = conexao.CreateCommand();
            // Chama o método auxiliar para construir a cláusula WHERE e adicionar parâmetros
            string filtrosPesquisa = QuerySelecionarCliente(comando);

            // Define a query completa com limite de 100 registros para performance
            string selectBd = $"SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj, uf, cidade, endereco, bairro, numero_residencia FROM emprestimosbd.cliente {filtrosPesquisa} LIMIT 100;";

            comando.CommandText = selectBd;

            using (var dataAdapter = new MySqlDataAdapter(comando))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Exibe os dados retornados na grade
                dataGridClientes.DataSource = dataTable;
            }
        }

        // --- MÉTODO: Construtor dinâmico da Query SQL baseada nos filtros preenchidos ---
        private string QuerySelecionarCliente(MySqlCommand Filtrar)
        {
            string filtrosPesquisa = "WHERE 1 = 1";

            // Filtro por Código
            if (!string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                filtrosPesquisa += " AND codigo = @codigo";
                Filtrar.Parameters.AddWithValue("@codigo", txtCodigoCliente.Text);
            }

            // Filtro por Nome (utiliza LIKE para buscas parciais)
            if (!string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                filtrosPesquisa += " AND nome_cliente LIKE @nome_cliente";
                Filtrar.Parameters.AddWithValue("@nome_cliente", "%" + txtNomeCliente.Text + "%");
            }

            // Filtro por Gênero
            if (!string.IsNullOrEmpty(comboBoxGeneroCliente.Text) && !comboBoxGeneroCliente.Text.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                filtrosPesquisa += " AND genero = @genero";
                Filtrar.Parameters.AddWithValue("@genero", comboBoxGeneroCliente.Text);
            }

            // Filtro por Celular
            if (!string.IsNullOrEmpty(maskedCelularSelecionar.Text))
            {
                filtrosPesquisa += " AND celular = @celular";
                Filtrar.Parameters.AddWithValue("@celular", maskedCelularSelecionar.Text);
            }

            // Filtro por Situação Cadastral
            if (!string.IsNullOrEmpty(comboBoxSituacaoCadastralSelecionar.Text) && !comboBoxSituacaoCadastralSelecionar.Text.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                filtrosPesquisa += " AND situacao_cadastral = @situacao_cadastral";
                Filtrar.Parameters.AddWithValue("@situacao_cadastral", comboBoxSituacaoCadastralSelecionar.Text);
            }

            // Filtro por CPF ou CNPJ
            if (!string.IsNullOrEmpty(maskedCpfCnpj.Text))
            {
                filtrosPesquisa += " AND cpf_cnpj = @cpf_cnpj";
                Filtrar.Parameters.AddWithValue("@cpf_cnpj", maskedCpfCnpj.Text);
            }

            // Filtro por Cidade
            if (!string.IsNullOrEmpty(txtCidade.Text))
            {
                filtrosPesquisa += " AND cidade LIKE @cidade";
                Filtrar.Parameters.AddWithValue("@cidade", "%" + txtCidade.Text + "%");
            }

            // Filtro por UF
            if (!string.IsNullOrEmpty(ComboBoxUF.Text) && !ComboBoxUF.Text.Equals("Todos", StringComparison.OrdinalIgnoreCase))
            {
                filtrosPesquisa += " AND uf LIKE @uf";
                Filtrar.Parameters.AddWithValue("@uf", ComboBoxUF.Text);
            }

            // Filtro por Endereço
            if (!string.IsNullOrEmpty(txtEndereco.Text))
            {
                filtrosPesquisa += " AND endereco LIKE @endereco";
                Filtrar.Parameters.AddWithValue("@endereco", "%" + txtEndereco.Text + "%");
            }

            // Filtro por Bairro
            if (!string.IsNullOrEmpty(txtBairro.Text))
            {
                filtrosPesquisa += " AND bairro LIKE @bairro";
                Filtrar.Parameters.AddWithValue("@bairro", "%" + txtBairro.Text + "%");
            }

            // Filtro por Número da Residência
            if (!string.IsNullOrEmpty(txtNumeroResidencia.Text))
            {
                filtrosPesquisa += " AND numero_residencia LIKE @numero_residencia";
                Filtrar.Parameters.AddWithValue("@numero_residencia", "%" + txtNumeroResidencia.Text + "%");
            }

            return filtrosPesquisa;
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
    }
}

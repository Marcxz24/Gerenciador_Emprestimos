using System.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmSelecionarFuncionario : Form
    {
        // Propriedade para retornar o objeto do funcionário selecionado para o formulário chamador
        public SelecionarFuncionario FuncionarioSelecionado { get; private set; }


        public frmSelecionarFuncionario()
        {
            InitializeComponent();

            // --- RESTRIÇÕES DE ENTRADA ---
            // Garante que campos de ID, CPF e Telefone aceitem apenas números durante a digitação
            txtCodigoFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCpfFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtTelefoneFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // --- EVENTO: Realiza a busca de funcionários com base nos filtros preenchidos ---
        private void btnSelecionarFuncionario_Click(object sender, EventArgs e)
        {
            SelecionarFuncionario selecionarFuncionario = new SelecionarFuncionario();

            // Inicialização de variáveis para os filtros
            int CodigoFuncionario = 0;
            string? nomeFuncionario = null;
            string? cpf = null;
            string? sexo = null;
            string? estadoCivil = null;
            string? telefoneFuncionario = null;
            string? cidadeFuncionario = null;
            string? situacaoFuncionario = null;

            // Captura e validação do Código
            if (!string.IsNullOrWhiteSpace(txtCodigoFuncionario.Text) && int.TryParse(txtCodigoFuncionario.Text, out int codFuncionario))
            {
                CodigoFuncionario = codFuncionario;
            }

            // Captura do Nome
            if (!string.IsNullOrWhiteSpace(txtNomeFuncionario.Text))
            {
                nomeFuncionario = txtNomeFuncionario.Text;
            }

            // Captura do CPF removendo a formatação (pontos e traços) para busca no banco
            if (!string.IsNullOrWhiteSpace(txtCpfFuncionario.Text))
            {
                cpf = txtCpfFuncionario.Text.Replace(".", "").Replace("-", "").Trim();
            }

            // Captura do Gênero
            if (!string.IsNullOrWhiteSpace(comboBoxGeneroCliente.Text))
            {
                sexo = comboBoxGeneroCliente.Text;
            }

            // Captura do Estado Civil
            if (!string.IsNullOrWhiteSpace(comboBoxEstadoCivil.Text))
            {
                estadoCivil = comboBoxEstadoCivil.Text;
            }

            // Captura do Telefone removendo parênteses e traços
            if (!string.IsNullOrWhiteSpace(txtTelefoneFuncionario.Text))
            {
                telefoneFuncionario = txtTelefoneFuncionario.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            }

            // Captura da Cidade
            if (!string.IsNullOrWhiteSpace(txtCidadeFuncionario.Text))
            {
                cidadeFuncionario = txtCidadeFuncionario.Text;
            }

            // Captura da Situação Cadastral
            if (!string.IsNullOrWhiteSpace(comboBoxSituacaoCadastralSelecionar.Text))
            {
                situacaoFuncionario = comboBoxSituacaoCadastralSelecionar.Text;
            }

            // Chama o método da classe de serviço que executa a Query no banco de dados
            DataTable dataTable = selecionarFuncionario.ListarFuncionarios(CodigoFuncionario, nomeFuncionario, cpf, sexo, estadoCivil, telefoneFuncionario, cidadeFuncionario, situacaoFuncionario);

            // Alimenta o DataGrid com os funcionários encontrados
            dataGridFuncionarios.DataSource = dataTable;
        }

        // --- EVENTO: Limpa todos os campos de filtro e reseta a grade ---
        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            dataGridFuncionarios.DataSource = null;
            txtCodigoFuncionario.Clear();
            txtNomeFuncionario.Clear();
            txtCpfFuncionario.Clear();
            txtTelefoneFuncionario.Clear();
            txtCidadeFuncionario.Clear();
            comboBoxGeneroCliente.SelectedIndex = -1;
            comboBoxEstadoCivil.SelectedIndex = -1;
            comboBoxSituacaoCadastralSelecionar.SelectedIndex = -1;
        }

        // --- EVENTO: Fecha o formulário de seleção ---
        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        // --- EVENTO: Seleciona o funcionário ao clicar duas vezes na linha da grade ---
        private void dataGridFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora cliques no cabeçalho
            if (e.RowIndex < 0)
                return;

            // Recupera o código do funcionário da linha selecionada
            int codigoFuncionario = Convert.ToInt32(dataGridFuncionarios.Rows[e.RowIndex].Cells["codigo"].Value);

            var service = new SelecionarFuncionario();

            // Busca o objeto completo do funcionário pelo código
            FuncionarioSelecionado = service.SelecionarFuncionarioPorCodigo(codigoFuncionario);

            // Define o resultado do diálogo como OK e fecha a tela para retornar o dado ao formulário pai
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

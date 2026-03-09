using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using System.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmSelecionarFuncionario : Form
    {
        // Propriedade para retornar o objeto do funcionário selecionado para o formulário chamador
        public FuncionarioDTO FuncionarioSelecionado { get; private set; }


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
            try
            {
                int.TryParse(txtCodigoFuncionario.Text, out int codigoFuncionario);

                string telefoneLimpo = txtTelefoneFuncionario.Text.
                    Replace("(", "").
                    Replace(")", "").
                    Replace("-", "").
                    Trim();

                string documentoLimpo = txtCpfFuncionario.Text.
                    Replace(".", "").
                    Replace("-", "").
                    Trim();

                FuncionarioDTO funcionarioDTO = new FuncionarioDTO
                {
                    Codigo = codigoFuncionario,
                    Nome = txtNomeFuncionario.Text,
                    Cpf = documentoLimpo,
                    Sexo = comboBoxGeneroCliente.Text,
                    EstadoCivil = comboBoxEstadoCivil.Text, 
                    Telefone = telefoneLimpo,
                    Cidade = txtCidadeFuncionario.Text,
                    Situacao = comboBoxSituacaoCadastralSelecionar.Text,
                };

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

                // Chama o método da classe de serviço que executa a Query no banco de dados
                DataTable dataTable = funcionarioDAO.ListarFuncionarios(funcionarioDTO);

                // Alimenta o DataGrid com os funcionários encontrados
                dataGridFuncionarios.DataSource = null;
                dataGridFuncionarios.Columns.Clear();
                dataGridFuncionarios.AutoGenerateColumns = true;
                dataGridFuncionarios.DataSource = dataTable;
                
                if (dataGridFuncionarios.Columns.Count > 0)
                {
                    dataGridFuncionarios.Columns["codigo"].HeaderText = "CODIGO";
                    dataGridFuncionarios.Columns["nome_funcionario"].HeaderText = "NOME";
                    dataGridFuncionarios.Columns["cpf_funcionario"].HeaderText = "CPF";
                    dataGridFuncionarios.Columns["sexo_funcionario"].HeaderText = "SEXO";
                    dataGridFuncionarios.Columns["funcionario_estado_civil"].HeaderText = "ESTADO CIVIL";
                    dataGridFuncionarios.Columns["username"].HeaderText = "USERNAME";
                    dataGridFuncionarios.Columns["telefone_funcionario"].HeaderText = "TELEFONE";
                    dataGridFuncionarios.Columns["cidade_funcionario"].HeaderText = "CIDADE";
                    dataGridFuncionarios.Columns["endereco_funcionario"].HeaderText = "ENDEREÇO";
                    dataGridFuncionarios.Columns["bairro_funcionario"].HeaderText = "BAIRRO";
                    dataGridFuncionarios.Columns["numero_residencia"].HeaderText = "N° RESIDÊNCIA";
                    dataGridFuncionarios.Columns["uf_funcionario"].HeaderText = "ESTADO";
                    dataGridFuncionarios.Columns["situacao_funcionario"].HeaderText = "SITUACAO";
                }
                else
                {
                    Funcoes.MensagemWarning("Nenhum funcionário encontrado com estes filtros.");
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Erro ao filtrar funcionários: " + ex.Message);
                Funcoes.MensagemErro("Erro técnico ao listar. Verifique o log.");
            }
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
            try
            {
                // Ignora cliques no cabeçalho
                if (e.RowIndex < 0)
                    return;

                // Recupera o código do funcionário da linha selecionada
                int codigoFuncionario = Convert.ToInt32(dataGridFuncionarios.Rows[e.RowIndex].Cells["codigo"].Value);

                var funcionario = new FuncionarioDAO();

                // Busca o objeto completo do funcionário pelo código
                FuncionarioSelecionado = funcionario.SelecionarFuncionarioPorCodigo(codigoFuncionario);

                // Define o resultado do diálogo como OK e fecha a tela para retornar o dado ao formulário pai
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao selecionar o funcionário.\n\nDetalhes: " + ex.Message);
            }
        }
    }
}
using System.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmSelecionarFuncionario : Form
    {
        public SelecionarFuncionario FuncionarioSelecionado { get; private set; }


        public frmSelecionarFuncionario()
        {
            InitializeComponent();
            txtCodigoFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCpfFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtTelefoneFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private void btnSelecionarFuncionario_Click(object sender, EventArgs e)
        {
            SelecionarFuncionario selecionarFuncionario = new SelecionarFuncionario();

            int CodigoFuncionario = 0;
            string? nomeFuncionario = null;
            string? cpf = null;
            string? sexo = null;
            string? estadoCivil = null;
            string? telefoneFuncionario = null;
            string? cidadeFuncionario = null;
            string? situacaoFuncionario = null;

            if (!string.IsNullOrWhiteSpace(txtCodigoFuncionario.Text) && int.TryParse(txtCodigoFuncionario.Text, out int codFuncionario))
            {
                CodigoFuncionario = codFuncionario;
            }

            if (!string.IsNullOrWhiteSpace(txtNomeFuncionario.Text))
            {
                nomeFuncionario = txtNomeFuncionario.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtCpfFuncionario.Text))
            {
                cpf = txtCpfFuncionario.Text.Replace(".", "").Replace("-", "").Trim();
            }

            if (!string.IsNullOrWhiteSpace(comboBoxGeneroCliente.Text))
            {
                sexo = comboBoxGeneroCliente.Text;
            }

            if (!string.IsNullOrWhiteSpace(comboBoxEstadoCivil.Text))
            {
                estadoCivil = comboBoxEstadoCivil.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefoneFuncionario.Text))
            {
                telefoneFuncionario = txtTelefoneFuncionario.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            }

            if (!string.IsNullOrWhiteSpace(txtCidadeFuncionario.Text))
            {
                cidadeFuncionario = txtCidadeFuncionario.Text;
            }

            if (!string.IsNullOrWhiteSpace(comboBoxSituacaoCadastralSelecionar.Text))
            {
                situacaoFuncionario = comboBoxSituacaoCadastralSelecionar.Text;
            }

            DataTable dataTable = selecionarFuncionario.ListarFuncionarios(CodigoFuncionario, nomeFuncionario, cpf, sexo, estadoCivil, telefoneFuncionario, cidadeFuncionario, situacaoFuncionario);

            dataGridFuncionarios.DataSource = dataTable;
        }

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

        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int codigoFuncionario = Convert.ToInt32(dataGridFuncionarios.Rows[e.RowIndex].Cells["codigo"].Value);

            var service = new SelecionarFuncionario();

            FuncionarioSelecionado = service.SelecionarFuncionarioPorCodigo(codigoFuncionario);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

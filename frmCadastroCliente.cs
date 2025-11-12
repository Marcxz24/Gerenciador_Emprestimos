using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gerenciador_de_Emprestimos
{
    public partial class FormCadastroCliente : Form
    {
        public FormCadastroCliente()
        {
            InitializeComponent();
            txtNumeroResidencia.KeyPress += SomenteNumeros_KeyPress;
            MaskedTxtCpfCnpjCliente.KeyPress += SomenteNumeros_KeyPress;
        }

        private void SomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Função que gerencia os campos do formulário.
        private void GerenciarBotoesCampos(bool OcultarBotoes, bool ManifestarBotoes, bool LimparCampos)
        {
            comboBoxSituacaoCadastral.Enabled = ManifestarBotoes;
            txtNomeCliente.ReadOnly = !ManifestarBotoes;
            btnRadioCpf.Enabled = ManifestarBotoes;
            btnRadioCnpj.Enabled = ManifestarBotoes;
            MaskedTxtCpfCnpjCliente.ReadOnly = !ManifestarBotoes;
            btnRadioMasculino.Enabled = ManifestarBotoes;
            btnRadioFeminino.Enabled = ManifestarBotoes;
            btnRadioGeneroOutros.Enabled = ManifestarBotoes;
            comboBoxEstadoCivil.Enabled = ManifestarBotoes;
            txtCidadeCliente.ReadOnly = !ManifestarBotoes;
            comboBoxEstadoUF.Enabled = ManifestarBotoes;
            txtEnderecoCliente.ReadOnly = !ManifestarBotoes;
            txtBairroCliente.ReadOnly = !ManifestarBotoes;
            txtNumeroResidencia.ReadOnly = !ManifestarBotoes;
            MaskedTxtCepCliente.ReadOnly = !ManifestarBotoes;
            MaskedTxtCelularCliente.ReadOnly = !ManifestarBotoes;
            txtEmailCliente.ReadOnly = !ManifestarBotoes;
            txtObservacoes.ReadOnly = !ManifestarBotoes;

            if (LimparCampos)
            {
                comboBoxSituacaoCadastral.SelectedIndex = -1;
                txtNomeCliente.Clear();
                btnRadioCpf.Checked = false;
                btnRadioCnpj.Checked = false;
                MaskedTxtCpfCnpjCliente.Clear();
                btnRadioMasculino.Checked = false;
                btnRadioFeminino.Checked = false;
                btnRadioGeneroOutros.Checked = false;
                comboBoxEstadoCivil.SelectedIndex = -1;
                txtCidadeCliente.Clear();
                comboBoxEstadoUF.SelectedIndex = -1;
                txtEnderecoCliente.Clear();
                txtBairroCliente.Clear();
                txtNumeroResidencia.Clear();
                MaskedTxtCepCliente.Clear();
                MaskedTxtCelularCliente.Clear();
                txtEmailCliente.Clear();
                txtObservacoes.Clear();
                txtCodigoCliente.Clear();
            }

            btnNovoCadastro.Visible = !OcultarBotoes;
            btnEditarCadastro.Visible = !OcultarBotoes;
            btnPesquisarCliente.Visible = !OcultarBotoes;
            btnFecharForm.Visible = !OcultarBotoes;
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        private void btnSalvarCadastroCliente_Click(object sender, EventArgs e)
        {
            if (validacoesCampos() == true)
            {
                return;
            }

            SalvarCadastro();

            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
        }

        private void SalvarCadastro()
        {

            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand insertBd = conexao.CreateCommand())
            {
                insertBd.CommandText = "INSERT INTO cliente (nome_cliente, cpf_cnpj, genero, estado_civil, endereco, bairro, cidade, uf, numero_residencia, cep, celular, email, observacoes, situacao_cadastral, imagem, data_cadastro) VALUES(@nome_cliente, @cpf_cnpj, @genero, @estado_civil, @endereco, @bairro, @cidade, @uf, @numero_residencia, @cep, @celular, @email, @observacoes, @situacao_cadastral, @imagem, @data_cadastro)";


                insertBd.Parameters.AddWithValue("@nome_cliente", txtNomeCliente.Text);

                insertBd.Parameters.AddWithValue("@cpf_cnpj", MaskedTxtCpfCnpjCliente.Text);

                if (btnRadioMasculino.Checked == true)
                {
                    insertBd.Parameters.AddWithValue("@genero", "MASCULINO");
                }
                else if (btnRadioFeminino.Checked == true)
                {
                    insertBd.Parameters.AddWithValue("@genero", "FEMININO");
                }
                else
                {
                    insertBd.Parameters.AddWithValue("@genero", "OUTROS");
                }

                insertBd.Parameters.AddWithValue("@estado_civil", comboBoxEstadoCivil.Text);

                insertBd.Parameters.AddWithValue("@endereco", txtEnderecoCliente.Text);

                insertBd.Parameters.AddWithValue("@bairro", txtBairroCliente.Text);

                insertBd.Parameters.AddWithValue("@cidade", txtCidadeCliente.Text);

                insertBd.Parameters.AddWithValue("@uf", comboBoxEstadoUF.Text);

                insertBd.Parameters.AddWithValue("@numero_residencia", txtNumeroResidencia.Text);

                insertBd.Parameters.AddWithValue("@cep", MaskedTxtCepCliente.Text);

                insertBd.Parameters.AddWithValue("@celular", MaskedTxtCelularCliente.Text);

                insertBd.Parameters.AddWithValue("@email", txtEmailCliente.Text);

                insertBd.Parameters.AddWithValue("@observacoes", txtObservacoes.Text);

                if (comboBoxSituacaoCadastral.Text == "ATIVO")
                {
                    insertBd.Parameters.AddWithValue("@situacao_cadastral", "ATIVO");
                }
                else
                {
                    insertBd.Parameters.AddWithValue("@situacao_cadastral", "INATIVO");
                }

                insertBd.Parameters.AddWithValue("@imagem", DBNull.Value);

                insertBd.Parameters.AddWithValue("@data_cadastro", DateTime.Now);

                insertBd.ExecuteNonQuery();

                insertBd.CommandText = "SELECT @@IDENTITY";
                txtCodigoCliente.Text =  insertBd.ExecuteScalar().ToString();
            }
        }

        private bool validacoesCampos()
        {
            if (string.IsNullOrEmpty(comboBoxSituacaoCadastral.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Situação Cadastral",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxSituacaoCadastral.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Nome do Cliente",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtNomeCliente.Focus();

                return true;
            }

            if (btnRadioCpf.Checked == false && btnRadioCnpj.Checked == false)
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: CPF/CNPJ",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MaskedTxtCpfCnpjCliente.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCpfCnpjCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: CPF/CNPJ",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MaskedTxtCpfCnpjCliente.Focus();

                return true;
            }

            if (btnRadioMasculino.Checked == false && btnRadioFeminino.Checked == false && btnRadioGeneroOutros.Checked == false)
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Gênero",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Endereço",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtEnderecoCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBairroCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Bairro",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtBairroCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCidadeCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Cidade",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtCidadeCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEstadoUF.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: UF",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxEstadoUF.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroResidencia.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: Número da Residência",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtNumeroResidencia.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCepCliente.Text))
            {
                MessageBox.Show("Tentativa de INSERT INTO em valores NOT NULL\n\nCampo: CEP",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MaskedTxtCepCliente.Focus();

                return true;
            }

            return false;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            formSelecionarCliente formPesquisarCliente = new formSelecionarCliente();
            formPesquisarCliente.ShowDialog();
        }

        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRadioCpf_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRadioCpf.Checked == true)
            {
                MaskedTxtCpfCnpjCliente.Mask = "000,000,000-00";
                MaskedTxtCpfCnpjCliente.Focus();
            }
        }

        private void btnRadioCnpj_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRadioCnpj.Checked == true)
            {
                MaskedTxtCpfCnpjCliente.Mask = "00,000,000/0000-00";
                MaskedTxtCpfCnpjCliente.Focus();
            }
        }
    }
}
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
                btnRadioCpf.Checked = true;
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

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        private bool validarCpfCadastrado(string cpf)
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (var selectBd = conexao.CreateCommand())
            {
                selectBd.CommandText = "SELECT COUNT(*) FROM emprestimosbd.cliente WHERE cpf_cnpj = @cpf";
                selectBd.Parameters.AddWithValue("@cpf", cpf);

                int quantidadeCpf = Convert.ToInt32(selectBd.ExecuteScalar());
                return quantidadeCpf > 0;
            }
        }

        private void SalvarCadastro()
        {

            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand insertBd = conexao.CreateCommand())
            {
                insertBd.CommandText = "INSERT INTO emprestimosbd.cliente (nome_cliente, cpf_cnpj, genero, estado_civil, endereco, bairro, cidade, uf, numero_residencia, cep, celular, email, observacoes, situacao_cadastral, imagem, data_cadastro) VALUES(@nome_cliente, @cpf_cnpj, @genero, @estado_civil, @endereco, @bairro, @cidade, @uf, @numero_residencia, @cep, @celular, @email, @observacoes, @situacao_cadastral, @imagem, @data_cadastro)";


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
                txtCodigoCliente.Text = insertBd.ExecuteScalar().ToString();
            }
        }

        private bool validacoesCampos()
        {
            if (string.IsNullOrEmpty(comboBoxSituacaoCadastral.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Situação Cadastral",
                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                comboBoxSituacaoCadastral.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Nome do Cliente",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNomeCliente.Focus();

                return true;
            }

            if (btnRadioCpf.Checked == false && btnRadioCnpj.Checked == false)
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF/CNPJ",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MaskedTxtCpfCnpjCliente.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCpfCnpjCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF/CNPJ",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MaskedTxtCpfCnpjCliente.Focus();

                return true;
            }

            if (validarCpfCadastrado(MaskedTxtCpfCnpjCliente.Text))
            {
                MessageBox.Show("Já Existe um Cliente com este CPF Cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (btnRadioMasculino.Checked == false && btnRadioFeminino.Checked == false && btnRadioGeneroOutros.Checked == false)
            {
                MessageBox.Show("Botão de Genêro não Marcado, por favor Marque!\n\nCampo: Gênero",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Endereço",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtEnderecoCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBairroCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Bairro",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtBairroCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCidadeCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Cidade",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCidadeCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEstadoUF.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: UF",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                comboBoxEstadoUF.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroResidencia.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Número da Residência",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNumeroResidencia.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCepCliente.Text))
            {
                MessageBox.Show("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CEP",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MaskedTxtCepCliente.Focus();

                return true;
            }

            return false;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            frmSelecionarCliente formPesquisarCliente = new frmSelecionarCliente();
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

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtNomeCliente);
        }

        private void txtEnderecoCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtEnderecoCliente);
        }

        private void txtBairroCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBairroCliente);
        }

        private void txtCidadeCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtCidadeCliente);
        }
    }
}
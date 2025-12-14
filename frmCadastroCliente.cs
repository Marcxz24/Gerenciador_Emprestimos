using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_Emprestimos
{
    public partial class FormCadastroCliente : Form
    {
        private string _codigoClienete;

        private bool _EditarCadastro;

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

        private void CarrgarDadosCliente(string codigo)
        {
            string selectSql = "SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            {
                MySqlCommand comando = new MySqlCommand(selectSql, conexao);
                comando.Parameters.AddWithValue("@codigo", codigo);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtCodigoCliente.Text = reader["codigo"].ToString();
                    txtNomeCliente.Text = reader["nome_cliente"].ToString();
                    MaskedTxtCpfCnpjCliente.Text = reader["cpf_cnpj"].ToString();
                    string genero = reader["genero"].ToString();

                    if (genero == "Feminino")
                    {
                        btnRadioFeminino.Checked = true;
                    }

                    if (genero == "Masculino")
                    {
                        btnRadioMasculino.Checked = true;
                    }

                    if (genero == "Outros")
                    {
                        btnRadioGeneroOutros.Checked = true;
                    }

                    comboBoxEstadoCivil.SelectedItem = reader["estado_civil"].ToString();
                    txtEnderecoCliente.Text = reader["endereco"].ToString();
                    txtBairroCliente.Text = reader["bairro"].ToString();
                    txtCidadeCliente.Text = reader["cidade"].ToString();
                    comboBoxEstadoUF.SelectedItem = reader["uf"].ToString();
                    txtNumeroResidencia.Text = reader["numero_residencia"].ToString();
                    MaskedTxtCepCliente.Text = reader["cep"].ToString();
                    MaskedTxtCelularCliente.Text = reader["celular"].ToString();
                    txtEmailCliente.Text = reader["email"].ToString();
                    txtObservacoes.Text = reader["observacoes"].ToString();
                    comboBoxSituacaoCadastral.SelectedItem = reader["situacao_cadastral"].ToString();
                    // imagens futuramente...
                }
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
            _EditarCadastro = false;

            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        private void btnSalvarCadastroCliente_Click(object sender, EventArgs e)
        {
            if (!_EditarCadastro)
            {
                if (validacoesCampos() == true)
                {
                    return;
                }
            }

            SalvarCadastro();

            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
        }

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            _EditarCadastro = true;

            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: false);
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

        private void EditarCadastro()
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand UpdateBd = conexao.CreateCommand())
            {
                UpdateBd.CommandText = @"
                                    UPDATE emprestimosbd.cliente 
                                    SET 
                                        nome_cliente = @nome_cliente, 
                                        cpf_cnpj = @cpf_cnpj, 
                                        genero = @genero, 
                                        estado_civil = @estado_civil, 
                                        endereco = @endereco, 
                                        bairro = @bairro, 
                                        cidade = @cidade, 
                                        uf = @uf, 
                                        numero_residencia = @numero_residencia, 
                                        cep = @cep, 
                                        celular = @celular, 
                                        email = @email, 
                                        observacoes = @observacoes, 
                                        situacao_cadastral = @situacao_cadastral 
                                    WHERE codigo = @codigo"
                ;

                UpdateBd.Parameters.AddWithValue("@codigo", int.Parse(txtCodigoCliente.Text));
                UpdateBd.Parameters.AddWithValue("@nome_cliente", txtNomeCliente.Text);
                UpdateBd.Parameters.AddWithValue("@cpf_cnpj", MaskedTxtCpfCnpjCliente.Text);
                if (btnRadioMasculino.Checked == true)
                {
                    UpdateBd.Parameters.AddWithValue("@genero", "MASCULINO");
                }
                else if (btnRadioFeminino.Checked == true)
                {
                    UpdateBd.Parameters.AddWithValue("@genero", "FEMININO");
                }
                else
                {
                    UpdateBd.Parameters.AddWithValue("@genero", "OUTROS");
                }
                UpdateBd.Parameters.AddWithValue("@estado_civil", comboBoxEstadoCivil.Text);
                UpdateBd.Parameters.AddWithValue("@endereco", txtEnderecoCliente.Text);
                UpdateBd.Parameters.AddWithValue("@bairro", txtBairroCliente.Text);
                UpdateBd.Parameters.AddWithValue("@cidade", txtCidadeCliente.Text);
                UpdateBd.Parameters.AddWithValue("@uf", comboBoxEstadoUF.Text);
                UpdateBd.Parameters.AddWithValue("@numero_residencia", txtNumeroResidencia.Text);
                UpdateBd.Parameters.AddWithValue("@cep", MaskedTxtCepCliente.Text);
                UpdateBd.Parameters.AddWithValue("@celular", MaskedTxtCelularCliente.Text);
                UpdateBd.Parameters.AddWithValue("@email", txtEmailCliente.Text);
                UpdateBd.Parameters.AddWithValue("@observacoes", txtObservacoes.Text);
                if (comboBoxSituacaoCadastral.Text == "ATIVO")
                {
                    UpdateBd.Parameters.AddWithValue("@situacao_cadastral", "ATIVO");
                }
                else
                {
                    UpdateBd.Parameters.AddWithValue("@situacao_cadastral", "INATIVO");
                }

                UpdateBd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        private void InserirCadastro()
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

                Funcoes.MensagemInformation("Cliente Cadastrado!");

                insertBd.CommandText = "SELECT @@IDENTITY";
                txtCodigoCliente.Text = insertBd.ExecuteScalar().ToString();

                conexao.Close();
            }
        }

        private void SalvarCadastro()
        {
            if (_EditarCadastro)
            {
                EditarCadastro();
            }
            else
            {
                InserirCadastro();
            }
        }

        private bool validacoesCampos()
        {
            if (string.IsNullOrEmpty(comboBoxSituacaoCadastral.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Situação Cadastral");

                comboBoxSituacaoCadastral.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Nome do Cliente");

                txtNomeCliente.Focus();

                return true;
            }

            if (btnRadioCpf.Checked == false && btnRadioCnpj.Checked == false)
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Marque os Botões!\n\nCampo: CPF/CNPJ");

                MaskedTxtCpfCnpjCliente.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCpfCnpjCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF / CNPJ");

                MaskedTxtCpfCnpjCliente.Focus();

                return true;
            }

            if (validarCpfCadastrado(MaskedTxtCpfCnpjCliente.Text))
            {
                Funcoes.MensagemWarning("Já Existe um Cliente com este CPF Cadastrado");
                return true;
            }

            if (btnRadioMasculino.Checked == false && btnRadioFeminino.Checked == false && btnRadioGeneroOutros.Checked == false)
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Marque um dos Botões!\n\nCampo: Genêro");

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Endereço do Cliente");

                txtEnderecoCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBairroCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Bairro");

                txtBairroCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCidadeCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Cidade");

                txtCidadeCliente.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEstadoUF.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: UF");

                comboBoxEstadoUF.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroResidencia.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Número da Residência");

                txtNumeroResidencia.Focus();

                return true;
            }

            if (string.IsNullOrWhiteSpace(MaskedTxtCepCliente.Text))
            {
                Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CEP");

                MaskedTxtCepCliente.Focus();

                return true;
            }

            return false;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            frmSelecionarCliente formPesquisarCliente = new frmSelecionarCliente();
            formPesquisarCliente.ShowDialog();

            string codigo = formPesquisarCliente.codigoSelecionado;

            CarrgarDadosCliente(codigo);
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
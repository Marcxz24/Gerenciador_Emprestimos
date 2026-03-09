using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using Microsoft.VisualBasic.Devices;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Forms
{
    public partial class frmCadastroClientePJ : Form
    {
        private bool _EditarCadastroClientePJ = false;

        public frmCadastroClientePJ()
        {
            InitializeComponent();
            txtCodigo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCnpj.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtIncricaoEstadual.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCep.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCelularEmpresa.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private async void txtCep_Leave(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Replace("-", "").Replace(".", "").Trim();

            if (cep.Length == 8)
            {
                CepService buscaCep = new CepService();

                var endereco = await buscaCep.ConsultarCep(cep);

                if (endereco != null)
                {
                    cmbEstado.Text = endereco.uf;
                    txtCidade.Text = endereco.localidade;
                    txtEndereco.Text = endereco.logradouro;
                    txtBairro.Text = endereco.bairro;

                    txtNumeroEmpresa.Focus();
                }
            }
        }

        private bool ValidarCampos()
        {
            ClienteDAO cliente = new ClienteDAO();

            if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text))
            {
                Funcoes.MensagemWarning("O campo Razão Social é obrigatório.");
                txtRazaoSocial.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNomeFantasia.Text))
            {
                Funcoes.MensagemWarning("O campo Nome Fantasia é obrigatório.");
                txtNomeFantasia.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(cmbSituacao.Text))
            {
                Funcoes.MensagemWarning("O Campo Situação é obrigatório.");
                cmbSituacao.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                Funcoes.MensagemWarning("O campo CNPJ é obrigatório.");
                txtCnpj.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(cmbTipoIE.Text))
            {
                Funcoes.MensagemWarning("O campo Tipo IE é obrigatório.");
                cmbTipoIE.Focus();
                return true;
            }

            if (cmbTipoIE.Text == "CONTRIBUINTE")
            {
                if (string.IsNullOrWhiteSpace(txtIncricaoEstadual.Text))
                {
                    Funcoes.MensagemWarning("O campo Inscrição Estadual é obrigatório para cliente contribuíntes.");
                    txtIncricaoEstadual.Focus();
                    return true;
                }
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                Funcoes.MensagemWarning("O campo UF (Estado) é obrigatório.");
                cmbEstado.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                Funcoes.MensagemWarning("O Campo Cidade é obrigatório.");
                txtCidade.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                Funcoes.MensagemWarning("O Campo Endereço é obrigatório.");
                txtEndereco.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBairro.Text))
            {
                Funcoes.MensagemWarning("O Campo Bairro é obrigatório.");
                txtBairro.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroEmpresa.Text))
            {
                Funcoes.MensagemWarning("O Campo N° Residência é obrigatório.");
                txtNumeroEmpresa.Focus();
                return true;
            }

            if (_EditarCadastroClientePJ == false)
            {
                // Chama ó Método da classe Cliente passando o valor digitado no Masked Text Box referente ao CPF e CNPJ, se já existir, encerra.
                if (cliente.CpfJaCadastrado(txtCnpj.Text))
                {
                    Funcoes.MensagemWarning("Já Existe um Cliente com este CPF Cadastrado");
                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }
            }
            else
            {
                int codigoCliente = Convert.ToInt32(txtCodigo.Text);

                // Chama ó Método da classe Cliente passando o valor digitado no Masked Text Box referente ao CPF e CNPJ, se já existir e for diferente do cliente que está sendo editado, encerra.
                if (cliente.CpfDeClienteCadastrado(codigoCliente, txtCnpj.Text))
                {
                    Funcoes.MensagemWarning("Já Existe um Cliente com este CPF Cadastrado");
                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }
            }

            return false;
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
                return;

            SalvarCadastro();

            GerenciarBotoes(false, false, false);
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formSelecionarCliente = new frmSelecionarCliente())
                {
                    if (formSelecionarCliente.ShowDialog() == DialogResult.OK)
                    {
                        var cliente = formSelecionarCliente.ClienteSelecionado;

                        var documentoLimpo = cliente.cpf_cnpj.Replace(".", "").Replace("-", "").Trim();

                        if (documentoLimpo.Length == 11)
                        {
                            Funcoes.MensagemWarning("Este cliente é uma Pessoa Fisíca (CPF).\nUse a tela de Cadastro de Clientes (CPF) para selecioná-lo.");
                            return; // Interrompe o preenchimento e sai do método
                        }

                        txtCodigo.Text = cliente.codigo.ToString();
                        txtRazaoSocial.Text = cliente.nome_cliente;
                        txtNomeFantasia.Text = cliente.nome_fantasia;
                        cmbSituacao.Text = cliente.situacao_cadastral;
                        txtCnpj.Text = cliente.cpf_cnpj;
                        cmbTipoIE.Text = cliente.tipo_ie;
                        txtIncricaoEstadual.Text = cliente.inscricao_estadual;
                        txtCep.Text = cliente.cep;
                        cmbEstado.Text = cliente.uf;
                        txtCidade.Text = cliente.cidade;
                        txtEndereco.Text = cliente.endereco;
                        txtBairro.Text = cliente.bairro;
                        txtNumeroEmpresa.Text = cliente.numero_residencia.ToString();
                        txtCelularEmpresa.Text = cliente.celular;
                        txtEmailEmpresa.Text = cliente.email;
                        txtObservacoes.Text = cliente.observacoes;
                    }
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("ocorreu um erro ao selecionar o cliente: " + ex);
                Serilog.Log.Error("ocorreu um erro ao selecionar o cliente: " + ex);
            }
        }

        private void GerenciarBotoes(bool ManifestarCampos, bool OcultarBotoes, bool LimparCampos)
        {
            // Campos referentes aos dados da empresa
            txtRazaoSocial.ReadOnly = !ManifestarCampos;
            txtNomeFantasia.ReadOnly = !ManifestarCampos;
            cmbSituacao.Enabled = ManifestarCampos;
            txtCnpj.ReadOnly = !ManifestarCampos;
            cmbTipoIE.Enabled = ManifestarCampos;
            txtIncricaoEstadual.ReadOnly = !ManifestarCampos;

            // Campos referentes ao endereço da empresa
            txtCep.ReadOnly = !ManifestarCampos;
            cmbEstado.Enabled = ManifestarCampos;
            txtCidade.ReadOnly = !ManifestarCampos;
            txtEndereco.ReadOnly = !ManifestarCampos;
            txtBairro.ReadOnly = !ManifestarCampos;
            txtNumeroEmpresa.ReadOnly = !ManifestarCampos;

            // campos que não são obrigatórios (Celular, E-mail e Observações)
            txtCelularEmpresa.ReadOnly = !ManifestarCampos;
            txtEmailEmpresa.ReadOnly = !ManifestarCampos;
            txtObservacoes.ReadOnly = !ManifestarCampos;

            if (LimparCampos)
            {
                // Campos referentes aos dados da empresa
                txtCodigo.Clear();
                txtRazaoSocial.Clear();
                txtNomeFantasia.Clear();
                cmbSituacao.SelectedIndex = -1;
                txtCnpj.Clear();
                cmbTipoIE.SelectedIndex = -1;
                txtIncricaoEstadual.Clear();

                // Campos referentes ao endereço da empresa
                txtCep.Clear();
                cmbEstado.SelectedIndex = -1;
                txtCidade.Clear();
                txtEndereco.Clear();
                txtBairro.Clear();
                txtNumeroEmpresa.Clear();

                // campos que não são obrigatórios (Celular, E-mail e Observações)
                txtCelularEmpresa.Clear();
                txtEmailEmpresa.Clear();
                txtObservacoes.Clear();
            }

            // Campos que representam os botões de (Novo/Editar)
            btnNovoCadastro.Visible = !OcultarBotoes;
            btnEditarCadastro.Visible = !OcultarBotoes;
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            _EditarCadastroClientePJ = false;

            GerenciarBotoes(true, true, true);
        }

        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            _EditarCadastroClientePJ = true;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                Funcoes.MensagemWarning("Selecione uma Empresa para poder Editar primeiro.");
                return;
            }

            GerenciarBotoes(true, true, false);
        }

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoes(false, false, true);
        }

        private void SalvarCadastro()
        {
            if (_EditarCadastroClientePJ)
            {
                EditarCadastro();
            }
            else
            {
                CadastrarNovaEmpresa();
            }
        }

        private void CadastrarNovaEmpresa()
        {
            try
            {
                int.TryParse(txtNumeroEmpresa.Text, out int numeroConvertido);

                string cnpjLimpo = txtCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                string telefoneLimpo = txtCelularEmpresa.Text
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .Replace("-", "")
                                                            .Replace(" ", "")
                                                            .Trim();

                ClienteDTO empresa = new ClienteDTO
                {
                    nome_cliente = txtRazaoSocial.Text,
                    nome_fantasia = txtNomeFantasia.Text,
                    situacao_cadastral = cmbSituacao.Text,
                    cpf_cnpj = cnpjLimpo,
                    tipo_ie = cmbTipoIE.Text,
                    inscricao_estadual = txtIncricaoEstadual.Text,
                    cep = txtCep.Text,
                    uf = cmbEstado.Text,
                    cidade = txtCidade.Text,
                    endereco = txtEndereco.Text,
                    bairro = txtBairro.Text,
                    numero_residencia = numeroConvertido,
                    celular = telefoneLimpo,
                    email = txtEmailEmpresa.Text,
                    observacoes = txtObservacoes.Text,
                };

                ClienteDAO empresaDAO = new ClienteDAO();
                bool temErro = empresaDAO.cadastrarCliente(empresa);

                if (!temErro)
                    txtCodigo.Text = empresaDAO.CodigoCliente.ToString();
                else
                    Funcoes.MensagemWarning("Não foi possível cadastrar. Verifique se o CPF/CNPJ já existe.");
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Houve um Erro ao inserir a nova Empresa. " + ex);
                return;
            }
        }

        private void EditarCadastro()
        {
            try
            {
                int.TryParse(txtCodigo.Text, out int codigoEmpresa);
                int.TryParse(txtNumeroEmpresa.Text, out int numeroConvertido);

                ClienteDTO empresa = new ClienteDTO
                {
                    codigo = codigoEmpresa,
                    nome_cliente = txtRazaoSocial.Text,
                    nome_fantasia = txtNomeFantasia.Text,
                    situacao_cadastral = cmbSituacao.Text,
                    cpf_cnpj = txtCnpj.Text,
                    tipo_ie = cmbTipoIE.Text,
                    inscricao_estadual = txtIncricaoEstadual.Text,
                    cep = txtCep.Text,
                    uf = cmbEstado.Text,
                    cidade = txtCidade.Text,
                    endereco = txtEndereco.Text,
                    bairro = txtBairro.Text,
                    numero_residencia = numeroConvertido,
                    celular = txtCelularEmpresa.Text,
                    email = txtEmailEmpresa.Text,
                    observacoes = txtObservacoes.Text,
                };

                ClienteDAO empresaDAO = new ClienteDAO();
                empresaDAO.EditarCliente(empresa);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Houve um erro ao realizar a alteração no cadastro da empresa. " + ex);
            }
        }

        private void txtRazaoSocial_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtRazaoSocial);
        }

        private void txtNomeFantasia_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtNomeFantasia);
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtCidade);
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtEndereco);
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBairro);
        }

        private async void txtCnpj_Leave(object sender, EventArgs e)
        {
            try
            {
                CnpjServices consultaCnpj = new CnpjServices();
                var empresa = await consultaCnpj.ConsultarCnpj(txtCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", ""));

                if (empresa != null)
                {
                    txtRazaoSocial.Text = empresa.razao_social;
                    txtNomeFantasia.Text = empresa.nome_fantasia;
                    cmbEstado.Text = empresa.uf;
                    txtCep.Text = empresa.cep;
                    txtCidade.Text = empresa.municipio;
                    txtEndereco.Text = empresa.logradouro;
                    txtBairro.Text = empresa.bairro;
                    txtNumeroEmpresa.Text = empresa.numero;
                    txtEmailEmpresa.Text = empresa.email;
                    txtCelularEmpresa.Text = empresa.ddd_telefone_1;

                    txtObservacoes.Focus();
                }
                else
                {
                    Funcoes.MensagemWarning("CNPJ não localizado na base de dados.");
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("Houve um erro ao realizar a consulta na API (https://brasilapi.com.br/)");
                Serilog.Log.Error("Houve um erro ao realizar a consulta na API(https://brasilapi.com.br/ " + ex);
            }
        }
    }
}
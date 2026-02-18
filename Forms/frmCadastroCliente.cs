using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using Microsoft.VisualBasic.Logging;
using Serilog;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmCadastroCliente : Form
    {
        Cliente cliente = new Cliente();

        // Varável privada booleana utilizada para verificar se irá Ediatr o Cliente.
        private bool _EditarCadastro;

        public frmCadastroCliente()
        {
            InitializeComponent();
            txtNumeroResidencia.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            MaskedTxtCpfCnpjCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // Método responsável por controlar o estado visual e a interatividade dos componentes da tela.
        private void GerenciarBotoesCampos(bool OcultarBotoes, bool ManifestarBotoes, bool LimparCampos)
        {
            // Habilita ou desabilita a edição dos campos de seleção e texto.
            // Para campos de texto, usamos 'ReadOnly' para permitir a seleção/cópia sem alteração.
            comboBoxSituacaoCadastral.Enabled = ManifestarBotoes;
            txtNomeCliente.ReadOnly = !ManifestarBotoes;
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

            // Se o parâmetro LimparCampos for verdadeiro, redefine todos os controles para o estado inicial/vazio.
            if (LimparCampos)
            {
                comboBoxSituacaoCadastral.SelectedIndex = -1; // Remove seleção dos ComboBox
                txtNomeCliente.Clear();
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

            // Controla a visibilidade dos botões principais de navegação e ação.
            // Inverte o valor de OcultarBotoes para definir se devem aparecer ou sumir.
            btnNovoCadastro.Visible = !OcultarBotoes;
            btnEditarCadastro.Visible = !OcultarBotoes;
            btnPesquisarCliente.Visible = !OcultarBotoes;
            btnFecharForm.Visible = !OcultarBotoes;
        }

        // Botão novo cadastro, que ao ser clicado fica oculto, listando apenas o botão de salvar.
        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            // Editar cadastro recebe false.
            _EditarCadastro = false; // Variavel global para edição de cadastro recebe false, que não será editado.

            // Chama o método responsável por gerenciar os botões, desbloqueando os campos, limpando e ocultando os botões.
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        // Botão Cancelar Cadastro. Se for clicado limpa todos os campos, bloqueia os campos, e exibe novamente os botões.
        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        // Botão para salvar o Cadastro do cliente.
        private void btnSalvarCadastroCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Chama o método responsável pelas validações dos campos.
                if (validacoesCampos() == true)
                {
                    // Se ele achar um campo vazio, encerra o método.
                    return;
                }

                SalvarCadastro(); // Executa o Método responsável por Salvar os Dados, UPDATE ou INSERT.

                // Chama o método responsável por gerenciar os campos e botões.
                GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro ao clicar no botão Salvar Cadastro no formulário de Clientes.");
                Funcoes.MensagemErro("Ocorreu um Erro ao Salvar Cadastro! Solicite o Suporte.");
            }
        }

        // Evento do Botão de editar cadastro de cliente.
        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoCliente.Text))
            {
                Funcoes.MensagemWarning("Selecione um Cliente para poder Editar.");
                return;
            }

            // Variável Global recebe o valor true.
            _EditarCadastro = true;

            // Chama o método responsável por gerenciar os campos do formulário.
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: false);
        }

        // Método privado para editar o cadastro dde cliente.
        private void EditarCadastro()
        {
            try
            {
                // Variaveis recebem que representam os campos do formulário, recebem o valor listado nos campos.
                string? nomeCliente = txtNomeCliente.Text; ;
                string? cpfCnpj = MaskedTxtCpfCnpjCliente.Text;
                string? genero = null;
                string? estadoCivil = comboBoxEstadoCivil.Text;
                string? endereco = txtEnderecoCliente.Text;
                string? bairro = txtBairroCliente.Text;
                string? cidade = txtCidadeCliente.Text;
                string? uf = comboBoxEstadoUF.Text;
                int numeroResidencia = Convert.ToInt32(txtNumeroResidencia.Text);
                string? cep = MaskedTxtCepCliente.Text;
                string? celular = MaskedTxtCelularCliente.Text;
                string? email = txtEmailCliente.Text;
                string? observacoes = txtObservacoes.Text;
                string? situacaoCadastral = comboBoxSituacaoCadastral.Text;

                // Se o Radio Button Masculino estiver Marcado, a variavel genero recebe marculino.
                if (btnRadioMasculino.Checked == true)
                    genero = "MASCULINO";

                // Se o Radio Button Feminino estiver Marcado, a variavel genero recebe Feminino.
                if (btnRadioFeminino.Checked == true)
                    genero = "FEMININO";

                // Se o Radio Button Outros estiver Marcado, a variavel genero recebe Outros.
                if (btnRadioGeneroOutros.Checked == true)
                    genero = "OUTROS";

                // Objeto Global cliente recebe o código do cliente. listado no Text Box referente ao Código.
                cliente.CodigoCliente = Convert.ToInt32(txtCodigoCliente.Text);

                // Chama o Método da classe responsável por realizar o UPDATE diretamente no Banco de Dados.
                cliente.EditarCliente(cliente.CodigoCliente, nomeCliente, cpfCnpj, genero, estadoCivil, endereco, bairro, cidade, uf, numeroResidencia, cep, celular, email, observacoes, situacaoCadastral);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro ao executar o método EditarCadastro no formulário de Clientes.");
                throw;
            }
        }

        // Método privado responsável por Cadastrar um Novo cliente.
        private void InserirCadastro()
        {
            try
            {
                // Variaveis que representam os campos do formulários, recebe os valores escritos nos campos.
                string? nomeCliente = txtNomeCliente.Text;
                string? cpfCnpj = MaskedTxtCpfCnpjCliente.Text;
                string? genero = null;
                string? estadoCivil = comboBoxEstadoCivil.Text;
                string? endereco = txtEnderecoCliente.Text;
                string? bairro = txtBairroCliente.Text;
                string? cidade = txtCidadeCliente.Text;
                string? uf = comboBoxEstadoUF.Text;
                int numeroResidencia = 0;
                string? cep = MaskedTxtCepCliente.Text;
                string? celular = MaskedTxtCelularCliente.Text;
                string? email = txtEmailCliente.Text;
                string? observacoes = txtObservacoes.Text;
                string? situacaoCadastral = comboBoxSituacaoCadastral.Text;

                // Se o Radio Button Masculino estiver Marcado, a variavel genero recebe marculino.
                if (btnRadioMasculino.Checked == true)
                    genero = "MASCULINO";

                // Se o Radio Button Feminino estiver Marcado, a variavel genero recebe Feminino.
                if (btnRadioFeminino.Checked == true)
                    genero = "FEMININO";

                // Se o Radio Button Outros estiver Marcado, a variavel genero recebe Outros.
                if (btnRadioGeneroOutros.Checked == true)
                    genero = "OUTROS";

                // realiza a conversão do do valor descrito no Text Box, para o valor inteiro INT
                int.TryParse(txtNumeroResidencia.Text, out numeroResidencia);

                // Objeto Global chama o método da classe responsável por Realizar o INSERT no Banco de Dados.
                cliente.cadastrarCliente(nomeCliente, cpfCnpj, genero, estadoCivil, endereco, bairro, cidade, uf, numeroResidencia, cep, celular, email, observacoes, situacaoCadastral);

                // O Text Box Referente ao código do cliente recebe o valor do ultimo cliente cadastrado no SELECT @@IDENTITY
                txtCodigoCliente.Text = cliente.CodigoCliente.ToString();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro ao executar o método InserirCadastro no formulário de Clientes.");
                throw;
            }
        }

        // Método responsável por Informar qual será o processo, EDITAR ou INSERIR.
        private void SalvarCadastro()
        {
            // Se _EditarCadastro for True, ele irá chamar o méotodo de editar
            if (_EditarCadastro)
            {
                EditarCadastro();
            }
            // Senão, ele irá realizar o Método de inserção.
            else
            {
                InserirCadastro();
            }
        }

        // Método Boleano responsável por realizar as validações dos campos obrigatórios.
        /// <summary>
        /// True = Existe Erro e bloqueia a passagem para o proximo método.
        /// False = Não Existe Erro e libera a passagem para o proximo método.
        /// </summary>
        private bool validacoesCampos()
        {
            try
            {
                // Se Combo Box Estiver Vazio, encerra o método neste trecho.
                if (string.IsNullOrEmpty(comboBoxSituacaoCadastral.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Situação Cadastral");

                    comboBoxSituacaoCadastral.Focus();

                    return true;
                }

                // Se o Text Box referente ao nome do cliente estiver Vazio, encerra o Método neste Trecho.
                if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Nome do Cliente");

                    txtNomeCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o Masked Text Box Estiver vazio, mostra a mensagem e encerra o método.
                if (string.IsNullOrWhiteSpace(MaskedTxtCpfCnpjCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CPF / CNPJ");

                    MaskedTxtCpfCnpjCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                if (_EditarCadastro == false)
                {
                    // Chama ó Método da classe Cliente passando o valor digitado no Masked Text Box referente ao CPF e CNPJ, se já existir, encerra.
                    if (cliente.CpfJaCadastrado(MaskedTxtCpfCnpjCliente.Text))
                    {
                        Funcoes.MensagemWarning("Já Existe um Cliente com este CPF Cadastrado");
                        return true; // Existe Erro e bloqueia a passagem para o proximo método.
                    }
                }
                else
                {
                    int codigoCliente = Convert.ToInt32(txtCodigoCliente.Text);

                    // Chama ó Método da classe Cliente passando o valor digitado no Masked Text Box referente ao CPF e CNPJ, se já existir e for diferente do cliente que está sendo editado, encerra.
                    if (cliente.CpfDeClienteCadastrado(codigoCliente, MaskedTxtCpfCnpjCliente.Text))
                    {
                        Funcoes.MensagemWarning("Já Existe um Cliente com este CPF Cadastrado");
                        return true; // Existe Erro e bloqueia a passagem para o proximo método.
                    }
                }


                // Chama a classe responsável por validar se o CPF está valido, realizando o calculo para validar CPF.
                if (ValidacaoCpf.ValidarCpf(MaskedTxtCpfCnpjCliente.Text) == false)
                {
                    Funcoes.MensagemWarning("CPF inválido, favor informar um CPF valido.");

                    MaskedTxtCpfCnpjCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o Radio Button Masculino, Feminino ou Outros estiver desmarcado, encerra o método neste trecho.
                if (btnRadioMasculino.Checked == false && btnRadioFeminino.Checked == false && btnRadioGeneroOutros.Checked == false)
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Marque um dos Botões!\n\nCampo: Genêro");

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o endereço do ciente estiver vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Endereço do Cliente");

                    txtEnderecoCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o bairro do cliente estiver vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(txtBairroCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Bairro");

                    txtBairroCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se a cidade do cliente vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(txtCidadeCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Cidade");

                    txtCidadeCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o Combo Box referente aos Estados estiver vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(comboBoxEstadoUF.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: UF");

                    comboBoxEstadoUF.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o número da residencia estiver vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(txtNumeroResidencia.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: Número da Residência");

                    txtNumeroResidencia.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                // Se o CEP estiver vazio ou com espaços em branco, encerra o método neste trecho.
                if (string.IsNullOrWhiteSpace(MaskedTxtCepCliente.Text))
                {
                    Funcoes.MensagemWarning("Campo Obrigatório Vazio, por favor Preencha!\n\nCampo: CEP");

                    MaskedTxtCepCliente.Focus();

                    return true; // Existe Erro e bloqueia a passagem para o proximo método.
                }

                return false; // Se chegou até aqui não existe erro e pode passar para os proximos métodos.
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro durante a execução das validações de campos.");
                return true;
            }
        }

        // Evento do botão responsável por abrir o formulário de selecionar cliente.
        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Instância um novo frmSelecionarCliente para poder mostrar o Formulário responsável por Selecionar Cliente.
                using (var formSelecionarCliente = new frmSelecionarCliente())
                {
                    // Mostra o formulário de selecionar cliente ao ser clicado no botão de selecionar cliente.
                    if (formSelecionarCliente.ShowDialog() == DialogResult.OK)
                    {
                        // variavel cliente recebe o cliente selecionado do form selecionar cliente.
                        var cliente = formSelecionarCliente.ClienteSelecionado;

                        /// ----- Os códigos Abaixo estão recebendo os valores que foram selecionados no form selecionar cliente listado no DataGrid.
                        // Text Box recebe o código do cliente. 
                        txtCodigoCliente.Text = cliente.codigo.ToString();
                        // Text Box Nome do cliente recebe o nome do cliente.
                        txtNomeCliente.Text = cliente.nome_cliente;

                        // Masked Text Box CPF/CNPJ recebe o valor do CPF do cliente selecionado.
                        MaskedTxtCpfCnpjCliente.Text = cliente.cpf_cnpj;

                        // Marca o Radio Button Masculino se o genero do cliente for igual a Masculino.
                        btnRadioMasculino.Checked = cliente.genero == "Masculino";
                        // Marca o Radio Button Feminino se o genero do cliente for igual a Feminino.
                        btnRadioFeminino.Checked = cliente.genero == "Feminino";
                        // Marca o Radio Button Outros se o genero do cliente for igual a Outros.
                        btnRadioGeneroOutros.Checked = cliente.genero == "Outros";

                        // o Combo Box estado Civil recebe o valor listado no estado civil.
                        comboBoxEstadoCivil.SelectedItem = cliente.estado_civil;
                        // o Text Box Recebe o valor listado no endereço.
                        txtEnderecoCliente.Text = cliente.endereco;
                        // o Text Box Bairro recebe o valor do bairro.
                        txtBairroCliente.Text = cliente.bairro;
                        // o Text Box Cidade recebe o valor do Cidade.
                        txtCidadeCliente.Text = cliente.cidade;
                        // o Combo Box UF recebe o valor do UF.
                        comboBoxEstadoUF.Text = cliente.uf;
                        // o Text Box Numero Residencia recebe o valor do Numero Residencia.
                        txtNumeroResidencia.Text = cliente.numero_residencia.ToString();
                        // o Masked Text Box CEP recebe o valor do CEP.
                        MaskedTxtCepCliente.Text = cliente.cep;
                        // o Masked Box Celular recebe o valor do Celular.
                        MaskedTxtCelularCliente.Text = cliente.celular;
                        // o Text Box Email recebe o valor do Email.
                        txtEmailCliente.Text = cliente.email;
                        // o Text Box Observacoes recebe o valor do Observacoes.
                        txtObservacoes.Text = cliente.observacoes;
                        // o Combo Box Situação Cadastral recebe o valor do Situação Cadastral.
                        comboBoxSituacaoCadastral.Text = cliente.situacao_cadastral;
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Ocorreu um erro ao Selecionar o Cliente");
                Funcoes.MensagemErro("Erro ao carregar dados do cliente.");
            }
        }

        // Evento Click do botão para fechar o formulário.
        private void btnFecharForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Text Box Nome cliente recebe a função de deixar a primeira letra maiúscula.
        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtNomeCliente);
        }

        // Text Box Endereço recebe a função de deixar a primeira letra maiúscula.
        private void txtEnderecoCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtEnderecoCliente);
        }

        // Text Box Bairro recebe a função de deixar a primeira letra maiúscula.
        private void txtBairroCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBairroCliente);
        }

        // Text Box Cidade recebe a função de deixar a primeira letra maiúscula.
        private void txtCidadeCliente_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtCidadeCliente);
        }

        private async void MaskedTxtCepCliente_Leave(object sender, EventArgs e)
        {
            string cep = MaskedTxtCepCliente.Text.Replace("-", "").Replace(".", "").Trim();

            if (cep.Length == 8)
            {
                try
                {
                    CepService buscaCep = new CepService();

                    var endereco = await buscaCep.ConsultarCep(cep);

                    if (endereco != null)
                    {
                        txtEnderecoCliente.Text = endereco.logradouro;
                        txtBairroCliente.Text = endereco.bairro;
                        txtCidadeCliente.Text = endereco.localidade;
                        comboBoxEstadoUF.Text = endereco.uf;

                        txtNumeroResidencia.Focus();
                    }
                    else
                    {
                        Funcoes.MensagemWarning("CEP não encontrado. Verifique o CEP e tente novamente.");
                    }
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "Erro ao consultar CEP no serviço de CEP.");
                    Funcoes.MensagemErro("Erro ao consultar CEP. Verifique o CEP e tente novamente.");
                }
            }
        }
    }
}
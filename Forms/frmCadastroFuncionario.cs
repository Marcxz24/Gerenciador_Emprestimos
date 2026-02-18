using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Security;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmCadastroFuncionario : Form
    {
        Funcionario funcionario = new Funcionario();

        private bool _EditarCadastro;

        private bool _AlterarSenha = false;

        // Construtor do formulário de cadastro de funcionário
        public frmCadastroFuncionario()
        {
            InitializeComponent();
            txtBoxCodigo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxCpfFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxTelefoneFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxNumeroResidencia.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxCep.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // Controla o estado dos controles da tela (Habilitar/Desabilitar, Limpar e Visibilidade).
        private void GerenciarBotoesCampos(bool OcultarBotoes, bool ManifestarBotoes, bool LimparCampos)
        {
            // --- 1. CONTROLE DE EDIÇÃO (Habilitar ou Bloquear campos) ---
            // ComboBoxes usam .Enabled (Habilitado/Desabilitado)
            comboBoxSituacao.Enabled = ManifestarBotoes;
            comboBoxSexoFuncionario.Enabled = ManifestarBotoes;
            comboBoxEstadoCivil.Enabled = ManifestarBotoes;
            comboBoxUf.Enabled = ManifestarBotoes;

            // TextBoxes usam .ReadOnly (Somente Leitura)
            // O operador '!' inverte o valor: se ManifestarBotoes for true, ReadOnly será false.
            txtBoxNomeFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxCpfFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxCidadeFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxTelefoneFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxUsername.ReadOnly = !ManifestarBotoes;
            txtBoxBairro.ReadOnly = !ManifestarBotoes;
            txtBoxEndereco.ReadOnly = !ManifestarBotoes;
            txtBoxCep.ReadOnly = !ManifestarBotoes;
            txtBoxNumeroResidencia.ReadOnly = !ManifestarBotoes;

            // Habilitar os CheckBox Referentes aos Privilégios.
            // CheckBox usam .Enabled (Habilitado/Desabilitado)
            chkBoxAcessarCadastroCliente.Enabled = ManifestarBotoes;
            chkBoxCadastroFuncionario.Enabled = ManifestarBotoes;
            chkBoxNovosEmprestimos.Enabled = ManifestarBotoes;
            chkBoxPagamentoParcela.Enabled = ManifestarBotoes;
            chkBoxVizualizarEmprestimos.Enabled = ManifestarBotoes;
            chkBoxConsultarParcela.Enabled = ManifestarBotoes;

            // --- 2. LIMPEZA DOS CAMPOS ---
            if (LimparCampos)
            {
                // Reseta a seleção dos ComboBoxes (-1 significa nenhum item selecionado)
                comboBoxSituacao.SelectedIndex = -1;
                comboBoxSexoFuncionario.SelectedIndex = -1;
                comboBoxEstadoCivil.SelectedIndex = -1;
                comboBoxUf.SelectedIndex = -1;

                // Limpa o texto de todas as TextBoxes
                txtBoxCodigo.Clear();
                txtBoxNomeFuncionario.Clear();
                txtBoxCpfFuncionario.Clear();
                txtBoxCidadeFuncionario.Clear();
                txtBoxTelefoneFuncionario.Clear();
                txtBoxUsername.Clear();
                txtBoxSenha.Clear();
                txtBoxBairro.Clear();
                txtBoxEndereco.Clear();
                txtBoxCep.Clear();
                txtBoxNumeroResidencia.Clear();

                // Limpa os CheckBox referentes aos privilégios.
                chkBoxCadastroFuncionario.Checked = false;
                chkBoxAcessarCadastroCliente.Checked = false;
                chkBoxNovosEmprestimos.Checked = false;
                chkBoxPagamentoParcela.Checked = false;
                chkBoxConsultarParcela.Checked = false;
                chkBoxVizualizarEmprestimos.Checked = false;
            }

            // --- 3. VISIBILIDADE DOS BOTÕES ---
            // Se OcultarBotoes for true, Visible será false (oculta os botões)
            btnNovoCadastro.Visible = !OcultarBotoes;
            btnEditarCadastro.Visible = !OcultarBotoes;
        }

        /// Valida os campos do formulário de funcionário.
        /// Retorna TRUE se encontrar algum erro (campo inválido).
        /// Retorna FALSE se todos os campos estiverem corretos.
        private bool validacoesCampos()
        {
            try
            {
                // Verifica se o Nome está vazio ou contém apenas espaços em branco
                if (string.IsNullOrWhiteSpace(txtBoxNomeFuncionario.Text))
                {
                    Funcoes.MensagemWarning("O campo Nome é obrigatório.");
                    return true; // Erro encontrado
                }

                // Verifica se o CPF está vazio ou nulo
                if (string.IsNullOrEmpty(txtBoxCpfFuncionario.Text))
                {
                    Funcoes.MensagemWarning("Campo CPF é obrigatório! Preencha os seguintes campos\n\nCampo: CPF");
                    return true; // Erro encontrado
                }

                // Chama o método da classe ValidacaoCpf para verificar se o dígito verificador é válido
                if (ValidacaoCpf.ValidarCpf(txtBoxCpfFuncionario.Text) == false)
                {
                    Funcoes.MensagemWarning("CPF inválido, favor informar um CPF valido.");
                    return true; // Erro encontrado
                }

                // Verifica se o Sexo foi selecionado no ComboBox
                if (string.IsNullOrEmpty(comboBoxSexoFuncionario.Text))
                {
                    Funcoes.MensagemWarning("Campo Sexo do funcionário é obrigatório.\n\nCampo: Sexo");
                    return true; // Erro encontrado
                }

                // Verifica se o Nome de Usuário (Login) foi preenchido
                if (string.IsNullOrWhiteSpace(txtBoxUsername.Text))
                {
                    Funcoes.MensagemWarning("O campo Login é obrigatório.\n\nCampo: Username");
                    return true; // Erro encontrado
                }

                // Verifica se a Senha foi preenchida
                if (string.IsNullOrWhiteSpace(txtBoxSenha.Text))
                {
                    Funcoes.MensagemWarning("O campo Senha é obrigatório.\n\nCampo: Senha");
                    return true; // Erro encontrado
                }

                // Verifica se a Cidade foi preenchida
                if (string.IsNullOrEmpty(txtBoxCidadeFuncionario.Text))
                {
                    Funcoes.MensagemWarning("Campo cidade é obrigatório\n\nCampo: cidade");
                    return true; // Erro encontrado
                }

                if (string.IsNullOrEmpty(txtBoxEndereco.Text))
                {
                    Funcoes.MensagemWarning("Campo Endereço é obrigatório\n\nCampo: Endereço");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxBairro.Text))
                {
                    Funcoes.MensagemWarning("Campo Bairro é obrigatório\n\nCampo: Bairro");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxNumeroResidencia.Text))
                {
                    Funcoes.MensagemWarning("Campo número de residência é obrigatório\n\nCampo: Número de Residência");
                    return true;
                }

                if (string.IsNullOrEmpty(txtBoxCep.Text))
                {
                    Funcoes.MensagemWarning("Campo CEP é Obrigatório\n\nCampo: CEP");
                    return true;
                }

                if (string.IsNullOrEmpty(comboBoxUf.Text))
                {
                    Funcoes.MensagemWarning("Campo UF é Obrigatório\n\nCampo: UF");
                    return true;
                }

                // Verifica se o Estado Civil foi selecionado
                if (string.IsNullOrEmpty(comboBoxEstadoCivil.Text))
                {
                    Funcoes.MensagemWarning("Campo estado civil é obrigatório\n\nCampo: Estado Civil");
                    return true; // Erro encontrado
                }

                // Verifica se o Telefone foi preenchido
                if (string.IsNullOrEmpty(txtBoxTelefoneFuncionario.Text))
                {
                    Funcoes.MensagemWarning("Campo Telefone do funcionário é obrigatório\n\nCampo: Telefone do Funcionário");
                    return true; // Erro encontrado
                }

                // Se o código chegou até aqui, significa que nenhuma validação falhou
                return false;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro durante a execução das validações de campos.");
                return true;
            }
        }

        // Evento do botão para iniciar um novo cadastro de funcionário
        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            _EditarCadastro = false;

            // Foi adicionado o campo para a liberação do Text Box referente a senha.
            // devido ao cadastrar um novo funcionáriodevido ao cadastrar um novo funcionário estar sendo tratado como redefinir a senha, e não como digitar a senha.
            if (_EditarCadastro == false)
            {
                txtBoxSenha.ReadOnly = false;
                lblLinkEditarSenha.Enabled = false;
            }

            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        // Evento do botão para cancelar o cadastro de funcionário
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se a Flag de editar cadastro estiver falsa. bloqueia o campo novamente ao Cancelar.
            if (_EditarCadastro == false)
            {
                txtBoxSenha.ReadOnly = true;
                lblLinkEditarSenha.Enabled = false;
            }

            if (_EditarCadastro == true)
            {
                txtBoxSenha.ReadOnly = true;
                lblLinkEditarSenha.Enabled = false;
            }

            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        // Evento do botão para salvar o cadastro de funcionário
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações dos campos obrigatorios
                if (validacoesCampos() == true)
                {
                    return;
                }

                // Chama o método centralizado que decide entre Inserir ou Editar
                SalvarCadastroFuncionario();

                // Chama o método de responsável por salvar os privilegios no Banco.
                SalvarPrivilegiosFuncionario();

                // Se a Flag de edição de cadastro estiver false, bloqueia novamente o campo referente a senha o Salvar.
                if (_EditarCadastro == false)
                {
                    txtBoxSenha.ReadOnly = true;
                }

                // Após salvar, bloqueia os campos e volta a exibir os botões principais
                GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Houve um erro ao Salvar o Cadastro de Funcionário");
                throw;
            }
        }

        private void SalvarPrivilegiosFuncionario()
        {
            try
            {
                // Obtém o ID do funcionário a partir da caixa de texto, convertendo para inteiro
                int codigoFuncionario = Convert.ToInt32(txtBoxCodigo.Text);

                // Cria um dicionário temporário para armazenar o par (Código da Tela, Marcado ou Não)
                var privilegios = new Dictionary<int, bool>();

                // Inicia a busca pelos CheckBoxes dentro de todos os controles do formulário
                PercorrerCheckBox(this.Controls, privilegios);

                // Instancia a camada de serviço para processar as regras de negócio
                var service = new FuncionarioPrivilegioService();

                // Envia o dicionário preenchido para ser persistido no banco de dados
                service.SalvarPrivilegios(codigoFuncionario, privilegios);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Houve um Erro ao Salvar os Privilégios do funcionário.");
                Funcoes.MensagemErro("Não foi possível salvar as permissões do funcionário.");
            }
        }

        // Método recursivo que varre a árvore de componentes da interface
        private void PercorrerCheckBox(Control.ControlCollection controles, Dictionary<int, bool> privilegios)
        {
            foreach (Control control in controles)
            {
                if (control is CheckBox chk)
                {
                    try
                    {
                        // Se a Tag estiver vazia, o Convert vai dar erro. 
                        if (chk.Tag != null)
                        {
                            int codigoTela = Convert.ToInt32(chk.Tag);
                            privilegios[codigoTela] = chk.Checked;
                        }
                        else
                        {
                            // Isso não trava o programa, mas avisa no log que você esqueceu a Tag no Designer
                            Serilog.Log.Warning("O CheckBox '{Nome}' não possui um código de tela na propriedade Tag.", chk.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Error(ex, "Falha ao converter a Tag do CheckBox '{Nome}' para Inteiro.", chk.Name);
                        // Não damos 'throw' aqui para não parar o loop dos outros CheckBoxes
                    }
                }

                if (control.HasChildren)
                {
                    PercorrerCheckBox(control.Controls, privilegios);
                }
            }
        }

        // Função para colocar a primeira letra em maiúscula no campo Nome do Funcionário
        private void txtBoxNomeFuncionario_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxNomeFuncionario);
        }

        // Função para colocar a primeira letra em maiúscula no campo Cidade do Funcionário
        private void txtBoxCidadeFuncionario_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxCidadeFuncionario);
        }

        // Declaração do método que trata o clique no botão de pesquisar funcionário
        private void btnPesquisarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria uma instância do formulário de seleção usando 'using' para garantir que 
                // a memória do formulário seja liberada (Dispose) assim que sair deste bloco
                using (var frmSelecionarFuncionario = new frmSelecionarFuncionario())
                {
                    // Abre o formulário como uma janela modal (ShowDialog) e verifica 
                    // se o usuário confirmou a seleção (clicou em OK ou selecionou alguém)
                    if (frmSelecionarFuncionario.ShowDialog() == DialogResult.OK)
                    {
                        // Recupera o objeto 'Funcionario' que foi guardado em uma propriedade 
                        // pública dentro do formulário de seleção
                        var funcionario = frmSelecionarFuncionario.FuncionarioSelecionado;

                        // Preenche os campos da tela principal convertendo os valores do objeto para String
                        txtBoxCodigo.Text = funcionario.CodigoFuncionario.ToString();
                        txtBoxNomeFuncionario.Text = funcionario.nome_funcionario.ToString();
                        txtBoxCpfFuncionario.Text = funcionario.cpf_funcionario.ToString();

                        // Define o texto dos ComboBoxes com base nos dados do funcionário
                        comboBoxSexoFuncionario.Text = funcionario.sexo_funcionario.ToString();
                        comboBoxEstadoCivil.Text = funcionario.funcionario_estado_civil.ToString();
                        comboBoxUf.Text = funcionario.uf_funcionario.ToString();

                        // Continua o preenchimento dos campos de texto (Usuário, Telefone e Cidade)
                        txtBoxUsername.Text = funcionario.username.ToString();
                        txtBoxTelefoneFuncionario.Text = funcionario.telefone_funcionario.ToString();
                        txtBoxCidadeFuncionario.Text = funcionario.cidade_funcionario.ToString();
                        txtBoxEndereco.Text = funcionario.endereco_funcionario.ToString();
                        txtBoxBairro.Text = funcionario.bairro_funcionario.ToString();
                        txtBoxCep.Text = funcionario.cep_funcionario.ToString();
                        txtBoxNumeroResidencia.Text = funcionario.numero_residencia.ToString();

                        // Define a situação cadastral no ComboBox
                        comboBoxSituacao.Text = funcionario.situacao_funcionario.ToString();

                        // Preenche o campo de senha (geralmente o Hash armazenado)
                        txtBoxSenha.Text = funcionario.senha_hash.ToString();

                        int codigoFuncionario = Convert.ToInt32(txtBoxCodigo.Text);

                        MarcarPrivilegiosFuncionario(codigoFuncionario);
                    }
                } // Aqui o formulário 'frmSelecionarFuncionario' é destruído da memória
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Houve um Erro ao Selecionar o Cadastro de funcionário.");
            }
        }

        // Método responsável pelo INSERT de um novo funcionário
        private void InserirNovoCadastroFuncionario()
        {
            try
            {
                if (!_EditarCadastro)
                {
                    // Valida os campos do formulário antes de prosseguir com o cadastro
                    if (validacoesCampos() == true)
                    {
                        return;
                    }
                }

                // Coleta os dados dos campos do formulário
                string? nome = txtBoxNomeFuncionario.Text;
                string? situacao = comboBoxSituacao.Text;
                string? cpf = txtBoxCpfFuncionario.Text;
                string? sexo = comboBoxSexoFuncionario.Text;
                string? estadoCivil = comboBoxEstadoCivil.Text;
                string? username = txtBoxUsername.Text;
                string? telefone = txtBoxTelefoneFuncionario.Text;
                string senhaHash = Seguranca.GerarHashSenha(txtBoxSenha.Text);
                string? cidade = txtBoxCidadeFuncionario.Text;
                string? endereco = txtBoxEndereco.Text;
                string? bairro = txtBoxBairro.Text;
                int.TryParse(txtBoxNumeroResidencia.Text, out int numeroResidencia);
                string? cep = txtBoxCep.Text;
                string? uf = comboBoxUf.Text;

                // Verifica se o CPF já está cadastrado no sistema
                if (funcionario.CpfJaCadastrado(cpf))
                {
                    Funcoes.MensagemWarning("Já existe um funcionário com este CPF cadastrado.");
                    return;
                }

                // Chama o método CadastrarFuncionario da classe Funcionario
                bool sucesso = funcionario.CadastrarFuncionario(nome, cpf, sexo, estadoCivil, username, senhaHash, telefone, cidade, endereco, bairro, numeroResidencia, cep, uf, situacao);

                // Se o cadastro foi bem-sucedido, exibe uma mensagem de sucesso
                if (sucesso)
                {
                    txtBoxCodigo.Text = Convert.ToString(funcionario.CodigoFuncionario);
                }

                // Após o cadastro, gerencia os botões e campos da tela
                GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro ao inserir funcionário: {Funcionario}", txtBoxNomeFuncionario.Text);
                throw;
            }
        }

        // Método responsável pelo UPDATE de um funcionário existente
        private void EditarCadastroFuncionario()
        {
            try
            {
                // Se o campo Código estiver vazio, não é possível editar
                if (string.IsNullOrWhiteSpace(txtBoxCodigo.Text))
                {
                    Funcoes.MensagemWarning("Não é possível editar sem um funcionário selecionado.");
                    return;
                }

                // Valida os campos do formulário antes de prosseguir com a edição
                if (validacoesCampos())
                    return;

                // Define uma váriavel para armazenar o código do funcionário
                int codigoFuncionario = 0;

                // Tenta converter o texto do campo Código para um número inteiro
                if (int.TryParse(txtBoxCodigo.Text, out int codFuncionario))
                {
                    codigoFuncionario = codFuncionario;
                }

                // Coleta os dados atualizados dos campos do formulário
                string nomeFuncionario = txtBoxNomeFuncionario.Text;
                string cpf = txtBoxCpfFuncionario.Text;
                string sexo = comboBoxSexoFuncionario.Text;
                string estadoCivil = comboBoxEstadoCivil.Text;
                string username = txtBoxUsername.Text;
                string telefone = txtBoxTelefoneFuncionario.Text;
                string cidade = txtBoxCidadeFuncionario.Text;
                string situacao = comboBoxSituacao.Text;
                string? endereco = txtBoxEndereco.Text;
                string? bairro = txtBoxBairro.Text;
                int.TryParse(txtBoxNumeroResidencia.Text, out int numeroResidencia);
                string? cep = txtBoxCep.Text;
                string? uf = comboBoxUf.Text;

                bool editouComSucesso = funcionario.EditarCadastroFuncionario(codigoFuncionario, nomeFuncionario, cpf, sexo, estadoCivil, username, telefone, cidade, endereco, bairro, numeroResidencia, cep, uf, situacao);

                if (editouComSucesso)
                {
                    // Se a flag de alteração de senha estiver ativa, atualiza a senha
                    if (_AlterarSenha == true && !string.IsNullOrWhiteSpace(txtBoxSenha.Text))
                    {
                        string novaSenhaHash = Seguranca.GerarHashSenha(txtBoxSenha.Text);
                        funcionario.AtualizarSenhaFuncionario(codigoFuncionario, novaSenhaHash);
                    }

                    GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
                }
                else
                {
                    Funcoes.MensagemWarning("Não foi possivel Editar o cadastro, verifique os dados.");
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Erro ao Editar funcionário: {Funcionario}", txtBoxNomeFuncionario.Text);
            }
        }

        // Método que atua como um "roteador": decide se deve Chamar a Inserção ou a Edição
        private void SalvarCadastroFuncionario()
        {
            // Se a flag de edição for verdadeira, chama o método de Update
            if (_EditarCadastro == true)
            {
                // Se a flag de edição for verdadeira, chama o método de Update
                EditarCadastroFuncionario();
            }
            else
            {
                // Caso contrário, chamar o método de Insert
                InserirNovoCadastroFuncionario();

                txtBoxCodigo.Text = Convert.ToString(funcionario.CodigoFuncionario);
            }
        }

        // Evento do botão Editar (Prepara a tela para edição)
        private void btnEditarCadastro_Click(object sender, EventArgs e)
        {
            // A flag de editar cadastro recebe true (verdadeiro) para editar o cadastro.
            _EditarCadastro = true;

            // Valida se o usuário primeiro selecionou alguém antes de clicar em Editar
            if (string.IsNullOrWhiteSpace(txtBoxCodigo.Text))
            {
                Funcoes.MensagemWarning("Não é possível Editar um Cadastro sem o funcionário selecionado.");
                return;
            }

            if (_EditarCadastro == true)
            {
                lblLinkEditarSenha.Enabled = true;
            }

            // Libera os campos para alteração mas não limpa os dados existentes
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: false);
        }

        // Evento que se clicar no link de redefinir a senha, irá alterar a senha!
        private void lblLinkEditarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Variavél redefinirSenha, que recebe se foi marcado SIM ou NÃO no MessageBox.
            var redefinirSenha = MessageBox.Show("Você Realmente deseja Redefinir a senha?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Se redefinir a senha for igual a Sim. Ele executa o bloco de código Abaixo, se for não, não faz nada.
            if (redefinirSenha == DialogResult.Yes)
            {
                // Limpa o campo da senha!
                txtBoxSenha.Clear();

                // Libera o campo da senha para poder digitar a nova senha!
                txtBoxSenha.ReadOnly = false;

                // Foca o cursor no Text Box da senha!
                txtBoxSenha.Focus();

                // Flag de alterar a senha recebe true.
                _AlterarSenha = true;

                // Mostra a mensagem para digitar a nova senha!
                Funcoes.MensagemInformation("Digite a nova senha e clique em Salvar.");
            }
        }

        // Label Link que acessa os privilegios do cadastro de cliente.
        private void lblLinkCadastroCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpBoxEmpresa.Visible = false;
            grpBoxCliente.Visible = true;
        }

        // Label Link que acessa os privilegios do cadastro de Funcionário.
        private void lblLinkCadastroFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpBoxCliente.Visible = false;
            grpBoxEmpresa.Visible = true;
        }

        private void MarcarPrivilegiosFuncionario(int codigoFuncionario)
        {
            try
            {
                // Instancia o serviço para acessar a lógica de busca
                var service = new FuncionarioPrivilegioService();

                // Obtém do banco de dados apenas a lista de IDs das telas que o funcionário tem acesso
                var telasPermitidas = service.BuscarTelasPermitidas(codigoFuncionario);

                // Inicia a varredura dos controles da tela para marcar os CheckBoxes correspondentes
                MarcarCheckBox(this.Controls, telasPermitidas);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Houve um Erro ao carregar privilégios do funcionário.");
                Funcoes.MensagemErro("Não foi possível carregar as permissões do funcionário.");
            }
        }

        // Método recursivo que percorre a hierarquia de componentes do formulário
        private void MarcarCheckBox(Control.ControlCollection controles, List<int> telasPermitidas)
        {
            foreach (Control control in controles)
            {
                // Se o controle for um CheckBox e possuir um ID de tela na Tag
                if (control is CheckBox chk && chk.Tag != null)
                {
                    // Converte a Tag para inteiro para comparação
                    int codigoTela = Convert.ToInt32(chk.Tag);

                    // Define o estado do CheckBox: 
                    // Fica Marcado (true) se o ID da tela estiver na lista vinda do banco
                    // Fica Desmarcado (false) caso contrário
                    chk.Checked = telasPermitidas.Contains(codigoTela);
                }

                // Se encontrar um container (como Panel ou GroupBox), entra nele para buscar mais CheckBoxes
                if (control.HasChildren)
                {
                    MarcarCheckBox(control.Controls, telasPermitidas);
                }
            }
        }

        // Método responsável por deixar as primeiras letras de uma palavra Maiuscula.
        private void txtBoxEndereco_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxEndereco);
        }

        // Método responsável por deixar as primeiras letras de uma palavra Maiuscula.
        private void txtBoxBairro_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxBairro);
        }

        private async void txtBoxCep_Leave(object sender, EventArgs e)
        {
            string cep = txtBoxCep.Text.Replace(".", "").Replace("-", "").Trim();

            if (cep.Length == 8)
            {
                try
                {
                    CepService buscaCep = new CepService();

                    var endereco = await buscaCep.ConsultarCep(cep);

                    if (endereco != null)
                    {
                        txtBoxEndereco.Text = endereco.logradouro;
                        txtBoxBairro.Text = endereco.bairro;
                        txtBoxCidadeFuncionario.Text = endereco.localidade;
                        comboBoxUf.Text = endereco.uf;

                        txtBoxNumeroResidencia.Focus();
                    }
                    else
                    {
                        Funcoes.MensagemWarning("CEP não encontrado. Verifique o número e tente novamente.");
                    }
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "Erro ao consultar CEP: {CEP}", cep);
                    Funcoes.MensagemErro("Erro ao consultar CEP. Verifique o CEP e tente novamente.");
                }
            }
        }
    }
}
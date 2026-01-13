using iText.StyledXmlParser.Jsoup.Nodes;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmCadastroFuncionario : Form
    {
        private bool _EditarCadastro;

        private bool _AlterarSenha = false;

        // Construtor do formulário de cadastro de funcionário
        public frmCadastroFuncionario()
        {
            InitializeComponent();
            txtBoxCodigo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxCpfFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxTelefoneFuncionario.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        // Controla o estado dos controles da tela (Habilitar/Desabilitar, Limpar e Visibilidade).
        private void GerenciarBotoesCampos(bool OcultarBotoes, bool ManifestarBotoes, bool LimparCampos)
        {
            // --- 1. CONTROLE DE EDIÇÃO (Habilitar ou Bloquear campos) ---
            // ComboBoxes usam .Enabled (Habilitado/Desabilitado)
            comboBoxSituacao.Enabled = ManifestarBotoes;
            comboBoxSexoFuncionario.Enabled = ManifestarBotoes;
            comboBoxEstadoCivil.Enabled = ManifestarBotoes;

            // TextBoxes usam .ReadOnly (Somente Leitura)
            // O operador '!' inverte o valor: se ManifestarBotoes for true, ReadOnly será false.
            txtBoxNomeFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxCpfFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxCidadeFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxTelefoneFuncionario.ReadOnly = !ManifestarBotoes;
            txtBoxUsername.ReadOnly = !ManifestarBotoes;
            lblLinkEditarSenha.Enabled = ManifestarBotoes;

            // --- 2. LIMPEZA DOS CAMPOS ---
            if (LimparCampos)
            {
                // Reseta a seleção dos ComboBoxes (-1 significa nenhum item selecionado)
                comboBoxSituacao.SelectedIndex = -1;
                comboBoxSexoFuncionario.SelectedIndex = -1;
                comboBoxEstadoCivil.SelectedIndex = -1;

                // Limpa o texto de todas as TextBoxes
                txtBoxCodigo.Clear();
                txtBoxNomeFuncionario.Clear();
                txtBoxCpfFuncionario.Clear();
                txtBoxCidadeFuncionario.Clear();
                txtBoxTelefoneFuncionario.Clear();
                txtBoxUsername.Clear();
                txtBoxSenha.Clear();
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

        // Evento do botão para iniciar um novo cadastro de funcionário
        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            _EditarCadastro = false;

            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        // Evento do botão para cancelar o cadastro de funcionário
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        // Evento do botão para salvar o cadastro de funcionário
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            // Se for um novo cadastro, valida todos os campos obrigatórios
            if (!_EditarCadastro)
            {
                if (validacoesCampos() == true)
                {
                    return;
                }
            }

            // Chama o método centralizado que decide entre Inserir ou Editar
            SalvarCadastroFuncionario();

            // Após salvar, bloqueia os campos e volta a exibir os botões principais
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
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

                    // Continua o preenchimento dos campos de texto (Usuário, Telefone e Cidade)
                    txtBoxUsername.Text = funcionario.username.ToString();
                    txtBoxTelefoneFuncionario.Text = funcionario.telefone_funcionario.ToString();
                    txtBoxCidadeFuncionario.Text = funcionario.cidade_funcionario.ToString();

                    // Define a situação cadastral no ComboBox
                    comboBoxSituacao.Text = funcionario.situacao_funcionario.ToString();

                    // Preenche o campo de senha (geralmente o Hash armazenado)
                    txtBoxSenha.Text = funcionario.senha_hash.ToString();
                }
            } // Aqui o formulário 'frmSelecionarFuncionario' é destruído da memória
        }

        // Método responsável pelo INSERT de um novo funcionário
        private void InserirNovoCadastroFuncionario()
        {
            if (!_EditarCadastro)
            {
                // Valida os campos do formulário antes de prosseguir com o cadastro
                if (validacoesCampos() == true)
                {
                    return;
                }
            }

            // Cria uma nova instância da classe Funcionario para realizar o cadastro
            Funcionario funcionario = new Funcionario();

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

            // Verifica se o CPF já está cadastrado no sistema
            if (funcionario.CpfJaCadastrado(cpf))
            {
                Funcoes.MensagemWarning("Já existe um funcionário com este CPF cadastrado.");
                return;
            }

            // Tenta cadastrar o funcionário com os dados fornecidos
            try
            {
                // Chama o método CadastrarFuncionario da classe Funcionario
                bool sucesso = funcionario.CadastrarFuncionario(nome, cpf, sexo, estadoCivil, username, senhaHash, telefone, cidade, situacao);

                // Se o cadastro foi bem-sucedido, exibe uma mensagem de sucesso
                if (sucesso)
                {
                    Funcoes.MensagemInformation("Funcionário cadastrado com sucesso!");
                }

                // Após o cadastro, gerencia os botões e campos da tela
                GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
            }
            // Em caso de qualquer exceção durante o processo de cadastro, captura a exceção
            catch (Exception ex)
            {
                // Em caso de erro durante o cadastro, exibe uma mensagem de erro
                Funcoes.MensagemWarning("Houve um erro ao realizar o cadastro" + ex);
            }
        }

        // Método responsável pelo UPDATE de um funcionário existente
        private void EditarCadastroFuncionario()
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

            // Cria uma nova instância da classe Funcionario para realizar a edição
            Funcionario funcionario = new Funcionario();

            // Chama o método EditarCadastroFuncionario da classe Funcionario
            funcionario.EditarCadastroFuncionario(codigoFuncionario,nomeFuncionario, cpf, sexo, estadoCivil, username, telefone, cidade, situacao);

            // Se a flag de alteração de senha estiver ativa, atualiza a senha
            if (_AlterarSenha == true)
            {
                if (!string.IsNullOrWhiteSpace(txtBoxSenha.Text))
                {
                    string novaSenhaHash = Seguranca.GerarHashSenha(txtBoxSenha.Text);
                    funcionario.AtualizarSenhaFuncionario(codigoFuncionario, novaSenhaHash);
                }
            }

            Funcoes.MensagemInformation("Cadastro do funcionário atualizado com sucesso.");
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

            // Libera os campos para alteração mas não limpa os dados existentes
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: false);
        }

        // Evento que se clicar no link de redefinir a senha, irá alterar a senha!
        private void lblLinkEditarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Variavél redefinirSenha, que recebe se foi marcado SIM ou NÂO no MessageBox.
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

    }
}
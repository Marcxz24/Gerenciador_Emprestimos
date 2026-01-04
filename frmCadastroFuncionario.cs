namespace Gerenciador_de_Emprestimos
{
    public partial class frmCadastroFuncionario : Form
    {
        public string nome;
        public string cpf;
        public string sexo;
        public string estadoCivil;
        public string username;
        public string telefone;
        public string cidade;
        public string situacao;

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
            txtBoxSenha.ReadOnly = !ManifestarBotoes;

            // --- 2. LIMPEZA DOS CAMPOS ---
            if (LimparCampos)
            {
                // Reseta a seleção dos ComboBoxes (-1 significa nenhum item selecionado)
                comboBoxSituacao.SelectedIndex = -1;
                comboBoxSexoFuncionario.SelectedIndex = -1;
                comboBoxEstadoCivil.SelectedIndex = -1;

                // Limpa o texto de todas as TextBoxes
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

        private bool validacoesCampos()
        {
            if (string.IsNullOrWhiteSpace(txtBoxNomeFuncionario.Text))
            {
                Funcoes.MensagemWarning("O campo Nome é obrigatório.");
                return true;
            }

            if (string.IsNullOrEmpty(txtBoxCpfFuncionario.Text))
            {
                Funcoes.MensagemWarning("Campo CPF é obrigatório! Preencha os seguintes campos\n\nCampo: CPF");
                return true;
            }

            if (ValidacaoCpf.ValidarCpf(txtBoxCpfFuncionario.Text) == false)
            {
                Funcoes.MensagemWarning("CPF inválido, favor informar um CPF valido.");
                return true;
            }

            if (string.IsNullOrEmpty(comboBoxSexoFuncionario.Text))
            {
                Funcoes.MensagemWarning("Campo Sexo do funcionário é obrigatório.\n\nCampo: Sexo");
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBoxUsername.Text))
            {
                Funcoes.MensagemWarning("O campo Login é obrigatório.\n\nCampo: Username");
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtBoxSenha.Text))
            {
                Funcoes.MensagemWarning("O campo Senha é obrigatório.\n\nCampo: Senha");
                return true;
            }

            if (string.IsNullOrEmpty(txtBoxCidadeFuncionario.Text))
            {
                Funcoes.MensagemWarning("Campo cidade é obrigatório\n\nCampo: cidade");
                return true;
            }

            if (string.IsNullOrEmpty(comboBoxEstadoCivil.Text))
            {
                Funcoes.MensagemWarning("Campo estado civil é obrigatório\n\nCampo: Estado Civil");
                return true;
            }

            if (string.IsNullOrEmpty(txtBoxTelefoneFuncionario.Text))
            {
                Funcoes.MensagemWarning("Campo Telefone do funcionário é obrigatório\n\nCampo: Telefone do Funcionário");
                return true;
            }

            return false;
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: true, ManifestarBotoes: true, LimparCampos: true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: true);
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            if (validacoesCampos() == true)
            {
                return;
            }

            Funcionario funcionario = new Funcionario();

            nome = txtBoxNomeFuncionario.Text;
            situacao = comboBoxSituacao.Text;
            cpf = txtBoxCpfFuncionario.Text;
            sexo = comboBoxSexoFuncionario.Text;
            estadoCivil = comboBoxEstadoCivil.Text;
            username = txtBoxUsername.Text;
            telefone = txtBoxTelefoneFuncionario.Text;
            string senhaHash = Seguranca.GerarHashSenha(txtBoxSenha.Text);
            cidade = txtBoxCidadeFuncionario.Text;

            if (funcionario.CpfJaCadastrado(cpf))
            {
                Funcoes.MensagemWarning("Já existe um funcionário com este CPF cadastrado.");
                return;
            }

            try
            {
                bool sucesso = funcionario.CadastrarFuncionario(nome, cpf, sexo, estadoCivil, username, senhaHash, telefone, cidade, situacao);

                if (sucesso)
                {
                    Funcoes.MensagemInformation("Funcionário cadastrado com sucesso!");
                }

                GerenciarBotoesCampos(OcultarBotoes: false, ManifestarBotoes: false, LimparCampos: false);
            }
            catch (Exception ex)
            {
                Funcoes.MensagemWarning("Houve um erro ao realizar o cadastro" + ex);
            }
        }

        private void txtBoxNomeFuncionario_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxNomeFuncionario);
        }

        private void txtBoxCidadeFuncionario_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PrimeiraLetraMaiuscula(txtBoxCidadeFuncionario);
        }
    }
}

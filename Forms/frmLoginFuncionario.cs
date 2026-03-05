using Gerenciador_de_Emprestimos.Security;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmLoginFuncionario : Form
    {
        public bool LoginRealizado { get; private set; } = false;

        LoginService login = new LoginService();

        // Método Construtor da classe
        public frmLoginFuncionario()
        {
            // Inicializa os componentes visuais criados no Designer (botões, campos de texto, etc.)
            InitializeComponent();
        }

        /// Verifica se os campos de login e senha foram preenchidos.
        /// Retorna TRUE caso algum campo esteja vazio (indicando falha).
        private bool ValidarCampos()
        {
            try
            {
                // Verifica se o campo de usuário está vazio ou nulo
                if (string.IsNullOrEmpty(txtBoxUsername.Text))
                {
                    // Exibe mensagem de alerta personalizada
                    Funcoes.MensagemWarning("Campo Usuário em Branco! Preencha Por favor!\n\nCampo: Usuário");
                    return true; // Retorna true indicando que houve erro na validação
                }

                // Verifica se o campo de senha está vazio ou nulo
                if (string.IsNullOrEmpty(txtBoxSenha.Text))
                {
                    // Exibe mensagem de alerta personalizada
                    Funcoes.MensagemWarning("Campo Senha em Branco! Preencha Por favor!\n\nCampo: Senha");
                    return true; // Retorna true indicando que houve erro na validação
                }

                // Verifica se o usuário está inativo
                if (login.ValidarUsuarioInativo(txtBoxUsername.Text))
                {
                    // Exibe mensagem de alerta personalizada
                    Funcoes.MensagemWarning("Não é possivel acessar o Sistema com Usuário INATIVOS!");
                    return true; // Retorna true indicando que houve erro na validação
                }

                // Se passar por ambos, retorna false (não há erros)
                return false;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro inesperado durante a Validação dos Campos de Login.\n\nDetalhes: " + ex.Message);
                return true; // Retorna true indicando que houve erro na validação
            }
        }

        // --- EVENTO: Acionado quando o cursor sai do campo de Usuário (Leave) ---
        private void txtBoxUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                string textoDigitado = txtBoxUsername.Text.Trim();

                // Se o que foi digitado não for um número (ID do funcionário), 
                // entende-se que o usuário digitou o próprio "username" e não faz nada.
                if (!int.TryParse(textoDigitado, out int codigoFuncionario))
                {
                    return;
                }

                // Se for um número, o sistema tenta buscar o nome de usuário vinculado àquele ID
                LoginService login = new LoginService();
                string username = login.ObterUsernamePorCodigo(codigoFuncionario);

                // Se a busca não retornar nada, avisa que o código é inválido ou o funcionário está bloqueado
                if (string.IsNullOrEmpty(username))
                {
                    Funcoes.MensagemWarning("Funcionário não encontrado ou INATIVO no Sistema.");
                    txtBoxUsername.Clear();
                    txtBoxUsername.Focus(); // Devolve o cursor para o campo para correção
                    return;
                }

                // Preenche automaticamente o campo com o nome de usuário encontrado
                txtBoxUsername.Text = username;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro inesperado durante ao Localizar Código do funcionário.\n\nDetalhes: " + ex.Message);
            }
        }

        private void frmLoginFuncionario_Load(object sender, EventArgs e)
        {
            picBoxLogoLogin.Left = (this.ClientSize.Width - picBoxLogoLogin.Width) / 2;
            picBoxLogoLogin.Top = (this.ClientSize.Height - picBoxLogoLogin.Height) / 2 - 50;

            txtBoxUsername.Focus(); // Define o foco inicial no campo de usuário para melhor usabilidade
        }

        /// <summary>
        /// Evento disparado ao pressionar uma tecla no campo de Senha.
        /// Substitui o clique do botão de Login, permitindo autenticar apenas com o 'Enter'.
        /// </summary>
        private void txtBoxSenha_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi o 'Enter'
            if (e.KeyCode == Keys.Enter)
            {
                // Impede o som de 'erro' do Windows ao processar o Enter
                e.SuppressKeyPress = true;

                try
                {
                    // Valida se os campos obrigatórios (usuário e senha) estão preenchidos
                    if (ValidarCampos())
                    {
                        return; // Interrompe o processo se houver campos vazios
                    }

                    // Instancia o serviço de login e tenta autenticar o usuário
                    // O parâmetro 'out' extrai o ID do funcionário para uso na sessão caso o login seja válido
                    bool sucessoLogin = login.LoginUsuario(txtBoxUsername.Text, txtBoxSenha.Text, out int codigoFuncionario);

                    if (sucessoLogin)
                    {
                        // Define que a autenticação foi concluída com sucesso
                        LoginRealizado = true;

                        // Armazena os dados do usuário na classe estática de Sessão para acesso global no sistema
                        Sessao.CodigoFuncionarioLogado = codigoFuncionario;
                        Sessao.NomeFuncionarioLogado = txtBoxUsername.Text;

                        // Carrega as permissões e níveis de acesso vinculados ao funcionário logado
                        ControleAcesso.CarregarPrivilegios(codigoFuncionario);

                        // Verifica se o formulário de login foi aberto a partir da Tela Inicial
                        if (this.Owner is frmTelaIncial telaPrincipal)
                        {
                            // Atualiza as informações de usuário no rodapé/dashboard da tela principal
                            telaPrincipal.AtualizarUsuarioLogado(Sessao.CodigoFuncionarioLogado, Sessao.NomeFuncionarioLogado);

                            // Desbloqueia as funcionalidades e menus do sistema
                            telaPrincipal.ConfigurarAcesso(true);
                        }

                        // Fecha o formulário de login e libera o acesso ao sistema
                        this.Close();
                    }
                    else
                    {
                        // Caso as credenciais sejam inválidas, exibe alerta e limpa a senha para nova tentativa
                        Funcoes.MensagemErro("Falha no Login! Usuário ou Senha incorretos!");
                        txtBoxSenha.Clear();
                        txtBoxSenha.Focus();
                    }
                }
                catch (Exception ex)
                {
                    // Captura falhas inesperadas (como perda de conexão com o banco) e registra o erro
                    Funcoes.MensagemErro("Ocorreu um erro inesperado durante o Login.\n\nDetalhes: " + ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// Evento disparado no campo de Usuário. 
        /// Permite que o usuário digite o Código (ID) do funcionário e o sistema converta para o Username automaticamente.
        /// </summary>
        private void txtBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se o usuário pressionou 'Enter' após digitar o código ou nome
            if (e.KeyCode == Keys.Enter)
            {
                // Silencia o bipe do Windows
                e.SuppressKeyPress = true;

                try
                {
                    string textoDigitado = txtBoxUsername.Text.Trim();

                    // Tenta converter o texto digitado para um número inteiro (ID do funcionário)
                    if (!int.TryParse(textoDigitado, out int codigoFuncionario))
                    {
                        // Se não for número, assume-se que é o nome de usuário e move o foco para a senha
                        txtBoxSenha.Focus();
                        return;
                    }

                    // Se for número, busca no banco o nome de usuário vinculado a esse código
                    LoginService login = new LoginService();
                    string username = login.ObterUsernamePorCodigo(codigoFuncionario);

                    // Se a busca não retornar um nome, o ID é inexistente ou o funcionário está inativo
                    if (string.IsNullOrEmpty(username))
                    {
                        Funcoes.MensagemWarning("Funcionário não encontrado ou INATIVO no Sistema.");
                        txtBoxUsername.Clear();
                        txtBoxUsername.Focus();
                        return;
                    }

                    // Se encontrou o funcionário, preenche o campo de texto com o Username e pula para a senha
                    txtBoxUsername.Text = username;
                    txtBoxSenha.Focus();
                }
                catch (Exception ex)
                {
                    // Loga o erro internamente usando Serilog para depuração futura
                    Serilog.Log.Error("Erro ao localizar funcionário por código: " + ex.Message);
                }
            }
        }
    }
}
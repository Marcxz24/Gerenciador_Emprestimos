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

        // Evento disparado ao clicar no botão de "Logar".
        private void btnLogarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Chama o método de validação interna (verifica se os campos estão vazios)
                // Se retornar true (erro), o 'return' abaixo interrompe a execução do login.
                if (ValidarCampos())
                {
                    return; // Sai do método e não prossegue com o processo de autenticação
                }

                // Tenta realizar o login chamando a camada de serviço (LoginService)
                // O parâmetro 'out' recupera o código do funcionário caso o login seja bem-sucedido
                bool sucessoLogin = login.LoginUsuario(txtBoxUsername.Text, txtBoxSenha.Text, out int codigoFuncionario);

                if (sucessoLogin)
                {
                    LoginRealizado = true;

                    Sessao.CodigoFuncionarioLogado = codigoFuncionario;
                    Sessao.NomeFuncionarioLogado = txtBoxUsername.Text;

                    // Chama o método da classe Controle de Acesso, que carrega os privilegios do usuário logado.
                    ControleAcesso.CarregarPrivilegios(codigoFuncionario);

                    // VERIFICAÇÃO DE HIERARQUIA: Tenta encontrar o formulário "pai" (Tela Inicial)
                    // Isso permite que o login "avise" a tela principal quem entrou no sistema
                    if (this.Owner is frmTelaIncial telaPrincipal)
                    {
                        // Atualiza o nome do usuário no rodapé/cabeçalho da tela principal
                        telaPrincipal.AtualizarUsuarioLogado(Sessao.CodigoFuncionarioLogado, Sessao.NomeFuncionarioLogado);

                        // Libera os menus e botões do sistema que estavam bloqueados
                        telaPrincipal.ConfigurarAcesso(true);
                    }

                    this.Close(); // Fecha o formulário de login após o sucesso
                }
                else
                {
                    // Se a senha ou usuário estiverem errados, exibe mensagem padrão
                    Funcoes.MensagemErro("Falha no Login! Usuário ou Senha incorretos!");
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, exibe a mensagem de erro
                Funcoes.MensagemErro("Ocorreu um erro inesperado durante o Login.\n\nDetalhes: " + ex.Message);
                return; // Sai do método para evitar continuar o processo de login
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
        }
    }
}
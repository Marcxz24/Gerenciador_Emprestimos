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

        /// Evento disparado ao clicar no botão de "Logar".
        private void btnLogarUsuario_Click(object sender, EventArgs e)
        {
            // Chama o método de validação. 
            // Se retornar true (erro), o 'return' abaixo interrompe a execução do login.
            if (ValidarCampos() == true)
            {
                return; // Sai do método e não prossegue com o processo de autenticação
            }

            // Caso o código continue após este IF, aqui entraria a lógica de 
            // consultar o banco de dados para validar o usuário e a senha.
        }
    }
}

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
    public partial class frmObservacoesEmprestimos : Form
    {
        // String publica que irá armazenar o Texto do emprestimo.
        public string ObsercacoesEmprestimos;

        public frmObservacoesEmprestimos()
        {
            InitializeComponent();
        }

        // Método publico que retorna a string do emprestimo.
        public string AdquirirDadosObservacoes(string msgObservacoes)
        {
            try
            {
                // Se o campo txtObservacoes for diferente de nulo ou sem espaços em branco. Roda o código abaixo.
                if (!string.IsNullOrWhiteSpace(txtObservacoesEmprestimos.Text))
                {
                    // a variavel msgObservacoes recebe o valor digitado no Text box.
                    msgObservacoes = txtObservacoesEmprestimos.Text;
                    // a variavel publica recebe o texto armazenado na variavel acima.
                    ObsercacoesEmprestimos = msgObservacoes;
                }

                // Retorna a mensagem msgObeservacoes.
                return msgObservacoes;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao Adiquirir as Observações.\n\nDetalhes: " + ex.Message);
                return null;
            }
        }

        // Método privado para salvar as observações.
        private void btnSalvarObservacoes_Click(object sender, EventArgs e)
        {
            try
            {
                // Chama o método AdquirirObservacoes, passando a variavel publica como parametros.
                AdquirirDadosObservacoes(ObsercacoesEmprestimos);
                // Fecha o formulário.
                Close();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Ocorreu um erro ao Salvar as Observações.\n\nDetalhes: " + ex.Message);
            }
        }
    }
}

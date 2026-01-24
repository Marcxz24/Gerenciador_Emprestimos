using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos.Utils
{
    // Define uma classe interna para funções utilitárias que podem ser usadas em qualquer formulário
    internal class Funcoes
    {
        // --- MÉTODO: Formata o texto para "Nome Próprio" (Ex: joão silva -> João Silva) ---
        public static void PrimeiraLetraMaiuscula(Control controle)
        {
            // Define a cultura brasileira para garantir que acentos sejam tratados corretamente
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;

            string text = controle.Text;

            // Converte a primeira letra de cada palavra para maiúscula
            text = textInfo.ToTitleCase(text);

            // REGRA DE EXCEÇÃO: Mantém conectivos em minúsculo (Padrão da língua portuguesa)
            text = text.Replace(" De ", " de ").
                        Replace(" Da ", " da ").
                        Replace(" Do ", " do ").
                        Replace(" Das ", " das ").
                        Replace(" Dos ", " dos ").
                        Replace(" E ", " e ");

            controle.Text = text;

            // Se o controle for um TextBox, move o cursor para o final do texto
            // Isso evita que o cursor volte para o início enquanto o usuário digita
            if (controle is TextBox txt)
            {
                txt.SelectionStart = txt.Text.Length;
            }
        }

        // --- MÉTODO: Bloqueia qualquer caractere que não seja número no teclado ---
        public static void SomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se não for número e não for uma tecla de controle (como Backspace), cancela o evento
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // "Handled = true" diz ao Windows que o caractere já foi tratado e não deve aparecer
            }
        }

        // --- MÉTODO: Permite números e apenas uma vírgula (Para valores monetários) ---
        public static void SomenteNumerosComVirgula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite se: For dígito OU tecla de controle OU (for vírgula E o campo ainda não tiver outra vírgula)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != ',' || (sender as TextBox).Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        // --- MÉTODOS DE MENSAGEM: Padronizam as caixas de diálogo do sistema ---

        public static void MensagemWarning(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção! Analisar os seguintes critérios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MensagemInformation(string mensagem)
        {
            MessageBox.Show(mensagem, "Operação Realizada com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

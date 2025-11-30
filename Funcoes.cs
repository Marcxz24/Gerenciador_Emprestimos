using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos
{
    internal class Funcoes
    {
        public static void PrimeiraLetraMaiuscula(Control controle)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;

            string text = controle.Text;

            text = textInfo.ToTitleCase(text);

            text = text.Replace(" De ", " de ").
                        Replace(" Da ", " da ").
                        Replace(" Do ", " do ").
                        Replace(" Das ", " das ").
                        Replace(" Dos ", " dos ").
                        Replace(" E ", " e ");

            controle.Text = text;

            if (controle is TextBox txt)
            {
                txt.SelectionStart = txt.Text.Length;
            }
            
        }

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

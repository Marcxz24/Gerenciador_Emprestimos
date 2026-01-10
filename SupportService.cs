using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class SupportService
    {
        public const string NumeroWhatsApp = "5538991334465";

        public static void AbrirChatWhatsApp()
        {
            string mensagem = "Olá, preciso de suporte com o Gerenciador de Empréstimos.";
            string url = $"https://wa.me/{NumeroWhatsApp}?text={Uri.EscapeDataString(mensagem)}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}

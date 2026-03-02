using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    public static class WhatsAppService
    {
        public static void EnviarMensagem(string telefone, string mensagem)
        {
            string telefoneFormatado = telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (!telefoneFormatado.StartsWith("55"))
            {
                telefoneFormatado = "55" + telefoneFormatado;
            }

            string url = $"https://wa.me/{telefoneFormatado}?text={Uri.EscapeDataString(mensagem)}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}

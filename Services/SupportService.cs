using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    internal class SupportService
    {
        // Define uma constante com o número de telefone (formato internacional: código país + DDD + número)
        // Por ser 'const', este valor não pode ser alterado durante a execução do programa
        public const string NumeroWhatsApp = "5538991334465";

        // Define um método estático para abrir o chat, permitindo chamá-lo sem instanciar a classe
        public static void AbrirChatWhatsApp()
        {
            // Define a frase padrão que aparecerá escrita na caixa de mensagem do usuário
            string mensagem = "Olá, preciso de suporte com o Gerenciador de Empréstimos.";

            // Monta a URL da API do WhatsApp (wa.me) usando interpolação de string
            // O 'Uri.EscapeDataString' converte espaços e caracteres especiais em um formato que a URL entenda (como %20)
            string url = $"https://wa.me/{NumeroWhatsApp}?text={Uri.EscapeDataString(mensagem)}";

            // Inicia um processo do sistema operacional para abrir o link
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                // Define o destino como a URL montada acima
                FileName = url,

                // 'UseShellExecute = true' é obrigatório no .NET Core / .NET 5+ para abrir URLs no navegador padrão
                // Ele instrui o Windows a decidir qual programa deve abrir esse link (geralmente o Chrome, Edge ou WhatsApp)
                UseShellExecute = true
            });
        }
    }
}

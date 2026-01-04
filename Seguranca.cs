using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class Seguranca
    {
        public static string GerarHashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool VerificarSenha(string senhaDigitada, string senhaHashBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, senhaHashBanco);
        }
    }
}

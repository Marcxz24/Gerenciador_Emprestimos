using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define o agrupamento lógico (namespace) do projeto
namespace Gerenciador_de_Emprestimos
{
    // Declara a classe 'Seguranca', que centraliza as regras de criptografia
    public class Seguranca
    {
        // Método estático que recebe uma senha em texto puro e a transforma em um Hash seguro
        public static string GerarHashSenha(string senha)
        {
            // Utiliza a biblioteca BCrypt para criar uma representação criptografada da senha
            // Este valor retornado é o que deve ser salvo na coluna 'senha_hash' do seu banco de dados
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        // Método estático que compara a senha que o usuário digitou no Login com o Hash que está no banco
        public static bool VerificarSenha(string senhaDigitada, string senhaHashBanco)
        {
            // O BCrypt consegue descriptografar internamente o hash para validar se a senha combina
            // Retorna 'true' se a senha estiver correta e 'false' se estiver errada
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, senhaHashBanco);
        }
    }
}
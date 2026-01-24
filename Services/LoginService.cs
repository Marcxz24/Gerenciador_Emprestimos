using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    // Define a classe interna responsável pelos serviços de autenticação e validação de login
    internal class LoginService
    {
        // Propriedade para armazenar o ID do usuário que conseguiu logar com sucesso
        public int CodigoUsuarioLogado { get; private set; }

        // --- MÉTODO: Realiza a autenticação do usuário ---
        // Retorna true/false para o login e usa o 'out' para devolver o ID do funcionário para quem chamou
        public bool LoginUsuario(string Username, string Passowrd, out int CodigoFuncionario)
        {
            CodigoFuncionario = 0; // Inicializa a variável de saída

            // Seleciona o código e o hash da senha baseado no username informado
            string sql = @"SELECT codigo, senha_hash, situacao_funcionario
                        FROM emprestimosbd.funcionario
                        WHERE username = @username";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@username", Username);

                using (var leia = comando.ExecuteReader())
                {
                    // Se o username não for encontrado no banco, retorna falso imediatamente
                    if (!leia.Read())
                    {
                        return false;
                    }

                    // Recupera o Hash da senha que está armazenado no banco
                    string senhaHashBanco = leia["senha_hash"].ToString();

                    // COMPARAÇÃO DE SEGURANÇA:
                    // O BCrypt verifica se a senha digitada (texto puro) bate com o Hash do banco
                    bool senhaCorreta = BCrypt.Net.BCrypt.Verify(Passowrd, senhaHashBanco);

                    // Se a senha estiver errada, retorna falso
                    if (!senhaCorreta)
                    {
                        return false;
                    }

                    // Se chegou aqui, o usuário existe e a senha está correta
                    CodigoFuncionario = Convert.ToInt32(leia["codigo"]);
                    return true;
                }
            }
        }

        // --- MÉTODO: Recupera o nome de exibição do usuário baseado no código ---
        // Útil para mostrar "Bem-vindo, [Nome]" na tela principal
        public string ObterUsernamePorCodigo(int codigoFuncionario)
        {
            string sql = @"SELECT username
                        FROM emprestimosbd.funcionario
                        WHERE codigo = @codigo
                        AND situacao_funcionario = 'ATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoFuncionario);

                // ExecuteScalar é usado quando queremos apenas UM valor (uma célula) de retorno
                object resultado = comando.ExecuteScalar();

                return resultado == null ? null : resultado.ToString();
            }
        }

        // --- MÉTODO: Verifica se o usuário está bloqueado (Inativo) ---
        // Serve para impedir o acesso mesmo que a senha esteja correta
        public bool ValidarUsuarioInativo(string usermame)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.funcionario 
                        WHERE username = @username
                        AND situacao_funcionario = 'INATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@username", usermame);

                // Conta quantos registros existem com esse username e status INATIVO
                int countUserInativo = Convert.ToInt32(comando.ExecuteScalar());

                // Se for maior que 0, o usuário está inativo
                return countUserInativo > 0;
            }
        }
    }
}

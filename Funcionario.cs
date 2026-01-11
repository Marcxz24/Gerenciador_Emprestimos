using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class Funcionario
    {
        // Propriedade para identificar o funcionário (útil para carregar dados posteriormente)
        public int Codigo { get; set; }

        // --- MÉTODO: Realiza a inserção de um novo funcionário no banco ---
        public bool CadastrarFuncionario(string nome, string cpf, string sexo, string estadoCivil, string username, string senha, string telefone, string cidade, string situacao)
        {
            // VALIDAÇÃO DE INTEGRIDADE: Chama o método abaixo para verificar se o CPF já existe
            // Isso evita que o banco gere um erro de chave duplicada ou dados inconsistentes
            if (CpfJaCadastrado(cpf))
            {
                return false;
            }

            // Comando SQL de inserção estruturado para o MySQL
            string sql = @"INSERT INTO funcionario
                        (
                        nome_funcionario,
                        cpf_funcionario,
                        sexo_funcionario,
                        funcionario_estado_civil,
                        username,
                        senha_hash,
                        telefone_funcionario,
                        cidade_funcionario,
                        situacao_funcionario,
                        data_cadastro
                        )
                        VALUES
                        (
                        @nome_funcionario,
                        @cpf_funcionario,
                        @sexo_funcionario,
                        @funcionario_estado_civil,
                        @username,
                        @senha_hash,
                        @telefone_funcionario,
                        @cidade_funcionario,
                        @situacao_funcionario,
                        @data_cadastro
                        )";

            try
            {
                // Gerencia a conexão e o comando de forma segura
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    // Mapeia os parâmetros para evitar SQL Injection
                    comando.Parameters.AddWithValue("@nome_funcionario", nome);
                    comando.Parameters.AddWithValue("@cpf_funcionario", cpf);
                    comando.Parameters.AddWithValue("@sexo_funcionario", sexo);
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", estadoCivil);
                    comando.Parameters.AddWithValue("@username", username);
                    comando.Parameters.AddWithValue("@senha_hash", senha); // Aqui deve entrar o Hash do BCrypt
                    comando.Parameters.AddWithValue("@telefone_funcionario", telefone);
                    comando.Parameters.AddWithValue("@cidade_funcionario", cidade);
                    comando.Parameters.AddWithValue("@situacao_funcionario", situacao);
                    comando.Parameters.AddWithValue("@data_cadastro", DateTime.Now); // Registra o momento exato do cadastro

                    // Executa a inserção
                    comando.ExecuteNonQuery();

                    // Usa sua classe de utilitários para exibir o sucesso
                    Funcoes.MensagemInformation("Cliente Cadastrado com Sucesso!");

                    return true;
                }
            }
            catch (MySqlException)
            {
                // Se houver qualquer erro de banco de dados, retorna falso
                return false;
            }
        }

        // --- MÉTODO: Verifica se o CPF informado já pertence a algum funcionário ---
        public bool CpfJaCadastrado(string cpf)
        {
            string sql = "SELECT COUNT(*) FROM emprestimosbd.funcionario WHERE cpf_funcionario = @cpf_funcionario";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@cpf_funcionario", cpf);

                // Retorna o número de registros encontrados (0 se não existir, 1 ou mais se existir)
                int count = Convert.ToInt32(comando.ExecuteScalar());

                return count > 0;
            }
        }
    }
}

using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class FuncionarioPrivilegioRepository
    {
        // Método que busca no banco apenas os IDs das telas onde o funcionário tem acesso ativo (pode_acessar = 1)
        public List<int> ObterTelasPermitidas(int codigoFuncionario)
        {
            var telas = new List<int>();

            // Query SQL para filtrar permissões por funcionário e status ativo
            string sql = @"SELECT codigo_tela FROM funcionario_tela_privilegio
                        WHERE codigo_funcionario = @codigo_funcionario
                        AND pode_acessar = 1";

            // 'using' garante que a conexão e o comando sejam fechados e descartados da memória automaticamente
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                // Adição de parâmetro para evitar SQL Injection
                cmd.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionario);

                // Executa a leitura dos dados de forma sequencial
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Adiciona o código da tela encontrado na lista de retorno
                        telas.Add(reader.GetInt32("codigo_tela"));
                    }
                }
            }

            return telas;
        }

        // Método que verifica se já existe qualquer registro (seja 0 ou 1) para o par Funcionário/Tela
        public bool ExistePrivilegio(int codigoFuncionario, int codigoTela)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.funcionario_tela_privilegio
                        WHERE codigo_funcionario = @codigo_funcionario
                        AND codigo_tela = @codigo_tela";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionario);
                cmd.Parameters.AddWithValue("@codigo_tela", codigoTela);

                // ExecuteScalar é usado pois o retorno é um valor único (o total da contagem)
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Método que insere um novo registro de permissão na tabela
        public void InserirPrivilegios(int codigoFuncionario, int codigoTela, bool podeAcessar)
        {
            string sql = @"INSERT INTO emprestimosbd.funcionario_tela_privilegio
                        (
                         codigo_funcionario,
                         codigo_tela,
                         pode_acessar
                        )
                        VALUES
                        (
                         @codigo_funcionario,
                         @codigo_tela,
                         @pode_acessar
                        )";

            using (var conexa = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexa))
            {
                cmd.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionario);
                cmd.Parameters.AddWithValue("@codigo_tela", codigoTela);
                cmd.Parameters.AddWithValue("@pode_Acessar", podeAcessar);

                // ExecuteNonQuery é usado para comandos que não retornam dados (INSERT, UPDATE, DELETE)
                cmd.ExecuteNonQuery();
            }
        }

        // Método que atualiza um registro de permissão já existente
        public void AtualizarPrivilegios(int codigoFuncionario, int codigoTela, bool podeAcessar)
        {
            string sql = @"UPDATE emprestimosbd.funcionario_tela_privilegio
                        SET
                            pode_acessar = @pode_acessar
                        WHERE codigo_funcionario = @codigo_funcionario
                            AND codigo_tela = @codigo_tela";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionario);
                cmd.Parameters.AddWithValue("@codigo_tela", codigoTela);
                cmd.Parameters.AddWithValue("@pode_acessar", podeAcessar);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

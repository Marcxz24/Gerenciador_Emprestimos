using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Services;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
     public class FuncionarioDAO
     {
        // --- MÉTODO: Realiza a inserção de um novo funcionário no banco ---
        public bool CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            // VALIDAÇÃO DE INTEGRIDADE: Chama o método abaixo para verificar se o CPF já existe
            // Isso evita que o banco gere um erro de chave duplicada ou dados inconsistentes
            if (CpfJaCadastrado(funcionario.Cpf))
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
                        endereco_funcionario,
                        bairro_funcionario,
                        numero_residencia,
                        cep_funcionario,
                        uf_funcionario,
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
                        @endereco_funcionario,
                        @bairro_funcionario,
                        @numero_residencia,
                        @cep_funcionario,
                        @uf_funcionario,
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
                    comando.Parameters.AddWithValue("@nome_funcionario", funcionario.Nome);
                    comando.Parameters.AddWithValue("@cpf_funcionario", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@sexo_funcionario", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", funcionario.EstadoCivil);
                    comando.Parameters.AddWithValue("@username", funcionario.Username);
                    comando.Parameters.AddWithValue("@senha_hash", funcionario.SenhaHash); // Aqui deve entrar o Hash do BCrypt
                    comando.Parameters.AddWithValue("@telefone_funcionario", funcionario.Telefone);
                    comando.Parameters.AddWithValue("@cidade_funcionario", funcionario.Cidade);
                    comando.Parameters.AddWithValue("@endereco_funcionario", funcionario.Endereco);
                    comando.Parameters.AddWithValue("@bairro_funcionario", funcionario.Bairro);
                    comando.Parameters.AddWithValue("@numero_residencia", funcionario.NumeroResidencia);
                    comando.Parameters.AddWithValue("@cep_funcionario", funcionario.Cep);
                    comando.Parameters.AddWithValue("@uf_funcionario", funcionario.Cep);
                    comando.Parameters.AddWithValue("@situacao_funcionario", funcionario.Situacao);
                    comando.Parameters.AddWithValue("@data_cadastro", DateTime.Now); // Registra o momento exato do cadastro

                    // Executa a inserção
                    comando.ExecuteNonQuery();

                    // cmd cria um novo comando de texto, para receber o Código do ultimo cliente adicionado.
                    comando.CommandText = "SELECT @@IDENTITY";

                    funcionario.Codigo = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (MySqlException)
            {
                // Se houver qualquer erro de banco de dados, retorna falso
                return false;
            }

            return true;
        }

        public bool EditarCadastroFuncionario(FuncionarioDTO funcionario)
        {
            string sql = @"
                           UPDATE emprestimosbd.funcionario
                           SET
	                            nome_funcionario = @nome_funcionario,
                                cpf_funcionario = @cpf_funcionario,
                                sexo_funcionario = @sexo_funcionario,
                                funcionario_estado_civil = @funcionario_estado_civil, 
                                username = @username,
                                telefone_funcionario = @telefone_funcionario, 
                                cidade_funcionario = @cidade_funcionario,
                                endereco_funcionario = @endereco_funcionario,
                                bairro_funcionario = @bairro_funcionario,
                                numero_residencia = @numero_residencia,
                                cep_funcionario = @cep_funcionario,
                                uf_funcionario = @uf_funcionario,
                                situacao_funcionario = @situacao_funcionario
                           WHERE codigo = @codigo";

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", funcionario.Codigo);
                    comando.Parameters.AddWithValue("@nome_funcionario", funcionario.Nome);
                    comando.Parameters.AddWithValue("@cpf_funcionario", funcionario.Cpf);
                    comando.Parameters.AddWithValue("@sexo_funcionario", funcionario.Sexo);
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", funcionario.EstadoCivil);
                    comando.Parameters.AddWithValue("@username", funcionario.Username);
                    comando.Parameters.AddWithValue("@telefone_funcionario", funcionario.Telefone);
                    comando.Parameters.AddWithValue("@cidade_funcionario", funcionario.Cidade);
                    comando.Parameters.AddWithValue("@endereco_funcionario", funcionario.Endereco);
                    comando.Parameters.AddWithValue("@bairro_funcionario", funcionario.Bairro);
                    comando.Parameters.AddWithValue("@numero_residencia", funcionario.NumeroResidencia);
                    comando.Parameters.AddWithValue("@cep_funcionario", funcionario.Cep);
                    comando.Parameters.AddWithValue("@uf_funcionario", funcionario.Uf);
                    comando.Parameters.AddWithValue("@situacao_funcionario", funcionario.Situacao);

                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }

            return true;
        }

        public void AtualizarSenhaFuncionario(int codigo, string novaSenhaHash)
        {
            string sql = @"
                           UPDATE emprestimosbd.funcionario
                           SET
                                senha_hash = @senha_hash
                           WHERE codigo = @codigo";
            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Parameters.AddWithValue("@senha_hash", novaSenhaHash);
                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Funcoes.MensagemErro("Erro ao atualizar a senha do funcionário: " + ex.Message);
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

        // --- MÉTODO: Busca um único funcionário pelo ID (Código) ---
        public FuncionarioDTO SelecionarFuncionarioPorCodigo(int CodigoFuncionario)
        {
            string sql = @"SELECT * FROM emprestimosbd.funcionario WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", CodigoFuncionario);

                using (var reader = comando.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    // CORREÇÃO: Instanciando o DTO e usando os nomes corretos das propriedades
                    return new FuncionarioDTO
                    {
                        Codigo = reader.GetInt32("codigo"),
                        Nome = reader.GetString("nome_funcionario"),
                        Cpf = reader.GetString("cpf_funcionario"),
                        Sexo = reader.GetString("sexo_funcionario"),
                        EstadoCivil = reader.GetString("funcionario_estado_civil"),
                        Username = reader.GetString("username"),
                        SenhaHash = reader.GetString("senha_hash"),
                        Telefone = reader.GetString("telefone_funcionario"),
                        Cidade = reader.GetString("cidade_funcionario"),
                        Endereco = reader.GetString("endereco_funcionario"),
                        Bairro = reader.GetString("bairro_funcionario"),
                        NumeroResidencia = reader.GetInt32("numero_residencia"),
                        Cep = reader.GetString("cep_funcionario"),
                        Uf = reader.GetString("uf_funcionario"),
                        Situacao = reader.GetString("situacao_funcionario")
                    };
                }
            }
        }

        // --- MÉTODO: Retorna uma tabela (DataTable) filtrada para exibir no DataGridView ---
        public DataTable ListarFuncionarios(FuncionarioDTO funcionarioDTO)
        {
            // Instancia a tabela que armazenará os resultados na memória
            DataTable dataTable = new DataTable();

            // Consulta SQL base (sem filtros)
            string sql = @"SELECT 
	                            codigo, 
	                            nome_funcionario, 
	                            cpf_funcionario, 
	                            sexo_funcionario, 
	                            funcionario_estado_civil, 
	                            username, 
	                            telefone_funcionario, 
	                            cidade_funcionario, 
                                endereco_funcionario,
                                bairro_funcionario,
                                numero_residencia,
                                uf_funcionario,
	                            situacao_funcionario 
                            FROM emprestimosbd.funcionario";

            // Inicializa a cláusula WHERE. O '1 = 1' serve para facilitar a concatenação de múltiplos 'AND'
            string sqlFiltros = @" WHERE 1 = 1";

            // --- CONSTRUÇÃO DINÂMICA DO SQL ---
            // Verifica cada parâmetro; se contiver valor, adiciona a linha correspondente ao comando SQL
            if (funcionarioDTO.Codigo > 0)
            {
                sqlFiltros += " AND codigo = @codigo";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Nome))
            {
                sqlFiltros += " AND nome_funcionario LIKE @nome_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Cpf))
            {
                sqlFiltros += " AND cpf_funcionario = @cpf_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Sexo))
            {
                sqlFiltros += " AND sexo_funcionario = @sexo_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.EstadoCivil))
            {
                sqlFiltros += " AND funcionario_estado_civil = @funcionario_estado_civil";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Telefone))
            {
                sqlFiltros += " AND telefone_funcionario = @telefone_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Cidade))
            {
                sqlFiltros += " AND cidade_funcionario = @cidade_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(funcionarioDTO.Situacao))
            {
                sqlFiltros += " AND situacao_funcionario = @situacao_funcionario";
            }

            // Junta a base da query com os filtros gerados
            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                // --- ATRIBUIÇÃO DE PARÂMETROS AO COMANDO ---
                // Repete as verificações para garantir que apenas parâmetros necessários sejam enviados ao banco
                if (funcionarioDTO.Codigo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", funcionarioDTO.Codigo);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Nome))
                {
                    // Adiciona os símbolos de porcentagem para busca parcial (LIKE)
                    comando.Parameters.AddWithValue("@nome_funcionario", "%" + funcionarioDTO.Nome + "%");
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Cpf))
                {
                    comando.Parameters.AddWithValue("@cpf_funcionario", funcionarioDTO.Cpf);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Sexo))
                {
                    comando.Parameters.AddWithValue("@sexo_funcionario", funcionarioDTO.Sexo);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.EstadoCivil))
                {
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", funcionarioDTO.EstadoCivil);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Telefone))
                {
                    comando.Parameters.AddWithValue("@telefone_funcionario", funcionarioDTO.Telefone);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Cidade))
                {
                    comando.Parameters.AddWithValue("@cidade_funcionario", funcionarioDTO.Cidade);
                }

                if (!string.IsNullOrWhiteSpace(funcionarioDTO.Situacao))
                {
                    comando.Parameters.AddWithValue("@situacao_funcionario", funcionarioDTO.Situacao);
                }

                // O DataAdapter executa o comando e preenche o DataTable de uma só vez
                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }

            // Retorna o objeto DataTable pronto para ser usado como DataSource do Grid
            return dataTable;
        }
     }
}
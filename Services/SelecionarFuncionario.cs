using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gerenciador_de_Emprestimos.Services
{
    // Define a classe que representa tanto o modelo do Funcionário quanto os métodos de busca
    public class SelecionarFuncionario
    {
        // --- PROPRIEDADES: Mapeiam as colunas da tabela 'funcionario' do banco de dados ---
        public int CodigoFuncionario { get; set; }
        public string nome_funcionario { get; set; }
        public string cpf_funcionario { get; set; }
        public string sexo_funcionario { get; set; }
        public string funcionario_estado_civil { get; set; }
        public string username { get; set; }
        public string senha_hash { get; set; }
        public string telefone_funcionario { get; set; }
        public string cidade_funcionario { get; set; }
        public string situacao_funcionario { get; set; }

        // --- MÉTODO: Busca um único funcionário pelo ID (Código) ---
        public SelecionarFuncionario SelecionarFuncionarioPorCodigo(int CodigoFuncionario)
        {
            // Define a consulta SQL para buscar todas as colunas de um registro específico
            string sql = @"SELECT * FROM emprestimosbd.funcionario WHERE codigo = @codigo";

            // Gerencia a abertura da conexão e do comando com 'using' para liberar recursos automaticamente
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                // Vincula o parâmetro @codigo ao valor recebido para prevenir SQL Injection
                comando.Parameters.AddWithValue("@codigo", CodigoFuncionario);

                // Executa o leitor de dados (DataReader)
                using (var reader = comando.ExecuteReader())
                {
                    // Se o banco não encontrar nenhum registro, retorna nulo
                    if (!reader.Read())
                    {
                        return null;
                    }

                    // Cria uma nova instância da classe e preenche as propriedades com os dados do banco
                    return new SelecionarFuncionario
                    {
                        CodigoFuncionario = reader.GetInt32("codigo"),
                        nome_funcionario = reader.GetString("nome_funcionario"),
                        cpf_funcionario = reader.GetString("cpf_funcionario"),
                        sexo_funcionario = reader.GetString("sexo_funcionario"),
                        funcionario_estado_civil = reader.GetString("funcionario_estado_civil"),
                        username = reader.GetString("username"),
                        senha_hash = reader.GetString("senha_hash"),
                        telefone_funcionario = reader.GetString("telefone_funcionario"),
                        cidade_funcionario = reader.GetString("cidade_funcionario"),
                        situacao_funcionario = reader.GetString("situacao_funcionario"),
                    };
                }
            }
        }

        // --- MÉTODO: Retorna uma tabela (DataTable) filtrada para exibir no DataGridView ---
        public DataTable ListarFuncionarios(int Codigo, string nomeFuncionario, string cpf, string sexo, string estadoCivil, string telefoneFuncionario, string cidadeFuncionario, string situacaoFuncionario)
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
                            situacao_funcionario 
                        FROM emprestimosbd.funcionario";

            // Inicializa a cláusula WHERE. O '1 = 1' serve para facilitar a concatenação de múltiplos 'AND'
            string sqlFiltros = @" WHERE 1 = 1";

            // --- CONSTRUÇÃO DINÂMICA DO SQL ---
            // Verifica cada parâmetro; se contiver valor, adiciona a linha correspondente ao comando SQL
            if (Codigo > 0)
            {
                sqlFiltros += " AND codigo = @codigo";
            }

            if (!string.IsNullOrWhiteSpace(nomeFuncionario))
            {
                sqlFiltros += " AND nome_funcionario LIKE @nome_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                sqlFiltros += " AND cpf_funcionario = @cpf_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(sexo))
            {
                sqlFiltros += " AND sexo_funcionario = @sexo_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(estadoCivil))
            {
                sqlFiltros += " AND funcionario_estado_civil = @funcionario_estado_civil";
            }

            if (!string.IsNullOrWhiteSpace(telefoneFuncionario))
            {
                sqlFiltros += " AND telefone_funcionario = @telefone_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(cidadeFuncionario))
            {
                sqlFiltros += " AND cidade_funcionario = @cidade_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(situacaoFuncionario))
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
                if (Codigo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", Codigo);
                }

                if (!string.IsNullOrWhiteSpace(nomeFuncionario))
                {
                    // Adiciona os símbolos de porcentagem para busca parcial (LIKE)
                    comando.Parameters.AddWithValue("@nome_funcionario", "%" + nomeFuncionario + "%");
                }

                if (!string.IsNullOrWhiteSpace(cpf))
                {
                    comando.Parameters.AddWithValue("@cpf_funcionario", cpf);
                }

                if (!string.IsNullOrWhiteSpace(sexo))
                {
                    comando.Parameters.AddWithValue("@sexo_funcionario", sexo);
                }

                if (!string.IsNullOrWhiteSpace(estadoCivil))
                {
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", estadoCivil);
                }

                if (!string.IsNullOrWhiteSpace(telefoneFuncionario))
                {
                    comando.Parameters.AddWithValue("@telefone_funcionario", telefoneFuncionario);
                }

                if (!string.IsNullOrWhiteSpace(cidadeFuncionario))
                {
                    comando.Parameters.AddWithValue("@cidade_funcionario", cidadeFuncionario);
                }

                if (!string.IsNullOrWhiteSpace(situacaoFuncionario))
                {
                    comando.Parameters.AddWithValue("@situacao_funcionario", situacaoFuncionario);
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

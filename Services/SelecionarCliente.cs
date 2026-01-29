using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Gerenciador_de_Emprestimos.Services
{
    public class SelecionarCliente
    {
        // --- PROPRIEDADES: Representam as colunas da tabela 'cliente' no banco de dados ---
        public int codigo { get; set; }
        public string nome_cliente { get; set; }
        public string cpf_cnpj { get; set; }
        public string genero { get; set; }
        public string estado_civil { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int? numero_residencia { get; set; }
        public string cep { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string observacoes { get; set; }
        public string situacao_cadastral { get; set; }
        public DateTime data_cadastro { get; set; }
        // Imagens futuramente (Lembrete para expansão do código)

        // --- MÉTODO ESTÁTICO: Obtém uma lista geral de clientes para preencher o DataGrid ---
        public static DataTable GetClientes(bool ATIVOS)
        {
            var dataTable = new DataTable();

            // Query que seleciona apenas as colunas principais para visualização rápida na grade
            var sql = "SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj FROM emprestimosbd.cliente;";

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                {
                    conexao.Open(); // Abre a conexão com o banco
                    using (var data = new MySqlDataAdapter(sql, conexao))
                    {
                        data.Fill(dataTable); // Preenche a tabela com os dados do SELECT
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra falha na conexão ou na query
                MessageBox.Show("Problema execução de Query SELECT no campo dataGrid", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        // --- MÉTODO: Consulta os dados de um cliente específico e retorna em formato de DataTable ---
        public DataTable ConsultarClientePorCodigo(int CodigoCliente)
        {
            DataTable dataTable = new DataTable();

            var sqlConsulta = @"SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlConsulta, conexao))
            {
                // Verifica se o código é válido antes de tentar a busca
                if (CodigoCliente > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", CodigoCliente);

                    using (var data = new MySqlDataAdapter(comando))
                    {
                        data.Fill(dataTable); // Preenche o DataTable com todas as colunas do cliente
                    }
                }
            }

            return dataTable;
        }

        // --- MÉTODO: Busca os dados de um cliente e retorna um Objeto da própria classe 'SelecionarCliente' ---
        public SelecionarCliente BuscarClientePorCodigo(int codigoCliente)
        {
            var sql = @"SELECT 
                            codigo, 
                            nome_cliente, 
                            cpf_cnpj, 
                            genero, 
                            estado_civil, 
                            endereco, 
                            bairro, 
                            cidade, 
                            uf, 
                            numero_residencia, 
                            cep, 
                            celular, 
                            email, 
                            observacoes, 
                            situacao_cadastral, 
                            imagem, 
                            data_cadastro 
                        FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("codigo", codigoCliente);

                using (var reader = comando.ExecuteReader())
                {
                    // Se encontrar o registro, lê os dados e mapeia para as propriedades do objeto
                    if (reader.Read())
                    {
                        return new SelecionarCliente
                        {
                            codigo = reader.GetInt32("codigo"),
                            nome_cliente = reader.GetString("nome_cliente"),
                            cpf_cnpj = reader.GetString("cpf_cnpj"),
                            genero = reader.GetString("genero"),
                            estado_civil = reader.GetString("estado_civil"),
                            endereco = reader.GetString("endereco"),
                            bairro = reader.GetString("bairro"),
                            cidade = reader.GetString("cidade"),
                            uf = reader.GetString("uf"),
                            numero_residencia = reader.GetInt32("numero_residencia"),
                            cep = reader.GetString("cep"),
                            celular = reader.GetString("celular"),
                            email = reader.GetString("email"),
                            observacoes = reader.GetString("observacoes"),
                            situacao_cadastral = reader.GetString("situacao_cadastral"),
                            data_cadastro = reader.GetDateTime("data_cadastro")
                        };
                    }
                }
            }

            // Retorna null se nenhum cliente for encontrado com o código fornecido
            return null;
        }
    }
}
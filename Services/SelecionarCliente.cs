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

        // Método para listar os cliente no dataGrid.
        public DataTable ListarClientes()
        {
            // Cria um DataTable para armazenar os resultados da consulta
            DataTable dt = new DataTable();

            // Query SQL para selecionar todos os campos da tabela 'cliente'
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
                        FROM emprestimosbd.cliente";

            // Executa a consulta e preenche o DataTable
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("codigo", codigo);
                comando.Parameters.AddWithValue("nome_cliente", nome_cliente);
                comando.Parameters.AddWithValue("cpf_cnpj", cpf_cnpj);
                comando.Parameters.AddWithValue("genero", genero);
                comando.Parameters.AddWithValue("estado_civil", estado_civil);
                comando.Parameters.AddWithValue("endereco", endereco);
                comando.Parameters.AddWithValue("bairro", bairro);
                comando.Parameters.AddWithValue("cidade", cidade);
                comando.Parameters.AddWithValue("uf", uf);
                comando.Parameters.AddWithValue("numero_residencia", numero_residencia);
                comando.Parameters.AddWithValue("cep", cep);
                comando.Parameters.AddWithValue("celular", celular);
                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("observacoes", observacoes);
                comando.Parameters.AddWithValue("situacao_cadastral", situacao_cadastral);
                comando.Parameters.AddWithValue("data_cadastro", data_cadastro);

                // Usa MySqlDataAdapter para preencher o DataTable com os resultados da consulta
                using (var data = new MySqlDataAdapter(comando))
                {
                    data.Fill(dt); // Preenche o DataTable com os dados do SELECT
                }
            }

            // Retorna o DataTable preenchido
            return dt;
        }
    }
}
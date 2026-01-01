using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Gerenciador_de_Emprestimos
{
    public class SelecionarCliente
    {
        public int codigo { get; set; }
        public string nome_cliente { get; set; }
        public string cpf_cnpj { get; set; }
        public string genero { get; set; }
        public string estado_civil { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int numero_residencia { get; set; }
        public string cep { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string observacoes { get; set; }
        public string situacao_cadastral { get; set; }
        // Imagens futuramente

        public static DataTable GetClientes(bool ATIVOS)
        {
            var dataTable = new DataTable();

            var sql = "SELECT codigo, nome_cliente, genero, celular, situacao_cadastral, cpf_cnpj FROM emprestimosbd.cliente;";

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                {
                    conexao.Open();
                    using (var data = new MySqlDataAdapter(sql, conexao))
                    {
                        data.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema execução de Query SELECT no campo dataGrid", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public DataTable ConsultarClientePorCodigo(int CodigoCliente)
        {
            DataTable dataTable = new DataTable();

            var sqlConsulta = @"SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlConsulta, conexao))
            {
                if (CodigoCliente > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", CodigoCliente);

                    using (var data = new MySqlDataAdapter(comando))
                    {
                        data.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public SelecionarCliente BuscarClientePorCodigo(int codigoCliente)
        {
            var sql = @"SELECT * FROM emprestimosbd.cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("codigo", codigoCliente);

                using (var reader = comando.ExecuteReader())
                {
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
                        };
                    }
                }
            }

            return null;
        }
    }
}

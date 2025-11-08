using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gerenciador_de_Emprestimos
{
    class SelecionarCliente
    {
        public int codigo { get; set; }
        public string nome_cliente { get; set; }
        public string genero { get; set; }
        public string celular { get; set; }
        public string situacao_cadastral { get; set; }
        public string cpf_cnpj {  get; set; }

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
    }
}

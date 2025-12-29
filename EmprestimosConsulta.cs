using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class EmprestimosConsulta
    {
        public DataTable ConsultaEmprestimos(int? CodigoCliente, string NomeCliente, string StatusEmprestimo, decimal ValorEmprestado, decimal ValorParcela, decimal ValorJurosMonetario, int? QtnParcela, decimal ValorTotal)
        {
            DataTable dataTable = new DataTable();

            string sql = $@"SELECT e.codigo, c.nome_cliente, e.codigo_cliente, e.valor_emprestado, e.valor_emprestado_total, e.quantidade_parcela, e.valor_parcela, e.valor_juros, e.status_emprestimo 
                            FROM emprestimosbd.emprestimos e LEFT JOIN emprestimosbd.cliente c ON e.codigo_cliente = c.codigo";

            string sqlFiltros = " WHERE 1 = 1";

            if (CodigoCliente.HasValue)
            {
                sqlFiltros += " AND e.codigo_cliente = @codigo_cliente";
            }

            if (!string.IsNullOrWhiteSpace(NomeCliente))
            {
                sqlFiltros += " AND c.nome_cliente LIKE @nome_cliente";
            }

            if (!string.IsNullOrWhiteSpace(StatusEmprestimo))
            {
                sqlFiltros += " AND e.status_emprestimo = @status_emprestimo";
            }

            if (ValorEmprestado > 0)
            {
                sqlFiltros += " AND e.valor_emprestado = @valor_emprestado";
            }

            if (ValorParcela > 0)
            {
                sqlFiltros += " AND e.valor_parcela = @valor_parcela";
            }

            if (ValorJurosMonetario > 0)
            {
                sqlFiltros += " AND e.valor_juros = @valor_juros";
            }

            if (QtnParcela > 0)
            {
                sqlFiltros += " AND e.quantidade_parcela = @quantidade_parcela";
            }

            if (ValorTotal > 0)
            {
                sqlFiltros += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                }

                if (!string.IsNullOrEmpty(NomeCliente))
                {
                    comando.Parameters.AddWithValue("@nome_cliente", NomeCliente);
                }

                if (!string.IsNullOrWhiteSpace(StatusEmprestimo))
                {
                    comando.Parameters.AddWithValue("@status_emprestimo", StatusEmprestimo);
                }

                if (ValorEmprestado > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado", ValorEmprestado);
                }

                if (ValorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                }

                if (ValorJurosMonetario > 0)
                {
                    comando.Parameters.AddWithValue("@valor_juros", ValorJurosMonetario);
                }

                if (QtnParcela.HasValue && QtnParcela > 0)
                {
                    comando.Parameters.AddWithValue("@quantidade_parcela", QtnParcela);
                }

                if (ValorTotal > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", ValorTotal);
                }

                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}

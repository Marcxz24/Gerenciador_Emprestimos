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
        public DataTable ConsultaEmprestimos(int? CodigoCliente, string StatusEmprestimo, decimal ValorEmprestado, decimal ValorParcela, decimal ValorJurosMonetario, int? QtnParcela, decimal ValorTotal)
        {
            DataTable dataTable = new DataTable();

            string sql = $@"SELECT codigo, codigo_cliente, valor_emprestado, valor_emprestado_total, quantidade_parcela, valor_parcela, valor_juros, status_emprestimo FROM emprestimosbd.emprestimos";

            string sqlFiltros = " WHERE 1 = 1";

            if (CodigoCliente.HasValue)
            {
                sqlFiltros += " AND codigo_cliente = @codigo_cliente";
            }

            if (!string.IsNullOrWhiteSpace(StatusEmprestimo))
            {
                sqlFiltros += " AND status_emprestimo = @status_emprestimo";
            }

            if (ValorEmprestado > 0)
            {
                sqlFiltros += " AND valor_emprestado = @valor_emprestado";
            }

            if (ValorParcela > 0)
            {
                sqlFiltros += " AND valor_parcela = @valor_parcela";
            }

            if (ValorJurosMonetario > 0)
            {
                sqlFiltros += " AND valor_juros = @valor_juros";
            }

            if (QtnParcela > 0)
            {
                sqlFiltros += " AND quantidade_parcela = @quantidade_parcela";
            }

            if (ValorTotal > 0)
            {
                sqlFiltros += " AND valor_emprestado_total = @valor_emprestado_total";
            }

            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
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

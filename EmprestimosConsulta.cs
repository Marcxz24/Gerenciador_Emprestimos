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
        // --- MÉTODO: Consulta flexível com múltiplos filtros ---
        public DataTable ConsultaEmprestimos(int? CodigoCliente, string NomeCliente, string StatusEmprestimo, decimal ValorEmprestado, decimal ValorParcela, decimal ValorJurosMonetario, int? QtnParcela, decimal ValorTotal)
        {
            DataTable dataTable = new DataTable();

            // SQL Base: Busca dados do empréstimo e faz um JOIN para trazer o nome do cliente
            string sql = $@"SELECT e.codigo, e.codigo_cliente, c.nome_cliente, e.valor_emprestado, e.valor_emprestado_total AS valor_total, e.quantidade_parcela, e.valor_parcela, e.valor_juros, e.status_emprestimo 
                        FROM emprestimosbd.emprestimos e LEFT JOIN emprestimosbd.cliente c ON e.codigo_cliente = c.codigo";

            // Técnica "WHERE 1 = 1": Facilita a concatenação de filtros adicionais com "AND"
            string sqlFiltros = " WHERE 1 = 1";

            // Verificações condicionais: Se o parâmetro foi preenchido, adiciona a restrição no SQL
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

            // Monta a Query final
            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                // Vinculação de parâmetros (Parameters.AddWithValue) para prevenir SQL Injection
                // Repete as mesmas condições acima para alimentar os valores dos parâmetros
                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                }

                if (!string.IsNullOrEmpty(NomeCliente))
                {
                    // Dica: Se quiser busca parcial, use NomeCliente + "%" aqui
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

                // O DataAdapter preenche o DataTable de uma só vez para ser usado no DataGridView
                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // --- MÉTODO: Consulta específica para um único empréstimo ---
        public DataTable ConsultaEmprestimosPorCodigo(int codigoEmprestimo)
        {
            DataTable dataTable = new DataTable();

            string sqlCodigo = @"SELECT * FROM emprestimosbd.emprestimos WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlCodigo, conexao))
            {
                if (codigoEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", codigoEmprestimo);

                    using (var data = new MySqlDataAdapter(comando))
                    {
                        data.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}

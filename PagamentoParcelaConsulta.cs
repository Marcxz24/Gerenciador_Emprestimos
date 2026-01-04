using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class PagamentoParcelaConsulta
    {
        public DataTable ConsultaClienteEmprestimo(int? codigoCliente, int? codigoEmprestimo, decimal valorJuros, decimal valorTotal, decimal valorParcela)
        {
            DataTable dataTable = new DataTable();

            string sql = @"
                         SELECT
                            c.codigo AS codigo_cliente,
                            c.nome_cliente,
                            e.codigo AS codigo_emprestimo,
                            e.valor_emprestado_total AS valor_contrato,
                            p.codigo AS codigo_parcela,
                            e.valor_juros,
                            p.numero_parcela,
                            p.valor_parcela,
                            p.valor_pago,
                            p.status_parcela,
                            p.data_vencimento
                        FROM cliente c
                        INNER JOIN emprestimos e
                            ON c.codigo = e.codigo_cliente
                        INNER JOIN conta_receber p
                            ON e.codigo = p.codigo_emprestimo
            ";

            string? filtro = @"
                                WHERE 1 = 1
                                AND p.status_parcela = 'ABERTA'
                                ";

            if (codigoCliente > 0)
            {
                filtro += " AND c.codigo = @codigo_cliente";
            }

            if (codigoEmprestimo > 0)
            {
                filtro += " AND e.codigo = @codigo_emprestimo";
            }

            if (valorJuros > 0)
            {
                filtro += " AND e.valor_juros = @valor_juros";
            }

            if (valorTotal > 0)
            {
                filtro += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            if (valorParcela > 0)
            {
                filtro += " AND p.valor_parcela = @valor_parcela";
            }

            string sqlFinal = sql + filtro;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                if (codigoCliente > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", codigoCliente);
                }

                if (codigoEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                }

                if (valorJuros > 0)
                {
                    comando.Parameters.AddWithValue("@valor_juros", valorJuros);
                }

                if (valorTotal > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", valorTotal);
                }

                if (valorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", valorParcela);
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

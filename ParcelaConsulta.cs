using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class ParcelaConsulta
    {
        public DataTable ConsultaParcela(int? CodigoEmprestimo, int? CodigoCliente, string NomeCliente, string StatusParcela, decimal ValorParcela, int? NumeroParcela)
        {
            DataTable consultaDataTable = new DataTable();

            string SqlConsulta = "SELECT p.codigo as codigo_parcela, p.codigo_emprestimo, p.codigo_cliente, c.nome_cliente, e.valor_emprestado_total as valor_total, p.valor_parcela, p.numero_parcela, p.valor_pago, p.data_pagamento, p.data_vencimento, p.status_parcela FROM emprestimosbd.conta_receber p LEFT JOIN emprestimosbd.cliente c ON p.codigo_cliente = c.codigo LEFT JOIN emprestimosbd.emprestimos e ON p.codigo_emprestimo = e.codigo";

            string SqlFiltros = " WHERE 1 = 1";

            if (CodigoEmprestimo.HasValue)
            {
                SqlFiltros += " AND p.codigo_emprestimo = @codigo_emprestimo";
            }

            if (CodigoCliente.HasValue)
            {
                SqlFiltros += " AND p.codigo_cliente = @codigo_cliente";
            }

            if (!string.IsNullOrWhiteSpace(NomeCliente))
            {
                SqlFiltros += " AND c.nome_cliente LIKE %@nome_cliente%";
            }

            if (!string.IsNullOrWhiteSpace(StatusParcela))
            {
                SqlFiltros += " AND p.status_parcela LIKE @status_parcela";
            }

            if (NumeroParcela > 0)
            {
                SqlFiltros += " AND p.numero_parcela = @numero_parcela";
            }

            if (ValorParcela > 0)
            {
                SqlFiltros += " AND p.valor_parcela = @valor_parcela";
            }

            string sqlConsultaFinal = SqlConsulta + SqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlConsultaFinal, conexao))
            {
                if (CodigoEmprestimo.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", CodigoEmprestimo);
                }

                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                }

                if (!string.IsNullOrEmpty(NomeCliente))
                {
                    comando.Parameters.AddWithValue("@nome_cliente", NomeCliente);
                }

                if (!string.IsNullOrWhiteSpace(StatusParcela))
                {
                    comando.Parameters.AddWithValue("@status_parcela", StatusParcela);
                }

                if (NumeroParcela > 0)
                {
                    comando.Parameters.AddWithValue("@numero_parcela", NumeroParcela);
                }

                if (ValorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                }

                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(consultaDataTable);
                }
            }
            
            return consultaDataTable;
        }
    }
}

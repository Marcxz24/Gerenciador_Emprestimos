using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class EmprestimoDAO
    {
        public ParcelaDTO BuscarMenorParcelaAberta(int codigoEmprestimo)
        {
            ParcelaDTO parcelaEncontrada = null;

            // Query que você validou, buscando a primeira aberta
            string sql = @"SELECT p.*, e.valor_juros, c.nome_cliente, e.valor_emprestado_total FROM conta_receber p
                            INNER JOIN emprestimos e
	                            ON e.codigo = p.codigo_emprestimo
                            INNER JOIN cliente c
	                            ON p.codigo_cliente = c.codigo
	                            WHERE codigo_emprestimo = 2
	                            AND status_parcela = 'ABERTA' 
		                            ORDER BY numero_parcela ASC LIMIT 1";

            using (var conn = ConexaoBancoDeDados.Conectar()) // Usa sua classe de conexão
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        parcelaEncontrada = new ParcelaDTO
                        {
                            CodigoParcela = dr.GetInt32("codigo"),
                            CodigoEmprestimo = dr.GetInt32("codigo_emprestimo"),
                            CodigoCliente = dr.GetInt32("codigo_cliente"),
                            NomeCliente = dr.GetString("nome_cliente"),
                            NumeroParcela = dr.GetInt32("numero_parcela"),
                            ValorParcela = dr.GetDecimal("valor_parcela"),
                            ValorEmprestimo = dr.GetDecimal("valor_emprestado_total"),
                            ValorJuros = dr.GetDecimal("valor_juros"),
                            DataVencimento = dr.GetDateTime("data_vencimento"),
                            StatusParcela = dr.GetString("status_parcela")
                        };
                    }
                }
            }
            return parcelaEncontrada;
        }
    }
}

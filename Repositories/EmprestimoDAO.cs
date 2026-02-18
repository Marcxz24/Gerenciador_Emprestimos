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
        // Método para buscar a menor parcela aberta de um empréstimo específico
        public ParcelaDTO BuscarMenorParcelaAberta(int codigoEmprestimo)
        {
            // Inicializa a variável para armazenar a parcela encontrada, inicialmente nula
            ParcelaDTO parcelaEncontrada = null;

            // Consulta SQL para selecionar a menor parcela aberta do empréstimo, incluindo os dados do cliente e do empréstimo
            string sql = @"SELECT p.*, e.valor_juros, c.nome_cliente, e.valor_emprestado_total FROM conta_receber p
                            INNER JOIN emprestimos e
	                            ON e.codigo = p.codigo_emprestimo
                            INNER JOIN cliente c
	                            ON p.codigo_cliente = c.codigo
	                            WHERE codigo_emprestimo = 2
	                            AND status_parcela = 'ABERTA' 
		                            ORDER BY numero_parcela ASC LIMIT 1";

            // Estabelece a conexão com o banco de dados e executa a consulta
            using (var conn = ConexaoBancoDeDados.Conectar())
            // Cria um comando SQL para buscar a menor parcela aberta do empréstimo
            using (var cmd = new MySqlCommand(sql, conn))
            {
                // Adiciona o parâmetro do código do empréstimo para a consulta SQL
                cmd.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);

                // Executa a leitura dos dados de forma sequencial
                using (var dr = cmd.ExecuteReader())
                {
                    // Se o banco encontrar um registro, preenche a instância de ParcelaDTO com os dados retornados
                    if (dr.Read())
                    {
                        // Cria uma nova instância de ParcelaDTO e preenche suas propriedades com os dados do banco
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

            // Retorna a parcela encontrada, ou nulo se nenhuma parcela aberta for encontrada para o empréstimo especificado
            return parcelaEncontrada;
        }
    }
}

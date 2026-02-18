using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    public class ListarEmprestimoService
    {
        public List<EmprestimosListaDTO> ListarEmprestimos()
        {
            var lista = new List<EmprestimosListaDTO>();

            string sql = @"SELECT 
	                            e.codigo, 
                                c.codigo, 
                                c.nome_cliente, 
                                e.valor_emprestado_total, 
                                e.percentual_juros, 
                                e.data_pagar,
                                e.observacoes,
                                e.status_emprestimo 
                            FROM emprestimosbd.emprestimos e
	                            INNER JOIN emprestimosbd.cliente c
		                        ON e.codigo_cliente = c.codigo
                                    WHERE status_emprestimo = 'ATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            using (var dataRead = cmd.ExecuteReader())
            {
                while (dataRead.Read())
                {
                    lista.Add(new EmprestimosListaDTO
                    {
                        CodigoEmprestimo = dataRead.GetInt32(0),
                        CodigoCliente = dataRead.GetInt32(1),
                        NomeCliente = dataRead.GetString(2),
                        ValorTotal = dataRead.GetDecimal(3),
                        Juros = dataRead.GetDecimal(4),
                        DataPagamento = dataRead.GetDateTime(5),
                        Observacoes = dataRead.IsDBNull(6) ? string.Empty : dataRead.GetString(6),
                        Status = dataRead.GetString(7)
                    });
                }
            }

            return lista;
        }
    }
}

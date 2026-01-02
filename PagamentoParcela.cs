using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class PagamentoParcela
    {
        public bool ExisteParcelaAnteriorAberta(int codigoEmprestimo, int numeroParcela)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber WHERE codigo_emprestimo = @codigo_emprestimo AND numero_parcela < @numero_parcela AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                comando.Parameters.AddWithValue("@numero_parcela", numeroParcela);

                int quantidade = Convert.ToInt32(comando.ExecuteScalar());

                return quantidade > 0;
            }
        }

        public void RealizarPagamento(int codigoParcela, decimal valorPago)
        {
            string sql = @"
                          UPDATE emprestimosbd.conta_receber
                          SET
	                        valor_pago = @valor_pago,
                            data_pagamento = now(),
                            status_parcela = 'PAGA'
                          WHERE codigo = @codigo
                            ";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);

                comando.Parameters.AddWithValue("@valor_pago", valorPago);

                comando.ExecuteNonQuery();
            }
        }
    }
}

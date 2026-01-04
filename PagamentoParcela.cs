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
        public int codigoEmprestimo { get; set; }

        // Método parcela já paga, vai no banco de dados, lê os status e retorna true se a parcela já estiver PAGA.
        private bool ParcelaJaPaga(int codigoParcela)
        {
            string sql = @"
                      SELECT status_parcela FROM emprestimosbd.conta_receber
                      WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);

                string statusParcela = comando.ExecuteScalar()?.ToString();

                return statusParcela == "PAGA";
            }
        }

        // Método que obtem o quanto já foi pago, serve para o pagamento parcial.
        private decimal ObterValorPago(int codigoParcela)
        {
            string sql = @"SELECT IFNULL(valor_pago, 0)
                           FROM emprestimosbd.conta_receber
                           WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);

                return Convert.ToDecimal(comando.ExecuteScalar());
            }
        }

        // Método que atualiza o pagamento (Realiza um UPDATE no Banco de Dados).
        private void AtualizarPagamento(int codigoParcela, int codigoEmprestimo,decimal valorPagoTotal, decimal valorParcela)
        {
            if (valorPagoTotal < valorParcela)
            {
                string sql = @"
                        UPDATE emprestimosbd.conta_receber
                        SET
                            valor_pago = @valor_pago,
                            data_ultimo_pagamento = NOW(),
                            status_parcela = 'ABERTA'
                        WHERE codigo = @codigo";

                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigoParcela);
                    comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);

                    comando.ExecuteNonQuery();
                }
            }
            else
            {
                string sql = @"
                        UPDATE emprestimosbd.conta_receber
                        SET
                            valor_pago = @valor_pago,
                            data_ultimo_pagamento = NOW(),
                            data_pagamento = NOW(),
                            status_parcela = 'PAGA'
                        WHERE codigo = @codigo";

                EmprestimosCliente emprestimo = new EmprestimosCliente();

                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigoParcela);
                    comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        throw new("Esta parcela já foi quitada.");
                    }

                    if (!ExisteParcelaAberta(codigoEmprestimo))
                    {
                        emprestimo.QuitarEmprestimo(codigoEmprestimo);
                    }
                }
            }
        }

        // Método que irá ser chamado no formulário.
        public bool RealizarPagamento(int codigoParcela, int codigoEmprestimo, int numeroParcela, decimal valorInformado, decimal valorParcela, out string mensagem)
        {
            mensagem = "";

            if (ParcelaJaPaga(codigoParcela))
            {
                mensagem = "Esta parcela já foi Paga";
                return false;
            }

            if (ExisteParcelaAnteriorAberta(codigoEmprestimo, numeroParcela))
            {
                mensagem = "Existem parcelas anteriores em aberto. Efetue o pagamento das parcelas anteriores antes de pagar esta parcela.";
                return false;
            }

            decimal valorPagoAtual = ObterValorPago(codigoParcela);
            decimal novoTotal = valorPagoAtual + valorInformado;

            if (novoTotal > valorParcela)
            {
                mensagem = "O valor informado não pode ser maior que o valor da parcela.";
                return false;
            }

            AtualizarPagamento(codigoParcela, codigoEmprestimo, novoTotal, valorParcela);

            return true;
        }

        // Método que verifica se existe parcela aberta para o empréstimo.
        private bool ExisteParcelaAberta(int codigoEmprestimo)
        {
            string sql = @"
                        SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                        WHERE codigo_emprestimo = @codigo_emprestimo
                        AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);

                int qtnParcelaAberta = Convert.ToInt32(comando.ExecuteScalar());

                return qtnParcelaAberta > 0;
            }
        }

        // Método que verifica se existe parcela anterior aberta para o empréstimo.
        private bool ExisteParcelaAnteriorAberta(int codigoEmprestimo, int numeroParcela)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                           WHERE codigo_emprestimo = @codigo_emprestimo 
                           AND numero_parcela < @numero_parcela 
                           AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                comando.Parameters.AddWithValue("@numero_parcela", numeroParcela);

                int quantidade = Convert.ToInt32(comando.ExecuteScalar());

                return quantidade > 0;
            }
        }
    }
}

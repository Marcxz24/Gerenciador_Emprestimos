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

        // --- MÉTODOS DE APOIO (PRIVADOS) ---

        // Verifica no banco se a parcela já possui o status 'PAGA' para evitar pagamentos duplicados
        private bool ParcelaJaPaga(int codigoParcela)
        {
            string sql = @"SELECT status_parcela FROM emprestimosbd.conta_receber WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                // ExecuteScalar retorna apenas o valor da primeira coluna (status_parcela)
                string statusParcela = comando.ExecuteScalar()?.ToString();
                return statusParcela == "PAGA";
            }
        }

        // Busca o valor acumulado já pago anteriormente na parcela (útil para pagamentos parciais)
        private decimal ObterValorPago(int codigoParcela)
        {
            // IFNULL garante que se o campo for NULL no banco, retorne 0
            string sql = @"SELECT IFNULL(valor_pago, 0) FROM emprestimosbd.conta_receber WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                return Convert.ToDecimal(comando.ExecuteScalar());
            }
        }

        // Executa a atualização dos dados da parcela no banco de dados
        private void AtualizarPagamento(int codigoParcela, int codigoEmprestimo, decimal valorPagoTotal, decimal valorParcela)
        {
            // CASO 1: Pagamento Parcial (Valor pago acumulado ainda é menor que o valor total da parcela)
            if (valorPagoTotal < valorParcela)
            {
                string sql = @"UPDATE emprestimosbd.conta_receber SET valor_pago = @valor_pago, 
                           data_ultimo_pagamento = NOW(), status_parcela = 'ABERTA' WHERE codigo = @codigo";

                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigoParcela);
                    comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);
                    comando.ExecuteNonQuery();
                }
            }
            // CASO 2: Pagamento Total / Quitação da Parcela
            else
            {
                string sql = @"UPDATE emprestimosbd.conta_receber SET valor_pago = @valor_pago, 
                           data_ultimo_pagamento = NOW(), data_pagamento = NOW(), 
                           status_parcela = 'PAGA' WHERE codigo = @codigo";

                EmprestimosCliente emprestimo = new EmprestimosCliente();

                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigoParcela);
                    comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);

                    int linhasAfetadas = comando.ExecuteNonQuery();

                    if (linhasAfetadas == 0) throw new("Esta parcela já foi quitada.");

                    // REGRA DE OURO: Se não existem mais parcelas abertas, quita o empréstimo inteiro automaticamente
                    if (!ExisteParcelaAberta(codigoEmprestimo))
                    {
                        emprestimo.QuitarEmprestimo(codigoEmprestimo);
                    }
                }
            }
        }

        // --- MÉTODO PRINCIPAL (CHAMADO PELO FORMULÁRIO) ---
        public bool RealizarPagamento(int codigoParcela, int codigoEmprestimo, int numeroParcela, decimal valorInformado, decimal valorParcela, out string mensagem)
        {
            mensagem = "";

            // Validação 1: Parcela já quitada
            if (ParcelaJaPaga(codigoParcela))
            {
                mensagem = "Esta parcela já foi Paga";
                return false;
            }

            // Validação 2: Bloqueia pular parcelas (Ex: pagar a 3ª sem ter pago a 2ª)
            if (ExisteParcelaAnteriorAberta(codigoEmprestimo, numeroParcela))
            {
                mensagem = "Existem parcelas anteriores em aberto. Efetue o pagamento das parcelas anteriores antes de pagar esta parcela.";
                return false;
            }

            // Cálculo para permitir amortização parcial
            decimal valorPagoAtual = ObterValorPago(codigoParcela);
            decimal novoTotal = valorPagoAtual + valorInformado;

            // Validação 3: Evita pagar mais do que o valor da parcela
            if (novoTotal > valorParcela)
            {
                mensagem = "O valor informado não pode ser maior que o valor da parcela.";
                return false;
            }

            // Se passar por todas as validações, realiza o UPDATE
            AtualizarPagamento(codigoParcela, codigoEmprestimo, novoTotal, valorParcela);
            return true;
        }

        // Verifica se restam parcelas 'ABERTAS' para o contrato de empréstimo
        private bool ExisteParcelaAberta(int codigoEmprestimo)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                       WHERE codigo_emprestimo = @codigo_emprestimo AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        // Regra para manter a ordem cronológica dos pagamentos
        private bool ExisteParcelaAnteriorAberta(int codigoEmprestimo, int numeroParcela)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                       WHERE codigo_emprestimo = @codigo_emprestimo 
                       AND numero_parcela < @numero_parcela AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                comando.Parameters.AddWithValue("@numero_parcela", numeroParcela);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }
    }
}

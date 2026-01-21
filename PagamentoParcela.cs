using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class PagamentoParcela
    {
        public int codigoEmprestimo { get; set; }
        public string ObservacoesParcela { get; set; }

        // --- MÉTODOS DE APOIO (PRIVADOS) ---

        // Obter os Dados da Parcela no Banco de Dados
        public Parcela ObterDadosParcela(int codigoParcela)
        {
            string sql = @"SELECT codigo, valor_parcela, percentual_parcela, data_vencimento, data_ultimo_calculo_juros, status_parcela
                            FROM emprestimosbd.conta_receber
                            WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);

                using (var reader = comando.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null; // Parcela não encontrada
                    }

                    return new Parcela
                    {
                        Codigo = reader.GetInt32("codigo"),
                        ValorParcela = reader.GetDecimal("valor_parcela"),
                        PercentualJuros = reader.GetDecimal("percentual_parcela"),
                        DataVencimento = reader.GetDateTime("data_vencimento"),
                        DataUltimoCalculoJuros = reader.IsDBNull("data_ultimo_calculo_juros") ? null : reader.GetDateTime("data_ultimo_calculo_juros"),
                    };
                }
            }
        }

        // --- Métodos Referente ao Processo de Pagamento ---

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
                string sql = @"UPDATE emprestimosbd.conta_receber 
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

        // --- Métodos Referentes ao Recalculo de Juros ---

        // Método responsável, por recalcular o % dos juros e alterar o valor em parcelas vencidas.
        public bool RecalcularJurosEAvancarMes(int CodigoParcela)
        {
            Parcela parcela = ObterDadosParcela(CodigoParcela);

            if (parcela == null)
                throw new Exception("Parcela não encontrada.");

            if (!string.IsNullOrEmpty(parcela.Status) && parcela.Status.Equals("PAGA", StringComparison.OrdinalIgnoreCase))
                return false; // Parcela já paga, não recalcula juros

            DateTime referencia = parcela.DataUltimoCalculoJuros ?? parcela.DataVencimento;
            DateTime novaDataUltimoCalculo = referencia.AddMonths(1); // Avança um mês

            decimal taxa = parcela.PercentualJuros / 100m;
            decimal novoValor = Math.Round(parcela.ValorParcela * (1m + taxa), 2, MidpointRounding.AwayFromZero);

            string sql = @"UPDATE emprestimosbd.conta_receber 
                           SET
                               valor_parcela = @valor_parcela, 
                               data_ultimo_calculo_juros = @data_ultimo_calculo_juros,
                               status_parcela = 'ATRASADA'
                           WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@valor_parcela", novoValor);
                comando.Parameters.AddWithValue("@data_ultimo_calculo_juros", novaDataUltimoCalculo);
                comando.Parameters.AddWithValue("@codigo", CodigoParcela);

                int linhasAfetadas = comando.ExecuteNonQuery();
                return linhasAfetadas > 0; // Retorna true se a atualização foi bem-sucedida
            }
        }

        // Método publico para adicionar Observações a Parcela.
        public void AdicionarObservacoesAParcela(int codigoParcela, string observacoes)
        {
            // variavel tipo STRING que armazena o comando do UPDATE para adicionar a Observação a parcela.
            string sql = @"
                            UPDATE emprestimosbd.conta_receber
                            SET
	                            observacoes = @observacoes
                            WHERE codigo = @codigo";

            // Se Observação foi diferente de Nulo com Espaços em Branco, executa o algoritimo abaixo.
            if (!string.IsNullOrWhiteSpace(observacoes))
            {
                // Abre a conexão com o Banco de Dados.
                using (var conexao = ConexaoBancoDeDados.Conectar())
                // Variavel comando recebe um novo comando MySQL passando 'sql' e 'conexao' como parametros.
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    // Adiciona o parametro @codigo com o valor 'codigoParcela'
                    comando.Parameters.AddWithValue("@codigo", codigoParcela);
                    // Adiciona o parametro @observacoes com o valor 'observacoes'
                    comando.Parameters.AddWithValue("@observacoes", observacoes);
                    // Roda o comando ExecuteNonQuery para rodar o comando do UPDATE.
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
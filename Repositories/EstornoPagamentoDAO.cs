using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class EstornoPagamentoDAO
    {
        public bool ValidarSequenciaEstorno(EstornoPagamentoDTO dto)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber
                           WHERE codigo_emprestimo = @codigo_emprestimo
	                            AND numero_parcela > @numero_parcela
                                AND status_parcela = 'PAGA'";

            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo_emprestimo", dto.CodigoEmprestimo);
                cmd.Parameters.AddWithValue("@numero_parcela", dto.NumeroParcela);

                int parcelasPosterioresPagas = Convert.ToInt32(cmd.ExecuteScalar());

                return parcelasPosterioresPagas == 0;
            }
        }

        public bool EstornarPagamento(EstornoPagamentoDTO dto)
        {
            using (var conn = ConexaoBancoDeDados.Conectar())
            {
                string sqlCheck = "SELECT valor_pago, status_parcela FROM emprestimosbd.conta_receber WHERE codigo = @codigo";

                using (var cmdCheck = new MySqlCommand(sqlCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@codigo", dto.CodigoParcela);
                    using (var reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal valorNoBanco = reader.GetDecimal("valor_pago");

                            if (valorNoBanco <= 0)
                            {
                                throw new Exception("Bloqueio: Esta parcela não possui saldo pago disponível para estorno.");
                            }

                            if (dto.ValorEstornado > valorNoBanco)
                            {
                                throw new Exception($"Bloqueio: Valor de estorno ({dto.ValorEstornado:C2}) maior que o saldo pago ({valorNoBanco:C2}).");
                            }
                        }
                        else
                        {
                            throw new Exception("Bloqueio: Parcela não encontrada no sistema.");
                        }
                    }
                }

                // Iniciamos a transação para garantir que o LOG e o UPDATE aconteçam juntos
                var transacao = conn.BeginTransaction();
                try
                {
                    // SQL Único para Total e Parcial
                    // Ele subtrai o valor e decide o status comparando com e.valor_parcela
                    string sql = @"UPDATE emprestimosbd.conta_receber c
                                   INNER JOIN emprestimosbd.emprestimos e ON c.codigo_emprestimo = e.codigo
                                   SET 
                                       c.valor_pago = c.valor_pago - @valor_estornado,
                                       c.status_parcela = IF((c.valor_pago - @valor_estornado) < e.valor_parcela, 'ABERTA', 'PAGA'),
                                       c.data_pagamento = IF((c.valor_pago - @valor_estornado) < e.valor_parcela, NULL, c.data_pagamento),
                                       c.data_ultimo_pagamento = IF((c.valor_pago - @valor_estornado) < e.valor_parcela, NULL, c.data_ultimo_pagamento)
                                   WHERE c.codigo = @codigo_parcela 
                                     AND c.valor_pago >= @valor_estornado";

                    using (var cmd = new MySqlCommand(sql, conn, transacao))
                    {
                        cmd.Parameters.AddWithValue("@valor_estornado", dto.ValorEstornado);
                        cmd.Parameters.AddWithValue("@codigo_parcela", dto.CodigoParcela);

                        int rows = cmd.ExecuteNonQuery();

                        // Se nenhuma linha foi alterada, é porque o WHERE barrou por saldo insuficiente
                        if (rows == 0)
                            throw new Exception("Operação cancelada: Valor de estorno maior que o valor pago ou parcela não encontrada.");
                    }

                    // 2. Atualiza o Status do Empréstimo para garantir que não fique como 'QUITADO'
                    string sqlEmprestimo = @"UPDATE emprestimosbd.emprestimos 
                                             SET status_emprestimo = 'ATIVO' 
                                             WHERE codigo = @codigo AND status_emprestimo = 'QUITADO'";

                    using (var cmdEmp = new MySqlCommand(sqlEmprestimo, conn, transacao))
                    {
                        cmdEmp.Parameters.AddWithValue("@codigo", dto.CodigoEmprestimo);
                        cmdEmp.ExecuteNonQuery();
                    }

                    // 3. Registra o Log de Auditoria (Reutilizando seu método existente)
                    RegistrarEstorno(dto, conn, transacao);

                    transacao.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    Serilog.Log.Error("Erro crítico no processo de estorno: " + ex.Message);
                    return false;
                }
            }
        }

        public bool RegistrarEstorno(EstornoPagamentoDTO dto, MySqlConnection conn, MySqlTransaction trans) 
        {
            try
            {
                string sql = @"INSERT INTO emprestimosbd.estorno_pagamento
                                (
	                                codigo_parcela,
	                                codigo_emprestimo,
	                                codigo_funcionario,
	                                valor_estornado,
	                                motivo_estorno
                                )
                                VALUES
                                (
	                                @codigo_parcela,
	                                @codigo_emprestimo,
	                                @codigo_funcionario,
	                                @valor_estornado,
	                                @motivo_estorno
                                )";

                using (var cmd = new MySqlCommand(sql, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@codigo_parcela", dto.CodigoParcela);
                    cmd.Parameters.AddWithValue("@codigo_emprestimo", dto.CodigoEmprestimo);
                    cmd.Parameters.AddWithValue("@codigo_funcionario", dto.CodigoFuncionario);
                    cmd.Parameters.AddWithValue("@valor_estornado", dto.ValorEstornado);
                    cmd.Parameters.AddWithValue("@motivo_estorno", dto.MotivoEstorno);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Houve um erro ao registrar o Estorno: " + ex);
                return false;
            }
        }

        public DataTable ListarParcelasParaEstorno(EstornoPagamentoDTO dto)
        {
            DataTable dt = new DataTable();

            try
            {

                string sql = @"SELECT 
	                                c.codigo as codigo_parcela, 
	                                c.codigo_emprestimo, 
                                    cl.nome_cliente,
                                    c.numero_parcela,
                                    e.valor_emprestado_total,
                                    e.valor_parcela,
                                    c.valor_pago, 
                                    c.data_pagamento, 
                                    c.status_parcela
                                FROM emprestimosbd.conta_receber c
                                INNER JOIN emprestimosbd.emprestimos e
	                                ON c.codigo_emprestimo = e.codigo
                                INNER JOIN emprestimosbd.cliente cl
                                    ON cl.codigo = e.codigo_cliente
                                    WHERE c.valor_pago > 0";

                string filtro = " AND c.status_parcela IN ('PAGA', 'ABERTA')";
                
                if (dto.CodigoEmprestimo > 0)
                    filtro += " AND c.codigo_emprestimo = @codigo_emprestimo";

                if (dto.CodigoCliente > 0)
                    filtro += " AND e.codigo_cliente = @codigo_cliente";

                string sqlFinal = sql + filtro;

                using (var conn = ConexaoBancoDeDados.Conectar())
                using (var cmd = new MySqlCommand(sqlFinal, conn))
                {
                    if (dto.CodigoEmprestimo > 0)
                        cmd.Parameters.AddWithValue("@codigo_emprestimo", dto.CodigoEmprestimo);

                    if (dto.CodigoCliente > 0)
                        cmd.Parameters.AddWithValue("@codigo_cliente", dto.CodigoCliente);

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Houve um erro ao listar as parcelas pagas: " + ex);
            }

            return dt;
        }
    }
}

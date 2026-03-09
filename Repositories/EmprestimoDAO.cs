using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            ParcelaDTO parcelaEncontrada = null;

            string sql = @"SELECT p.*, e.valor_juros, c.nome_cliente, e.valor_emprestado_total FROM conta_receber p
                                INNER JOIN emprestimos e
                                 ON e.codigo = p.codigo_emprestimo
                                INNER JOIN cliente c
                                 ON p.codigo_cliente = c.codigo
                                 WHERE codigo_emprestimo = @codigo_emprestimo
                                 AND status_parcela = 'ABERTA' 
                                  ORDER BY numero_parcela ASC LIMIT 1";

            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        parcelaEncontrada = new ParcelaDTO
                        {
                            Codigo = dr.GetInt32("codigo"),
                            CodigoEmprestimo = dr.GetInt32("codigo_emprestimo"),
                            CodigoCliente = dr.GetInt32("codigo_cliente"),
                            NomeCliente = dr.GetString("nome_cliente"),
                            NumeroParcela = dr.GetInt32("numero_parcela"),
                            ValorParcela = dr.GetDecimal("valor_parcela"),
                            ValorEmprestimo = dr.GetDecimal("valor_emprestado_total"),
                            ValorJuros = dr.GetDecimal("valor_juros"),
                            DataVencimento = DateOnly.FromDateTime(dr.GetDateTime("data_vencimento")),
                            StatusParcela = dr.GetString("status_parcela")
                        };
                    }
                }
            }

            return parcelaEncontrada;
        }

        // --- MÉTODOS DE CONSULTA E VALIDAÇÃO ---

        // Consulta flexível: traz empréstimos conforme filtros (migrado de Services.EmprestimosConsulta)
        public DataTable ConsultaEmprestimos(int? CodigoCliente, string NomeCliente, string StatusEmprestimo, decimal ValorEmprestado, decimal ValorParcela, decimal ValorJurosMonetario, int? QtnParcela, decimal ValorTotal)
        {
            DataTable dataTable = new DataTable();

            string sql = @"SELECT e.codigo, e.codigo_cliente, c.nome_cliente, e.valor_emprestado, e.valor_emprestado_total AS valor_total, e.quantidade_parcela, e.valor_parcela, e.valor_juros, e.status_emprestimo
                               FROM emprestimosbd.emprestimos e
                               LEFT JOIN emprestimosbd.cliente c ON e.codigo_cliente = c.codigo";

            string sqlFiltros = " WHERE 1 = 1";

            if (CodigoCliente.HasValue)
            {
                sqlFiltros += " AND e.codigo_cliente = @codigo_cliente";
            }

            if (!string.IsNullOrWhiteSpace(NomeCliente))
            {
                sqlFiltros += " AND c.nome_cliente LIKE @nome_cliente";
            }

            if (!string.IsNullOrWhiteSpace(StatusEmprestimo))
            {
                sqlFiltros += " AND e.status_emprestimo = @status_emprestimo";
            }

            if (ValorEmprestado > 0)
            {
                sqlFiltros += " AND e.valor_emprestado = @valor_emprestado";
            }

            if (ValorParcela > 0)
            {
                sqlFiltros += " AND e.valor_parcela = @valor_parcela";
            }

            if (ValorJurosMonetario > 0)
            {
                sqlFiltros += " AND e.valor_juros = @valor_juros";
            }

            if (QtnParcela.HasValue && QtnParcela > 0)
            {
                sqlFiltros += " AND e.quantidade_parcela = @quantidade_parcela";
            }

            if (ValorTotal > 0)
            {
                sqlFiltros += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                }

                if (!string.IsNullOrEmpty(NomeCliente))
                {
                    comando.Parameters.AddWithValue("@nome_cliente", "%" + NomeCliente + "%");
                }

                if (!string.IsNullOrWhiteSpace(StatusEmprestimo))
                {
                    comando.Parameters.AddWithValue("@status_emprestimo", StatusEmprestimo);
                }

                if (ValorEmprestado > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado", ValorEmprestado);
                }

                if (ValorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                }

                if (ValorJurosMonetario > 0)
                {
                    comando.Parameters.AddWithValue("@valor_juros", ValorJurosMonetario);
                }

                if (QtnParcela.HasValue && QtnParcela > 0)
                {
                    comando.Parameters.AddWithValue("@quantidade_parcela", QtnParcela);
                }

                if (ValorTotal > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", ValorTotal);
                }

                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        // Consulta específica por código do empréstimo (migrado)
        public DataTable ConsultaEmprestimosPorCodigo(int codigoEmprestimo)
        {
            DataTable dataTable = new DataTable();

            string sqlCodigo = @"SELECT * FROM emprestimosbd.emprestimos WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlCodigo, conexao))
            {
                if (codigoEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", codigoEmprestimo);

                    using (var data = new MySqlDataAdapter(comando))
                    {
                        data.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Verifica se o cliente já possui algum empréstimo com status 'ATIVO' no banco de dados
        public bool ValidarClienteEmprestimo(string codigoCliente)
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand SelectCliente = conexao.CreateCommand())
            {
                SelectCliente.CommandText = "SELECT COUNT(*) FROM emprestimosbd.emprestimos WHERE codigo_cliente = @codigo_cliente AND status_emprestimo = 'ATIVO'";

                SelectCliente.Parameters.AddWithValue("@codigo_cliente", codigoCliente);

                int quantidadeCliente = Convert.ToInt32(SelectCliente.ExecuteScalar());
                return quantidadeCliente > 0;
            }
        }

        // Verifica se o cliente em questão está com a situação 'INATIVO' no cadastro
        public bool validarClienteInativo(string codigoClienteInativo)
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand SelectInativo = conexao.CreateCommand())
            {
                SelectInativo.CommandText = "SELECT COUNT(*) FROM emprestimosbd.cliente WHERE codigo = @codigo AND situacao_cadastral = 'INATIVO'";

                SelectInativo.Parameters.AddWithValue("@codigo", codigoClienteInativo);

                int quantidadeClienteInativo = Convert.ToInt32(SelectInativo.ExecuteScalar());
                return quantidadeClienteInativo > 0;
            }
        }

        // Insere o empréstimo e dispara a geração de parcelas usando Transação para segurança total
        public bool InserirDadosEmprestimo(EmprestimoDTO emprestimo)
        {
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var transacao = conexao.BeginTransaction())
            {
                try
                {
                    string sqlInsertEmprestimo = @"INSERT INTO emprestimosbd.emprestimos (codigo_cliente, valor_emprestado, valor_emprestado_total, quantidade_parcela, valor_parcela, valor_juros, percentual_juros, tipo_juros, data_emprestimo, data_pagar, observacoes, status_emprestimo)  VALUES(@codigo_cliente, @valor_emprestado, @valor_emprestado_total, @quantidade_parcela, @valor_parcela, @valor_juros, @percentual_juros, @tipo_juros, @data_emprestimo, @data_pagar, @observacoes, @status_emprestimo); SELECT LAST_INSERT_ID();";

                    using (var comando = new MySqlCommand(sqlInsertEmprestimo, conexao, transacao))
                    {
                        comando.Parameters.AddWithValue("@codigo_cliente", emprestimo.CodigoCliente);
                        comando.Parameters.AddWithValue("@valor_emprestado", emprestimo.ValorEmprestado);
                        comando.Parameters.AddWithValue("@valor_emprestado_total", emprestimo.ValorTotal);
                        comando.Parameters.AddWithValue("@quantidade_parcela", emprestimo.QuantidadeParcela);
                        comando.Parameters.AddWithValue("@valor_parcela", emprestimo.ValorParcela);
                        comando.Parameters.AddWithValue("@valor_juros", emprestimo.ValorJurosMonetario);
                        comando.Parameters.AddWithValue("@percentual_juros", emprestimo.ValorJurosPercentual);
                        comando.Parameters.AddWithValue("@tipo_juros", emprestimo.TipoJuros);

                        DateTime dataEmprestimoDb = emprestimo.DataEmprestimo.ToDateTime(TimeOnly.MinValue);
                        DateTime dataVencimentoDb = emprestimo.DataVencimentoInicial.ToDateTime(TimeOnly.MinValue);

                        comando.Parameters.AddWithValue("@data_emprestimo", dataEmprestimoDb);
                        comando.Parameters.AddWithValue("@data_pagar", dataVencimentoDb);
                        comando.Parameters.AddWithValue("@observacoes", emprestimo.ObservacoesEmprestimos);
                        comando.Parameters.AddWithValue("@status_emprestimo", emprestimo.StatusEmprestimo);

                        emprestimo.Codigo = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    GerarParcela(emprestimo, conexao, transacao);

                    transacao.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    Funcoes.MensagemErro("Houve um erro ao gerar empréstimo:\n" + ex.Message);
                    Serilog.Log.Error("Erro ao inserir empréstimo: " + ex.Message);

                    return false;
                }
            }
        }

        // Método privado que cria as linhas de parcelas na tabela conta_receber
        private void GerarParcela(EmprestimoDTO emprestimo, MySqlConnection conexao, MySqlTransaction transacao)
        {
            string sqlParcela = @"
                                INSERT INTO emprestimosbd.conta_receber
                                (
                                    codigo_emprestimo,
                                    codigo_cliente, 
                                    numero_parcela,
                                    valor_parcela,
                                    percentual_parcela,
                                    data_vencimento
                                )
                                VALUES
                                (
                                    @codigo_emprestimo,
                                    @codigo_cliente, 
                                    @numero_parcela,
                                    @valor_parcela,
                                    @percentual_parcela,
                                    @data_vencimento
                                )";

            for (int i = 1; i <= emprestimo.QuantidadeParcela; i++)
            {
                using (var comando = new MySqlCommand(sqlParcela, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", emprestimo.Codigo);
                    comando.Parameters.AddWithValue("@codigo_cliente", emprestimo.CodigoCliente);
                    comando.Parameters.AddWithValue("@numero_parcela", i);
                    comando.Parameters.AddWithValue("@valor_parcela", emprestimo.ValorParcela);
                    comando.Parameters.AddWithValue("@percentual_parcela", emprestimo.ValorJurosPercentual);

                    DateTime dataVencimentoDb = emprestimo.DataVencimentoInicial.ToDateTime(TimeOnly.MinValue);

                    if (emprestimo.TipoJuros == "DIARIO")
                        comando.Parameters.AddWithValue("@data_vencimento", dataVencimentoDb.AddDays(i - 1));
                    else
                        comando.Parameters.AddWithValue("@data_vencimento", dataVencimentoDb.AddMonths(i - 1));

                    comando.ExecuteNonQuery();
                }
            }
        }

        // Altera o status do empréstimo para QUITADO e registra a data atual
        public void QuitarEmprestimo(int CodigoEmprestimo)
        {
            if (CodigoEmprestimo <= 0)
            {
                return;
            }

            string sql = @"
                          UPDATE emprestimosbd.emprestimos
                          SET
                            data_quitacao = now(),
                            status_emprestimo = 'QUITADO'
                          WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", CodigoEmprestimo);

                comando.ExecuteNonQuery();
            }
        }

        public DataTable ListarEmprestimos()
        {
            DataTable dt = new DataTable();

            string sql = @"SELECT 
                               e.codigo  AS codigo_emprestimo, 
                               c.codigo AS codigo_cliente, 
                               c.nome_cliente, 
                               e.valor_emprestado_total AS valor_total, 
                               e.percentual_juros, 
                               e.data_pagar,
                               e.observacoes,
                               e.status_emprestimo 
                           FROM emprestimosbd.emprestimos e
                            INNER JOIN emprestimosbd.cliente c
                                ON e.codigo_cliente = c.codigo
                            WHERE status_emprestimo = 'ATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            using (var adapter = new MySqlDataAdapter(comando))
            {
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}

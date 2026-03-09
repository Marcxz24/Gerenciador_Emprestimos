using System.Data;
using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class ParcelaDAO
    {
        // Retorna os dados da parcela (mapeado para ParcelaDTO)
        public ParcelaDTO GetParcela(int codigoParcela)
        {
            string sql = @"SELECT 
                                    p.codigo,
                                    p.valor_parcela,
                                    p.valor_pago,
                                    p.percentual_parcela,
                                    p.data_vencimento,
                                    p.data_ultimo_calculo_juros,
                                    p.status_parcela,
                                    e.tipo_juros
                               FROM emprestimosbd.conta_receber p
                               INNER JOIN emprestimosbd.emprestimos e ON p.codigo_emprestimo = e.codigo
                               WHERE p.codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);

                using (var reader = comando.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var dto = new ParcelaDTO
                    {
                        Codigo = reader.GetInt32("codigo"),
                        ValorParcela = reader.IsDBNull(reader.GetOrdinal("valor_parcela")) ? 0m : reader.GetDecimal("valor_parcela"),
                        ValorPago = reader.IsDBNull(reader.GetOrdinal("valor_pago")) ? 0m : reader.GetDecimal("valor_pago"),
                        PercentualJuros = reader.IsDBNull(reader.GetOrdinal("percentual_parcela")) ? 0m : reader.GetDecimal("percentual_parcela"),
                        DataVencimento = DateOnly.FromDateTime(reader.GetDateTime("data_vencimento")),
                        StatusParcela = reader.IsDBNull(reader.GetOrdinal("status_parcela")) ? null : reader.GetString("status_parcela"),
                        TipoJuros = reader.IsDBNull(reader.GetOrdinal("tipo_juros")) ? null : reader.GetString("tipo_juros"),
                        DataUltimoCalculoJuros = reader.IsDBNull(reader.GetOrdinal("data_ultimo_calculo_juros"))
                            ? null
                            : DateOnly.FromDateTime(reader.GetDateTime("data_ultimo_calculo_juros"))
                    };

                    return dto;
                }
            }
        }

        // Retorna o valor já pago acumulado da parcela
        public decimal GetValorPago(int codigoParcela)
        {
            string sql = @"SELECT IFNULL(valor_pago, 0) FROM emprestimosbd.conta_receber WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                return Convert.ToDecimal(comando.ExecuteScalar());
            }
        }

        // Atualiza parcial (pagamento não quitando a parcela)
        public void UpdateValorPagoPartial(int codigoParcela, decimal valorPagoTotal)
        {
            string sql = @"UPDATE emprestimosbd.conta_receber 
                               SET valor_pago = @valor_pago, data_ultimo_pagamento = NOW(), status_parcela = 'ABERTA'
                               WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);
                comando.ExecuteNonQuery();
            }
        }

        // Marca parcela como paga (quitada) e retorna número de linhas afetadas
        public int MarkParcelaPaga(int codigoParcela, decimal valorPagoTotal)
        {
            string sql = @"UPDATE emprestimosbd.conta_receber 
                               SET valor_pago = @valor_pago, data_ultimo_pagamento = NOW(), data_pagamento = NOW(), status_parcela = 'PAGA'
                               WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                comando.Parameters.AddWithValue("@valor_pago", valorPagoTotal);
                return comando.ExecuteNonQuery();
            }
        }

        // Conta se existem parcelas abertas para um empréstimo
        public int CountParcelasAbertas(int codigoEmprestimo)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                               WHERE codigo_emprestimo = @codigo_emprestimo AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        // Conta se existem parcelas anteriores em aberto (regra de ordem)
        public int CountParcelasAnterioresAbertas(int codigoEmprestimo, int numeroParcela)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.conta_receber 
                           WHERE codigo_emprestimo = @codigo_emprestimo 
                           AND numero_parcela < @numero_parcela AND status_parcela = 'ABERTA'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                comando.Parameters.AddWithValue("@numero_parcela", numeroParcela);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        // Atualiza valor da parcela ao recalcular juros (marca como ATRASADA)
        public int UpdateParcelaValorJuros(int codigoParcela, decimal novoValor, DateTime dataUltimoCalculo)
        {
            string sql = @"UPDATE emprestimosbd.conta_receber 
                               SET valor_parcela = @valor_parcela, data_ultimo_calculo_juros = @data_ultimo_calculo_juros, status_parcela = 'ATRASADA'
                               WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@valor_parcela", novoValor);
                comando.Parameters.AddWithValue("@data_ultimo_calculo_juros", dataUltimoCalculo);
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                return comando.ExecuteNonQuery();
            }
        }

        // Adiciona ou atualiza observações na parcela
        public void AddObservacoes(int codigoParcela, string observacoes)
        {
            if (string.IsNullOrWhiteSpace(observacoes)) return;

            string sql = @"UPDATE emprestimosbd.conta_receber
                               SET observacoes = @observacoes
                               WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                comando.Parameters.AddWithValue("@observacoes", observacoes);
                comando.ExecuteNonQuery();
            }
        }

        // Verifica se a parcela já está marcada como paga
        public bool IsParcelaPaga(int codigoParcela)
        {
            string sql = @"SELECT status_parcela FROM emprestimosbd.conta_receber WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoParcela);
                string status = comando.ExecuteScalar()?.ToString();
                return status == "PAGA";
            }
        }

        // Método que recebe diversos filtros e retorna um DataTable para preencher o DataGrid
        public DataTable ConsultaParcela(ParcelaDTO parcela)
        {
            // Instancia a tabela que receberá os dados do banco
            DataTable consultaDataTable = new DataTable();

            // SQL Base: Realiza o JOIN entre conta_receber (p), cliente (c) e emprestimos (e)
            // Isso permite trazer o nome do cliente e o valor total do empréstimo em uma única consulta
            string SqlConsulta = @"SELECT 
	                                    p.codigo as codigo_parcela, 
                                        p.codigo_emprestimo, 
                                        p.codigo_cliente, 
                                        c.nome_cliente, 
                                        e.valor_emprestado_total as valor_total, 
                                        p.valor_parcela, p.numero_parcela, 
                                        p.valor_pago, 
                                        p.data_pagamento, 
                                        p.data_vencimento, 
                                        p.status_parcela 
                                    FROM emprestimosbd.conta_receber p 
                                    INNER JOIN emprestimosbd.cliente c ON p.codigo_cliente = c.codigo 
                                    INNER JOIN emprestimosbd.emprestimos e ON p.codigo_emprestimo = e.codigo";

            // Inicializa a cláusula de filtros. O '1 = 1' facilita a adição de múltiplos 'AND'
            string SqlFiltros = " WHERE 1 = 1";

            // --- BLOCO DE CONSTRUÇÃO DINÂMICA DA QUERY ---

            // Se o código do empréstimo foi informado (.HasValue), adiciona o filtro
            if (parcela.CodigoEmprestimo > 0)
            {
                SqlFiltros += " AND p.codigo_emprestimo = @codigo_emprestimo";
            }

            // Filtro por código do cliente
            if (parcela.CodigoCliente > 0)
            {
                SqlFiltros += " AND p.codigo_cliente = @codigo_cliente";
            }

            // Filtro por nome do cliente usando LIKE (busca parcial)
            if (!string.IsNullOrWhiteSpace(parcela.NomeCliente))
            {
                SqlFiltros += " AND c.nome_cliente LIKE @nome_cliente";
            }

            // Filtro por status (ex: Pago, Pendente, Atrasado)
            if (!string.IsNullOrWhiteSpace(parcela.StatusParcela))
            {
                SqlFiltros += " AND p.status_parcela LIKE @status_parcela";
            }

            // Filtro pelo número da parcela (ex: parcela 2 de 10)
            if (parcela.NumeroParcela > 0)
            {
                SqlFiltros += " AND p.numero_parcela = @numero_parcela";
            }

            // Filtro pelo valor total do empréstimo original
            if (parcela.ValorParcela > 0)
            {
                SqlFiltros += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            // Filtro pelo valor específico da parcela
            if (parcela.ValorParcela > 0)
            {
                SqlFiltros += " AND p.valor_parcela = @valor_parcela";
            }

            // Combina a consulta principal com os filtros gerados
            string sqlConsultaFinal = SqlConsulta + SqlFiltros;

            // Gerencia a conexão e o comando SQL
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlConsultaFinal, conexao))
            {
                // --- BLOCO DE ATRIBUIÇÃO DE PARÂMETROS ---
                // Adiciona apenas os parâmetros cujos filtros foram incluídos acima

                if (parcela.CodigoEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", parcela.CodigoEmprestimo);
                }

                if (parcela.CodigoCliente > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", parcela.CodigoCliente);
                }

                if (!string.IsNullOrEmpty(parcela.NomeCliente))
                {
                    // Adiciona os coringas (%) para encontrar nomes que contenham o termo digitado
                    comando.Parameters.AddWithValue("@nome_cliente", "%" + parcela.NomeCliente + "%");
                }

                if (!string.IsNullOrWhiteSpace(parcela.StatusParcela))
                {
                    comando.Parameters.AddWithValue("@status_parcela", parcela.StatusParcela);
                }

                if (parcela.NumeroParcela > 0)
                {
                    comando.Parameters.AddWithValue("@numero_parcela", parcela.NumeroParcela);
                }

                if (parcela.ValorEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", parcela.ValorEmprestimo);
                }

                if (parcela.ValorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", parcela.ValorParcela);
                }

                // Utiliza o DataAdapter para executar o comando e preencher o DataTable
                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(consultaDataTable);
                }
            }

            // Retorna a tabela preenchida (com ou sem linhas, dependendo do resultado)
            return consultaDataTable;
        }
    }
}

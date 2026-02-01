using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    // Classe responsável por consultar parcelas que estão pendentes para pagamento
    public class PagamentoParcelaConsulta
    {
        // Método que busca a relação entre Cliente, Empréstimo e Parcelas usando filtros opcionais
        public DataTable ConsultaClienteEmprestimo(int? codigoCliente, int? codigoEmprestimo, decimal valorJuros, decimal valorTotal, decimal valorParcela)
        {
            // Cria a tabela que armazenará o resultado para o DataGrid
            DataTable dataTable = new DataTable();

            // SQL base com INNER JOIN: Cruza as três tabelas principais do sistema
            // Traz dados do cliente (nome), do empréstimo (juros/total) e da parcela (número/vencimento)
            string sql = @"
                     SELECT
                        c.codigo AS codigo_cliente,
                        c.nome_cliente,
                        e.codigo AS codigo_emprestimo,
                        e.valor_emprestado_total AS valor_contrato,
                        p.codigo AS codigo_parcela,
                        e.valor_juros,
                        p.numero_parcela,
                        p.valor_parcela,
                        p.valor_pago,
                        p.status_parcela,
                        p.data_vencimento
                    FROM cliente c
                    INNER JOIN emprestimos e
                        ON c.codigo = e.codigo_cliente
                    INNER JOIN conta_receber p
                        ON e.codigo = p.codigo_emprestimo
        ";

            // Define o filtro padrão: apenas parcelas com status 'ABERTA' devem aparecer nesta consulta
            // O '1 = 1' ajuda na concatenação dos próximos 'AND'
            string? filtro = @"
                            WHERE 1 = 1
                            AND p.status_parcela IN ('ABERTA', 'ATRASADA')
                            ";

            // --- ADIÇÃO DINÂMICA DE FILTROS ---
            // Se o código do cliente for maior que zero, adiciona o filtro de ID do cliente
            if (codigoCliente > 0)
            {
                filtro += " AND c.codigo = @codigo_cliente";
            }

            // Filtra por um contrato de empréstimo específico
            if (codigoEmprestimo > 0)
            {
                filtro += " AND e.codigo = @codigo_emprestimo";
            }

            // Filtra pelo valor dos juros configurado no contrato
            if (valorJuros > 0)
            {
                filtro += " AND e.valor_juros = @valor_juros";
            }

            // Filtra pelo valor total do contrato
            if (valorTotal > 0)
            {
                filtro += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            // Filtra pelo valor exato da parcela
            if (valorParcela > 0)
            {
                filtro += " AND p.valor_parcela = @valor_parcela";
            }

            // Une a estrutura do SELECT com os filtros construídos
            string sqlFinal = sql + filtro;

            // Inicia a comunicação com o banco de dados
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                // --- ATRIBUIÇÃO DE PARÂMETROS ---
                // Repete as validações para injetar os valores de forma segura (SQL Injection Protection)
                if (codigoCliente > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", codigoCliente);
                }

                if (codigoEmprestimo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                }

                if (valorJuros > 0)
                {
                    comando.Parameters.AddWithValue("@valor_juros", valorJuros);
                }

                if (valorTotal > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", valorTotal);
                }

                if (valorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", valorParcela);
                }

                // Preenche o DataTable usando o DataAdapter
                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }

            // Retorna a tabela com os dados prontos para o DataGridView
            return dataTable;
        }
    }
}

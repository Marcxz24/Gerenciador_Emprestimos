using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    // Define uma classe interna para gerenciar as consultas de parcelas
    internal class ParcelaConsulta
    {
        // Método que recebe diversos filtros e retorna um DataTable para preencher o DataGrid
        public DataTable ConsultaParcela(int? CodigoEmprestimo, int? CodigoCliente, string NomeCliente, string StatusParcela, decimal ValorTotal, decimal ValorParcela, int? NumeroParcela)
        {
            // Instancia a tabela que receberá os dados do banco
            DataTable consultaDataTable = new DataTable();

            // SQL Base: Realiza o JOIN entre conta_receber (p), cliente (c) e emprestimos (e)
            // Isso permite trazer o nome do cliente e o valor total do empréstimo em uma única consulta
            string SqlConsulta = "SELECT p.codigo as codigo_parcela, p.codigo_emprestimo, p.codigo_cliente, c.nome_cliente, e.valor_emprestado_total as valor_total, p.valor_parcela, p.numero_parcela, p.valor_pago, p.data_pagamento, p.data_vencimento, p.status_parcela FROM emprestimosbd.conta_receber p LEFT JOIN emprestimosbd.cliente c ON p.codigo_cliente = c.codigo LEFT JOIN emprestimosbd.emprestimos e ON p.codigo_emprestimo = e.codigo";

            // Inicializa a cláusula de filtros. O '1 = 1' facilita a adição de múltiplos 'AND'
            string SqlFiltros = " WHERE 1 = 1";

            // --- BLOCO DE CONSTRUÇÃO DINÂMICA DA QUERY ---

            // Se o código do empréstimo foi informado (.HasValue), adiciona o filtro
            if (CodigoEmprestimo.HasValue)
            {
                SqlFiltros += " AND p.codigo_emprestimo = @codigo_emprestimo";
            }

            // Filtro por código do cliente
            if (CodigoCliente.HasValue)
            {
                SqlFiltros += " AND p.codigo_cliente = @codigo_cliente";
            }

            // Filtro por nome do cliente usando LIKE (busca parcial)
            if (!string.IsNullOrWhiteSpace(NomeCliente))
            {
                SqlFiltros += " AND c.nome_cliente LIKE @nome_cliente";
            }

            // Filtro por status (ex: Pago, Pendente, Atrasado)
            if (!string.IsNullOrWhiteSpace(StatusParcela))
            {
                SqlFiltros += " AND p.status_parcela LIKE @status_parcela";
            }

            // Filtro pelo número da parcela (ex: parcela 2 de 10)
            if (NumeroParcela > 0)
            {
                SqlFiltros += " AND p.numero_parcela = @numero_parcela";
            }

            // Filtro pelo valor total do empréstimo original
            if (ValorTotal > 0)
            {
                SqlFiltros += " AND e.valor_emprestado_total = @valor_emprestado_total";
            }

            // Filtro pelo valor específico da parcela
            if (ValorParcela > 0)
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

                if (CodigoEmprestimo.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", CodigoEmprestimo);
                }

                if (CodigoCliente.HasValue)
                {
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                }

                if (!string.IsNullOrEmpty(NomeCliente))
                {
                    // Adiciona os coringas (%) para encontrar nomes que contenham o termo digitado
                    comando.Parameters.AddWithValue("@nome_cliente", "%" + NomeCliente + "%");
                }

                if (!string.IsNullOrWhiteSpace(StatusParcela))
                {
                    comando.Parameters.AddWithValue("@status_parcela", StatusParcela);
                }

                if (NumeroParcela > 0)
                {
                    comando.Parameters.AddWithValue("@numero_parcela", NumeroParcela);
                }

                if (ValorTotal > 0)
                {
                    comando.Parameters.AddWithValue("@valor_emprestado_total", ValorTotal);
                }

                if (ValorParcela > 0)
                {
                    comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
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

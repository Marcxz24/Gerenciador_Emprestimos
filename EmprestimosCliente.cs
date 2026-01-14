using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class EmprestimosCliente
    {
        // --- PROPRIEDADES DE IDENTIFICAÇÃO E ESTADO ---
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public string StatusEmprestimo { get; private set; } = "ATIVO";

        // --- PROPRIEDADES FINANCEIRAS ---
        public decimal ValorEmprestado { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal ValorJurosPercentual { get; set; }
        public decimal ValorJurosMonetario { get; private set; }
        public decimal ValorParcela { get; private set; }
        public decimal ValorTotal { get; private set; }

        // --- PROPRIEDADES DE DATA ---
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataVencimentoInicial { get; set; }

        // --- MÉTODOS DE CÁLCULO FINANCEIRO ---

        // Calcula o valor real em dinheiro dos juros sobre o montante emprestado
        private decimal CalcularJurosValorEmprestado()
        {
            ValorJurosMonetario = (ValorEmprestado * ValorJurosPercentual) / 100;
            return ValorJurosMonetario;
        }

        // Soma o valor do principal com o valor dos juros para obter o total do contrato
        public decimal SomarJurosAoTotal()
        {
            CalcularJurosValorEmprestado();

            ValorTotal = ValorEmprestado + ValorJurosMonetario;

            return ValorTotal;
        }

        // Realiza a divisão do total pela quantidade de parcelas, respeitando o limite de 20
        public int DividirParcelas()
        {
            if (QuantidadeParcela >= 1 && QuantidadeParcela <= 20)
            {
                ValorParcela = ValorTotal / QuantidadeParcela;
            }
            else if (QuantidadeParcela > 20)
            {
                Funcoes.MensagemWarning("Quantidade de parcelas excede o limite máximo permitido (20).\n\nVerifique e tente novamente.");
            }
            else
            {
                Funcoes.MensagemWarning("Quantidade de parcelas inválida. Verifique e tente novamente.");
            }

            return QuantidadeParcela;
        }

        // Configura o status inicial e a data atual para o novo empréstimo
        public void AtivarEmprestimo()
        {
            StatusEmprestimo = "ATIVO";
            DataEmprestimo = DateOnly.FromDateTime(DateTime.Today);
        }

        // --- MÉTODOS DE CONSULTA E VALIDAÇÃO ---

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

        // --- MÉTODOS DE PERSISTÊNCIA (BANCO DE DADOS) ---

        // Insere o empréstimo e dispara a geração de parcelas usando Transação para segurança total
        public void InserirDadosEmorestimo()
        {
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var transacao = conexao.BeginTransaction())
            {
                try
                {
                    // SQL para inserir o registro pai (Empréstimo) e recuperar o ID gerado
                    string sqlInsertEmprestimo = @"INSERT INTO emprestimosbd.emprestimos (codigo_cliente, valor_emprestado, valor_emprestado_total, quantidade_parcela, valor_parcela, valor_juros, percentual_juros, data_emprestimo, data_pagar, status_emprestimo)  VALUES(@codigo_cliente, @valor_emprestado, @valor_emprestado_total, @quantidade_parcela, @valor_parcela, @valor_juros, @percentual_juros, @data_emprestimo, @data_pagar, @status_emprestimo); SELECT LAST_INSERT_ID();";

                    using (var comando = new MySqlCommand(sqlInsertEmprestimo, conexao, transacao))
                    {
                        comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                        comando.Parameters.AddWithValue("@valor_emprestado", ValorEmprestado);
                        comando.Parameters.AddWithValue("@valor_emprestado_total", ValorTotal);
                        comando.Parameters.AddWithValue("@quantidade_parcela", QuantidadeParcela);
                        comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                        comando.Parameters.AddWithValue("@valor_juros", ValorJurosMonetario);
                        comando.Parameters.AddWithValue("@percentual_juros", ValorJurosPercentual);

                        // Conversão necessária de DateOnly para DateTime para o MySQL
                        DateTime dataEmprestimoDb = DataEmprestimo.ToDateTime(TimeOnly.MinValue);
                        DateTime dataVencimentoDb = DataVencimentoInicial.ToDateTime(TimeOnly.MinValue);

                        comando.Parameters.AddWithValue("@data_emprestimo", dataEmprestimoDb);
                        comando.Parameters.AddWithValue("@data_pagar", dataVencimentoDb);
                        comando.Parameters.AddWithValue("@status_emprestimo", StatusEmprestimo);

                        // Executa e armazena o ID do empréstimo na propriedade Codigo
                        Codigo = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    // Gera as parcelas vinculadas a este código de empréstimo
                    GerarParcela(Codigo, conexao, transacao);

                    // Se não houve erros, confirma as alterações no banco
                    transacao.Commit();

                    Funcoes.MensagemInformation("Dados do Empréstimo Inseridos com Sucesso!");
                }
                catch (Exception ex)
                {
                    // Em caso de erro, desfaz qualquer inserção parcial (Rollback)
                    transacao.Rollback();
                    Funcoes.MensagemErro("Houve um erro ao gerar empréstimo:\n" + ex.Message);
                }
            }
        }

        // Método privado que cria as linhas de parcelas na tabela conta_receber
        private void GerarParcela(int codigoEmprestimo, MySqlConnection conexao, MySqlTransaction transacao)
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

            // Laço de repetição para criar cada parcela mensal
            for (int i = 1; i <= QuantidadeParcela; i++)
            {
                using (var comando = new MySqlCommand(sqlParcela, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo_emprestimo", codigoEmprestimo);
                    comando.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                    comando.Parameters.AddWithValue("@numero_parcela", i);
                    comando.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                    comando.Parameters.AddWithValue("@percentual_parcela", ValorJurosPercentual);

                    DateTime dataVencimentoDb = DataVencimentoInicial.ToDateTime(TimeOnly.MinValue);

                    // Incrementa os meses conforme o número da parcela (i-1 para a primeira ser no mês inicial)
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
    }
}
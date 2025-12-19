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
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public decimal ValorEmprestado { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal ValorJurosPercentual { get; set; }
        public decimal ValorJurosMonetario { get; private set; }
        public decimal ValorParcela { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPagamento { get; set; }
        public string? StatusEmprestimo { get; private set; }

        private decimal CalcularJurosValorEmprestado()
        {
            ValorJurosMonetario = (ValorEmprestado * ValorJurosPercentual) / 100;
            return ValorJurosMonetario;
        }

        public decimal SomarJurosAoTotal()
        {
            CalcularJurosValorEmprestado();

            ValorTotal = ValorEmprestado + ValorJurosMonetario;

            return ValorTotal;
        }

        public int DividirParcelas()
        {
            // Retirado o tratamento do if se QuantidadeParcela for igual a zero, para evitar divisão por zero, devido à validação já feita no formulário.
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

        public void AtivarEmprestimo()
        {
            StatusEmprestimo = "ATIVO";
            DataEmprestimo = DateTime.Now;
        }

        public void FinalizarEmprestimo()
        {
            StatusEmprestimo = "QUITADO";
            DataPagamento = DateTime.Now;
        }

        public bool ValidarClienteEmprestimo(string SelectodigoCliente)
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand SelectCliente = conexao.CreateCommand())
            {
                SelectCliente.CommandText = "SELECT COUNT(*) FROM emprestimosbd.emprestimos WHERE codigo_cliente = @codigo_cliente AND status_emprestimo = 'ATIVO'";
                
                SelectCliente.Parameters.AddWithValue("@codigo_cliente", SelectodigoCliente);

                int quantidadeCliente = Convert.ToInt32(SelectCliente.ExecuteScalar());
                return quantidadeCliente > 0;
            }
        }

        public void InserirDadosEmorestimo()
        {
            var conexao = ConexaoBancoDeDados.Conectar();

            using (MySqlCommand sqlInsertEmprestimo = conexao.CreateCommand())
            {
                sqlInsertEmprestimo.CommandText = @"INSERT INTO emprestimosbd.emprestimos (codigo_cliente, valor_emprestado, valor_emprestado_total, quantidade_parcela, valor_parcela, valor_juros, data_emprestimo, data_pagar, status_emprestimo)  VALUES(@codigo_cliente, @valor_emprestado, @valor_emprestado_total, @quantidade_parcela, @valor_parcela, @valor_juros, @data_emprestimo, @data_pagar, @status_emprestimo)";

                sqlInsertEmprestimo.Parameters.AddWithValue("@codigo_cliente", CodigoCliente);
                sqlInsertEmprestimo.Parameters.AddWithValue("@valor_emprestado", ValorEmprestado);
                sqlInsertEmprestimo.Parameters.AddWithValue("@valor_emprestado_total", ValorTotal);
                sqlInsertEmprestimo.Parameters.AddWithValue("@quantidade_parcela", QuantidadeParcela);
                sqlInsertEmprestimo.Parameters.AddWithValue("@valor_parcela", ValorParcela);
                sqlInsertEmprestimo.Parameters.AddWithValue("@valor_juros", ValorJurosMonetario);
                sqlInsertEmprestimo.Parameters.AddWithValue("@data_emprestimo", DataEmprestimo);
                sqlInsertEmprestimo.Parameters.AddWithValue("@data_pagar", DataPagamento);
                sqlInsertEmprestimo.Parameters.AddWithValue("@status_emprestimo", StatusEmprestimo);

                sqlInsertEmprestimo.ExecuteNonQuery();

                Funcoes.MensagemInformation("Dados do Empréstimo Inseridos com Sucesso!");

                conexao.Close();
            }
        }
    }
}
using Gerenciador_de_Emprestimos.Database;
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
        public string StatusEmprestimo { get; private set; }

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
            if (QuantidadeParcela == 0)
            {
                Funcoes.MensagemErro("Tentativa de Divisão por Zero!\nSe o cliente não parcelou, informe 1 no campo da Parcela.");

                return 0;
            }
            else
            {
                if (QuantidadeParcela >= 1 && QuantidadeParcela <= 20)
                {
                    ValorParcela = ValorTotal / QuantidadeParcela;
                }
                else if (QuantidadeParcela > 20)
                {
                    Funcoes.MensagemWarning("Quantidade de parcelas excede o limite máximo permitido (20). Verifique e tente novamente.");
                }
                else
                {
                    Funcoes.MensagemWarning("Quantidade de parcelas inválida. Verifique e tente novamente.");
                }
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

        public void InserirDadosEmorestimo()
        {
            // Lógica para inserir os dados do empréstimo no banco de dados
            // Utilizando o MySQL Connector/NET, para inserir no Banco de Dados MySQL os dados do empréstimo.

            string sqlInsertEmprestimo = "INSERT INTO emprestimosbd.cliente (codigo_cliente, valor_emprestado, valor_emprestado_total, valor_juros, data_emprestimo, data_pagar, status_emprestimo)  VALUES(@codigo_cliente, @valor_emprestado, @valor_emprestado_total, @valor_juros, @data_emprestimo, @data_pagar, @status_emprestimo)";
        }
    }
}

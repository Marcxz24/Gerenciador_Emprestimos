using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_Emprestimos.Services
{
    internal class EmprestimoServices
    {
        // Executa a cadeia de cálculos financeiros
        public void CalcularEmprestimoCompleto(EmprestimoDTO emprestimo)
        {
            CalcularJurosMonetario(emprestimo);
            SomarJurosAoTotal(emprestimo);
            DividirParcelas(emprestimo);
        }

        private void CalcularJurosMonetario(EmprestimoDTO emprestimo)
        {
            emprestimo.ValorJurosMonetario = emprestimo.ValorEmprestado * (emprestimo.ValorJurosPercentual / 100);
        }

        private void SomarJurosAoTotal(EmprestimoDTO emprestimo)
        {
            emprestimo.ValorTotal = emprestimo.ValorEmprestado + emprestimo.ValorJurosMonetario;
        }

        public bool DividirParcelas(EmprestimoDTO emprestimo)
        {
            // Validação de negócio: limite de parcelas
            if (emprestimo.QuantidadeParcela >= 1 && emprestimo.QuantidadeParcela <= 100)
            {
                emprestimo.ValorParcela = emprestimo.ValorTotal / emprestimo.QuantidadeParcela;
                return true;
            }
            else
            {
                Funcoes.MensagemWarning("Quantidade de parcelas inválida (Máximo 100).");
                return false;
            }
        }

        public void PrepararAtivacao(EmprestimoDTO emprestimo)
        {
            emprestimo.StatusEmprestimo = "ATIVO";
            emprestimo.DataEmprestimo = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
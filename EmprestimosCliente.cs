using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class EmprestimosCliente
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public decimal ValorEmprestado { get; set; }
        public decimal TaxaJuros { get; set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPagamento { get; set; }
        public string StatusEmprestimo { get; private set; }

        private decimal CalcularJuros()
        {
            return ValorEmprestado * TaxaJuros / 100;
        }

        public decimal CalcularValorTotal()
        {
            CalcularJuros();
            ValorTotal = ValorEmprestado + TaxaJuros;
            return ValorTotal;
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
    }
}

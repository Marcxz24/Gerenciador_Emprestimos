using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class EmprestimoDTO
    {
        // --- PROPRIEDADES DE IDENTIFICAÇÃO E ESTADO ---
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public string StatusEmprestimo { get;  set; } = "ATIVO";

        // PROPRIEDADE AUXILIAR PARA O METODO DE LISTAR EMPRESTIMOS ---
        public string NomeCliente { get; set;}

        // --- PROPRIEDADES FINANCEIRAS ---
        public decimal ValorEmprestado { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal ValorJurosPercentual { get; set; }
        public decimal ValorJurosMonetario { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorTotal { get; set; }
        public string ObservacoesEmprestimos { get; set; }
        public string TipoJuros { get; set; } // "Mensal" ou "Diario"

        // --- PROPRIEDADES DE DATA ---
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataVencimentoInicial { get; set; }

        // --- PROPRIEDADE AUXILIAR PARA O METODO DE LISTAR EMPRESTIMOS ---
    }
}

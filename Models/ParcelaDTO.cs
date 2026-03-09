using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class ParcelaDTO
    {
        // --- Identificação ---
        public int Codigo { get; set; }
        public int CodigoEmprestimo { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public int NumeroParcela { get; set; }

        // --- Valores Financeiros ---
        public decimal ValorEmprestimo { get; set; } // Valor base do contrato
        public decimal ValorParcela { get; set; }    // Valor atual da parcela (com juros se houver)
        public decimal ValorJuros { get; set; }      // Valor monetário do juro calculado
        public decimal PercentualJuros { get; set; } // % de juros aplicado
        public decimal ValorPago { get; set; }      // Total já amortizado nesta parcela

        // --- Datas e Status ---
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataUltimoCalculoJuros { get; set; }
        public string StatusParcela { get; set; }    // PAGA, ABERTA, ATRASADA
        public string TipoJuros { get; set; } // DIARIO, MENSAL
    }
}

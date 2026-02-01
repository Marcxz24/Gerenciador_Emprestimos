using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class Parcela
    {
        public int Codigo { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal PercentualJuros { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataUltimoCalculoJuros { get; set; }
        public string Status { get; set; }
        public string TipoJuros { get; set; }
    }
}

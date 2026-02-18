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
        public int CodigoParcela { get; set; }
        public int CodigoEmprestimo { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorEmprestimo { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorJuros { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public string StatusParcela { get; set; }
    }
}

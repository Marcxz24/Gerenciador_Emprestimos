using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class EmprestimosListaDTO
    {
        public int CodigoEmprestimo { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Juros { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
    }
}

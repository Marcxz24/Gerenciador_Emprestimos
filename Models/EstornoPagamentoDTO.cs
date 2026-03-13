using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class EstornoPagamentoDTO
    {
        public int? Codigo { get; set; }
        public int? CodigoParcela { get; set; }
        public int? CodigoEmprestimo { get; set; }
        public int? CodigoFuncionario { get; set; }
        public int? CodigoCliente { get; set; }

        // Usamos DateTime aqui porque o banco grava o momento exato (TIMESTAMP)
        public DateTime DataEstorno { get; set; }

        public decimal ValorEstornado { get; set; }
        public string MotivoEstorno { get; set; }

        // Propriedades Auxiliares (Opcionais - Úteis para exibir no Grid de Estorno)
        public string NomeFuncionario { get; set; }
        public int NumeroParcela { get; set; }
    }
}

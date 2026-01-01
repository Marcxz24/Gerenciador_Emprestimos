using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class PagamentoParcela
    {
        public int codigoEmprestimo {  get; set; }
        public int codigoParcela { get; set; }
        public decimal valorJuros { get; set; }
        public decimal valorTotal  { get; set; }

        public void RealizarPagamento()
        {
            string sql = @"
                          UPDATE emprestimosbd.conta_receber
                          SET
	                        valor_pago = @valor_pago,
                            data_pagamento = now(),
                            status_parcela = 'PAGA'
                          WHERE codigo = @codigo";
        }
    }
}

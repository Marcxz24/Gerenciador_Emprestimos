using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class EmprestimosConsulta
    {
        public DataTable ConsultaEmprestimos()
        {
            DataTable dataTable = new DataTable();

            string sql = @"SELECT codigo, codigo_cliente, valor_emprestado, valor_emprestado_total, quantidade_parcela, valor_parcela, valor_juros, status_emprestimo FROM emprestimosbd.emprestimos LIMIT 100";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            {
                using (var dataAdapter = new MySqlDataAdapter(sql, conexao))
                {
                    dataAdapter.Fill(dataTable);

                }
            }
            return dataTable;
        }
    }
}

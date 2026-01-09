using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class LoginService
    {
        public bool Login(string Username, string Passowrd)
        {
            
        }

        public bool ValidarUsuarioInativo(string usermame)
        {
            string sql = @"SELECT COUNT(*) FROM emprestimosbd.funcionario 
                            WHERE username = @username
                            AND situacao_funcionario = 'INATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@username", usermame);

                int countUserInativo = Convert.ToInt32(comando.ExecuteScalar());

                return countUserInativo > 0;
            }
        }
    }
}

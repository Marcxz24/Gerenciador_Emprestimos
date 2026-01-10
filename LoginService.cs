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
        public int CodigoUsuarioLogado { get; private set; }

        public bool LoginUsuario(string Username, string Passowrd, out int CodigoFuncionario)
        {
            CodigoFuncionario = 0;

            string sql = @"SELECT codigo, senha_hash, situacao_funcionario
                            FROM emprestimosbd.funcionario
                            WHERE username = @username";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@username", Username);

                using (var leia = comando.ExecuteReader())
                {
                    if (!leia.Read())
                    {
                        return false;
                    }

                    string senhaHashBanco = leia["senha_hash"].ToString();

                    bool senhaCorreta = BCrypt.Net.BCrypt.Verify(Passowrd, senhaHashBanco);

                    if (!senhaCorreta)
                    {
                        return false;
                    }

                    CodigoFuncionario = Convert.ToInt32(leia["codigo"]);
                    return true;
                }
            }
        }

        public string ObterUsernamePorCodigo(int codigoFuncionario)
        {
            string sql = @"SELECT username
                            FROM emprestimosbd.funcionario
                            WHERE codigo = @codigo
                            AND situacao_funcionario = 'ATIVO'";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoFuncionario);
                
                object resultado = comando.ExecuteScalar();

                return resultado == null ? null : resultado.ToString();
            }
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

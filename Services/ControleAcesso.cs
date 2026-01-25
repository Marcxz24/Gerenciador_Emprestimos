using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    public static class ControleAcesso
    {
        private static List<string> _telasPermitidas = new List<string>();

        public static void CarregarPrivilegios(int CodigoFuncionario)
        {
            _telasPermitidas.Clear();

            string sql = @"SELECT ts.form_name FROM funcionario_tela_privilegio fp
                            INNER JOIN telas_sistema ts ON ts.codigo = fp.codigo_tela
                            WHERE fp.codigo_funcionario = @codigo_funcionario
	                            AND fp.pode_acessar = 1";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo_funcionario", CodigoFuncionario);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _telasPermitidas.Add(reader.GetString("form_name"));
                    }
                }
            }
        }

        public static bool PodeAcessar(string formName)
        {
            return _telasPermitidas.Contains(formName);
        }
    }
}

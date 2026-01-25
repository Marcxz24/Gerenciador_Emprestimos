using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public static class PrivilegioAcaoRepository
    {
        public static Dictionary<string, bool> BuscarPrivilegios(int codigoFuncionario)
        {
            var privilegios = new Dictionary<string, bool>();

            string sql = @"SELECT pa.nome_acao_privilegio, fpa.permitido_acao 
                           FROM funcionario_privilegio_acao fpa
                            INNER JOIN privilegios_acao pa
	                            ON pa.codigo = fpa.codigo_acao_privilegio
                           WHERE fpa.codigo_funcionario = @codigo_funcionario";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionario);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string acao = reader.GetString("nome_acao_privilegio");
                        bool permtido = reader.GetBoolean("permtido_acao");

                        privilegios[acao] = permtido;
                    }
                }
            }

            return privilegios;
        }
    }
}

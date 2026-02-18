using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    // Classe estática para controle de acesso baseado em privilégios de tela
    public static class ControleAcesso
    {
        // lista estatica para armazenar as telas que são permitidas ao funcionário logado
        private static List<string> _telasPermitidas = new List<string>();

        // Método para carregar os privilégios de acesso do funcionário.
        public static void CarregarPrivilegios(int CodigoFuncionario)
        {
            // Limpa a lista de telas permitidas antes de carregar os privileégios.
            _telasPermitidas.Clear();

            // string SQL para selecionar as telas que o funcionário pode acessar, 1 pode acessar, 0 não pode acessar
            string sql = @"SELECT ts.form_name FROM funcionario_tela_privilegio fp
                            INNER JOIN telas_sistema ts ON ts.codigo = fp.codigo_tela
                            WHERE fp.codigo_funcionario = @codigo_funcionario
	                            AND fp.pode_acessar = 1";

            // Conecta ao banco de dados e executa a consulta para obter as telas permitidas para o funcionário logado
            using (var conexao = ConexaoBancoDeDados.Conectar())
            // Cria um comando SQL para selecionar as telas permitidas para o funcionário logado
            using (var comando = new MySqlCommand(sql, conexao))
            {
                // Adiciona o parâmetro do código do funcionário para a consulta SQL
                comando.Parameters.AddWithValue("@codigo_funcionario", CodigoFuncionario);

                // Executa a consulta e lê os resultados para preencher a lista de telas permitidas
                using (var reader = comando.ExecuteReader())
                {
                    // Enquanto houver registros retornados pela consulta, adiciona o nome da tela à lista de telas permitidas
                    while (reader.Read())
                    {
                        _telasPermitidas.Add(reader.GetString("form_name"));
                    }
                }
            }
        }

        // Método para verificar se o funcionário tem acesso a uma tela específica, comparando o nome da tela com a lista de telas permitidas
        public static bool PodeAcessar(string formName)
        {
            // Verifica se o nome da tela está presente na lista de telas permitidas para o funcionário logado
            return _telasPermitidas.Contains(formName);
        }
    }
}

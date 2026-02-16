using MySql.Data.MySqlClient;

namespace Gerenciador_de_Emprestimos.Database
{
    // Classe responsável pela conexão com o Banco de Dados.
    public class ConexaoBancoDeDados
    {
        // String privada que representa o caminho para a servidor, usuário, senha, e o banco de dados.
        private static string conexaoString = "server=localhost;port=3306;user id=emprestimo_user;password=tX#4pN9!cV7qL2yZ;database=emprestimosbd";

        public static string StringConexao => conexaoString;

        // Método estatico publico para abrir a conexão com o Banco de Dados.
        public static MySqlConnection Conectar()
        {
            // Váriavel conexao recebe uma nova MySQL Connection
            MySqlConnection conexao = new MySqlConnection(conexaoString);

            // Abre a conexão.
            conexao.Open();

            // retorna a conexão.
            return conexao;
        }
    }
}

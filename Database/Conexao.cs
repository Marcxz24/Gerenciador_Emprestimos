using MySql.Data.MySqlClient;

namespace Gerenciador_de_Emprestimos.Database
{
    public class ConexaoBancoDeDados
    {
        private static string conexaoString = "server=localhost;port=3306;user id=emprestimo_user;password=tX#4pN9!cV7qL2yZ;database=emprestimosbd";

        public static MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            return conexao;
        }
    }
}

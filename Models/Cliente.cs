using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gerenciador_de_Emprestimos.Models
{
    public class Cliente
    {
        // Variável global, que será utilizada para receber o código do cliente.
        public int CodigoCliente { get; set; }

        // Método booleano para realizar o cadastro do cliente. True se tiver algum erro. False se tiver sido um sucesso.
        public bool cadastrarCliente(string nomeCliente, string cpfCnpj, string genero, string estadoCivil, string endereco, string bairro, string cidade, string uf, int numeroResidencia, string cep, string celular, string email, string observacoes, string situacaoCadastral)
        {
            // Chama o método responsável por validar se já existe um CPF cadastrado.
            if (CpfJaCadastrado(cpfCnpj) == true)
            {
                // retorna true se tiver encontrado, encerrando o método.
                return true;
            }

            // String SQL responsável para criar o comando INSERT INTO no banco de dados, para registrar os clientes.
            string sqlInsert = @"INSERT INTO emprestimosbd.cliente 
                                (
	                                nome_cliente, 
	                                cpf_cnpj, 
                                    genero, 
                                    estado_civil, 
                                    endereco, 
                                    bairro, 
                                    cidade, 
                                    uf, 
                                    numero_residencia, 
                                    cep, 
                                    celular, 
                                    email, 
                                    observacoes, 
                                    situacao_cadastral, 
                                    imagem, 
                                    data_cadastro
                                )
                                VALUES
                                (
	                                @nome_cliente, 
                                    @cpf_cnpj, 
                                    @genero, 
                                    @estado_civil, 
                                    @endereco, 
                                    @bairro, 
                                    @cidade, 
                                    @uf, 
                                    @numero_residencia, 
                                    @cep, 
                                    @celular, 
                                    @email, 
                                    @observacoes, 
                                    @situacao_cadastral, 
                                    @imagem, 
                                    @data_cadastro
                                )";

            // Tenta executar o código que pode lançar uma exceção (Erro)
            try
            {
                // Abre a conexão com o Banco de Dados.
                using (var conexao = ConexaoBancoDeDados.Conectar())
                // Váriavel cmd recebe um novo comando SQL, passando a string INSERT e a conexão.
                using (var cmd = new MySqlCommand(sqlInsert, conexao))
                {
                    // variavel cmd recebe os parametros adicionando com o valor.
                    cmd.Parameters.AddWithValue("@nome_cliente", nomeCliente);
                    cmd.Parameters.AddWithValue("@cpf_cnpj", cpfCnpj);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.Parameters.AddWithValue("@estado_civil", estadoCivil);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@uf", uf);
                    cmd.Parameters.AddWithValue("@numero_residencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@celular", celular);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@observacoes", observacoes);
                    cmd.Parameters.AddWithValue("@situacao_cadastral", situacaoCadastral);
                    cmd.Parameters.AddWithValue("@imagem", DBNull.Value);
                    cmd.Parameters.AddWithValue("@data_cadastro", DateTime.Now);

                    // Execita o comando no banco de dados.
                    cmd.ExecuteNonQuery();

                    // cmd cria um novo comando de texto, para receber o Código do ultimo cliente adicionado.
                    cmd.CommandText = "SELECT @@IDENTITY";

                    // Variavel global CodigoCliente recebe o valor que recebeu, ao executar a query acima.
                    CodigoCliente =  Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            // Se der erro, ele executa uma Exceção (Erro) do MySQL e encerra o método.
            catch (MySqlException)
            {
                // Retorna true encerrando o método.
                return true;
            }

            // Retorna false, completando o Método se ele tiver sido executado com sucesso.
            return false;
        }

        // Método Booleando para realizar a ediçaõ de um cliente.
        public bool EditarCliente(int codigoCliente, string nomeCliente, string cpfCnpj, string genero, string estadoCivil, string endereco, string bairro, string cidade, string uf, int numeroResidencia, string cep, string celular, string email, string observacoes, string situacaoCadastral)
        {
            // String que irá receber o UPDATE responsável por editar um cliente.
            string sqlUpdate = @"UPDATE emprestimosbd.cliente 
                                    SET 
                                        nome_cliente = @nome_cliente, 
                                        cpf_cnpj = @cpf_cnpj, 
                                        genero = @genero, 
                                        estado_civil = @estado_civil, 
                                        endereco = @endereco, 
                                        bairro = @bairro, 
                                        cidade = @cidade, 
                                        uf = @uf, 
                                        numero_residencia = @numero_residencia, 
                                        cep = @cep, 
                                        celular = @celular, 
                                        email = @email, 
                                        observacoes = @observacoes, 
                                        situacao_cadastral = @situacao_cadastral 
                                    WHERE codigo = @codigo";

            // Tenta executar o código abaixo, e se falhar lança uma nova exceção MySQL
            try
            {
                // conexao recebe a conexão aberta com o Banco de Dados.
                using (var conexao = ConexaoBancoDeDados.Conectar())
                // Variavel cmd recebe um novo comando MySQL, recebendo a string de Edição, com a conexão do MySQL.
                using (var cmd = new MySqlCommand(sqlUpdate, conexao))
                {
                    // cmd recebe com os parametros adicionando com o valor.
                    cmd.Parameters.AddWithValue("@codigo", codigoCliente);
                    cmd.Parameters.AddWithValue("@nome_cliente", nomeCliente);
                    cmd.Parameters.AddWithValue("@cpf_cnpj", cpfCnpj);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.Parameters.AddWithValue("@estado_civil", estadoCivil);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@uf", uf);
                    cmd.Parameters.AddWithValue("@numero_residencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@celular", celular);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@observacoes", observacoes);
                    cmd.Parameters.AddWithValue("@situacao_cadastral", situacaoCadastral);

                    // Executa o comando se não houve nenhum erro.
                    cmd.ExecuteNonQuery();
                }
            }
            // Se houve erro, lança uma nova exceção MySQL.
            catch (MySqlException)
            {
                // Retorna true se houve erro.
                return true;
            }

            // Retorna false se não houve nenhum erro.
            return false;
        }

        // Método Booleando que valida se o CPF já pertence a um cliente.
        public bool CpfJaCadastrado(string cpf)
        {
            // Variavel sql tipo string, que conta a quantidade de linhas retornadas de um cpf.
            // 1 - Se já exisitr o CPF passado form cadastrado.
            // 0 - Se o CPF passado do form não estiver cadastrado.
            string sql = "SELECT COUNT(*) FROM emprestimosbd.cliente WHERE cpf_cnpj = @cpf_cnpj";

            // variavel conexao recebe a conexão com o Banco de Dados aberta.
            using (var conexao = ConexaoBancoDeDados.Conectar())
            // variavel comando recebe um novo comando MySQL recebendo a variavel sql e conexao como argumenos.
            using (var comando = new MySqlCommand(sql, conexao))
            {
                // comando recebe os paremetros e adicionando com valor o cpf.
                comando.Parameters.AddWithValue("@cpf_cnpj", cpf);

                // variavel count que recebe a contagem das linhas (0 se não existir, 1 ou mais se existir)
                int count = Convert.ToInt32(comando.ExecuteScalar());

                // Encerra o método de a contagem for maior que 0
                return count > 0;
            }
        }
    }
}
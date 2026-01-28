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
        public int CodigoCliente { get; set; }

        public bool cadastrarCliente(string nomeCliente, string cpfCnpj, string genero, string estadoCivil, string endereco, string bairro, string cidade, string uf, int numeroResidencia, string cep, string celular, string email, string observacoes, string situacaoCadastral)
        {
            if (CpfJaCadastrado(cpfCnpj) == true)
            {
                return true;
            }

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

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var cmd = new MySqlCommand(sqlInsert, conexao))
                {
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
                    cmd.Parameters.AddWithValue("data_cadastro", DateTime.Now);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT @@IDENTITY";

                    CodigoCliente =  Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (MySqlException)
            {
                return true;
            }

            return false;
        }

        // --- MÉTODO: Verifica se o CPF informado já pertence a algum funcionário ---
        public bool CpfJaCadastrado(string cpf)
        {
            string sql = "SELECT COUNT(*) FROM emprestimosbd.cliente WHERE cpf_cnpj = @cpf_cnpj";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@cpf_cnpj", cpf);

                // Retorna o número de registros encontrados (0 se não existir, 1 ou mais se existir)
                int count = Convert.ToInt32(comando.ExecuteScalar());

                return count > 0;
            }
        }
    }
}

using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class Funcionario
    {
        public int Codigo { get; set; }

        public bool CadastrarFuncionario(string nome, string cpf, string sexo, string estadoCivil, string username, string senha, string telefone, string cidade, string situacao)
        {
            if (CpfJaCadastrado(cpf))
            {
                return false;
            }

            string sql = @"INSERT INTO funcionario
                            (
                            nome_funcionario,
                            cpf_funcionario,
                            sexo_funcionario,
                            funcionario_estado_civil,
                            username,
                            senha_hash,
                            telefone_funcionario,
                            cidade_funcionario,
                            situacao_funcionario,
                            data_cadastro
                            )
                            VALUES
                            (
                            @nome_funcionario,
                            @cpf_funcionario,
                            @sexo_funcionario,
                            @funcionario_estado_civil,
                            @username,
                            @senha_hash,
                            @telefone_funcionario,
                            @cidade_funcionario,
                            @situacao_funcionario,
                            @data_cadastro
                            )";

            try 
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome_funcionario", nome);
                    comando.Parameters.AddWithValue("@cpf_funcionario", cpf);
                    comando.Parameters.AddWithValue("@sexo_funcionario", sexo);
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", estadoCivil);
                    comando.Parameters.AddWithValue("@username", username);
                    comando.Parameters.AddWithValue("@senha_hash", senha);
                    comando.Parameters.AddWithValue("@telefone_funcionario", telefone);
                    comando.Parameters.AddWithValue("@cidade_funcionario", cidade);
                    comando.Parameters.AddWithValue("@situacao_funcionario", situacao);
                    comando.Parameters.AddWithValue("@data_cadastro", DateTime.Now);

                    comando.ExecuteNonQuery();

                    Funcoes.MensagemInformation("Cliente Cadastrado com Sucesso!");

                    return true;
                }
            }
            catch(MySqlException)
            {
                return false;
            }
        }

        public bool CpfJaCadastrado(string cpf)
        {
            string sql = "SELECT COUNT(*) FROM emprestimosbd.funcionario WHERE cpf_funcionario = @cpf_funcionario";
            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@cpf_funcionario", cpf);
                int count = Convert.ToInt32(comando.ExecuteScalar());

                return count > 0;
            }
        }
    }
}

using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class Lembrete
    {
        public int Codigo { get; set; }
        public int CodigoFuncionario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }

        public void CriarLembrete()
        {
            // Lógica para criar um lembrete
            string sql = @"
                            INSERT INTO emprestimosbd.lembrete
                            (   
                                codigo_funcionario, 
                                titulo, 
                                descricao, 
                                situacao
                            )
                            VALUES
                            ( 
                                @Codigo_funcionario, 
                                @Titulo, 
                                @Descricao, 
                                @Situacao   
                            )";

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo_funcionario", CodigoFuncionario);
                    comando.Parameters.AddWithValue("@titulo", Titulo);
                    comando.Parameters.AddWithValue("@descricao", Descricao);
                    comando.Parameters.AddWithValue("@situacao", Situacao);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceção, por exemplo, logar o erro ou mostrar uma mensagem ao usuário
                throw new Exception("Erro ao criar lembrete: " + ex.Message);
            }
        }

        public void EditarLembrete()
        {
            // Lógica para editar um lembrete
        }

        public void ExcluirLembrete()
        {
            // Lógica para excluir um lembrete
        }
    }
}

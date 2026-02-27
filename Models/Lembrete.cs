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
                    comando.Parameters.AddWithValue("@titulo", this.Titulo ?? "Novo Lembrete");
                    comando.Parameters.AddWithValue("@descricao", this.Descricao ?? "");
                    comando.Parameters.AddWithValue("@situacao", "ATIVO");

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
            int codigoLembrete = Codigo;
            string tituloAtualizado = Titulo;
            string descricaoAtualizado = Descricao;

            string sql = @"
                            UPDATE emprestimosbd.lembrete
                            SET 
                                titulo = @titulo, 
                                descricao = @descricao 
                            WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoLembrete);
                cmd.Parameters.AddWithValue("@titulo", tituloAtualizado);
                cmd.Parameters.AddWithValue("@descricao", descricaoAtualizado);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirLembrete()
        {
            int codigoLembrete = Codigo;
            string situacao = "Excluído";

            string sql = @"
                            UPDATE emprestimosbd.lembrete
                            SET 
                                situacao = @situacao 
                            WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoLembrete);
                cmd.Parameters.AddWithValue("@situacao", situacao);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Lembrete> ListarLembretes(int codigoFuncionarioLogado)
        {
            List<Lembrete> lembretes = new List<Lembrete>();

            string sql = @"SELECT codigo, codigo_funcionario, titulo, descricao, situacao 
	                           FROM emprestimosbd.lembrete 
	                           WHERE codigo_funcionario = @codigo_funcionario
                               AND situacao = 'ATIVO'";

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo_funcionario", codigoFuncionarioLogado);

                    using (var dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lembrete item = new Lembrete();

                            item.Codigo = Convert.ToInt32(dr["codigo"]);
                            item.CodigoFuncionario = Convert.ToInt32(dr["codigo_funcionario"]);
                            item.Titulo = dr["titulo"].ToString();
                            item.Descricao = dr["descricao"].ToString();
                            item.Situacao = dr["situacao"].ToString();

                            lembretes.Add(item);
                        }
                    }
                }

                return lembretes;
            }
            catch (Exception ex)
            {
                // Lidar com exceção, por exemplo, logar o erro ou mostrar uma mensagem ao usuário
                throw new Exception("Erro ao listar lembretes: " + ex.Message);
            }
        }
    }
}

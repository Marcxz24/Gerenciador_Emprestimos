using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class LembreteDAO
    {
        public List<LembreteDTO> ListarLembretes(int codigoFuncionarioLogado)
        {
            List<LembreteDTO> lembretes = new List<LembreteDTO>();

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
                            LembreteDTO item = new LembreteDTO();

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

        public void CriarLembrete(LembreteDTO dto)
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
                    comando.Parameters.AddWithValue("@codigo_funcionario", dto.CodigoFuncionario);
                    comando.Parameters.AddWithValue("@titulo", dto.Titulo ?? "Novo Lembrete");
                    comando.Parameters.AddWithValue("@descricao", dto.Descricao ?? "");
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

        public void EditarLembrete(LembreteDTO dto)
        {
            string sql = @"
                            UPDATE emprestimosbd.lembrete
                            SET 
                                titulo = @titulo, 
                                descricao = @descricao 
                            WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.Codigo);
                cmd.Parameters.AddWithValue("@titulo", dto.Titulo);
                cmd.Parameters.AddWithValue("@descricao", dto.Descricao);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditarLembrete(int codigoLembrete, string tituloAtualizado, string descricaoAtualizado)
        {
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

        public void ExcluirLembrete(int codigoLembrete)
        {
            string sql = @"
                            UPDATE emprestimosbd.lembrete
                            SET 
                                situacao = @situacao 
                            WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoLembrete);
                cmd.Parameters.AddWithValue("@situacao", "Excluído");

                cmd.ExecuteNonQuery();
            }
        }
    }
}

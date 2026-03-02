using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Utils;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class ModeloMensagemDAO
    {
        public int codigoModeloMensagem { get; set; }
        public string descricao { get; set; }
        public string mensagem { get; set; }
        public string situacao { get; set; }

        public void CadastrarModeloMensagem(string descricao, string mensagem, string situacao)
        {
            string sql = @"
                            INSERT INTO emprestimosbd.modelo_mensagem
                            (
                                descricao, 
                                mensagem, 
                                situacao
                            )
                            VALUES
                            (
	                            @descricao, 
                                @mensagem, 
                                @situacao
                            )";

            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@mensagem", mensagem);
                cmd.Parameters.AddWithValue("@situacao", situacao);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID()";

                codigoModeloMensagem = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void EditarModeloMensagem(int codigoModeloMsg, string descricao, string mensagem, string situacao)
        {
            string sql = @"
                            UPDATE emprestimosbd.modelo_mensagem
                            SET
	                            descricao = @descricao,
                                mensagem = @mensagem, 
                                situacao = @situacao
                            WHERE codigo = @codigo";

            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoModeloMsg);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@mensagem", mensagem);
                cmd.Parameters.AddWithValue("@situacao", situacao);

                cmd.ExecuteNonQuery();
            }
        }

        public void SelecionarModeloPorCodigo(int codigoModeloMsg)
        {
            string sql = @"
                            SELECT 
                                descricao, 
                                mensagem, 
                                situacao
                            FROM emprestimosbd.modelo_mensagem
                            WHERE codigo = @codigo";
            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoModeloMsg);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        descricao = reader.GetString("descricao");
                        mensagem = reader.GetString("mensagem");
                        situacao = reader.GetString("situacao");
                    }
                }
            }
        }

        public DataTable ListarTodosOsModelos(int? codigo, string descricao, string situacao)
        {
            DataTable dt = new DataTable();

            string sql = @"
                            SELECT 
	                            codigo, 
                                descricao, 
                                mensagem, 
                                situacao
                            FROM emprestimosbd.modelo_mensagem
                            WHERE 1 = 1";

            if (codigo.HasValue)
            {
                sql += " AND codigo = @codigo";
            }

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                sql += " AND descricao LIKE @descricao";
            }

            if (!string.IsNullOrWhiteSpace(situacao) && situacao != "TODOS")
            {
                sql += " AND situacao = @situacao";
            }

            try
            {
                using (var conn = ConexaoBancoDeDados.Conectar())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (sql.Contains("@codigo"))
                        cmd.Parameters.AddWithValue("@codigo", codigo.Value);

                    if (sql.Contains("@descricao"))
                        cmd.Parameters.AddWithValue("@descricao", "%" + descricao + "%");

                    if (sql.Contains("@situacao"))
                        cmd.Parameters.AddWithValue("@situacao", situacao);

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Funcoes.MensagemErro("Ocorreu um erro ao listar os modelos de mensagem.\n\nDetalhes: " + ex.Message);
                Serilog.Log.Error("Ocorreu um erro ao listar os modelos de mensagem.\n\nDetalhes: " + ex.Message);
            }

            return dt;
        }

        public ModeloMensagemDAO SelecionarModeloMensagemPorCodigo(int codigoModeloMsg)
        {
            string sql = @"
                            SELECT 
                                descricao, 
                                mensagem, 
                                situacao
                            FROM emprestimosbd.modelo_mensagem
                            WHERE codigo = @codigo";

            using (var conn = ConexaoBancoDeDados.Conectar())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigoModeloMsg);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ModeloMensagemDAO
                        {
                            codigoModeloMensagem = codigoModeloMsg,
                            descricao = reader.GetString("descricao"),
                            mensagem = reader.GetString("mensagem"),
                            situacao = reader.GetString("situacao")
                        };
                    }
                }
            }

            return null;
        }
    }
}
using Gerenciador_de_Emprestimos.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    internal class SelecionarFuncionario
    {
        public int codigo { get; set; }
        public string nome_funcionario { get; set; }
        public string cpf_funcionario { get; set; }
        public string sexo_funcionario { get; set; }
        public string funcionario_estado_civil { get; set; }
        public string username { get; set; }
        public string senha_hash { get; set; }
        public string telefone_funcionario { get; set; }
        public string cidade_funcionario { get; set; }
        public string situacao_funcionario { get; set; }

        public SelecionarFuncionario SelecionarFuncionarioPorCodigo(int CodigoFuncionario)
        {
            string sql = @"SELECT * FROM emprestimosbd.funcionario WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", CodigoFuncionario);

                using (var reader = comando.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new SelecionarFuncionario
                    {
                        codigo = reader.GetInt32("codigo"),
                        nome_funcionario = reader.GetString("nome_funcionario"),
                        cpf_funcionario = reader.GetString("cpf_funcionario"),
                        sexo_funcionario = reader.GetString("sexo_funcionario"),
                        funcionario_estado_civil = reader.GetString("funcionario_estado_civil"),
                        username = reader.GetString("username"),
                        senha_hash = reader.GetString("senha_hash"),
                        telefone_funcionario = reader.GetString("telefone_funcionario"),
                        cidade_funcionario = reader.GetString("cidade_funcionario"),
                        situacao_funcionario = reader.GetString("situacao_funcionario"),
                    };
                }
            }
        }

        public DataTable ListarFuncionarios(int Codigo, string nomeFuncionario, string cpf, string sexo, string estadoCivil, string telefoneFuncionario, string cidadeFuncionario, string situacaoFuncionario)
        {
            DataTable dataTable = new DataTable();

            string sql = @"SELECT 
                                codigo, 
                                nome_funcionario, 
                                cpf_funcionario, 
                                sexo_funcionario, 
                                funcionario_estado_civil, 
                                username, 
                                telefone_funcionario, 
                                cidade_funcionario, 
                                situacao_funcionario 
                            FROM emprestimosbd.funcionario";
                           
            string sqlFiltros = @" WHERE 1 = 1";

            if (Codigo > 0)
            {
                sqlFiltros += " AND codigo = @codigo";
            }

            if (!string.IsNullOrWhiteSpace(nomeFuncionario))
            {
                sqlFiltros += " AND nome_funcionario LIKE @nome_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                sqlFiltros += " AND cpf_funcionario = @cpf_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(sexo))
            {
                sqlFiltros += " AND sexo_funcionario = @sexo_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(estadoCivil))
            {
                sqlFiltros += " AND funcionario_estado_civil = @funcionario_estado_civil";
            }
            
            if (!string.IsNullOrWhiteSpace(telefoneFuncionario))
            {
                sqlFiltros += " AND telefone_funcionario = @telefone_funcionario";
            }
            
            if (!string.IsNullOrWhiteSpace(cidadeFuncionario))
            {
                sqlFiltros += " AND cidade_funcionario = @cidade_funcionario";
            }

            if (!string.IsNullOrWhiteSpace(situacaoFuncionario))
            {
                sqlFiltros += " AND situacao_funcionario = @situacao_funcionario";
            }

            string sqlFinal = sql + sqlFiltros;

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sqlFinal, conexao))
            {
                if (Codigo > 0)
                {
                    comando.Parameters.AddWithValue("@codigo", Codigo);
                }

                if (!string.IsNullOrWhiteSpace(nomeFuncionario))
                {
                    comando.Parameters.AddWithValue("@nome_funcionario", "%" + nomeFuncionario + "%");
                }

                if (!string.IsNullOrWhiteSpace(cpf))
                {
                    comando.Parameters.AddWithValue("@cpf_funcionario", cpf);
                }

                if (!string.IsNullOrWhiteSpace(sexo))
                {
                    comando.Parameters.AddWithValue("@sexo_funcionario", sexo);
                }

                if (!string.IsNullOrWhiteSpace(estadoCivil))
                {
                    comando.Parameters.AddWithValue("@funcionario_estado_civil", estadoCivil);
                }
                
                if (!string.IsNullOrWhiteSpace(telefoneFuncionario))
                {
                    comando.Parameters.AddWithValue("@telefone_funcionario", telefoneFuncionario);
                }
                
                if (!string.IsNullOrWhiteSpace(cidadeFuncionario))
                {
                    comando.Parameters.AddWithValue("@cidade_funcionario", cidadeFuncionario);
                }

                if (!string.IsNullOrWhiteSpace(situacaoFuncionario))
                {
                    comando.Parameters.AddWithValue("@situacao_funcionario", situacaoFuncionario);
                }

                using (var dataAdapter = new MySqlDataAdapter(comando))
                {
                    dataAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}

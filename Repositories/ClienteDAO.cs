using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class ClienteDAO
    {
        // Variável global, que será utilizada para receber o código do cliente.
        public int CodigoCliente { get; set; }

        // Método booleano para realizar o cadastro do cliente. True se tiver algum erro. False se tiver sido um sucesso.
        public bool cadastrarCliente(ClienteDTO cliente)
        {
            // Chama o método responsável por validar se já existe um CPF cadastrado.
            if (CpfJaCadastrado(cliente.cpf_cnpj) == true)
            {
                // retorna true se tiver encontrado, encerrando o método.
                return true;
            }

            // String SQL responsável para criar o comando INSERT INTO no banco de dados, para registrar os clientes.
            string sqlInsert = @"INSERT INTO emprestimosbd.cliente 
                                    (
                                        nome_cliente, 
                                        nome_fantasia, -- Coluna referente a empresa
                                        cpf_cnpj, 
                                        tipo_ie, -- Coluna referente a empresa
                                        inscricao_estadual, -- Coluna referente a empresa
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
                                        @nome_fantasia, 
                                        @cpf_cnpj, 
                                        @tipo_ie, 
                                        @inscricao_estadual, 
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
                    cmd.Parameters.AddWithValue("@nome_cliente", cliente.nome_cliente);
                    cmd.Parameters.AddWithValue("@nome_fantasia", cliente.nome_fantasia);
                    cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.cpf_cnpj);

                    // Dados Fiscais da empresa como IE e Contribuinte
                    cmd.Parameters.AddWithValue("@tipo_ie", cliente.tipo_ie);
                    cmd.Parameters.AddWithValue("@inscricao_estadual", cliente.inscricao_estadual);

                    // REGRAS DO BANCO: Tratamento para permitir valores Nulos (Pessoa Jurídica)
                    cmd.Parameters.AddWithValue("@genero", (object)cliente.genero ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado_civil", (object)cliente.estado_civil ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@bairro", cliente.bairro);
                    cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
                    cmd.Parameters.AddWithValue("@uf", cliente.uf);
                    cmd.Parameters.AddWithValue("@numero_residencia", cliente.numero_residencia);
                    cmd.Parameters.AddWithValue("@cep", cliente.cep);
                    cmd.Parameters.AddWithValue("@celular", cliente.celular);
                    cmd.Parameters.AddWithValue("@email", cliente.email);
                    cmd.Parameters.AddWithValue("@observacoes", cliente.observacoes);
                    cmd.Parameters.AddWithValue("@situacao_cadastral", cliente.situacao_cadastral);

                    // REGRA DA IMAGEM: Tratamento para cliente sem foto
                    cmd.Parameters.AddWithValue("@imagem", (object)cliente.imagem ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@data_cadastro", DateTime.Now);

                    // Executa o comando no banco de dados.
                    cmd.ExecuteNonQuery();

                    // cmd cria um novo comando de texto, para receber o Código do ultimo cliente adicionado.
                    cmd.CommandText = "SELECT @@IDENTITY";

                    // Variavel global CodigoCliente recebe o valor que recebeu, ao executar a query acima.
                    CodigoCliente = Convert.ToInt32(cmd.ExecuteScalar());
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
        // REGRA APLICADA: Substituição de 15 variáveis pelo objeto ClienteDTO
        public bool EditarCliente(ClienteDTO cliente)
        {
            // String que irá receber o UPDATE responsável por editar um cliente.
            // REGRA APLICADA: Adicionado o campo 'imagem = @imagem' no UPDATE para permitir trocar a foto
            string sqlUpdate = @"UPDATE emprestimosbd.cliente 
                                    SET 
                                        nome_cliente = @nome_cliente,
                                        nome_fantasia = @nome_fantasia, 
                                        cpf_cnpj = @cpf_cnpj, 
                                        tipo_ie = @tipo_ie,        
                                        inscricao_estadual = @inscricao_estadual, 
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
                                        situacao_cadastral = @situacao_cadastral,
                                        imagem = @imagem
                                    WHERE codigo = @codigo";

            // Tenta executar o código abaixo, e se falhar lança uma nova exceção MySQL
            try
            {
                // conexao recebe a conexão aberta com o Banco de Dados.
                using (var conexao = ConexaoBancoDeDados.Conectar())
                // Variavel cmd recebe um novo comando MySQL, recebendo a string de Edição, com a conexão do MySQL.
                using (var cmd = new MySqlCommand(sqlUpdate, conexao))
                {
                    // cmd recebe com os parametros adicionando com o valor diretamente do DTO.
                    cmd.Parameters.AddWithValue("@codigo", cliente.codigo);
                    cmd.Parameters.AddWithValue("@nome_cliente", cliente.nome_cliente);
                    cmd.Parameters.AddWithValue("@cpf_cnpj", cliente.cpf_cnpj);

                    // Parametros referentes ao cadastro da empresa.
                    cmd.Parameters.AddWithValue("@nome_fantasia", cliente.nome_fantasia);
                    cmd.Parameters.AddWithValue("@tipo_ie", cliente.tipo_ie);
                    cmd.Parameters.AddWithValue("@inscricao_estadual", cliente.inscricao_estadual);

                    // REGRAS DO BANCO: Tratamento para permitir valores Nulos
                    cmd.Parameters.AddWithValue("@genero", (object)cliente.genero ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado_civil", (object)cliente.estado_civil ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
                    cmd.Parameters.AddWithValue("@bairro", cliente.bairro);
                    cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
                    cmd.Parameters.AddWithValue("@uf", cliente.uf);
                    cmd.Parameters.AddWithValue("@numero_residencia", cliente.numero_residencia);
                    cmd.Parameters.AddWithValue("@cep", cliente.cep);
                    cmd.Parameters.AddWithValue("@celular", cliente.celular);
                    cmd.Parameters.AddWithValue("@email", cliente.email);
                    cmd.Parameters.AddWithValue("@observacoes", cliente.observacoes);
                    cmd.Parameters.AddWithValue("@situacao_cadastral", cliente.situacao_cadastral);

                    // REGRA DA IMAGEM: Tratamento para salvar/atualizar nulo
                    cmd.Parameters.AddWithValue("@imagem", (object)cliente.imagem ?? DBNull.Value);

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

        public bool CpfDeClienteCadastrado(int codigoCliente, string cpf)
        {
            string sql = @"
                            SELECT COUNT(*) FROM emprestimosbd.cliente
                            WHERE cpf_cnpj = @cpf_cnpj
                                AND codigo <> @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoCliente);
                comando.Parameters.AddWithValue("@cpf_cnpj", cpf);

                int count = Convert.ToInt32(comando.ExecuteScalar());

                return count > 0;
            }
        }

        // --- MÉTODO: Lista clientes para o DataGrid (Filtrável por nome ou CPF) ---
        public DataTable ListarClientes(ClienteDTO cliente)
        {
            DataTable dt = new DataTable();
            // Se o filtro não estiver vazio, adicionamos a cláusula WHERE
            string sql = @"SELECT codigo, nome_cliente, nome_fantasia, genero, celular, situacao_cadastral, cpf_cnpj FROM cliente";

            string filtro = " WHERE 1 = 1";

            if (cliente.codigo > 0)
                filtro += " AND codigo = @codigo";

            if (!string.IsNullOrWhiteSpace(cliente.nome_cliente))
                filtro += " AND nome_cliente LIKE @nome_cliente";

            if (!string.IsNullOrWhiteSpace(cliente.situacao_cadastral))
                filtro += " AND situacao_cadastral = @situacao_cadastral";

            if (!string.IsNullOrWhiteSpace(cliente.genero))
                filtro += " AND genero = @genero";

            if (!string.IsNullOrWhiteSpace(cliente.cpf_cnpj))
                filtro += " AND cpf_cnpj = @cpf_cnpj";

            if (!string.IsNullOrWhiteSpace(cliente.celular))
                filtro += " AND celular = @celular";

            if (!string.IsNullOrWhiteSpace(cliente.cidade))
                filtro += " AND cidade = @cidade";

            if (!string.IsNullOrWhiteSpace(cliente.endereco))
                filtro += " AND endereco = @endereco";

            if (!string.IsNullOrWhiteSpace(cliente.bairro))
                filtro += " AND bairro = @bairro";

            if (cliente.numero_residencia > 0)
                filtro += " AND numero_residencia = @numero_residencia";

            if (!string.IsNullOrWhiteSpace(cliente.uf))
                filtro += " AND uf = @uf";

            string sqlFinal = sql + filtro;

            try
            {
                using (var conexao = ConexaoBancoDeDados.Conectar())
                using (var comando = new MySqlCommand(sqlFinal, conexao))
                {
                    if (cliente.codigo > 0)
                        comando.Parameters.AddWithValue("@codigo", cliente.codigo);

                    if (!string.IsNullOrWhiteSpace(cliente.nome_cliente))
                        comando.Parameters.AddWithValue("@nome_cliente", "%" + cliente.nome_cliente + "%");

                    if (!string.IsNullOrWhiteSpace(cliente.situacao_cadastral))
                        comando.Parameters.AddWithValue("@situacao_cadastral", cliente.situacao_cadastral);

                    if (!string.IsNullOrWhiteSpace(cliente.genero))
                        comando.Parameters.AddWithValue("@genero", cliente.genero);

                    if (!string.IsNullOrWhiteSpace(cliente.cpf_cnpj))
                        comando.Parameters.AddWithValue("@cpf_cnpj", cliente.cpf_cnpj);

                    if (!string.IsNullOrWhiteSpace(cliente.celular))
                        comando.Parameters.AddWithValue("@celular", cliente.celular);

                    if (!string.IsNullOrWhiteSpace(cliente.cidade))
                        comando.Parameters.AddWithValue("@cidade", cliente.cidade);

                    if (!string.IsNullOrWhiteSpace(cliente.endereco))
                        comando.Parameters.AddWithValue("@endereco", cliente.endereco);

                    if (!string.IsNullOrWhiteSpace(cliente.bairro))
                        comando.Parameters.AddWithValue("@bairro", cliente.bairro);

                    if (cliente.numero_residencia > 0)
                        comando.Parameters.AddWithValue("@numero_residencia", cliente.numero_residencia);

                    if (!string.IsNullOrWhiteSpace(cliente.uf))
                        comando.Parameters.AddWithValue("@uf", cliente.uf);

                    using (var data = new MySqlDataAdapter(comando))
                    {
                        data.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar clientes: " + ex.Message);
            }
            return dt;
        }

        // --- MÉTODO: Busca os dados completos de um cliente por CÓDIGO ---
        public ClienteDTO BuscarClientePorCodigo(int codigoCliente)
        {
            var sql = "SELECT * FROM cliente WHERE codigo = @codigo";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@codigo", codigoCliente);
                return MapearReaderParaObjeto(comando);
            }
        }

        // --- MÉTODO: Busca por NOME (Útil para pesquisas rápidas) ---
        public ClienteDTO BuscarClientePorNome(string nomeCliente)
        {
            var sql = "SELECT * FROM cliente WHERE nome_cliente LIKE @nome_cliente LIMIT 1";

            using (var conexao = ConexaoBancoDeDados.Conectar())
            using (var comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@nome_cliente", "%" + nomeCliente + "%");
                return MapearReaderParaObjeto(comando);
            }
        }

        // --- MÉTODO PRIVADO: O "Coração" do DAO (Mapeia o banco para o Objeto) ---
        private ClienteDTO MapearReaderParaObjeto(MySqlCommand cmd)
        {
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new ClienteDTO
                    {
                        codigo = reader.GetInt32("codigo"),
                        nome_cliente = reader.GetString("nome_cliente"),
                        nome_fantasia = reader.IsDBNull(reader.GetOrdinal("nome_fantasia")) ? null : reader.GetString("nome_fantasia"),
                        tipo_ie = reader.IsDBNull(reader.GetOrdinal("tipo_ie"))? null : reader.GetString("tipo_ie"),
                        inscricao_estadual = reader.IsDBNull(reader.GetOrdinal("inscricao_estadual")) ? null : reader.GetString("inscricao_estadual"),
                        cpf_cnpj = reader.GetString("cpf_cnpj"),
                        // Usando ternário para campos que podem ser nulos no banco
                        genero = reader.IsDBNull(reader.GetOrdinal("genero")) ? null : reader.GetString("genero"),
                        estado_civil = reader.IsDBNull(reader.GetOrdinal("estado_civil")) ? null : reader.GetString("estado_civil"),
                        endereco = reader.GetString("endereco"),
                        bairro = reader.GetString("bairro"),
                        cidade = reader.GetString("cidade"),
                        uf = reader.GetString("uf"),
                        numero_residencia = reader.GetInt32("numero_residencia"),
                        cep = reader.GetString("cep"),
                        celular = reader.GetString("celular"),
                        email = reader.GetString("email"),
                        observacoes = reader.GetString("observacoes"),
                        situacao_cadastral = reader.GetString("situacao_cadastral"),
                        data_cadastro = reader.GetDateTime("data_cadastro"),
                        // Mapeamento da imagem caso exista
                        imagem = reader.IsDBNull(reader.GetOrdinal("imagem")) ? null : (byte[])reader["imagem"]
                    };
                }
            }
            return null;
        }
    }
}
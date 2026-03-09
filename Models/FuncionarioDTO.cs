namespace Gerenciador_de_Emprestimos.Models
{
    public class FuncionarioDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Username { get; set; }
        public string SenhaHash { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int NumeroResidencia { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    /// <summary>
    /// DTO para representar informações básicas de uma empresa (Pessoa Jurídica).
    /// Utilizado para operações de cadastro e exibição de dados da empresa.
    /// </summary>
    public class EmpresaDTO
    {
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string ddd_telefone_1 { get; set; }
        public string email { get; set; }
    }
}

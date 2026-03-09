using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class ClienteDTO
    {
        // Identificação Única
        public int codigo { get; set; }

        // Dados Principais (Física e Jurídica)
        public string nome_cliente { get; set; } // Nome da Pessoa Física ou Razão Social
        public string? nome_fantasia { get; set; } // Opcional para Pessoa Física
        public string cpf_cnpj { get; set; }

        public string? tipo_ie { get; set; } // Contribuinte, Isento, Não Contribuinte
        public string? inscricao_estadual { get; set; }

        // Dados Pessoais (Podem ser nulos para Empresas)
        public string? genero { get; set; }
        public string? estado_civil { get; set; }

        // Endereço
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int numero_residencia { get; set; }
        public string cep { get; set; }

        // Contato e Status
        public string celular { get; set; }
        public string? email { get; set; }
        public string? observacoes { get; set; }
        public string situacao_cadastral { get; set; }

        // Arquivos / Metadados
        public byte[]? imagem { get; set; }
        public DateTime data_cadastro { get; set; }
    }
}

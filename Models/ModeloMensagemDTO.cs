using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class ModeloMensagemDTO
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string mensagem { get; set; }
        public string situacao { get; set; }
    }
}

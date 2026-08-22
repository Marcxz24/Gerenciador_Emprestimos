using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
        /// <summary>
        /// DTO que representa um modelo de mensagem padrão utilizado para cobranças ou notificações.
        /// Contém descrição, texto da mensagem e situação (ativo/inativo).
        /// </summary>
    public class ModeloMensagemDTO
    {
        /// <summary>
        /// Message code or identifier.
        /// </summary>
        public int codigo { get; set; }

        /// <summary>
        /// Short description of the message.
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// Full message text.
        /// </summary>
        public string mensagem { get; set; }

        /// <summary>
        /// Message status or situation.
        /// </summary>
        public string situacao { get; set; }
    }
}

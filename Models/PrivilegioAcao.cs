using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class PrivilegioAcao
    {
        public int Codigo { get; set; }
        public string NomeAcao { get; set; }
        public bool Permtido { get; set; }
    }
}

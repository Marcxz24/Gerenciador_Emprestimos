using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Models
{
    public class LembreteDTO
    {
        public int Codigo { get; set; }
        public int CodigoFuncionario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }

        public void EditarLembrete()
        {
            LembreteDAO dao = new LembreteDAO();
            dao.EditarLembrete(Codigo, Titulo, Descricao);
        }

        public void ExcluirLembrete()
        {
            LembreteDAO dao = new LembreteDAO();
            dao.ExcluirLembrete(Codigo);
        }
    }
}

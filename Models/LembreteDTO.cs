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
    /// <summary>
    /// Representa um lembrete (DTO) contendo dados e operações para editar e excluir um lembrete.
    /// </summary>
    public class LembreteDTO
    {
        public int Codigo { get; set; }
        public int CodigoFuncionario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }

        /// <summary>
        /// Edita o lembrete atual utilizando os dados do DTO.
        /// </summary>
        public void EditarLembrete()
        {
            LembreteDAO dao = new LembreteDAO();
            dao.EditarLembrete(Codigo, Titulo, Descricao);
        }

        /// <summary>
        /// Exclui o lembrete atual identificado pelo código.
        /// </summary>
        public void ExcluirLembrete()
        {
            LembreteDAO dao = new LembreteDAO();
            dao.ExcluirLembrete(Codigo);
        }
    }
}

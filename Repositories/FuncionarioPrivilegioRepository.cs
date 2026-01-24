using Gerenciador_de_Emprestimos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Repositories
{
    public class FuncionarioPrivilegioRepository
    {
        public void SalvarPrivilegios(int codigoFuncionario, Dictionary<int, bool> privilegio)
        {
            using (var conexao = ConexaoBancoDeDados.Conectar())
            {
                foreach (var item in privilegio)
                {
                    string sql = @"INSERT INTO funcionario_tela_privilegio
                                    (codigo_funcionario, codigo_tela, pode_acessar)
                                        VALUES
                                    (@funcionario, @tela, @acessar)
                                    ON DUPLICATE KEY UPDATE
                                    pode_acessar = @acessar";
                }
            }
        }
    }
}

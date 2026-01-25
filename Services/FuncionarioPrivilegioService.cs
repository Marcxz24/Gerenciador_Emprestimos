using Gerenciador_de_Emprestimos.Repositories;
using iText.Pdfua.Checkers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    public class FuncionarioPrivilegioService
    {
        // Declaração do repositório responsável pela persistência dos dados
        private readonly FuncionarioPrivilegioRepository _repository;

        // Construtor da classe que inicializa a instância do repositório
        public FuncionarioPrivilegioService()
        {
            _repository = new FuncionarioPrivilegioRepository();
        }

        // Método que retorna uma lista de IDs das telas que o funcionário tem permissão para acessar
        public List<int> BuscarTelasPermitidas(int codigoFuncionario)
        {
            return _repository.ObterTelasPermitidas(codigoFuncionario);
        }

        // Método responsável por processar e salvar as alterações de privilégios
        public void SalvarPrivilegios(int codigoFuncionario, Dictionary<int, bool> privilegios)
        {
            // Itera sobre o dicionário onde a Chave é o Código da Tela e o Valor é o booleano de acesso
            foreach (var item in privilegios)
            {
                int codigoTela = item.Key;
                bool podeAcessar = item.Value;

                // Verifica se já existe um registro de privilégio para esse funcionário nesta tela específica
                if (_repository.ExistePrivilegio(codigoFuncionario, codigoTela))
                {
                    // Se o registro já existe, executa a atualização (Update)
                    _repository.AtualizarPrivilegios(codigoFuncionario, codigoTela, podeAcessar);
                }
                else
                {
                    // Se o registro não existe, realiza uma nova inserção (Insert)
                    _repository.InserirPrivilegios(codigoFuncionario, codigoTela, podeAcessar);
                }
            }
        }
    }
}

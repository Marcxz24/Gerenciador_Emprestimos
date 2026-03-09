using System;
using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;

namespace Gerenciador_de_Emprestimos.Services
{
    // Serviço com regras de negócio relacionadas a parcelas.
    public class ParcelaService
    {
        private readonly ParcelaDAO _parcelaDao;
        private readonly EmprestimoDAO _emprestimoDao;

        public ParcelaService()
        {
            _parcelaDao = new ParcelaDAO();
            _emprestimoDao = new EmprestimoDAO();
        }

        // Expose retrieval for UI code
        public ParcelaDTO GetParcela(int codigoParcela)
        {
            return _parcelaDao.GetParcela(codigoParcela);
        }

        // Realiza validações de negócio e aplica pagamento parcial ou quitação.
        public bool RealizarPagamento(int codigoParcela, int codigoEmprestimo, int numeroParcela, decimal valorInformado, decimal valorParcela, out string mensagem)
        {
            mensagem = "";

            // Parcela já paga?
            if (_parcelaDao.IsParcelaPaga(codigoParcela))
            {
                mensagem = "Esta parcela já foi Paga";
                return false;
            }

            // Bloqueia pular parcelas
            if (_parcelaDao.CountParcelasAnterioresAbertas(codigoEmprestimo, numeroParcela) > 0)
            {
                mensagem = "Existem parcelas anteriores em aberto. Efetue o pagamento das parcelas anteriores antes de pagar esta parcela.";
                return false;
            }

            // Cálculo para amortização parcial
            decimal valorPagoAtual = _parcelaDao.GetValorPago(codigoParcela);
            decimal novoTotal = valorPagoAtual + valorInformado;

            if (novoTotal > valorParcela)
            {
                mensagem = "O valor informado não pode ser maior que o valor da parcela.";
                return false;
            }

            // Se pagamento parcial
            if (novoTotal < valorParcela)
            {
                _parcelaDao.UpdateValorPagoPartial(codigoParcela, novoTotal);
            }
            else
            {
                // Quitação: marca parcela como paga
                int linhas = _parcelaDao.MarkParcelaPaga(codigoParcela, novoTotal);
                if (linhas == 0)
                {
                    mensagem = "Esta parcela já foi quitada por outro processo.";
                    return false;
                }

                // Regra de negócio: se não existem mais parcelas abertas, quita o empréstimo
                if (_parcelaDao.CountParcelasAbertas(codigoEmprestimo) == 0)
                {
                    _emprestimoDao.QuitarEmprestimo(codigoEmprestimo);
                }
            }

            return true;
        }

        // Recalcula juros (regra de negócio). Retorna true se atualizou.
        public bool RecalcularJurosEAvancarMes(int codigoParcela)
        {
            var parcela = _parcelaDao.GetParcela(codigoParcela);

            if (parcela == null) throw new Exception("Parcela não encontrada.");

            if (!string.IsNullOrEmpty(parcela.StatusParcela) && parcela.StatusParcela.Equals("PAGA", StringComparison.OrdinalIgnoreCase))
                return false; // Não recalcula parcelas pagas

            // Determina referência de cálculo (último cálculo ou vencimento)
            DateTime referencia = parcela.DataUltimoCalculoJuros.HasValue
                ? parcela.DataUltimoCalculoJuros.Value.ToDateTime(TimeOnly.MinValue)
                : parcela.DataVencimento.ToDateTime(TimeOnly.MinValue);

            DateTime novaDataUltimoCalculo;
            decimal taxa = parcela.PercentualJuros / 100m;
            decimal novoValor;

            if (parcela.TipoJuros == "DIARIO")
            {
                novaDataUltimoCalculo = referencia.AddDays(1);
                novoValor = Math.Round(parcela.ValorParcela * (1m + taxa), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                novaDataUltimoCalculo = referencia.AddMonths(1);
                novoValor = Math.Round(parcela.ValorParcela * (1m + taxa), 2, MidpointRounding.AwayFromZero);
            }

            // Persiste alteração
            int linhas = _parcelaDao.UpdateParcelaValorJuros(codigoParcela, novoValor, novaDataUltimoCalculo);
            return linhas > 0;
        }

        // Adiciona observações (apenas encaminha para o DAO)
        public void AdicionarObservacoes(int codigoParcela, string observacoes)
        {
            _parcelaDao.AddObservacoes(codigoParcela, observacoes);
        }
    }
}
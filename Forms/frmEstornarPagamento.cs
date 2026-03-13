using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Security;
using Gerenciador_de_Emprestimos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_Emprestimos.Forms
{
    public partial class frmEstornarPagamento : Form
    {
        public frmEstornarPagamento()
        {
            InitializeComponent();
            txtCodigoEmprestimo.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtValorEstornado.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
            txtCodigoEmprestimoEstorno.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCodigoParcelaEstorno.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCodigoUserLogado.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private void frmEstornarPagamento_Load(object sender, EventArgs e)
        {
            txtCodigoUserLogado.Text = Sessao.CodigoFuncionarioLogado.ToString();
        }

        private bool ValidacoesCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoEmprestimoEstorno.Text))
            {
                Funcoes.MensagemWarning("Deve-se informar o Emprestimo para poder realizar o Estorno.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoParcelaEstorno.Text))
            {
                Funcoes.MensagemWarning("Deve-se informar a Parcela para poder realizar o Estorno.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoUserLogado.Text))
            {
                Funcoes.MensagemWarning("Deve-se estar informado o usuário logado.\n\nDeslogue do seu usuário e logue novamente e tente realizar o estorno!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotivoEstorno.Text))
            {
                Funcoes.MensagemWarning("Deve-se informar o Motivo do Estorno.");
                txtMotivoEstorno.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtValorEstornado.Text))
            {
                Funcoes.MensagemWarning("Deve-se informar o valor estornado ao realizar o estorno.");
                txtValorEstornado.Focus();
                return false;
            }

            if (txtMotivoEstorno.Text.Length < 10)
            {
                Funcoes.MensagemWarning("Motivo da operação inválido. Por favor, detalhe a justificativa com, no mínimo, 10 caracteres.");
                return false;
            }

            return true;
        }

        private void btnBuscarParcela_Click(object sender, EventArgs e)
        {
            try
            {
                var estornoDto = new EstornoPagamentoDTO();

                if (int.TryParse(txtCodigoEmprestimo.Text, out int codEmp))
                    estornoDto.CodigoEmprestimo = codEmp;

                if (int.TryParse(txtCodigoCliente.Text, out int codClie))
                    estornoDto.CodigoCliente = codClie;

                if (estornoDto.CodigoEmprestimo == 0 && estornoDto.CodigoCliente == 0)
                {
                    Funcoes.MensagemWarning("Favor informe o código do cliente ou o código do empréstimo");
                    return;
                }

                var dao = new EstornoPagamentoDAO();
                DataTable dt = dao.ListarParcelasParaEstorno(estornoDto);

                dtGridListarPagamentos.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    FormatarGridEstorno();
                }
                else
                {
                    dtGridListarPagamentos.DataSource = null;
                    Funcoes.MensagemWarning("Nenhuma parcela PAGA foi encontrada para os filtros informados."); return;
                }

            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("Erro ao realizar a busca: " + ex.Message);
                Serilog.Log.Error("Erro no clique de busca de parcelas: " + ex);
            }
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
            }
        }

        private void PreencherCamposCliente(ClienteDTO cliente)
        {
            txtCodigoCliente.Text = cliente.codigo.ToString();
            txtNomeCliente.Text = cliente.nome_cliente;
        }

        private void txtNomeCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
            }
        }

        private void BuscarCliente()
        {
            var clienteDao = new ClienteDAO();
            ClienteDTO resultado = null;

            if (int.TryParse(txtCodigoCliente.Text, out int codigo) && codigo > 0)
            {
                resultado = clienteDao.BuscarClientePorCodigo(codigo);
            }
            else if (!string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                resultado = clienteDao.BuscarClientePorNome(txtNomeCliente.Text);
            }

            if (resultado != null)
            {
                PreencherCamposCliente(resultado);
            }
            else
            {
                // Se não encontrou de nenhuma forma, abre a tela de seleção
                using (var frmBuscarCliente = new frmSelecionarCliente()) // Passa o que foi digitado para o filtro da busca
                {
                    if (frmBuscarCliente.ShowDialog() == DialogResult.OK)
                    {
                        PreencherCamposCliente(frmBuscarCliente.ClienteSelecionado);
                    }
                }
            }
        }

        private void FormatarGridEstorno()
        {
            // 1. Esconde as colunas de ID (essenciais para o código, inúteis para o usuário)
            if (dtGridListarPagamentos.Columns.Contains("codigo_parcela"))
                dtGridListarPagamentos.Columns["codigo_parcela"].Visible = false;

            // 2. Cabeçalhos com nomes amigáveis
            dtGridListarPagamentos.Columns["codigo_emprestimo"].HeaderText = "Cód Emprestimo";
            dtGridListarPagamentos.Columns["nome_cliente"].HeaderText = "Cliente";
            dtGridListarPagamentos.Columns["numero_parcela"].HeaderText = "Nº Parc.";
            dtGridListarPagamentos.Columns["valor_emprestado_total"].HeaderText = "Total Empr.";
            dtGridListarPagamentos.Columns["valor_parcela"].HeaderText = "Vlr. Parcela";
            dtGridListarPagamentos.Columns["valor_pago"].HeaderText = "Vlr. Pago";
            dtGridListarPagamentos.Columns["data_pagamento"].HeaderText = "Data Pagto";
            dtGridListarPagamentos.Columns["status_parcela"].HeaderText = "Status";

            // 3. Formatação Monetária (R$) e Alinhamentos
            // O "C2" coloca o símbolo de moeda automaticamente conforme a região do Windows
            dtGridListarPagamentos.Columns["valor_emprestado_total"].DefaultCellStyle.Format = "C2";
            dtGridListarPagamentos.Columns["valor_parcela"].DefaultCellStyle.Format = "C2";
            dtGridListarPagamentos.Columns["valor_pago"].DefaultCellStyle.Format = "C2";

            // Alinhamento central para números e datas facilita a leitura
            dtGridListarPagamentos.Columns["numero_parcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridListarPagamentos.Columns["data_pagamento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 4. Estética Final
            dtGridListarPagamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtGridListarPagamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleciona a linha toda ao clicar
            dtGridListarPagamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Efeito zebra
        }

        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Clear();
            txtCodigoEmprestimo.Clear();
            txtCodigoEmprestimoEstorno.Clear();
            txtNomeCliente.Clear();
            txtValorEstornado.Clear();
            txtMotivoEstorno.Clear();
            txtCodigoParcelaEstorno.Clear();
            dtGridListarPagamentos.DataSource = null;
            txtValorEstornado.Clear();
            txtValorPago.Clear();
            txtValorParcela.Clear();
        }

        private void dtGridListarPagamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtGridListarPagamentos.Rows[e.RowIndex];

                txtCodigoEmprestimoEstorno.Text = row.Cells["codigo_emprestimo"].Value.ToString();
                txtCodigoParcelaEstorno.Text = row.Cells["codigo_parcela"].Value.ToString();
                txtNumeroParcela.Text = row.Cells["numero_parcela"].Value.ToString();
                txtValorParcela.Text = row.Cells["valor_parcela"].Value.ToString();
                txtValorPago.Text = row.Cells["valor_pago"].Value.ToString();
            }
        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            if (!ValidacoesCampos())
                return;

            if (!decimal.TryParse(txtValorEstornado.Text, out decimal valorDigitado))
            {
                Funcoes.MensagemWarning("Informe um valor válido.");
                return;
            }

            try
            {
                var estornoDAO = new EstornoPagamentoDAO();
                var estornoDTO = new EstornoPagamentoDTO
                {
                    CodigoEmprestimo = Convert.ToInt32(txtCodigoEmprestimoEstorno.Text),
                    CodigoParcela = Convert.ToInt32(txtCodigoParcelaEstorno.Text),
                    CodigoFuncionario = Convert.ToInt32(txtCodigoUserLogado.Text),
                    ValorEstornado = Convert.ToDecimal(txtValorEstornado.Text),
                    NumeroParcela = Convert.ToInt32(txtNumeroParcela.Text),
                    MotivoEstorno = txtMotivoEstorno.Text
                };

                if (!estornoDAO.ValidarSequenciaEstorno(estornoDTO))
                {
                    Funcoes.MensagemWarning("Existem parcelas posteriores (ex: 3, 4...) que já estão pagas.\n\nPara manter a integridade, você deve estornar as parcelas na ordem inversa (da última paga para a primeira).");
                    return;
                }

                if (estornoDAO.EstornarPagamento(estornoDTO))
                {
                    Funcoes.MensagemInformation("Estorno realizado com sucesso!");
                    this.DialogResult = DialogResult.OK; // Fecha a tela informando sucesso para atualizar o Grid
                    this.Close();
                }
            }
            catch (Exception ex) 
            {
                Funcoes.MensagemWarning(ex.Message);
            }
        }
    }
}

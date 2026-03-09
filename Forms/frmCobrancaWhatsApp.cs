using Gerenciador_de_Emprestimos.Models;
using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Services;
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
    public partial class frmCobrancaWhatsApp : Form
    {
        public frmCobrancaWhatsApp()
        {
            InitializeComponent();
            txtCodigoModeloMsg.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtCodigoCliente.KeyPress += Funcoes.SomenteNumeros_KeyPress;
            txtBoxValorVencido.KeyPress += Funcoes.SomenteNumerosComVirgula_KeyPress;
        }

        private void LimparTela()
        {
            txtCodigoCliente.Clear();
            txtCodigoModeloMsg.Clear();
            txtNomeCliente.Clear();
            txtNomeCliente.Clear();
            txtMensagemCobranca.Clear();
            txtTelefoneCliente.Clear();
            txtModeloMsg.Clear();
            txtBoxValorVencido.Clear();
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void txtCodigoModeloMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtCodigoModeloMsg.Text, out int codigoModMsg))
                {
                    ModeloMensagemDAO dao = new ModeloMensagemDAO();

                    var modelo = dao.SelecionarModeloMensagemPorCodigo(codigoModMsg);

                    if (modelo != null)
                    {
                        PreencherCamposModeloMsg(codigoModMsg, modelo.descricao, modelo.mensagem);
                    }
                    else
                    {
                        Funcoes.MensagemWarning("Modelo não encontrado.");
                    }
                }
            }
        }

        private void PreencherCamposModeloMsg(int codigoModeloMsg, string desc, string msg)
        {
            txtCodigoModeloMsg.Text = codigoModeloMsg.ToString();
            txtModeloMsg.Text = desc;
            txtMensagemCobranca.Text = msg;

            if (!string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                txtMensagemCobranca.Text = txtMensagemCobranca.Text.Replace("{nome}", txtNomeCliente.Text);
            }
        }

        private void txtModeloMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string termo = txtModeloMsg.Text.Trim();

                if (!string.IsNullOrWhiteSpace(termo))
                {
                    ModeloMensagemDAO dao = new ModeloMensagemDAO();

                    DataTable dt = dao.ListarTodosOsModelos(null, termo, "TODOS");

                    if (dt.Rows.Count == 1)
                    {
                        var linha = dt.Rows[0];
                        PreencherCamposModeloMsg(Convert.ToInt32(linha["codigo"]), linha["descricao"].ToString(), linha["mensagem"].ToString());
                    }
                    else
                    {
                        Funcoes.MensagemWarning("Modelo não encontrado.");
                    }
                }
            }
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                Funcoes.MensagemWarning("informe o nome do cliente para poder enviar as mensagens!");
                txtNomeCliente.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtMensagemCobranca.Text))
            {
                Funcoes.MensagemWarning("Informe o Modelo, ou digite uma mensagem para realizar a cobrança!");
                txtMensagemCobranca.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                Funcoes.MensagemWarning("Informe o telefone para poder enviar a mensagem!");
                txtTelefoneCliente.Focus();
                return true;
            }

            return false;
        }

        private void btnEnvioMensagem_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObrigatorios())
            {
                return;
            }

            try
            {
                string textoFinal = txtMensagemCobranca.Text;

                string valorDigitado = txtBoxValorVencido.Text;

                textoFinal = textoFinal.Replace("{nome}", txtNomeCliente.Text);

                textoFinal = textoFinal.Replace("{valor}", valorDigitado);

                WhatsAppService.EnviarMensagem(txtTelefoneCliente.Text, textoFinal);
            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("Ocorreu um erro ao enviar a mensagem: " + ex.Message);
                Serilog.Log.Error("Ocorreu um erro ao enviar a mensagem: " + ex.Message);
            }
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtCodigoCliente.Text, out int codigoCliente))
                {
                    var buscarCliente = new ClienteDAO();
                    var cliente = buscarCliente.BuscarClientePorCodigo(codigoCliente);

                    if (cliente != null)
                    {
                        PreencherCamposCliente(cliente);
                    }
                    else
                    {
                        using (var frmBuscarCliente = new frmSelecionarCliente())
                        {
                            if (frmBuscarCliente.ShowDialog() == DialogResult.OK)
                            {
                                var clienteSelecionado = frmBuscarCliente.ClienteSelecionado;

                                PreencherCamposCliente(clienteSelecionado);
                            }
                        }
                    }
                }
            }
        }

        private void txtNomeCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var servico = new ClienteDAO();
                var resultado = servico.BuscarClientePorNome(txtNomeCliente.Text);

                if (resultado != null)
                {
                    txtCodigoCliente.Text = resultado.codigo.ToString();
                    txtNomeCliente.Text = resultado.nome_cliente;
                    txtTelefoneCliente.Text = resultado.celular;
                }
                else
                {
                    using (var frmBuscarCliente = new frmSelecionarCliente())
                    {
                        if (frmBuscarCliente.ShowDialog() == DialogResult.OK)
                        {
                            var clienteSelecionado = frmBuscarCliente.ClienteSelecionado;

                            PreencherCamposCliente(clienteSelecionado);
                        }
                    }
                }
            }
        }

        private void PreencherCamposCliente(ClienteDTO cliente)
        {
            txtCodigoCliente.Text = cliente.codigo.ToString();
            txtNomeCliente.Text = cliente.nome_cliente;
            txtTelefoneCliente.Text = cliente.celular;

            if (txtMensagemCobranca.Text.Contains("{nome}"))
            {
                txtMensagemCobranca.Text = txtMensagemCobranca.Text.Replace("{nome}", cliente.nome_cliente);
            }
        }

        private void txtBoxValorVencido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxValorVencido.Text))
            {
                decimal valorVazio = 0;
                txtBoxValorVencido.Text = valorVazio.ToString("F2");
            }

            if (decimal.TryParse(txtBoxValorVencido.Text, out decimal valorDigitado))
            {
                txtBoxValorVencido.Text = valorDigitado.ToString("F2");

                txtMensagemCobranca.Text = txtMensagemCobranca.Text.Replace("{valor}", txtBoxValorVencido.Text);
            }
            else
            {
                Funcoes.MensagemWarning("Valor inválido. Por favor, digite um valor numérico.");
                txtBoxValorVencido.Focus();
            }
        }

        private void txtBoxValorVencido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (decimal.TryParse(txtBoxValorVencido.Text, out decimal valorDigitado))
                {
                    txtBoxValorVencido.Text = valorDigitado.ToString("F2");

                    txtMensagemCobranca.Text = txtMensagemCobranca.Text.Replace("{valor}", txtBoxValorVencido.Text);
                }
                else
                {
                    Funcoes.MensagemWarning("Valor inválido. Por favor, digite um valor numérico.");
                    txtBoxValorVencido.Focus();
                }
            }
        }
    }
}

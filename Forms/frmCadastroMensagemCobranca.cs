using Gerenciador_de_Emprestimos.Repositories;
using Gerenciador_de_Emprestimos.Utils;

namespace Gerenciador_de_Emprestimos.Forms
{
    public partial class frmCadastroMensagemCobranca : Form
    {
        private bool _EditarCadastro = false;

        public frmCadastroMensagemCobranca()
        {
            InitializeComponent();
        }

        private void GerenciarCampos(bool OcultarBotoes, bool ManifestarBotoes, bool LimparCampos)
        {
            txtDescricaoModeloMsg.ReadOnly = !ManifestarBotoes;
            cmbBoxSituacaoModeloMsg.Enabled = ManifestarBotoes;
            txtMensagemEnviar.ReadOnly = !ManifestarBotoes;

            if (LimparCampos)
            {
                txtCodigoModeloMsg.Clear();
                txtDescricaoModeloMsg.Clear();
                txtMensagemEnviar.Clear();
                cmbBoxSituacaoModeloMsg.SelectedIndex = -1;
            }

            btnNovo.Visible = OcultarBotoes;
            btnEditar.Visible = OcultarBotoes;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _EditarCadastro = false;

            GerenciarCampos(false, true, true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GerenciarCampos(true, false, true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _EditarCadastro = true;
            GerenciarCampos(false, true, false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacarCampos())
                {
                    return;
                }

                SalvarCadastroModeloMensagem();

                GerenciarCampos(true, false, false);
            }
            catch (Exception ex)
            {

            }
        }

        private void SalvarCadastroModeloMensagem()
        {
            if (_EditarCadastro)
            {
                EditarModeloMensagem();

            }
            else
            {
                CadastrarModeloMensagem();
            }
        }

        private void CadastrarModeloMensagem()
        {
            string descricao = txtDescricaoModeloMsg.Text;
            string mensagem = txtMensagemEnviar.Text;
            string situacao = cmbBoxSituacaoModeloMsg.SelectedItem.ToString();

            ModeloMensagemDAO modeloMensagemDAO = new ModeloMensagemDAO();
            modeloMensagemDAO.CadastrarModeloMensagem(descricao, mensagem, situacao);

            txtCodigoModeloMsg.Text = modeloMensagemDAO.codigoModeloMensagem.ToString();
        }

        private void EditarModeloMensagem()
        {
            if (ValidacarCampos())
            {
                return;
            }

            int codigoModeloMsg = Convert.ToInt32(txtCodigoModeloMsg.Text);
            string descricao = txtDescricaoModeloMsg.Text;
            string mensagem = txtMensagemEnviar.Text;
            string situacao = cmbBoxSituacaoModeloMsg.SelectedItem.ToString();

            ModeloMensagemDAO modeloMensagemDAO = new ModeloMensagemDAO();
            modeloMensagemDAO.EditarModeloMensagem(codigoModeloMsg, descricao, mensagem, situacao);
        }

        private bool ValidacarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescricaoModeloMsg.Text))
            {
                Funcoes.MensagemWarning("A descrição do modelo de mensagem é obrigatória.\n\nPor favor preencha a descrição!");
                txtDescricaoModeloMsg.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(cmbBoxSituacaoModeloMsg.Text))
            {
                Funcoes.MensagemWarning("A Situação do Modelo da mensagem é obrigatória.\n\nPor favor selecione a Situação!");
                cmbBoxSituacaoModeloMsg.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtMensagemEnviar.Text))
            {
                Funcoes.MensagemWarning("O Modelo da mensagem é obrigatório.\n\nPor favor preencha o modelo da mensagem!");
                txtMensagemEnviar.Focus();
                return true;
            }

            return false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frmSelecionarMsg = new frmSelecionarModeloMsg())
                {
                    if (frmSelecionarMsg.ShowDialog() == DialogResult.OK)
                    {
                        txtCodigoModeloMsg.Text = frmSelecionarMsg.CodigoSelecionado.ToString();
                        txtDescricaoModeloMsg.Text = frmSelecionarMsg.DescricaoSelecionada;
                        txtMensagemEnviar.Text = frmSelecionarMsg.MensagemSelecionada;
                        cmbBoxSituacaoModeloMsg.SelectedItem = frmSelecionarMsg.SituacaoSelecionada;
                    }
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemErro("Ocorreu um erro ao pesquisar o modelo de mensagem.");
                Serilog.Log.Error("Erro ao capturar modelo de mensagem: " + ex.Message);
            }
        }
    }
}
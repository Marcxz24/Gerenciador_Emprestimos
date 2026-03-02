using Gerenciador_de_Emprestimos.Repositories;
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
    public partial class frmSelecionarModeloMsg : Form
    {
        // Propriedades para transportar os dados de volta
        public int CodigoSelecionado { get; set; }
        public string DescricaoSelecionada { get; set; }
        public string MensagemSelecionada { get; set; }
        public string SituacaoSelecionada { get; set; }

        public frmSelecionarModeloMsg()
        {
            InitializeComponent();
            txtCodigoModMsg.KeyPress += Funcoes.SomenteNumeros_KeyPress;
        }

        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            txtCodigoModMsg.Clear();
            txtDescricaoModMsg.Clear();
            cmbBoxSituacaoModMsg.SelectedIndex = -1;
            dtGridModeloMsg.DataSource = null;
        }

        private void btnPesquisarModMsg_Click(object sender, EventArgs e)
        {
            ModeloMensagemDAO dao = new ModeloMensagemDAO();

            int? codigo = null;
            string? descricao = null;
            string? situacao = null;

            if (!string.IsNullOrWhiteSpace(txtCodigoModMsg.Text))
            {
                int.TryParse(txtCodigoModMsg.Text, out int codigoModeloMsg);
                codigo = codigoModeloMsg;
            }

            if (!string.IsNullOrWhiteSpace(txtDescricaoModMsg.Text))
            {
                descricao = txtDescricaoModMsg.Text;
            }

            if (!string.IsNullOrWhiteSpace(cmbBoxSituacaoModMsg.Text))
            {
                situacao = cmbBoxSituacaoModMsg.Text;
            }

            dtGridModeloMsg.DataSource = dao.ListarTodosOsModelos(codigo, descricao, situacao);
        }

        private void dtGridModeloMsg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var linha = dtGridModeloMsg.Rows[e.RowIndex];

                CodigoSelecionado = Convert.ToInt32(linha.Cells["codigo"].Value);
                DescricaoSelecionada = linha.Cells["descricao"].Value.ToString();
                MensagemSelecionada = linha.Cells["mensagem"].Value.ToString();
                SituacaoSelecionada = linha.Cells["situacao"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

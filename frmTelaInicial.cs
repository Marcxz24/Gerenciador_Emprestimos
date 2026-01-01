using System;
using System.Windows.Forms;
using MySql.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class FormTelaIncial : Form
    {
        public FormTelaIncial()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCadastroCliente formularioCadastroCliente = new FormCadastroCliente();
            formularioCadastroCliente.ShowDialog();
        }

        private void novosEmprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmprestimos formularioEmprestimos = new FormEmprestimos();
            formularioEmprestimos.ShowDialog();
        }

        private void visualizarEmprestimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarEmprestimos frmVisualizarEmprestimos = new frmVisualizarEmprestimos();
            frmVisualizarEmprestimos.Show();
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void visualizarEmprestimosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVisualizarEmprestimos frmVisualizarEmprestimos = new frmVisualizarEmprestimos();
            frmVisualizarEmprestimos.Show();
        }

        private void recebimentoDeParcelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagamentoEmprestimo frmPagamentoParcela = new frmPagamentoEmprestimo();
            frmPagamentoParcela.ShowDialog();
        }

        private void visualizarParcelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarParcelas frmConsultaParcela = new frmConsultarParcelas();
            frmConsultaParcela.Show();
        }

        private void pagamentoDeParcelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagamentoEmprestimo frmPagamento = new frmPagamentoEmprestimo(); 
            frmPagamento.ShowDialog();
        }
    }
}

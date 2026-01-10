using System;
using System.Windows.Forms;
using MySql.Data;

namespace Gerenciador_de_Emprestimos
{
    public partial class frmTelaIncial : Form
    {
        public frmTelaIncial()
        {
            InitializeComponent();
            ConfigurarAcesso(false);

            frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();

            loginFuncionario.Owner = this;

            loginFuncionario.StartPosition = FormStartPosition.CenterScreen;

            loginFuncionario.Show();
        }

        private void frmTelaIncial_Load(object sender, EventArgs e)
        {
            ConfigurarAcesso(false);
        }

        public void ConfigurarAcesso(bool logado)
        {
            MenuStripCadastro.Enabled = logado;
            MenuStripCadastro.Visible = logado;

            MenuStripFinanceiro.Enabled = logado;
            MenuStripFinanceiro.Visible = logado;

            MenuStripRelatorios.Enabled = logado;
            MenuStripRelatorios.Visible = logado;

            loginToolStripMenuItem.Enabled = !logado;
            loginToolStripMenuItem.Visible = !logado;

            logoffToolStripMenuItem.Enabled = logado;
            logoffToolStripMenuItem.Visible = logado;
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

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionario frmCadastroFuncionario = new frmCadastroFuncionario();
            frmCadastroFuncionario.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente fazer logoff do sistema?\nAs tarefas não concluídas serão interrompidas.", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                ConfigurarAcesso(false);

                frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();
                loginFuncionario.Owner = this;
                loginFuncionario.Show();
            }

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginFuncionario loginFuncionario = new frmLoginFuncionario();
            loginFuncionario.Owner = this;
            loginFuncionario.Show();

        }
    }
}

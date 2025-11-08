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

        private void btnChamarFormCadastroCliente_Click(object sender, EventArgs e)
        {
            FormCadastroCliente formularioCadastroCliente = new FormCadastroCliente();
            formularioCadastroCliente.ShowDialog();
        }

        private void btnChamarFormEmprestimos_Click_1(object sender, EventArgs e)
        {
            FormEmprestimos formularioEmprestimos = new FormEmprestimos();
            formularioEmprestimos.ShowDialog();
        }

        private void btnFecharAplicacao_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

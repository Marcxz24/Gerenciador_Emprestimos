using Gerenciador_de_Emprestimos.Models;
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
    public partial class frmNovoLembrete : Form
    {
        public frmNovoLembrete()
        {
            InitializeComponent();
        }

        private void btnSalvarLembrete_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Trim() == "")
            {
                Funcoes.MensagemWarning("Digite um título.");
                return;
            }

            if (txtDescricao.Text.Trim() == "")
            {
                Funcoes.MensagemWarning("Digite uma descrição.");
                return;
            }

            Lembrete lembrete = new Lembrete
            {
                CodigoFuncionario = 1,
                Titulo = txtTitulo.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Situacao = "Pendente"
            };
        }
    }
}

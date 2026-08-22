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
    public partial class frmSobreEmpresa : Form
    {
        public frmSobreEmpresa()
        {
            InitializeComponent();
        }

        // Evento que é disparado quando o link é clicado, redirenciona para o site do GitHub do desenvolvedor
        private void linkLblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // o linkLblGitHub.LinkVisited = true; indica que o link foi visitado, mudando a cor do link para indicar que ele já foi clicado
            linkLblGitHub.LinkVisited = true;

            // Abre o link do GitHub do desenvolvedor no navegador padrão do sistema
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/Marcxz24",
                UseShellExecute = true,
            });
        }

        // Evento que é disparado quando o botão "OK" é clicado, fecha a tela
        private void btnOkFecharTela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

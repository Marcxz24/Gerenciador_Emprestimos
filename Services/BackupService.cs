using Gerenciador_de_Emprestimos.Database;
using Gerenciador_de_Emprestimos.Utils;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Services
{
    public class BackUpService
    {
        public bool RealizarBackup(string caminhoDestino)
        {
            try
            {
                string strConexao = ConexaoBancoDeDados.StringConexao;

                var builder = new MySqlXConnectionStringBuilder(strConexao);

                string usuario = builder.UserID;
                string senha = builder.Password;
                string banco = builder.Database;
                string servidor = builder.Server;

                string caminhoDump = @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe";

                string argumentos = $"-h {servidor} -u {usuario} -p\"{senha}\" {banco} -r \"{caminhoDestino}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = caminhoDump,
                    Arguments = argumentos,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true
                };

                using (Process processo = Process.Start(psi))
                {
                    processo.WaitForExit();
                    return processo.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                Funcoes.MensagemWarning("Erro no BackupService: " + ex.Message);
                Serilog.Log.Error("Erro no BackupService: " + ex.Message);
                return false;
            }
        }
    }
}

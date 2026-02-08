using Gerenciador_de_Emprestimos.Utils;
using Serilog;

namespace Gerenciador_de_Emprestimos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.File("Log/Log_Error.txt").CreateLogger();

            try
            {
                Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new frmTelaIncial());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ocorreu uma falha crítica na inicialização do sistema.");
                Funcoes.MensagemErro("Erro crítico detectado. Verifique os logs na pasta do sistema.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
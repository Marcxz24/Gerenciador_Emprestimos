using Gerenciador_de_Emprestimos.Models;
using System.Text.Json;

namespace Gerenciador_de_Emprestimos.Services
{
    public class CnpjServices
    {
        private static readonly HttpClient cliente = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

        public async Task<EmpresaDTO> ConsultarCnpj(string cnpj)
        {
            string cnpjLimpo = new string(cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim().Where(char.IsDigit).ToArray());

            if (cnpjLimpo.Length != 14)
                throw new Exception("CNPJ Deve conter 14 dígitos.");

            try
            {
                var response = await cliente.GetAsync($"https://brasilapi.com.br/api/cnpj/v1/{cnpjLimpo}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<EmpresaDTO>(json);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Falha na comunicação com o serviço de busca: " + ex.Message);
            }
        }
    }
}
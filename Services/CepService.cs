using Newtonsoft.Json;
using System.Net.Http;

namespace Gerenciador_de_Emprestimos.Services
{
    public class CepService
    {
        public async Task<dynamic> ConsultarCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic resultado = JsonConvert.DeserializeObject(json);

                    if (resultado.erro == "true") return null;

                    return resultado;
                }
            }

            return null;
        }
    }
}

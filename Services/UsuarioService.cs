using Projeto02.AppWebForum.Common;
using Projeto02.AppWebForum.Models;
using System.Net.Http.Headers;

namespace Projeto02.AppWebForum.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _httpClient;
        //private readonly IConfiguration _configuration;

        public UsuarioService(IHttpClientFactory client, IConfiguration config)
        {
            _httpClient = client.CreateClient();

            Utils.ConfigHttp(_httpClient);
            //_configuration = config;
            

            ////_httpClient.BaseAddress = new Uri("https://localhost:44328/");
            //_httpClient.BaseAddress = new Uri(config["UrlApi"].ToString());
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new
            //    MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<UsuarioClient>> ListarUsuarios()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/usuario");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<UsuarioClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível estabelecer a conexão");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

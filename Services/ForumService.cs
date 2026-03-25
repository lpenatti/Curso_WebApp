using NuGet.Packaging.Signing;
using Projeto02.AppWebForum.Common;
using Projeto02.AppWebForum.Models;
using System.Net.Http.Headers;

namespace Projeto02.AppWebForum.Services
{
    public class ForumService : IForumService
    {
        private readonly HttpClient _httpClient;
        public ForumService(IHttpClientFactory client)
        {
            _httpClient = client.CreateClient();

            Utils.ConfigHttp(_httpClient);

            //_httpClient.BaseAddress = new Uri("https://localhost:44328/");
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new
            //    MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IEnumerable<ForumClient>> ListarForuns()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/forum");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<ForumClient[]>(); 
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

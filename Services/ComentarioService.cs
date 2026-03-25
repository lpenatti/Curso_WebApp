using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto02.AppWebForum.Common;
using Projeto02.AppWebForum.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Projeto02.AppWebForum.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly HttpClient _httpClient;

        public ComentarioService(IHttpClientFactory client)
        {
            _httpClient = client.CreateClient();
            Utils.ConfigHttp(_httpClient);

            //_httpClient.BaseAddress = new Uri("https://localhost:44328/");
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new
            //    MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task Incluir(ComentarioClient comentario)
        {
            try
            {
                // gerar o json a partir do objeto fornecido
                string json = JsonConvert.SerializeObject(comentario);

                // gerar o fluxo de bytes para a API
                HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

                // enviamos o objeto para a API
                var response = await _httpClient.PostAsync("api/comentarios", content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode + response.ReasonPhrase);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ForumUsuarioComentariosDTO>> ListarComentariosLinq(int idForum)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/comentarios/linq/{idForum}");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<ForumUsuarioComentariosDTO[]>();
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

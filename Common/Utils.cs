using System.Net.Http.Headers;

namespace Projeto02.AppWebForum.Common
{
    public class Utils
    {
        public static void ConfigHttp(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44328/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

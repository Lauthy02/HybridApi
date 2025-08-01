using HybridApi.Models;
using System.Text.Json;

namespace HybridApi.Services
{
    public class PublicApiService : IPublicApiService
    {
        private readonly HttpClient _httpClient;

        public PublicApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PublicPost>> GetPosts()
        {
            var response = await _httpClient.GetAsync("/posts");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var posts = await JsonSerializer.DeserializeAsync<List<PublicPost>>(
                responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                // Por defecto, System.Text.Json es sensible a mayúsculas/minúsculas y espera que las propiedades del JSON coincidan exactamente con las de la clase
                // Se debe indicar a System.Text.Json que ignore las mayúsculas/minúsculas usando la opción PropertyNameCaseInsensitive = true:

            );

            return posts ?? new List<PublicPost>();

            /* Este servicio recibe un HttpClient a través de su constructor. 
             * El método GetPosts utiliza este cliente para realizar una solicitud GET al endpoint /posts, 
             * deserializa la respuesta JSON en una lista de objetos PublicPost y la devuelve.
             */
        }
    }
}

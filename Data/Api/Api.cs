using Domain.Entities;
using System.Text.Json;

namespace Data.Api
{
    public class Api : IApi
    {
        private readonly HttpClient _httpClient;
        private const string _reqresAPIBaseUrl = "https://app-academy-neu-codechallenge.azurewebsites.net/api/cut";

        public Api(HttpClient httpClientFactory) => _httpClient = httpClientFactory;

        public IEnumerable<Machine>? GetAll()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Concat(_reqresAPIBaseUrl, ""))
            {
                Headers =
                {
                    { "Accept", "application/json" },
                    { "Authorization", "Basic bGFudGVrYWNhZGVteTo6Y1BJaTxreUYoPTVPWGM=" }
                }
            };

            var httpResponseMessage = _httpClient.Send(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            using var contentStream = httpResponseMessage.Content.ReadAsStream();

            return JsonSerializer.Deserialize<IEnumerable<Machine>>(contentStream);
        }

        public IEnumerable<Machine>? GetType(MachineType type)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Concat(_reqresAPIBaseUrl, "/", (int)type))
            {
                Headers =
                {
                    { "Accept", "application/json" },
                    { "Authorization", "Basic bGFudGVrYWNhZGVteTo6Y1BJaTxreUYoPTVPWGM=" }
                }
            };

            var httpResponseMessage = _httpClient.Send(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            using var contentStream = httpResponseMessage.Content.ReadAsStream();

            return JsonSerializer.Deserialize<IEnumerable<Machine>>(contentStream);
        }
    }
}

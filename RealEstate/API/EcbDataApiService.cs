using RealEstate.API.Domain;
using System.Text.Json;

namespace RealEstate.API.API
{
    public class EcbDataApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public string flowRef = "";

        public EcbDataApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ExternalApis:EcbDataApi"];
        }

        public async Task<Item?> GetItemAsync()
        {
            // 1. Call the API
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            // 2. Read and deserialize the JSON directly
            using var stream = await response.Content.ReadAsStreamAsync();
            var item = await JsonSerializer.DeserializeAsync<Item>(stream);

            return item;
        }
    }
}

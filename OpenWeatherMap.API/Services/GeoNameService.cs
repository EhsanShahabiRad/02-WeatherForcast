namespace OpenWeatherMap.API.Services
{
    public class GeoNameService : IGeoNameService
    {
        private readonly HttpClient _httpClient;
        public GeoNameService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<string> GetGeoNames(string apiUrl)
        { 
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    return null;
                }
        }
    }
}

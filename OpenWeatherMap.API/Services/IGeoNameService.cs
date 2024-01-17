namespace OpenWeatherMap.API.Services
{
    public interface IGeoNameService
    {
      Task<string> GetGeoNames(string apiUrl);
    }
}

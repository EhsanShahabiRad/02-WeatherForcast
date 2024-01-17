using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain
{
    public class Geoname
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
  
    }
}

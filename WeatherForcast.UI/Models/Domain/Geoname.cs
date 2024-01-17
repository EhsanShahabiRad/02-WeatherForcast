using System.Text.Json.Serialization;

namespace WeatherForcast.UI.Models.Domain
{
    public class Geoname
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

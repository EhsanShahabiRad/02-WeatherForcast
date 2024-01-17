using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.LatLon
{

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }


}

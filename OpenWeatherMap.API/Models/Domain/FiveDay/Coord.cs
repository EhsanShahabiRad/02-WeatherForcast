using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.FiveDay
{
    public class Coord
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }


}

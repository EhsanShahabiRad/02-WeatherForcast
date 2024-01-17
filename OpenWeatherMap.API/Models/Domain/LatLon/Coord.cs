using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.LatLon
{
    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }


}

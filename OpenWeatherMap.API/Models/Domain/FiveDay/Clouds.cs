using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.FiveDay
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }


}

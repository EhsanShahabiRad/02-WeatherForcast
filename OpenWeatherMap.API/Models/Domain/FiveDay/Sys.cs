using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.FiveDay
{
    public class Sys
    {
        [JsonPropertyName("pod")]
        public string Pod { get; set; }
    }


}

using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.LatLon
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }


}

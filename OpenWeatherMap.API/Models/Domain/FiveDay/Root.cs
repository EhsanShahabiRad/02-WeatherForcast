using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.FiveDay
{
    public class Root
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; }
        [JsonPropertyName("message")]
        public int Message { get; set; }
        [JsonPropertyName("cnt")]
        public int Cnt { get; set; }
        [JsonPropertyName("list")]
        public List<List> List { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }
    }


}

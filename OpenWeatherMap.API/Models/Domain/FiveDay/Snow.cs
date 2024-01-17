using Newtonsoft.Json;

namespace OpenWeatherMap.API.Models.Domain.FiveDay
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double _3h { get; set; }
    }


}

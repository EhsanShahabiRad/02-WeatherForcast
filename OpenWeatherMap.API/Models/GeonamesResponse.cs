using OpenWeatherMap.API.Models.Domain;

namespace OpenWeatherMap.API.Models
{
    public class GeonamesResponse
    {
        public int TotalResultsCount { get; set; }
        public Geoname[] geonames { get; set; }
    }
}

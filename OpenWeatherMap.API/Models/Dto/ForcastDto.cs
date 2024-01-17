using OpenWeatherMap.API.Models.Domain;

namespace OpenWeatherMap.API.Models.Dto
{
    public class ForcastDto
    {
        public ForcastWeather  CurrentWeather { get; set; } = new ForcastWeather();
        public List< ForcastWeather> FutureWeather { get; set; }= new List< ForcastWeather>();
    }
}

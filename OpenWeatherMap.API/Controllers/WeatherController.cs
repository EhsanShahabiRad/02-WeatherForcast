using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenWeatherMap.API.Models.Domain.LatLon;
using OpenWeatherMap.API.Models.Domain.FiveDay;
using OpenWeatherMap.API.Models.Dto;
using Microsoft.Extensions.Options;

namespace OpenWeatherMap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        HttpClient client = new HttpClient();
        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecastByCityName([FromQuery] string city)
        {

            
           // string apiKey = "fcadd28326c90c3262054e0e6ca599cd";

          //  string openWeatherLatLogURI = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
           
            string LatLonbaseUrl = _configuration["WeatherApi:LatLonBaseUrl"];
            string FiveDaysbaseUrl = _configuration["WeatherApi:FiveDaysForcastBaseUrl"];
            string apiKey = _configuration["WeatherApi:ApiKey"];

            
            string openWeatherLatLogURI = $"{LatLonbaseUrl}?q={city}&appid={apiKey}";

            Models.Domain.LatLon.Root LatLonData = await FetchLatLonData(openWeatherLatLogURI);
            var lat = LatLonData.Coord.Lat;
            var lon = LatLonData.Coord.Lon;
            string openWeatherFiveDaysURI = $"{FiveDaysbaseUrl}?lat={lat}&lon={lon}&appid={apiKey}";
         //   string openWeatherFiveDaysURI = $"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}";

            Models.Domain.FiveDay.Root FiveDayData = await FetchFiveDaysData(openWeatherFiveDaysURI);

            ForcastDto forcastDto = new ForcastDto();
            forcastDto.CurrentWeather.Humidity = LatLonData.Main.Humidity;
            forcastDto.CurrentWeather.Tempreture = LatLonData.Main.Temp;
            forcastDto.CurrentWeather.WindSpeed = LatLonData.Wind.Speed;
            foreach (var item in  FiveDayData.List)
            {
                forcastDto.FutureWeather.Add(new Models.Domain.ForcastWeather
                {
                    Humidity = item.Main.Humidity,
                    Tempreture = item.Main.Temp,
                    WindSpeed = item.Wind.Speed

                } ) ;
            }

            var x = 1;
            return Ok(forcastDto);

            //Get 5 Days Forcast
            async Task<Models.Domain.FiveDay.Root> FetchFiveDaysData(string openWeatherFiveDaysURI)
            {
                Models.Domain.FiveDay.Root root = new Models.Domain.FiveDay.Root();
                try
                {
                    
                        root = await client.GetFromJsonAsync<Models.Domain.FiveDay.Root>(openWeatherFiveDaysURI);
                        if (root != null)
                        {
                            return root;
                        }


                        //  string json = await response.Content.ReadAsStringAsync();
                        return null;
                    
                }
                catch (HttpRequestException ex)
                {
                    return null;
                }
            }

            //Get Lat and Lot
             async Task<Models.Domain.LatLon.Root> FetchLatLonData(string openWeatherLatLogURI)
            {
                Models.Domain.LatLon.Root root = new Models.Domain.LatLon.Root();
                try
                {
                   
                        root = await client.GetFromJsonAsync<Models.Domain.LatLon.Root>(openWeatherLatLogURI);
                        if (root != null)
                        {
                            return root;
                        }
                        return null;
                    
                }
                catch (HttpRequestException ex)
                {
                    return null;
                }
            }
        }
    }
}





    

using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OpenWeatherMap.API.Models;
using OpenWeatherMap.API.Services;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IGeoNameService _geoNameService;

    public CityController(IConfiguration configuration, IGeoNameService geoNameService)
    {
        _configuration = configuration;
        _geoNameService = geoNameService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCityNames()
    {
        string geoNamesApiUrl = _configuration["GeonameApi"];

        string geoNamesJson =  await _geoNameService.GetGeoNames(geoNamesApiUrl); 

        if (string.IsNullOrEmpty(geoNamesJson))
        {
            return StatusCode(500, "Error fetching data from Geonames API");
        }

        
        GeonamesResponse geonamesResponse = JsonSerializer.Deserialize<GeonamesResponse>(geoNamesJson);

        // Extract city names
        var cityNames = geonamesResponse?.geonames?.Select(geoname => geoname.Name);

        if (cityNames != null)
        {
            return Ok(cityNames);
        }

        return NoContent();
    }

    //private async Task<string> GetGeonamesJsonAsync(string apiUrl)
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        try
    //        {
    //            HttpResponseMessage response = await client.GetAsync(apiUrl);
    //            response.EnsureSuccessStatusCode(); 

    //            return await response.Content.ReadAsStringAsync();
    //        }
    //        catch (HttpRequestException e)
    //        {
    //            Console.WriteLine($"Error: {e.Message}");
    //            return null;
    //        }
    //    }
    //}
}
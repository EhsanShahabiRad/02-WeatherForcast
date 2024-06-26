﻿using System.Text.Json.Serialization;

namespace OpenWeatherMap.API.Models.Domain.LatLon
{
    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double Feels_like { get; set; }
        [JsonPropertyName("temp_min")]
        public double Temp_min { get; set; }
        [JsonPropertyName("temp_max")]
        public double Temp_max { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }


}

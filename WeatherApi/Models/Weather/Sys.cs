using System.Text.Json.Serialization;

namespace WeatherApi.Models.Weather
{
    public class Sys
    {
        [JsonPropertyName("country")] public string Country { get; set; } = string.Empty;
    }
}

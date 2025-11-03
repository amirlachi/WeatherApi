using System.Text.Json.Serialization;

namespace WeatherApi.Models.Weather
{
    public class Wind
    {
        [JsonPropertyName("speed")] public double Speed { get; set; }
    }
}

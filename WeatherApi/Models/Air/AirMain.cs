using System.Text.Json.Serialization;

namespace WeatherApi.Models.Air
{
    public class AirMain
    {
        [JsonPropertyName("aqi")] public int Aqi { get; set; }
    }
}

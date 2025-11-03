using System.Text.Json.Serialization;

namespace WeatherApi.Models.Weather
{
    public class Main
    {
        [JsonPropertyName("temp")] public double Temp { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
    }
}

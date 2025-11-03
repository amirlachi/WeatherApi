using System.Text.Json.Serialization;

namespace WeatherApi.Models.Air
{
    public class AirPollutionItem
    {
        [JsonPropertyName("main")] public AirMain Main { get; set; } = new();
        [JsonPropertyName("components")] public Dictionary<string, double> Components { get; set; } = new();
    }
}

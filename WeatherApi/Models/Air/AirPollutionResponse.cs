using System.Text.Json.Serialization;

namespace WeatherApi.Models.Air
{
    public class AirPollutionResponse
    {
        [JsonPropertyName("list")]
        public List<AirPollutionItem> List { get; set; } = new();
    }
}

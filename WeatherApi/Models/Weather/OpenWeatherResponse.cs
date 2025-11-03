using System.Text.Json.Serialization;

namespace WeatherApi.Models.Weather
{
    public class OpenWeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; } = new();

        [JsonPropertyName("main")]
        public Main Main { get; set; } = new();

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = new();

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; } = new();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}

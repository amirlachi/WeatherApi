using System.Globalization;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using WeatherApi.Models;
using WeatherApi.Models.Air;
using WeatherApi.Models.Weather;

namespace WeatherApi.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(HttpClient httpClient, IConfiguration config, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient;
            _apiKey = config["OpenWeather:ApiKey"] ?? throw new Exception("API key not configured.");
            _logger = logger;
        }

        public async Task<WeatherResponse> GetCityEnvironmentAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City name must not be empty.");

            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            _logger.LogInformation("Fetching weather for {City}", city);

            var weatherResult = await GetJsonAsync<OpenWeatherResponse>(weatherUrl);
            if (weatherResult == null)
                throw new InvalidOperationException("Weather data not found.");

            double lat = weatherResult.Coord.Lat;
            double lon = weatherResult.Coord.Lon;

            var airUrl = $"https://api.openweathermap.org/data/2.5/air_pollution?lat={lat.ToString(CultureInfo.InvariantCulture)}&lon={lon.ToString(CultureInfo.InvariantCulture)}&appid={_apiKey}";
            _logger.LogInformation("Fetching air pollution data for coordinates ({Lat}, {Lon})", lat, lon);

            var airResult = await GetJsonAsync<AirPollutionResponse>(airUrl);
            if (airResult == null || airResult.List.Count == 0)
                throw new InvalidOperationException("Air pollution data not found.");

            var pollutants = airResult.List.First().Components;
            int aqi = airResult.List.First().Main.Aqi;

            var airQualityText = Enum.IsDefined(typeof(AirQualityLevel), aqi)
                ? ((AirQualityLevel)aqi).ToString()
                : "Unknown";

            return new WeatherResponse(
                Temperature: weatherResult.Main.Temp,
                Humidity: weatherResult.Main.Humidity,
                WindSpeed: weatherResult.Wind.Speed,
                City: weatherResult.Name,
                Country: weatherResult.Sys.Country,
                AQI: aqi,
                MajorPollutants: pollutants,
                Latitude: lat,
                Longitude: lon,
                AirQualityText: airQualityText
            );
        }

        private async Task<T?> GetJsonAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                _logger.LogError("API error ({StatusCode}): {Error}", response.StatusCode, error);
                throw new HttpRequestException($"API error ({response.StatusCode}): {error}");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}

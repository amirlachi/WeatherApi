namespace WeatherApi.Models
{
    public record WeatherResponse(
        double Temperature,
        int Humidity,
        double WindSpeed,
        string City,
        string Country,
        int AQI,
        Dictionary<string, double> MajorPollutants,
        double Latitude,
        double Longitude,
        string AirQualityText
    );

    public enum AirQualityLevel
    {
        Good = 1,
        Fair = 2,
        Moderate = 3,
        Poor = 4,
        VeryPoor = 5
    }
}

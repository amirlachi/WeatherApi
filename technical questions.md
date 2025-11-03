
---

## 2) `Answers to technical questions.md`
```markdown
# Answers to technical questions

## 1) How much time did you spend on this task?
I spent approximately **6 hours** implementing, testing and documenting the API.

## If you had more time, what improvements or additions would you make?
- Add caching (in-memory or Redis) to avoid calling OpenWeather for frequent requests.
- Add rate-limiting and request throttling to protect the API and respect OpenWeather quotas.
- Add end-to-end integration tests using a recorded HTTP mock (e.g., WireMock or VCR-style fixtures).
- Add Dockerfile and Helm chart for containerized deployment.
- Add a small frontend or simple client to visualize data (map + pollutant graphs).
- Internationalization for textual AQI levels and better error messages.

## 2) Most useful recent feature in your favorite language (C#)
I find **record types** and **init-only setters** very useful for concise immutable DTOs.

Example:
```csharp
public record WeatherResponse(
    double Temperature,
    int Humidity,
    double WindSpeed,
    string City,
    string Country,
    int AQI,
    Dictionary<string,double> MajorPollutants,
    double Latitude,
    double Longitude,
    string AirQualityText
);

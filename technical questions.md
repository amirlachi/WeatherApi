
---

## 2) `Answers to technical questions`
```markdown
# Answers to technical questions
```
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
```
3) How do you identify and diagnose a performance issue in production?

- Collect metrics: CPU, memory, GC pauses, request rate, latencies (APM tools like Application Insights/New Relic/Datadog).

- Correlate logs and traces (distributed tracing — OpenTelemetry).

- Reproduce in staging with load tests.

- Use flamegraphs / CPU profiler to find hotspots.

- Inspect database slow queries and missing indexes.

- Mitigations: add caching, tune DB queries, optimize serialization, scale horizontally.

(Have performed these steps in prior projects — used profiling + APM + DB slow query logs.)

4) Last technical book or conference

- Book: Clean Architecture by Robert C. Martin — reinforced boundaries between layers and SOLID practices.

5) Opinion about this technical test

The test is practical and well-scoped: it asks for integration with a real external API, requires proper configuration and at least one unit test. It effectively evaluates design, error handling, and deliverables. Small improvements could include clearer expectations around deployment or required .NET version.

6) Describe yourself using JSON
```json
{
  "name": "Amirreza Lachinani",
  "age": 22,
  "role": "Backend Developer (C#/.NET)",
  "skills": ["C#", "ASP.NET Core", "SQL Server", "EF Core", "REST APIs"],
  "interests": ["Backend development", "Databases", "Clean Code"]
}
```

---

## 3) `.gitignore`


bin/
obj/
.vs/
*.user
*.suo
*.userosscache
*.sln.docstates
.env
secrets.json
**/appsettings.Development.json

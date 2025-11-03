# Weather + Air Quality API

This is a .NET Web API that returns current weather and air pollution data for a given city using OpenWeatherMap.

## Features
- Temperature (°C)
- Humidity (%)
- Wind speed (m/s)
- Air Quality Index (AQI) and textual level
- Major pollutants (e.g., pm2_5, pm10, co, no2, so2, o3)
- Coordinates (latitude / longitude)

## Required
- .NET 8 SDK (or .NET 7 if you changed target)
- OpenWeatherMap API key (free)

## Setup (local)
1. Clone the repo:
```bash
git clone https://github.com/amirlachi/WeatherApi.git
cd WeatherApi
```

2. Configure API key (one of these):
- Using environment variable (recommended):
```bash
# Linux / macOS
export OpenWeather__ApiKey="93af83931a38b3f56305041db555b35b"
# Windows (PowerShell)
$env:OpenWeather__ApiKey="93af83931a38b3f56305041db555b35b"
```

- Or using dotnet user-secrets (in project folder):
```bash
dotnet user-secrets init
dotnet user-secrets set "OpenWeather:ApiKey" "93af83931a38b3f56305041db555b35b"
```

3. Run:
```bash
dotnet run --project src/WeatherApi
```

4. Example request:
```bash
GET https://localhost:5001/api/weather/Tehran
```


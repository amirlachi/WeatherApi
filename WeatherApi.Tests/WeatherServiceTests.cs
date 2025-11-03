using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Services;

namespace WeatherApi.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetCityEnvironmentAsync_ShouldReturnWeatherResponse()
        {
            // Arrange
            var httpMessageHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(httpMessageHandler);
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?> { { "OpenWeather:ApiKey", "fakekey" } })
                .Build();
            var logger = Mock.Of<ILogger<WeatherService>>();

            var service = new WeatherService(httpClient, config, logger);

            // Act
            var result = await service.GetCityEnvironmentAsync("Tehran");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tehran", result.City);
            Assert.Equal(25, result.Temperature);
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string json;
            if (request.RequestUri!.ToString().Contains("weather"))
            {
                json = @"{
                ""coord"": { ""lon"": 51.4215, ""lat"": 35.6944 },
                ""main"": { ""temp"": 25, ""humidity"": 40 },
                ""wind"": { ""speed"": 5 },
                ""sys"": { ""country"": ""IR"" },
                ""name"": ""Tehran""
            }";
            }
            else
            {
                json = @"{
                ""list"": [{
                    ""main"": { ""aqi"": 2 },
                    ""components"": { ""pm2_5"": 10, ""co"": 100 }
                }]
            }";
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };
            return Task.FromResult(response);
        }
    }
}

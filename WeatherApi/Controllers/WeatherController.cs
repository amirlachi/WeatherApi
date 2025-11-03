using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("environment/{city}")]
        public async Task<ActionResult<WeatherResponse>> Get(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest(new { message = "City name is required." });

            var result = await _weatherService.GetCityEnvironmentAsync(city);
            return Ok(result);
        }
    }
}

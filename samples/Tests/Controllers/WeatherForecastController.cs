using Application;
using Microsoft.AspNetCore.Mvc;


namespace Tests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly Test1 _test;
        private readonly Test _test1;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, Test1 test, Test test1)
        {
            _logger = logger;
            _test = test;
            _test1 = test1;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var s = _test.Name;
            var ss = _test1.Name;
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
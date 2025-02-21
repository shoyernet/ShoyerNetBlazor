using Microsoft.AspNetCore.Mvc;

namespace ShoyerNetBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult GetWeather()
        {
            var rng = new Random();
            var weather = Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateTime.Now.AddDays(index).ToShortDateString(),
                TemperatureC = rng.Next(-20, 35),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();

            return Ok(weather);
        }
    }
}

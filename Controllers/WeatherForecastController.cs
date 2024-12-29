using AspNetCoreOpenTelemetryDemo.Data;
using AspNetCoreOpenTelemetryDemo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreOpenTelemetryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WeatherForecastController(MyDbContext context)
        {
            _context = context;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("external")]
        [HttpGet]
        public async Task GetExternalApiData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://www.ezzylearning.net");

            response.EnsureSuccessStatusCode();
        }

        [Route("countries")]
        [HttpGet]
        public async Task<IEnumerable<dynamic>> GetCountries()
        {
            return await _context.Countries                
                .Select(x => new
                {
                    x.Id,
                    x.Name
                })
                .OrderBy(x => x.Name)
                .Take(5)
                .ToListAsync();
        }
    }
}

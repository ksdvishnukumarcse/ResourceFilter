using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFilter.API.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceFilter.API.Controllers
{
    /// <summary>
    /// WeatherForecastController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// The summaries
        /// </summary>
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Withes the cache filter attributre.
        /// </summary>
        /// <returns>Collection of WeatherForecast</returns>
        [HttpGet("with-cache-filter-attribute")]
        [CacheResource]
        public IEnumerable<WeatherForecast> WithCacheFilterAttributre()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Withes the out cache filter attributre.
        /// </summary>
        /// <returns>Collection of WeatherForecast</returns>
        [HttpGet("with-out-cache-filter-attribute")]
        public IEnumerable<WeatherForecast> WithOutCacheFilterAttributre()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace TrainingPrometheus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly Gauge WeatherForecastTempraturesMetrics = Metrics.CreateGauge(
            $"{nameof(TrainingPrometheus)}_weather_forecast_temperatures", "Weather forecast temperatures",
            new GaugeConfiguration
            {
                LabelNames = new[] { "temperature" }
            });

        private static readonly Histogram WeatherForecastTempraturesDuration = Metrics.CreateHistogram
            ($"{nameof(TrainingPrometheus)}_weather_forecast_temperatures_duration", "Histogram of get weather forecast temperatures durations.");

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using (WeatherForecastTempraturesDuration.NewTimer())
            {
                var rng = new Random();
                var temperatures = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();

                foreach (var temperature in temperatures)
                {
                    WeatherForecastTempraturesMetrics.WithLabels(temperature.Date.ToString("d")).Set(temperature.TemperatureC);
                }

                return temperatures;
            }
        }
    }
}

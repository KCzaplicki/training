using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrainingDocker.Dtos;
using TrainingDocker.Repositories;

namespace TrainingDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastsRepository _weatherForecastsRepository;

        public WeatherForecastController(IWeatherForecastsRepository weatherForecastsRepository)
        {
            _weatherForecastsRepository = weatherForecastsRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForecasts = _weatherForecastsRepository.Get();

            return weatherForecasts.Select(x => new WeatherForecast
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            });
        }
    }
}

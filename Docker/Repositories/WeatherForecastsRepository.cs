using System.Collections.Generic;
using System.Linq;
using TrainingDocker.Models;

namespace TrainingDocker.Repositories
{
    public interface IWeatherForecastsRepository : IReadOnlyRepository<WeatherForecast>
    {
    }

    public class WeatherForecastsRepository : IWeatherForecastsRepository
    {
        private readonly TrainingDockerDbContext _context;

        public WeatherForecastsRepository(TrainingDockerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherForecast> Get() => _context.WeatherForecasts;

        public WeatherForecast Get(int id) => _context.WeatherForecasts.FirstOrDefault(x => x.Id == id);
    }
}

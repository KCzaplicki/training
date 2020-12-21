using TrainingDocker.Models;
using System;
using System.Linq;

namespace TrainingDocker
{
    public class DbInitializer
    {
        public static void Initialize(TrainingDockerDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.WeatherForecasts.Any())
            {
                return;
            }

            var weatherForecasts = new WeatherForecast[]
            {
                new WeatherForecast
                {
                    Date = DateTime.Today.AddDays(-2),
                    TemperatureC = 20,
                    Summary = "Sunny"
                },
                new WeatherForecast
                {
                    Date = DateTime.Today.AddDays(-1),
                    TemperatureC = 15,
                    Summary = "Raining"
                },
                new WeatherForecast
                {
                    Date = DateTime.Today,
                    TemperatureC = 10,
                    Summary = "Windy"
                }
            };

            context.WeatherForecasts.AddRange(weatherForecasts);
            context.SaveChanges();
        }
    }
}

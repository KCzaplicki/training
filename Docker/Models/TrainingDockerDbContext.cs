using Microsoft.EntityFrameworkCore;

namespace TrainingDocker.Models
{
    public class TrainingDockerDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public TrainingDockerDbContext(DbContextOptions<TrainingDockerDbContext> options) : base(options)
        {
        }
    }
}

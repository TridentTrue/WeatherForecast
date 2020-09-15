using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WeatherForecast.Infrastructure.Persistence
{
    // This factory class is required for development of the database using EF
    public class WeatherForecastContextFactory : IDesignTimeDbContextFactory<WeatherForecastContext>
    {
        public WeatherForecastContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WeatherForecast;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new WeatherForecastContext(optionsBuilder.Options);
        }
    }
}
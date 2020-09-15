using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Infrastructure.Persistence
{
	public class WeatherForecastContext : IdentityDbContext
	{
		public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
			: base(options)
		{
		}
	}
}

// This section is required for development of the database using EF
namespace WeatherForecast.Infrastructure
{
	using Microsoft.EntityFrameworkCore.Design;
	using WeatherForecast.Infrastructure.Persistence;

	public class GroceriesContextFactory : IDesignTimeDbContextFactory<WeatherForecastContext>
    {
        public WeatherForecastContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WeatherForecast;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new WeatherForecastContext(optionsBuilder.Options);
        }
    }
}
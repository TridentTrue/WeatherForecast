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
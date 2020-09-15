using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Common.Models;

namespace WeatherForecast.Application.Common.Interfaces
{
	public interface IWeatherService
	{
		Task<FiveDayForecastModel> GetFiveDayForecast(int woeid);
	}
}

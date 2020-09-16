using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Application.Common.Interfaces;

namespace WeatherForecast.MVC.ViewComponents
{
	public class FiveDayForecastViewComponent : ViewComponent
	{
		private readonly IWeatherService _weather;

		public FiveDayForecastViewComponent(IWeatherService weather)
		{
			_weather = weather;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			// Using WhereOnEarth ID for belfast. Could be modified to accept a parameter later.
			return View(await _weather.GetFiveDayForecast(44544));
		}
	}
}

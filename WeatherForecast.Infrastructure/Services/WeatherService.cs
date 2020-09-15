using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Common.Interfaces;
using WeatherForecast.Application.Common.Models;

namespace WeatherForecast.Infrastructure.Services
{
	public class WeatherService : IWeatherService
	{
		private const string BaseUrl = "https://www.metaweather.com/api/location/";
		private readonly HttpClient _client;

		public WeatherService(HttpClient client)
		{
			_client = client;
		}

		public async Task<FiveDayForecastModel> GetFiveDayForecast(int woeid)
		{
			HttpResponseMessage httpResponse = await _client.GetAsync(@$"{BaseUrl}{woeid}");

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new HttpRequestException("No data could be retrieved");
			}

			string responseContent = await httpResponse.Content.ReadAsStringAsync();
			FiveDayForecastModel task = JsonConvert.DeserializeObject<FiveDayForecastModel>(responseContent);

			return task;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherForecast.Infrastructure.Services;
using System.Threading.Tasks;
using Xunit;
using WeatherForecast.Application.Common.Models;

namespace WeatherForecast.Infrastructure.UnitTests.Services
{
	public class WeatherServiceTests
	{
		private readonly WeatherService _weatherService;

		public WeatherServiceTests()
		{
			_weatherService = new WeatherService(new HttpClient());
		}

		[Theory]
		[InlineData(44544, "Belfast")]
		[InlineData(44418, "London")]
		[InlineData(2487956, "San Francisco")]
		public async Task WeatherService_ReturnsDataForCityAsync(int woeid, string city)
		{
			var result = await _weatherService.GetFiveDayForecast(woeid);

			// check data arrives in expected format
			Assert.NotNull(result);
			Assert.IsType<FiveDayForecastModel>(result);

			// check city matches
			Assert.True(result.title == city);

			// check there is weather data for today and the next 5 days
			Assert.True(result.consolidated_weather.Length == 6);
		}

		[Fact]
		public async Task WeatherService_ThrowsHttpRequestExceptionAsync()
		{
			// test with invalid WherOnEarth ID
			await Assert.ThrowsAsync<HttpRequestException>(() => _weatherService.GetFiveDayForecast(99999999));
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WeatherForecast.Application.Common.Interfaces;
using WeatherForecast.MVC.Models;

namespace WeatherForecast.MVC.Controllers
{
	[Authorize]
    public class ForecastController : Controller
    {
  //      private readonly IWeatherService _weather;

  //      public ForecastController(IWeatherService weather)
  //      {
  //          _weather = weather;
  //      }

  //      public async Task<JsonResult> Test()
  //      {
  //          // Using WhereOnEarth ID for belfast. Could be modified to accept a parameter later.
  //          return Json(await _weather.GetFiveDayForecast(44544));
  //      }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FiveDayForecast()
        {
            return ViewComponent("FiveDayForecast");
        }
    }
}

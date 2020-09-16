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
        private readonly IWeatherService _weather;

        public ForecastController(IWeatherService weather)
        {
            _weather = weather;
        }

        public async Task<JsonResult> Test()
		{
            return Json(await _weather.GetFiveDayForecast(44544));
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FiveDayForecast()
        {
            return ViewComponent("FiveDayForecast");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

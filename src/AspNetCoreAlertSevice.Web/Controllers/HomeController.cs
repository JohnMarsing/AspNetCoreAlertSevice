using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreAlertSevice.Web.Models;
using AspNetCoreAlertSevice.Web.Features.Alerts;

namespace AspNetCoreAlertSevice.Web.Controllers
{
	public class HomeController : Controller
	{
		public AlertService _alertService { get; set; }
		public HomeController(AlertService alertService)
		{
			_alertService = alertService;
		}

		public IActionResult Index()
		{
			_alertService.Danger("It's my <b>middle</b> name.", true);
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAlertSevice.Web.Features.Alerts;

namespace AspNetCoreAlertSevice.Web.ViewComponents
{
	public class AlertsViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var alerts = TempData.ContainsKey(Alert.TempDataKey)
			? (List<Alert>)TempData[Alert.TempDataKey]
			: new List<Alert>();

			return View(alerts);
		}
	}
}

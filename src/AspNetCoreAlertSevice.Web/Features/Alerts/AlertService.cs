﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace AspNetCoreAlertSevice.Web.Features.Alerts
{
	public class AlertService
	{
		private readonly ITempDataDictionary _tempData;

		public AlertService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
		{
			_tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
		}

		public void Success(string message, bool dismissable = true)
		{
			AddAlert(AlertStyles.Success, message, dismissable);
		}

		public void Information(string message, bool dismissable = true)
		{
			AddAlert(AlertStyles.Information, message, dismissable);
		}

		public void Warning(string message, bool dismissable = true)
		{
			AddAlert(AlertStyles.Warning, message, dismissable);
		}

		public void Danger(string message, bool dismissable = true)
		{
			AddAlert(AlertStyles.Danger, message, dismissable);
		}

		private void AddAlert(string alertStyle, string message, bool dismissable)
		{
			var alerts = _tempData.ContainsKey(Alert.TempDataKey)
					? (List<Alert>)_tempData[Alert.TempDataKey]
					: new List<Alert>();

			alerts.Add(new Alert
			{
				AlertStyle = alertStyle,
				Message = message,
				Dismissable = dismissable
			});

			_tempData[Alert.TempDataKey] = alerts;
		}

	}
}

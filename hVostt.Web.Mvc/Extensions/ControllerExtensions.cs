using System;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ControllerExtensions
	{
		public static void SetCurrentTimeZone(this Controller controller, TimeZoneInfo timeZone)
		{
			TimeZoneManager.SetCurrent(controller.Session, timeZone);
		}

		public static TimeZoneInfo GetCurrentTimeZone(this Controller controller)
		{
			return TimeZoneManager.GetCurrent(controller.Session);
		}

		public static DateTime FromUtc(this Controller controller, DateTime dateTime)
		{
			return new TimeZoneManager(controller.Session).FromUtc(dateTime);
		}

		public static DateTime? FromUtc(this Controller controller, DateTime? dateTime)
		{
			return new TimeZoneManager(controller.Session).FromUtc(dateTime);
		}
	}
}

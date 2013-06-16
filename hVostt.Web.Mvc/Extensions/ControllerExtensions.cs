using System;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ControllerExtensions
	{
		public static void SetCurrentTimeZone(this ControllerBase controller, TimeZoneInfo timeZone)
		{
			if (timeZone == null)
				throw new ArgumentNullException("timeZone");
			var session = controller.ControllerContext.HttpContext.Session;
			if (session == null)
				throw new NullReferenceException("Session is null");
			session["TimeZone"] = timeZone;
		}

		public static TimeZoneInfo GetCurrentTimeZone(this ControllerBase controller, TimeZoneInfo defaultTimeZone = null)
		{
			var session = controller.ControllerContext.HttpContext.Session;
			var tz = (session == null) ? null : session["TimeZone"] as TimeZoneInfo;
			return tz ?? defaultTimeZone ?? TimeZoneInfo.Local;
		}

		public static DateTime FromUtc(this ControllerBase controller, DateTime dt, TimeZoneInfo defaultTimeZone = null)
		{
			return TimeZoneInfo.ConvertTimeFromUtc(dt, GetCurrentTimeZone(controller, defaultTimeZone));
		}

		public static DateTime? FromUtc(this ControllerBase controller, DateTime? dt, TimeZoneInfo defaultTimeZone = null)
		{
			if (dt.HasValue)
			{
				return TimeZoneInfo.ConvertTimeFromUtc(dt.Value, GetCurrentTimeZone(controller, defaultTimeZone));
			}
			return null;
		}
	}
}

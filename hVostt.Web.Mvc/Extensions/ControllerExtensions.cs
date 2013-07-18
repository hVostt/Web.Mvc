using System;
using System.Globalization;
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

		public static DateTime? IfModifiedSince(this Controller controller)
		{
			var rawIfModifiedSince = controller.Request.Headers.Get("If-Modified-Since");
			DateTime ifModifiedSince;
			return !string.IsNullOrEmpty(rawIfModifiedSince) &&
				   DateTime.TryParseExact(rawIfModifiedSince, "R", CultureInfo.InvariantCulture,
										  DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
										  out ifModifiedSince)
					   ? ifModifiedSince
					   : (DateTime?)null;
		}

		public static bool IfModifiedSince(this Controller controller, DateTime updated, bool updatedInLastModifiedFormat = false)
		{
			if (!updatedInLastModifiedFormat)
				updated = updated.ToLastModified();
			var ifModifiedSince = IfModifiedSince(controller);
			return ifModifiedSince.HasValue
				&& updated > ifModifiedSince.Value;
		}
	}
}

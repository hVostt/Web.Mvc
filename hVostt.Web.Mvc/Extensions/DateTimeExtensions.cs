using System;

namespace hVostt.Web.Mvc.Extensions
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Minimal DateTime (UTC) in Unix Timestamp format (0-day)
		/// </summary>
		public static readonly DateTime Epoc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Convert DateTime to Unix Timestamp
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>Unix timestamp</returns>
		public static long ToUnixTime(this DateTime dateTime)
		{
			var delta = dateTime.ToUniversalTime() - Epoc;

			return (long)delta.TotalSeconds;
		}

		/// <summary>
		/// Convert Unix Timestamp to DateTime (UTC)
		/// </summary>
		/// <param name="timestamp"></param>
		/// <returns>DateTime</returns>
		public static DateTime FromUnixTime(this long timestamp)
		{
			return Epoc.AddSeconds(timestamp);
		}

		/// <summary>
		/// Extract time part in TimeSpan from DateTime
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>TimeSpan</returns>
		public static TimeSpan ToTime(this DateTime dateTime)
		{
			return dateTime - dateTime.Date;
		}

		/// <summary>
		/// Get day of week by monday as week start
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>Number day of week (where monday is 0)</returns>
		public static int DayOfWeekByMonday(this DateTime dateTime)
		{
			if (dateTime.DayOfWeek == DayOfWeek.Sunday) return 6;
			return (int)dateTime.DayOfWeek - 1;
		}
	}
}

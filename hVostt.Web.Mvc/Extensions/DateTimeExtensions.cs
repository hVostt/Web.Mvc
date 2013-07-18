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

		/// <summary>
		/// Convert <paramref name="dateTime"/> to Last Modified DateTime format (without milliseconds)
		/// </summary>
		/// <remarks>
		/// <paramref name="dateTime"/> auto converted to UTC, if need
		/// </remarks>
		/// <param name="dateTime">Source DateTime</param>
		/// <returns>dateTime without milliseconds</returns>
		public static DateTime ToLastModified(this DateTime dateTime)
		{
			if (dateTime.Kind == DateTimeKind.Local)
				dateTime = dateTime.ToUniversalTime();
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
		}

		/// <summary>
		/// Convert <paramref name="dateTimeOffset"/> to Last Modified DateTime format (without milliseconds)
		/// </summary>
		/// <remarks>
		/// <paramref name="dateTimeOffset"/> auto converted to UTC
		/// </remarks>
		/// <param name="dateTimeOffset">Source DateTimeOffset</param>
		/// <returns>dateTime without milliseconds</returns>
		public static DateTime ToLastModified(this DateTimeOffset dateTimeOffset)
		{
			var dateTime = dateTimeOffset.UtcDateTime;
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
		}
	}
}

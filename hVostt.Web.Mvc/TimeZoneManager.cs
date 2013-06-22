using System;
using System.Web;
using System.Web.SessionState;

namespace hVostt.Web.Mvc
{
	public class TimeZoneManager
	{
		public static string SessionKey = "TimeZone";

		private readonly TimeZoneInfo _currentTimeZone;

		public TimeZoneManager()
		{
			_currentTimeZone = GetCurrent(HttpContext.Current.Session);
		}

		public TimeZoneManager(HttpSessionStateBase session)
		{
			_currentTimeZone = GetCurrent(session);
		}

		public TimeZoneManager(HttpSessionState session)
		{
			_currentTimeZone = GetCurrent(session);
		}

		public TimeZoneManager(TimeZoneInfo currentTimeZone)
		{
			_currentTimeZone = currentTimeZone;
		}

		/// <summary>
		/// Current time zone
		/// </summary>
		public TimeZoneInfo Current
		{
			get { return _currentTimeZone; }
		}

		/// <summary>
		/// DateTime.UtcNow converted to current time zone
		/// </summary>
		public DateTime Now
		{
			get { return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _currentTimeZone); }
		}

		/// <summary>
		/// Convert <paramref name="dateTime" /> to current time zone
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <param name="skipCheckKind">Skip check <paramref name="dateTime"/> Kind, otherwise Kind must be Utc</param>
		/// <returns>DateTime in current time zone</returns>
		public DateTime FromUtc(DateTime dateTime, bool skipCheckKind = false)
		{
			if (!skipCheckKind && dateTime.Kind != DateTimeKind.Utc)
				throw new ArgumentException("DateTime must be in UTC", "dateTime");
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, _currentTimeZone);
		}

		/// <summary>
		/// Convert <paramref name="dateTime" /> to current time zone
		/// </summary>
		/// <param name="dateTime">DateTime?</param>
		/// <param name="skipCheckKind">Skip check <paramref name="dateTime"/> Kind, otherwise Kind must be Utc</param>
		/// <returns>DateTime in current time zone</returns>
		public DateTime? FromUtc(DateTime? dateTime, bool skipCheckKind = false)
		{
			if (!dateTime.HasValue)
				return null;
			return FromUtc(dateTime.Value, skipCheckKind);
		}

		/// <summary>
		/// Convert <paramref name="dateTime"/> to UTC
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>DateTime in UTC</returns>
		public DateTime ToUtc(DateTime dateTime)
		{
			return dateTime.Kind == DateTimeKind.Utc
				? dateTime
				: TimeZoneInfo.ConvertTimeToUtc(dateTime, _currentTimeZone);
		}

		/// <summary>
		/// Convert <paramref name="dateTime"/> to UTC
		/// </summary>
		/// <param name="dateTime">DateTime</param>
		/// <returns>DateTime in UTC</returns>
		public DateTime? ToUtc(DateTime? dateTime)
		{
			if (!dateTime.HasValue)
				return null;
			return ToUtc(dateTime.Value);
		}

		/// <summary>
		/// Set current time zone in Session
		/// </summary>
		/// <param name="session">Session</param>
		/// <param name="timeZoneInfo">Current time zone</param>
		public static void SetCurrent(HttpSessionStateBase session, TimeZoneInfo timeZoneInfo)
		{
			if (timeZoneInfo == null)
				throw new ArgumentNullException("timeZoneInfo");
			if (session == null)
				throw new ArgumentNullException("session");
			session[SessionKey] = timeZoneInfo;
		}

		/// <summary>
		/// Set current time zone in Session
		/// </summary>
		/// <param name="session">Session</param>
		/// <param name="timeZoneInfo">Current time zone</param>
		public static void SetCurrent(HttpSessionState session, TimeZoneInfo timeZoneInfo)
		{
			if (timeZoneInfo == null)
				throw new ArgumentNullException("timeZoneInfo");
			if (session == null)
				throw new ArgumentNullException("session");
			session[SessionKey] = timeZoneInfo;
		}

		/// <summary>
		/// Get current time zone from Session
		/// </summary>
		/// <param name="session">Session</param>
		/// <returns>Current time zone info</returns>
		public static TimeZoneInfo GetCurrent(HttpSessionStateBase session)
		{
			if (session == null)
				throw new ArgumentNullException("session");
			return session[SessionKey] as TimeZoneInfo;
		}

		/// <summary>
		/// Get current time zone from Session
		/// </summary>
		/// <param name="session">Session</param>
		/// <returns>Current time zone info</returns>
		public static TimeZoneInfo GetCurrent(HttpSessionState session)
		{
			if (session == null)
				throw new ArgumentNullException("session");
			return session[SessionKey] as TimeZoneInfo;
		}
	}
}

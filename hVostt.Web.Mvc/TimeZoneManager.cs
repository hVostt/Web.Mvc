using System;
using System.Web;
using System.Web.SessionState;

namespace hVostt.Web.Mvc
{
	public class TimeZoneManager
	{
		public static string SessionKey = "TimeZone";

		private readonly TimeZoneInfo _timeZoneInfo;

		public TimeZoneManager()
		{
			_timeZoneInfo = GetCurrent(HttpContext.Current.Session);
		}

		public TimeZoneManager(HttpSessionStateBase session)
		{
			_timeZoneInfo = GetCurrent(session);
		}

		public TimeZoneManager(HttpSessionState session)
		{
			_timeZoneInfo = GetCurrent(session);
		}

		public TimeZoneManager(TimeZoneInfo timeZoneInfo)
		{
			_timeZoneInfo = timeZoneInfo;
		}

		public TimeZoneInfo Current { get { return _timeZoneInfo; } }

		public DateTime FromUtc(DateTime dateTime)
		{
			if (dateTime.Kind != DateTimeKind.Utc)
				throw new ArgumentException("DateTime must be in UTC", "dateTime");
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, _timeZoneInfo);
		}

		public DateTime? FromUtc(DateTime? dateTime)
		{
			if (!dateTime.HasValue)
				return null;
			return FromUtc(dateTime.Value);
		}

		public DateTime ToUtc(DateTime dateTime)
		{
			return dateTime.Kind == DateTimeKind.Utc
				? dateTime
				: TimeZoneInfo.ConvertTimeToUtc(dateTime, _timeZoneInfo);
		}

		public DateTime? ToUtc(DateTime? dateTime)
		{
			if (!dateTime.HasValue)
				return null;
			return ToUtc(dateTime.Value);
		}

		public static void SetCurrent(HttpSessionStateBase session, TimeZoneInfo timeZoneInfo)
		{
			if (timeZoneInfo == null)
				throw new ArgumentNullException("timeZoneInfo");
			if (session == null)
				throw new ArgumentNullException("session");
			session[SessionKey] = timeZoneInfo;
		}

		public static void SetCurrent(HttpSessionState session, TimeZoneInfo timeZoneInfo)
		{
			if (timeZoneInfo == null)
				throw new ArgumentNullException("timeZoneInfo");
			if (session == null)
				throw new ArgumentNullException("session");
			session[SessionKey] = timeZoneInfo;
		}

		public static TimeZoneInfo GetCurrent(HttpSessionStateBase session)
		{
			if (session == null)
				throw new ArgumentNullException("session");
			return session[SessionKey] as TimeZoneInfo;
		}

		public static TimeZoneInfo GetCurrent(HttpSessionState session)
		{
			if (session == null)
				throw new ArgumentNullException("session");
			return session[SessionKey] as TimeZoneInfo;
		}
	}
}

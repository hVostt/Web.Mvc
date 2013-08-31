using System;
using System.Globalization;
using System.Web;

namespace hVostt.Web.Mvc.Extensions
{
	public static class HttpRequestBaseExtensions
	{
		/// <summary>
		/// Get If-Modified-Since header from request
		/// </summary>
		/// <param name="request">Request</param>
		/// <returns>If-Modified-Since DateTime or null if empty</returns>
		public static DateTime? IfModifiedSince(this HttpRequestBase request)
		{
			var rawIfModifiedSince = request.Headers.Get("If-Modified-Since");
			DateTime ifModifiedSince;
			return !string.IsNullOrEmpty(rawIfModifiedSince) &&
				   DateTime.TryParseExact(rawIfModifiedSince, "R", CultureInfo.InvariantCulture,
										  DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
										  out ifModifiedSince)
					   ? ifModifiedSince
					   : (DateTime?)null;
		}

		/// <summary>
		/// Check if If-Modified-Since header is overdue (or empty)
		/// </summary>
		/// <param name="request">Request</param>
		/// <param name="lastModified">Last modified DateTime</param>
		/// <param name="updatedInLastModifiedFormat">Set to true, if <paramref name="lastModified" /> without milliseconds</param>
		/// <returns>Returns false if it is possible to response with status code 304 (Not Modified)</returns>
		public static bool IfModifiedSince(this HttpRequestBase request, DateTime lastModified, bool updatedInLastModifiedFormat = false)
		{
			var ifModifiedSince = IfModifiedSince(request);
			if (ifModifiedSince.HasValue)
			{
				if (!updatedInLastModifiedFormat)
					lastModified = lastModified.ToLastModified();
				return lastModified > ifModifiedSince.Value;
			}
			return true;
		}

		/// <summary>
		/// Get If-None-Match from request
		/// </summary>
		/// <param name="request">Request</param>
		/// <returns>Value of If-None-Match (or null if empty)</returns>
		public static string IfNoneMatch(this HttpRequestBase request)
		{
			return request.Headers.Get("If-None-Match");
		}

		/// <summary>
		/// Check if If-None-Match header is not equals <paramref name="etag"/> (or empty)
		/// </summary>
		/// <param name="request">Request</param>
		/// <param name="etag">Etag token</param>
		/// <param name="comparison">Rule for tokens comparsion (default StringComparison.Ordinal)</param>
		/// <returns>Returns false if it possible to response with code 304 (Not Modified)</returns>
		public static bool IfNoneMatch(this HttpRequestBase request, string etag, StringComparison comparison = StringComparison.Ordinal)
		{
			var ifNoneMatch = IfNoneMatch(request);
			return !etag.Equals(ifNoneMatch, comparison);
		}

	}
}

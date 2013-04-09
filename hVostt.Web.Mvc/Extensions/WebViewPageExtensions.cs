using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace hVostt.Web.Mvc.Extensions
{
	public static class WebViewPageExtensions
	{
		public static DateTime FromUtc(this WebViewPage page, DateTime dt)
		{
			var tz = (TimeZoneInfo)page.Session["TimeZone"];
			return TimeZoneInfo.ConvertTimeFromUtc(dt, tz);
		}

		public static DateTime? FromUtc(this WebViewPage page, DateTime? dt)
		{
			if (!dt.HasValue) return null;
			var tz = (TimeZoneInfo)page.Session["TimeZone"];
			return TimeZoneInfo.ConvertTimeFromUtc(dt.Value, tz);
		}

		public static void RedefineSection(this WebPageBase page, string sectionName)
		{
			if (page.IsSectionDefined(sectionName))
			{
				page.DefineSection(sectionName, () => page.Write(page.RenderSection(sectionName)));
			}
		}

		public static void RedefineSection(this WebPageBase page, params string[] sectionNames)
		{
			foreach (var s in sectionNames)
				RedefineSection(page, s);
		}
	}
}
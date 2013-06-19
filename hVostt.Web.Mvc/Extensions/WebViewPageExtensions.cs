using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace hVostt.Web.Mvc.Extensions
{
	public static class WebViewPageExtensions
	{
		public static TimeZoneManager GetTimeZoneManager(this WebViewPage page)
		{
			return new TimeZoneManager(page.Session);
		}

		public static DateTime FromUtc(this WebViewPage page, DateTime dateTime)
		{
			return GetTimeZoneManager(page).FromUtc(dateTime);
		}

		public static DateTime? FromUtc(this WebViewPage page, DateTime? dateTime)
		{
			return GetTimeZoneManager(page).FromUtc(dateTime);
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
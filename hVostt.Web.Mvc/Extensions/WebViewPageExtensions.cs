using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace hVostt.Web.Mvc.Extensions
{
	public static class WebViewPageExtensions
	{
		[Obsolete("use Controller.FromUtc extension")]
		public static DateTime FromUtc(this WebViewPage page, DateTime dt)
		{
			return page.ViewContext.Controller.FromUtc(dt);
		}

		[Obsolete("use Controller.FromUtc extension")]
		public static DateTime? FromUtc(this WebViewPage page, DateTime? dt)
		{
			return page.ViewContext.Controller.FromUtc(dt);
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
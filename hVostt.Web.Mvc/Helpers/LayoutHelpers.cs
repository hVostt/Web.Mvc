using System;
using System.Web;
using System.Web.Mvc;
using hVostt.Web.Mvc.Extensions;

namespace hVostt.Web.Mvc.Helpers
{
	public static class LayoutHelpers
	{
		private static string CreateTitle(string title)
		{
			return String.Format("<h2>{0}</h2>", HttpUtility.HtmlEncode(title));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper)
		{
			return new HtmlString(CreateTitle(htmlHelper.ViewData.Title()));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper, string title)
		{
			htmlHelper.ViewData.Title(title);
			return new HtmlString(CreateTitle(title));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper, string title, string subTitle)
		{
			htmlHelper.ViewData.Title(title);

			if (String.IsNullOrEmpty(subTitle))
				return new HtmlString(CreateTitle(title));

			return new HtmlString(String.Format("<hgroup><h2>{0}</h2><h3>{1}</h3></hgroup>",
				HttpUtility.HtmlEncode(title),
				HttpUtility.HtmlEncode(subTitle)));
		}
	}
}
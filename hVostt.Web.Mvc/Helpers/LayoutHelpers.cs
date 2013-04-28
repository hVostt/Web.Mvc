using System;
using System.Web;
using System.Web.Mvc;
using hVostt.Web.Mvc.Extensions;

namespace hVostt.Web.Mvc.Helpers
{
	public static class LayoutHelpers
	{
		public static string TitleFormat = "<h2 class=\"title\">{0}</h2>";
		public static string SubTitleFormat = "<hgroup class=\"title\"><h2>{0}</h2><h3>{1}</h3></hgroup>";

		private static string CreateTitle(string title)
		{
			return String.Format(TitleFormat, HttpUtility.HtmlEncode(title));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper)
		{
			return new HtmlString(CreateTitle(htmlHelper.ViewData.GetTitle()));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper, string title)
		{
			htmlHelper.ViewData.SetTitle(title);
			return new HtmlString(CreateTitle(title));
		}

		public static IHtmlString Title(this HtmlHelper htmlHelper, string title, string subTitle)
		{
			htmlHelper.ViewData.SetTitle(title);

			if (String.IsNullOrEmpty(subTitle))
				return new HtmlString(CreateTitle(title));

			return new HtmlString(String.Format(SubTitleFormat,
				HttpUtility.HtmlEncode(title),
				HttpUtility.HtmlEncode(subTitle)));
		}
	}
}
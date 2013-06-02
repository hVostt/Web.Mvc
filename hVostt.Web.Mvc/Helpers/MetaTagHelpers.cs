using System.Web;
using System.Web.Mvc;
using hVostt.Web.Mvc.Extensions;
using hVostt.Web.Mvc.Helpers.Meta;

namespace hVostt.Web.Mvc.Helpers
{
	public static class MetaTagHelpers
	{
		/// <summary>
		/// Get MetaBuilder for fluent adding meta tags
		/// </summary>
		/// <param name="html">HtmlHelper</param>
		/// <returns>MetaBuilder</returns>
		public static MetaBuilder Meta(this HtmlHelper html)
		{
			var collection = html.ViewData.Get<MetaCollection>(true);
			if (collection == null)
			{
				collection = new MetaCollection();
				html.ViewData.Set(collection, true);
			}
			return new MetaBuilder(collection);
		}

		/// <summary>
		/// Get rendered MetaCollection as IHtmlString
		/// </summary>
		/// <param name="html">HtmlHelper</param>
		/// <returns>Rendered meta tags</returns>
		public static IHtmlString MetaPartial(this HtmlHelper html)
		{
			var collection = html.ViewData.Get<MetaCollection>(true);
			return collection != null
				? new HtmlString(collection.ToString())
				: null;
		}
	}
}
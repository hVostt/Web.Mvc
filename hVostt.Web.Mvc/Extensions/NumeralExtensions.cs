using System;
using System.Globalization;
using System.Web;

namespace hVostt.Web.Mvc.Extensions
{
	public static class NumeralExtensions
	{
		public static IHtmlString ToPrice(this decimal d)
		{
			return new HtmlString(ToPriceString(d));
		}

		public static string ToPriceString(this decimal d)
		{
			return d.ToString(d - Decimal.Truncate(d) > 0 ? "#,#.00" : "#,#");
		}

		public static IHtmlString ToRaw(this decimal d)
		{
			return new HtmlString(d.ToString(CultureInfo.InvariantCulture));
		}

		public static IHtmlString ToRaw(this int i)
		{
			return new HtmlString(i.ToString(CultureInfo.InvariantCulture));
		}
	}
}
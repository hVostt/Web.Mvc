using System;
using System.Globalization;
using System.Web;

namespace hVostt.Web.Mvc.Extensions
{
	public static class NumeralExtensions
	{
		public static string ToPriceString(this decimal d, string zero = "")
		{
			return d == 0
				? zero
				: d.ToString(d - Decimal.Truncate(d) > 0 ? "#,#.00" : "#,#");
		}

		public static IHtmlString ToPrice(this decimal d, string zero = "")
		{
			return new HtmlString(ToPriceString(d, zero));
		}

		public static string ToRawString(this decimal d)
		{
			return d.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToRawString(this int i)
		{
			return i.ToString(CultureInfo.InvariantCulture);
		}

		public static IHtmlString ToRaw(this decimal d)
		{
			return new HtmlString(ToRawString(d));
		}

		public static IHtmlString ToRaw(this int i)
		{
			return new HtmlString(ToRawString(i));
		}
	}
}
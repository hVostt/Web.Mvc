using System.Web;

namespace hVostt.Web.Mvc
{
	public class Js
	{
		public static readonly IHtmlString Void = new HtmlString("javascript:void(0)");
		public static readonly IHtmlString Back = new HtmlString("javascript:history.back();");
	}
}
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewDataExtensions
	{
		public static void Title(this ViewDataDictionary viewData, string title)
		{
			viewData["Title"] = title;
		}

		public static void Title(this ViewDataDictionary viewData, string title, string subTitle)
		{
			viewData["Title"] = title;
			viewData["SubTitle"] = subTitle;
		}

		public static string Title(this ViewDataDictionary viewData)
		{
			return (string)viewData["Title"];
		}
	}
}
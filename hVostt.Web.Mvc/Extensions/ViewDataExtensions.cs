using System.Collections.Generic;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewDataExtensions
	{
		public static T As<T>(this ViewDataDictionary viewData, string key)
		{
			return (T)viewData[key];
		}

		public static IList<T> AsList<T>(this ViewDataDictionary viewData, string key)
		{
			return (IList<T>)viewData[key];
		}

		public static IEnumerable<T> AsEnum<T>(this ViewDataDictionary viewData, string key)
		{
			return (IEnumerable<T>)viewData[key];
		}

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
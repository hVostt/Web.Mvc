using System.Collections.Generic;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewDataExtensions
	{
		public static T Set<T>(this ViewDataDictionary viewData, T obj, bool fullName = false)
		{
			var type = typeof(T);
			viewData[fullName ? type.FullName : type.Name] = obj;
			return obj;
		}

		public static T Get<T>(this ViewDataDictionary viewData, bool fullName = false)
		{
			var type = typeof(T);
			return (T)viewData[fullName ? type.FullName : type.Name];
		}

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
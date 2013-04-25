using System.Collections.Generic;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewDataExtensions
	{
		public static string TitleKeyName = "Title";
		public static string SubTitleKeyName = "SubTitle";

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

		public static IEnumerable<T> AsEnumerable<T>(this ViewDataDictionary viewData, string key)
		{
			return (IEnumerable<T>)viewData[key];
		}

		public static IEnumerable<SelectListItem> AsSelectList(this ViewDataDictionary viewData, string key)
		{
			return (IEnumerable<SelectListItem>)viewData[key];
		}

		public static void Title(this ViewDataDictionary viewData, string title)
		{
			viewData[TitleKeyName] = title;
		}

		public static void SubTitle(this ViewDataDictionary viewData, string subTitle)
		{
			viewData[SubTitleKeyName] = subTitle;
		}

		public static void Title(this ViewDataDictionary viewData, string title, string subTitle)
		{
			viewData[TitleKeyName] = title;
			viewData[SubTitleKeyName] = subTitle;
		}

		public static string Title(this ViewDataDictionary viewData)
		{
			return (string)viewData[TitleKeyName];
		}

		public static string SubTitle(this ViewDataDictionary viewData)
		{
			return (string)viewData[SubTitleKeyName];
		}
	}
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewDataExtensions
	{
		/// <summary>
		/// Using by SetTitle() and GetTitle()
		/// </summary>
		public static string TitleKeyName = "Title";

		/// <summary>
		/// Using by SetTitle() and GetSubTitle()
		/// </summary>
		public static string SubTitleKeyName = "SubTitle";

		/// <summary>
		/// Using by Get&lt;T&gt;, Set&lt;T&gt; and Has&lt;T&gt;
		/// </summary>
		public static bool UseFullNameQualifier = false;

		/// <summary>
		/// Add <paramref name="obj"/> to ViewData by type name with UseFullNameQualifier
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="obj">Object</param>
		/// <returns>Returns <paramref name="obj"/></returns>
		public static T Set<T>(this ViewDataDictionary viewData, T obj)
			where T : class
		{
			return Set(viewData, obj, UseFullNameQualifier);
		}

		/// <summary>
		/// Add <paramref name="obj"/> to ViewData by type name with <paramref name="fullName"/>
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="obj">Object</param>
		/// <param name="fullName">Use or not full qualifier type name</param>
		/// <returns>Returns <paramref name="obj"/></returns>
		public static T Set<T>(this ViewDataDictionary viewData, T obj, bool fullName)
			where T : class
		{
			var type = typeof(T);
			viewData[fullName ? type.FullName : type.Name] = obj;
			return obj;
		}

		/// <summary>
		/// Returns object from ViewData by <typeparamref name="T"/> type name with UseFullNameQualifier
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <returns>Returns object of <typeparamref name="T"/> type</returns>
		public static T Get<T>(this ViewDataDictionary viewData)
			where T : class
		{
			return Get<T>(viewData, UseFullNameQualifier);
		}

		/// <summary>
		/// Returns object from ViewData by <typeparamref name="T"/> type name
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="fullName">Use or not full qualifier type name</param>
		/// <returns>Returns object of <typeparamref name="T"/> type</returns>
		public static T Get<T>(this ViewDataDictionary viewData, bool fullName)
			where T : class
		{
			var type = typeof(T);
			return (T)viewData[fullName ? type.FullName : type.Name];
		}

		/// <summary>
		/// Returns true if ViewData has object by <typeparamref name="T"/> type name with UseFullNameQualifier
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <returns>Returns ViewData.ContainsKey of <typeparamref name="T"/> type name</returns>
		public static bool Has<T>(this ViewDataDictionary viewData)
			where T : class
		{
			return Has<T>(viewData, UseFullNameQualifier);
		}

		/// <summary>
		/// Returns true if ViewData has object by <typeparamref name="T"/> type name
		/// </summary>
		/// <typeparam name="T">Resolve type name</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="fullName">Use or not full qualifier type name</param>
		/// <returns>Returns ViewData.ContainsKey of <typeparamref name="T"/> type name</returns>
		public static bool Has<T>(this ViewDataDictionary viewData, bool fullName)
			where T : class
		{
			var type = typeof(T);
			return viewData.ContainsKey(fullName ? type.FullName : type.Name);
		}

		/// <summary>
		/// Returns true if ViewData contains <paramref name="key"/>
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns>Returns ViewData.ContainsKey of <paramref name="key"/></returns>
		public static bool Has(this ViewDataDictionary viewData, string key)
		{
			return viewData.ContainsKey(key);
		}

		/// <summary>
		/// Returns true if ViewData contains <paramref name="key"/> and it's Boolean object is true
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns>Returns ViewData.ContainsKey of <paramref name="key"/> and it's contains Boolean == true</returns>
		public static bool Flag(this ViewDataDictionary viewData, string key)
		{
			return viewData.ContainsKey(key) && (bool)viewData[key];
		}

		/// <summary>
		/// Returns object from ViewData casted to <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Cast type</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns><typeparamref name="T"/> object</returns>
		public static T As<T>(this ViewDataDictionary viewData, string key)
		{
			return (T)viewData[key];
		}

		/// <summary>
		/// Returns IList from ViewData casted to <typeparamref name="T"/> type items
		/// </summary>
		/// <typeparam name="T">Items cast type</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns>IList&lt;<typeparamref name="T"/>&gt;</returns>
		public static IList<T> AsList<T>(this ViewDataDictionary viewData, string key)
		{
			return (IList<T>)viewData[key];
		}

		/// <summary>
		/// Returns IEnumerable from ViewData casted to <typeparamref name="T"/> type items
		/// </summary>
		/// <typeparam name="T">Items cast type</typeparam>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns>IEnumerable&lt;<typeparamref name="T"/>&gt;</returns>
		public static IEnumerable<T> AsEnumerable<T>(this ViewDataDictionary viewData, string key)
		{
			return (IEnumerable<T>)viewData[key];
		}

		/// <summary>
		/// Returns SelectList from ViewData
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <param name="key">Key</param>
		/// <returns>IEnumerable&lt;SelectListItem&gt;</returns>
		public static IEnumerable<SelectListItem> AsSelectList(this ViewDataDictionary viewData, string key)
		{
			return (IEnumerable<SelectListItem>)viewData[key];
		}

		/// <summary>
		/// Add/set Title to ViewData
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <param name="title">Title</param>
		public static string SetTitle(this ViewDataDictionary viewData, string title)
		{
			viewData[TitleKeyName] = title;
			return title;
		}

		/// <summary>
		/// Add/set Title and SubTitle to ViewData
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <param name="title">Title</param>
		/// <param name="subTitle">SubTitle</param>
		public static string SetTitle(this ViewDataDictionary viewData, string title, string subTitle)
		{
			viewData[TitleKeyName] = title;
			viewData[SubTitleKeyName] = subTitle;
			return title;
		}

		/// <summary>
		/// Get Title from ViewData
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <returns>Title string</returns>
		public static string GetTitle(this ViewDataDictionary viewData)
		{
			return (string)viewData[TitleKeyName];
		}

		/// <summary>
		/// Get SubTitle from ViewData
		/// </summary>
		/// <param name="viewData">ViewData</param>
		/// <returns>SubTitle string</returns>
		public static string GetSubTitle(this ViewDataDictionary viewData)
		{
			return (string)viewData[SubTitleKeyName];
		}
	}
}
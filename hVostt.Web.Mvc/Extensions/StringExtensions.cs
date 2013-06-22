using System;
using System.Web;

namespace hVostt.Web.Mvc.Extensions
{

	/// <summary>
	/// Happy String Extensions!
	/// No more UGLY String.Format, only "your string".F(params)
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Create RAW IHtmlString, that not be encoded in a template
		/// </summary>
		/// <param name="str">Source string</param>
		/// <returns>Wrapped string in HtmlString</returns>
		public static IHtmlString ToRaw(this string str)
		{
			return new HtmlString(str);
		}

		/// <summary>
		/// Crop string if length is greater <paramref name="maxLength"/>
		/// </summary>
		/// <param name="str">Source string</param>
		/// <param name="maxLength">Max length to crop</param>
		/// <returns>Cropped to <paramref name="maxLength"/> length</returns>
		public static string Crop(this string str, int maxLength)
		{
			if (str == null) return null;
			return str.Length > maxLength
					   ? str.Substring(0, maxLength)
					   : str;
		}

		/// <summary>
		/// Replaces one or more format items in a specified string with the string representation
		/// of a specified object.
		/// </summary>
		/// <param name="format">A composite format string (as String.Format).</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>
		/// A copy of format in which any format items are replaced by the string 
		/// representation of <paramref name="arg0"/>.
		/// </returns>
		public static string F(this string format, object arg0)
		{
			return String.Format(format, arg0);
		}

		/// <summary>
		/// Replaces the format item in a specified string with the string representation
		/// of a corresponding object in a specified array.
		/// </summary>
		/// <param name="format">A composite format string (as String.Format).</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>
		/// A copy of format in which the format items have been replaced by the string 
		/// representation of the corresponding objects in <paramref name="args"/>.
		/// </returns>
		public static string F(this string format, params object[] args)
		{
			return String.Format(format, args);
		}

		/// <summary>
		/// Replaces the format item in a specified string with the string representation
		/// of a corresponding object in a specified array. A specified parameter supplies
		/// culture-specific formatting information.
		/// </summary>
		/// <param name="format">A composite format string (as String.Format).</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>
		/// A copy of format in which the format items have been replaced by the string
		/// representation of the corresponding objects in <paramref name="args"/>.
		/// </returns>
		public static string F(this string format, IFormatProvider provider, params object[] args)
		{
			return String.Format(provider, format, args);
		}

		/// <summary>
		/// Replaces the format items in a specified string with the string representation
		/// of two specified objects.
		/// </summary>
		/// <param name="format">A composite format string (as String.Format).</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>
		/// A copy of format in which format items are replaced by the string representations
		/// of <paramref name="arg0"/> and <paramref name="arg1"/>.
		/// </returns>
		public static string F(this string format, object arg0, object arg1)
		{
			return String.Format(format, arg0, arg1);
		}

		/// <summary>
		/// Replaces the format items in a specified string with the string representation
		/// of three specified objects.
		/// </summary>
		/// <param name="format">A composite format string (as String.Format).</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>
		/// A copy of format in which the format items have been replaced by the string
		/// representations of <paramref name="arg0"/>, <paramref name="arg1"/>, and <paramref name="arg2"/>.
		/// </returns>
		public static string F(this string format, object arg0, object arg1, object arg2)
		{
			return String.Format(format, arg0, arg1, arg2);
		}
	}
}
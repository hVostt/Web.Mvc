﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class EnumExtensions
	{
		#region Display Extensions

		public static DisplayAttribute Display(this Enum value)
		{
			return Display(value.GetType(), value);
		}

		public static string Display(this Enum value, Func<DisplayAttribute, string> attr)
		{
			var display = value.Display();
			return display == null ? value.ToString() : attr(display);
		}

		public static string Display(this Enum value, Func<DisplayAttribute, string> attr, string noAttr)
		{
			var display = value.Display();
			return display == null ? noAttr : attr(display);
		}

		public static string DisplayName(this Enum value)
		{
			var display = value.Display();
			return display != null ? display.GetName() : value.ToString();
		}

		public static string DisplayDescription(this Enum value)
		{
			var display = value.Display();
			return display != null ? display.GetDescription() : value.ToString();
		}

		public static string DisplayShortName(this Enum value)
		{
			var display = value.Display();
			return display != null ? display.GetShortName() : value.ToString();
		}

		#endregion Display Extensions

		#region SelectList Extensions

		public static IEnumerable<SelectListItem> ToSelectList(this Enum value)
		{
			return GetSelectList(value);
		}

		public static IEnumerable<SelectListItem> ToMultiSelectList(this Enum value)
		{
			return GetMultiSelectList(value);
		}

		#endregion SelectList Extensions

		#region Display Methods

		public static DisplayAttribute Display(Type type, Enum value)
		{
			var name = Enum.GetName(type, value);
			return type.GetField(name).GetCustomAttribute<DisplayAttribute>();
		}

		public static DisplayAttribute Display(Type type, string value)
		{
			return type.GetField(value).GetCustomAttribute<DisplayAttribute>();
		}

		public static DisplayAttribute Display<T>(Enum value)
		{
			return Display(typeof(T), value);
		}

		public static DisplayAttribute Display<T>(string value)
		{
			return Display(typeof(T), value);
		}

		#endregion Display Mathods

		#region SelectList Methods

		public static IList<SelectListItem> GetSelectList<T>()
		{
			return GetSelectList(typeof(T));
		}

		public static IList<SelectListItem> GetSelectList(Enum value)
		{
			return GetSelectList(value.GetType(), value);
		}

		public static IList<SelectListItem> GetMultiSelectList(Enum value)
		{
			return GetMultiSelectList(value.GetType(), value);
		}

		public static IList<SelectListItem> GetMultiSelectList<T>(Enum value)
		{
			return value == null
				? GetSelectList(typeof(T))
				: GetMultiSelectList(typeof(T), value);
		}

		public static IList<SelectListItem> GetMultiSelectList<T>(IEnumerable<T> values)
		{
			if (values == null)
				return GetSelectList(typeof(T));

			try
			{
				var type = typeof(T);
				var list = (from T val in Enum.GetValues(type)
							let field = type.GetField(Enum.GetName(type, val))
							let display = field.GetCustomAttribute<DisplayAttribute>()
							let generate = display.GetAutoGenerateField()
							where !generate.HasValue || generate.Value
							select new SelectListItem
								{
									Value = val.ToString(),
									Text = display.GetName(),
									Selected = values.Contains(val)
								})
					.ToList();
				return list;
			}
			catch (NullReferenceException)
			{
				throw new NoDisplayAttributeException();
			}
		}

		public static IList<SelectListItem> GetSelectList(Type type)
		{
			try
			{
				var list = (from Enum val in Enum.GetValues(type)
							let display = Display(type, val)
							let generate = display.GetAutoGenerateField()
							where !generate.HasValue || generate.Value
							select new SelectListItem
								{
									Value = val.ToString(),
									Text = display.GetName(),
								})
					.ToList();
				return list;
			}
			catch (NullReferenceException)
			{
				throw new NoDisplayAttributeException();
			}
		}

		public static IList<SelectListItem> GetSelectList(Type type, Enum value)
		{
			try
			{
				var list = (from Enum val in Enum.GetValues(type)
							let display = Display(type, val)
							let generate = display.GetAutoGenerateField()
							where !generate.HasValue || generate.Value
							select new SelectListItem
								{
									Value = val.ToString(),
									Text = display.GetName(),
									Selected = val.Equals(value)
								})
					.ToList();
				return list;
			}
			catch (NullReferenceException)
			{
				throw new NoDisplayAttributeException();
			}
		}

		public static IList<SelectListItem> GetMultiSelectList(Type type, Enum value)
		{
			try
			{
				var list = (from Enum val in Enum.GetValues(type)
							let display = Display(type, val)
							let generate = display.GetAutoGenerateField()
							where !generate.HasValue || generate.Value
							select new SelectListItem
								{
									Value = val.ToString(),
									Text = display.GetName(),
									Selected = value.HasFlag(val)
								})
					.ToList();
				return list;
			}
			catch (NullReferenceException)
			{
				throw new NoDisplayAttributeException();
			}
		}

		public static IList<SelectListItem> GetMultiSelectList(Type type, IEnumerable<Enum> values)
		{
			try
			{
				var list = (from Enum val in Enum.GetValues(type)
							let display = Display(type, val)
							let generate = display.GetAutoGenerateField()
							where !generate.HasValue || generate.Value
							select new SelectListItem
								{
									Value = val.ToString(),
									Text = display.GetName(),
									Selected = values.Contains(val)
								})
					.ToList();
				return list;
			}
			catch (NullReferenceException)
			{
				throw new NoDisplayAttributeException();
			}
		}

		#endregion SelectList Methods
	}
}
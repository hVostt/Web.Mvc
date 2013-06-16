using System;
using System.Web.Mvc;

namespace hVostt.Web.Mvc.Extensions
{
	public static class ViewContextExtensions
	{
		/// <summary>
		/// Returns name of current action (from RouteData)
		/// </summary>
		/// <param name="viewContext">ViewContext</param>
		/// <returns>Name of current action</returns>
		public static string GetActionName(this ViewContext viewContext)
		{
			return (string)viewContext.RouteData.Values["action"];
		}

		/// <summary>
		/// Returns name of current controller (from RouteData)
		/// </summary>
		/// <param name="viewContext">ViewContext</param>
		/// <returns>Name of current controller</returns>
		public static string GetControllerName(this ViewContext viewContext)
		{
			return (string)viewContext.RouteData.Values["controller"];
		}

		/// <summary>
		/// Returns true if <paramref name="action"/> is null or equals current action name
		/// and <paramref name="controller"/> is null or equals current controller name
		/// </summary>
		/// <param name="viewContext">ViewContext</param>
		/// <param name="action">Checking action name</param>
		/// <param name="controller">Checking controller name</param>
		/// <returns>True if <paramref name="action"/> and <paramref name="controller"/> is current</returns>
		public static bool IsCurrent(this ViewContext viewContext, string action, string controller)
		{
			return (action == null ||
					action.Equals(GetActionName(viewContext),
								  StringComparison.CurrentCultureIgnoreCase))
				   &&
				   (controller == null ||
					controller.Equals(GetControllerName(viewContext),
									  StringComparison.CurrentCultureIgnoreCase));
		}
	}
}

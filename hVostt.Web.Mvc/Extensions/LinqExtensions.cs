using System.Collections.Generic;
using System.Linq;

namespace hVostt.Web.Mvc.Extensions
{
	public static class LinqExtensions
	{
		public static IEnumerable<T[]> SubArrays<T>(this IEnumerable<T> input, int size)
		{
			var counter = size;
			return input
				.GroupBy(_ => counter++ / size)
				.Select(g => g.ToArray());
		}
	}
}
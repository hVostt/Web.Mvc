using System.Collections.Generic;
using System.Text;

namespace hVostt.Web.Mvc.Helpers.Meta
{
	public class MetaCollection
	{
		private readonly Dictionary<string, MetaTag> _collection;

		public MetaCollection()
		{
			_collection = new Dictionary<string, MetaTag>();
		}

		public void Add(string name, string content, string lang = null)
		{
			_collection[name] = new MetaTag { Content = content, Lang = lang, IsHttpEquiv = false };
		}

		public void Equiv(string name, string content)
		{
			_collection[name] = new MetaTag { Content = content, Lang = null, IsHttpEquiv = true };
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			foreach (var item in _collection)
			{
				builder.Append("<meta ")
					   .Append(item.Value.IsHttpEquiv ? "http-equiv" : "name")
					   .Append("=\"")
					   .Append(item.Key)
					   .Append("\" content=\"")
					   .Append(item.Value.Content)
					   .Append('"');
				if (item.Value.Lang != null) builder.Append(" lang=\"").Append(item.Value.Lang).Append('"');
				builder.Append(" />\n");
			}
			return builder.ToString();
		}
	}
}
using System;
using System.Globalization;
using System.Web;

namespace hVostt.Web.Mvc.Helpers.Meta
{
	// TODO: add fully ViewPort support

	public class MetaBuilder : IHtmlString
	{
		private readonly MetaCollection _collection;

		public MetaBuilder(MetaCollection collection)
		{
			_collection = collection;
		}

		public MetaBuilder Add(string name, string content, string lang = null)
		{
			_collection.Add(name, content, lang);
			return this;
		}

		public MetaBuilder Equiv(string name, string content)
		{
			_collection.Equiv(name, content);
			return this;
		}

		public MetaBuilder Author(string author, string lang = null)
		{
			return Add("author", author, lang);
		}

		public MetaBuilder Copyright(string copyright, string lang = null)
		{
			return Add("copyright", copyright, lang);
		}

		public MetaBuilder Description(string description, string lang = null)
		{
			return Add("description", description, lang);
		}

		public MetaBuilder DocumentState(DocumentState documentState)
		{
			return Add("document-state", documentState.ToString());
		}

		public MetaBuilder Generator(string generator)
		{
			return Add("generator", generator);
		}

		public MetaBuilder Keywords(string keywords, string lang = null)
		{
			return Add("keywords", keywords, lang);
		}

		public MetaBuilder ResourceType(string resourceType)
		{
			return Add("resource-type", resourceType);
		}

		public MetaBuilder Revisit(int days)
		{
			return Add("revisit", days.ToString(CultureInfo.InvariantCulture));
		}

		public MetaBuilder Robots(bool index, bool follow, bool shorten = true)
		{
			return Add("robots",
					   index
						   ? follow
								 ? shorten ? "all" : "index,follow"
								 : "index,nofollow"
						   : follow
								 ? "noindex,follow"
								 : shorten ? "none" : "noindex,nofollow"
				);
		}

		public MetaBuilder Subject(string subject, string lang = null)
		{
			return Add("subject", subject, lang);
		}

		public MetaBuilder ContentLanguage(string language)
		{
			return Equiv("content-language", language);
		}

		public MetaBuilder ContentScriptType(string scriptType)
		{
			return Equiv("content-script-type", scriptType);
		}

		public MetaBuilder ContentStyleType(string styleType)
		{
			return Equiv("content-style-type", styleType);
		}

		public MetaBuilder ContentType(string contentType)
		{
			return Equiv("content-type", contentType);
		}

		public MetaBuilder Expires(DateTime expires)
		{
			if (expires.Kind == DateTimeKind.Local)
			{
				expires = expires.ToUniversalTime();
			}
			return Equiv("expires", expires.ToString("r", DateTimeFormatInfo.InvariantInfo));
		}

		public MetaBuilder PicsLabel(string label)
		{
			return Equiv("PICS-Label", label);
		}

		public MetaBuilder Pragma(bool noCache)
		{
			if (noCache)
			{
				return Equiv("pragma", "no-cache");
			}
			return this;
		}

		public MetaBuilder Refresh(string refresh)
		{
			return Equiv("refresh", refresh);
		}

		public MetaBuilder SetCookie(string cookie)
		{
			return Equiv("Set-Cookie", cookie);
		}

		public MetaBuilder WindowTarget(string target)
		{
			return Equiv("Window-target", target);
		}

		public MetaBuilder Imagetoolbar(bool yes)
		{
			return Equiv("Imagetoolbar", yes ? "yes" : "no");
		}

		public string ToHtmlString()
		{
			return _collection.ToString();
		}
	}
}
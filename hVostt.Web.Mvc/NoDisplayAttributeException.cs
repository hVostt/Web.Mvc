using System;
using System.Runtime.Serialization;

namespace hVostt.Web.Mvc
{
	[Serializable]
	public class NoDisplayAttributeException : Exception
	{
		public NoDisplayAttributeException()
			: base("DisplayAttribute is not found")
		{ }
		public NoDisplayAttributeException(string message) : base(message) { }
		protected NoDisplayAttributeException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}

using System.Web;

namespace hVostt.Web.Mvc
{
	public class NotFoundHttpException : HttpException
	{
		public NotFoundHttpException()
			: base(404, null)
		{
		}

		public NotFoundHttpException(string message)
			: base(404, message)
		{
		}
	}
}
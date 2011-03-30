using System.Web.Mvc;
using Vela.Common.Dal;

namespace Vela.Portal.Web.Plumbing
{
	public class UnitOfWorkAttribute : ActionFilterAttribute
	{
		private DocumentSessionScope _scope	;

		public DocumentSessionScope Scope
		{
			get { return _scope; }
			set { _scope = value; }
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			Scope.Dispose();
			base.OnActionExecuted(filterContext);
		}
	}
}
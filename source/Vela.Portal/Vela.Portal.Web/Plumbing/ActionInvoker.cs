using System.Collections.Generic;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Vela.Portal.Web.Plumbing
{
	public class ActionInvoker : ExtensibleActionInvoker
	{
		public ActionInvoker(IComponentContext context,
			IEnumerable<IActionFilter> actionFilters,
			IEnumerable<IAuthorizationFilter> authorizationFilters,
			IEnumerable<IExceptionFilter> exceptionFilters,
			IEnumerable<IResultFilter> resultFilters)
			: base(context, actionFilters, authorizationFilters, exceptionFilters, resultFilters)
		{
		}
	}
}
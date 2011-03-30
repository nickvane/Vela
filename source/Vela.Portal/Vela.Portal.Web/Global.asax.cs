using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Vela.Common.Dal;
using Vela.Portal.Web.Plumbing.Modules;
using Vela.VirtualEhr.IoC.Autofac;
using Vela.VirtualEhr.Persistence.IoC.Autofac;

namespace Vela.Portal.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	///<summary>
	///</summary>
	// ReSharper disable InconsistentNaming
	public class MvcApplication : HttpApplication
	{
		// Register Resolve Release Pattern
		// http://blog.ploeh.dk/2010/09/29/TheRegisterResolveReleasePattern.aspx

		private static IContainer _container;

		#region IContainer Members

		/// <summary>
		/// Gets the container.
		/// </summary>
		public IContainer Container
		{
			get { return _container; }
		}

		#endregion

		///<summary>
		///</summary>
		///<param name="filters"></param>
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		///<summary>
		///</summary>
		///<param name="routes"></param>
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
				new { controller = @"[^\.]*"} // Parameter constraints
				);
		}

		/// <summary>
		/// Fired when the first resource is requested from the web server and the web application starts
		/// </summary>
		protected void Application_Start()
		{
			// Register: create and configure the container
			_container = BootstrapContainer();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

			// MVC Stuff
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		public void Application_BeginRequest()
		{
			// Make sure there is an instance of DocumentSessionScope at the beginning of each request.
			// Autofac will dispose this instance of DocumentSessionScope at the end of the request.
			DependencyResolver.Current.GetService(typeof(DocumentSessionScope));
		}

		public void Application_EndRequest()
		{
			
		}

		/// <summary>
		/// Fired when the web application ends
		/// </summary>
		public void Application_End()
		{
			// Release: remember to dispose of your container when your application is about to shutdown to let it gracefully release all components and clean up after them
			_container.Dispose();
		}

		/// <summary>
		/// Fired when an error occurs
		/// </summary>
		public void Application_Error()
		{
			// Resolve: pull the logger out of the container (= root component in case of exceptions on this level)
			//ILogger logger = Container.Resolve<ILogger>() ?? NullLogger.Instance;
			//logger.Error("An error occured in the website.", Server.GetLastError().GetBaseException());
		}

		/// <summary>
		/// Bootstrapper is the place where you create and configure your container
		/// </summary>
		/// <returns>An Autofac container</returns>
		private IContainer BootstrapContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new ServiceModule());
			builder.RegisterModule(new DalModule());
			// You can make property injection available to your MVC views by adding the ViewRegistrationSource to your ContainerBuilder before building the application container.
			builder.RegisterSource(new ViewRegistrationSource());
			builder.RegisterModule(new PatientEhrLinkModule());
			builder.RegisterModule(new PatientStorageModule());
			builder.RegisterModule(new RavenModule());
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			return builder.Build();
		}
	}

	// ReSharper restore InconsistentNaming
}
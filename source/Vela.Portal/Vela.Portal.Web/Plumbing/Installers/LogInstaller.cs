using System.Web;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Vela.Portal.Web.Plumbing.Installers
{
    /// <summary>
    /// The contract to install components in the container.
    /// </summary>
    public class LogInstaller : IWindsorInstaller
    {
        private readonly HttpServerUtility _httpServerUtility;

        /// <summary>
        /// Creates a LogInstaller
        /// </summary>
        /// <param name="httpServerUtility">Provides helper methods for processing Web requests</param>
        public LogInstaller(HttpServerUtility httpServerUtility)
        {
            _httpServerUtility = httpServerUtility;
        }

        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Adds the LoggingFacility for log4net
            // Best practice:
            //      using Castle.Core.Logging;
    
            //      public class CustomerService
            //      {
            //         private ILogger _logger = NullLogger.Instance;

            //         public CustomerService()
            //         {
            //         }
    
            //         public ILogger Logger
            //         {
            //            get { return _logger; }
            //            set { _logger = value; }
            //         }

            //         // ...
            //      } 
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithConfig(_httpServerUtility.MapPath("~/log4net.config")));
        }
    }
}

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Vela.Common;

namespace Vela.Portal.Web.Plumbing.Installers
{
	/// <summary>
	/// The contract to install components in the container.
	/// </summary>
	public class DalInstaller : IWindsorInstaller
	{
		/// <summary>
		/// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
		/// </summary>
		/// <param name="container">The container.</param><param name="store">The configuration store.</param>
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				AllTypes.FromAssemblyNamed("Vela.AM.Dal")
					.BasedOn(typeof(IBaseRepository<>))
					.WithService.Base()
			);
			container.Register(
				AllTypes.FromAssemblyNamed("Vela.RM.Dal")
					.BasedOn(typeof(IBaseRepository<>))
					.WithService.Base()
			);
		}
	}
}
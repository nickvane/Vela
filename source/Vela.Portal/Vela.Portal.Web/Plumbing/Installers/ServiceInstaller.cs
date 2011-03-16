using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Vela.AM.Adl;
using Vela.SM.ArchetypeService;

namespace Vela.Portal.Web.Plumbing.Installers
{
	/// <summary>
	/// The contract to install components in the container.
	/// </summary>
	public class ServiceInstaller : IWindsorInstaller
	{
		/// <summary>
		/// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
		/// </summary>
		/// <param name="container">The container.</param><param name="store">The configuration store.</param>
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				AllTypes.FromAssemblyNamed("Vela.VirtualEhr")
					.BasedOn(typeof(IArchetypeService))
					.WithService.DefaultInterface().Configure(x => x.LifeStyle.PerWebRequest)
			);
			container.Register(
				AllTypes.FromAssemblyNamed("Vela.VirtualEhr")
					.BasedOn(typeof(IArchetypeParserFactory))
					.WithService.DefaultInterface().Configure(x => x.LifeStyle.PerWebRequest)
			);
			container.Register(
				AllTypes.FromAssemblyNamed("Vela.VirtualEhr")
					.BasedOn(typeof(ICompositionBuilder))
					.WithService.DefaultInterface().Configure(x => x.LifeStyle.PerWebRequest)
			);
		}
	}
}
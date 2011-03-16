using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.Web.Plumbing.Installers
{
	public class PatientStorageInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IChannelFactory<IPatientService>>().Instance(CreateChannelFactory()).LifeStyle.Singleton,
				Component.For<IPatientService>().UsingFactoryMethod(GetService).LifeStyle.PerWebRequest
				);
		}

		static IChannelFactory<IPatientService> CreateChannelFactory()
		{
			var binding = new BasicHttpBinding();
			return new ChannelFactory<IPatientService>(binding);
		}

		static IPatientService GetService(IKernel kernel)
		{
			var address = new EndpointAddress(ConfigurationManager.ConnectionStrings["Vela.Portal.PatientStorage"].ConnectionString);
			var factory = kernel.Resolve<IChannelFactory<IPatientService>>();
			return factory.CreateChannel(address);
		}
	}
}
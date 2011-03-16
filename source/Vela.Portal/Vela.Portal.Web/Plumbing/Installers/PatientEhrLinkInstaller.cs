using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Vela.Portal.PatientEhrLink.Contracts;

namespace Vela.Portal.Web.Plumbing.Installers
{
	public class PatientEhrLinkInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IChannelFactory<IPatientEhrLinkService>>().Instance(CreateChannelFactory()).LifeStyle.Singleton,
				Component.For<IPatientEhrLinkService>().UsingFactoryMethod(GetService).LifeStyle.PerWebRequest
				);
		}

		static IChannelFactory<IPatientEhrLinkService> CreateChannelFactory()
		{
			var binding = new BasicHttpBinding();
			return new ChannelFactory<IPatientEhrLinkService>(binding);
		}

		static IPatientEhrLinkService GetService(IKernel kernel)
		{
			var address = new EndpointAddress(ConfigurationManager.ConnectionStrings["Vela.Portal.PatientEhrLink"].ConnectionString);
			var factory = kernel.Resolve<IChannelFactory<IPatientEhrLinkService>>();
			return factory.CreateChannel(address);
		}
	}
}
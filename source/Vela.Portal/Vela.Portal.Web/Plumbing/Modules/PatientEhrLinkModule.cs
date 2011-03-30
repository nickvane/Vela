using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Autofac;
using Vela.Portal.PatientEhrLink.Contracts;

namespace Vela.Portal.Web.Plumbing.Modules
{
	public class PatientEhrLinkModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c => new ChannelFactory<IPatientEhrLinkService>(new BasicHttpBinding()))
								.As<IChannelFactory<IPatientEhrLinkService>>()
								.SingleInstance();

			builder.Register(c => c.Resolve<IChannelFactory<IPatientEhrLinkService>>().CreateChannel(new EndpointAddress(ConfigurationManager.ConnectionStrings["Vela.Portal.PatientEhrLink"].ConnectionString)))
				.As<IPatientEhrLinkService>()
				.InstancePerLifetimeScope();
		}
	}
}
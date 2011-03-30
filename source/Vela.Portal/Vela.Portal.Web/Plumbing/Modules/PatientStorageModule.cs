using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Autofac;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.Web.Plumbing.Modules
{
	public class PatientStorageModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c => new ChannelFactory<IPatientService>(new BasicHttpBinding()))
								.As<IChannelFactory<IPatientService>>()
								.SingleInstance();

			builder.Register(c => c.Resolve<IChannelFactory<IPatientService>>().CreateChannel(new EndpointAddress(ConfigurationManager.ConnectionStrings["Vela.Portal.PatientStorage"].ConnectionString)))
				.As<IPatientService>()
				.InstancePerLifetimeScope();
		}
	}
}
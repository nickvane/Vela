using Autofac;
using Autofac.Integration.Mvc;
using Newtonsoft.Json;
using Raven.Client;
using Raven.Client.Document;
using Vela.Common.Dal;

namespace Vela.Portal.Web.Plumbing.Modules
{
	public class RavenModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c =>
			                 	{
			                 		var store = new DocumentStore
			                 		            	{
			                 		            		ConnectionStringName = "Vela.Portal",
			                 		            		Conventions =
			                 		            			{
			                 		            				CustomizeJsonSerializer =
			                 		            					serializer => serializer.TypeNameHandling = TypeNameHandling.All
			                 		            			}
			                 		            	};
			                 		store.Initialize();
			                 		return store;
			                 	})
				.As<IDocumentStore>()
				.SingleInstance();

			builder.Register(c => new DocumentSessionScope(c.Resolve<IDocumentStore>().OpenSession()))
				.OwnedByLifetimeScope()
				.InstancePerHttpRequest();
		}
	}
}
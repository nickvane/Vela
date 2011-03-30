using Autofac;
using Vela.Common.Dal;

namespace Vela.VirtualEhr.Persistence.IoC.Autofac
{
	public class DalModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces();
		}
	}
}

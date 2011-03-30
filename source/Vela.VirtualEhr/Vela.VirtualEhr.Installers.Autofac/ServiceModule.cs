using Autofac;
using Vela.AM.Adl;
using Vela.SM.ArchetypeService;

namespace Vela.VirtualEhr.IoC.Autofac
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ArchetypeService>().As<IArchetypeService>();
			builder.RegisterType<CompositionBuilder>().As<ICompositionBuilder>();
			builder.RegisterType<ParserFactory>().As<IParserFactory>();
		}
	}
}

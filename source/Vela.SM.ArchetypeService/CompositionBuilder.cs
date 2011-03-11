using Vela.AM.Aom.Archetypes;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.SM.ArchetypeService
{
	public class CompositionBuilder : ICompositionBuilder
	{
		public Composition Build(Archetype archetype)
		{
			var composition = new Composition();

			return composition;
		}
	}
}

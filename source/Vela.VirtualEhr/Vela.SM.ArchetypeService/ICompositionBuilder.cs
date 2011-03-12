using Vela.AM.Aom.Archetypes;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.SM.ArchetypeService
{
	public interface ICompositionBuilder
	{
		Composition Build(Archetype archetype);
	}
}
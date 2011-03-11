using Vela.AM.Aom.Archetypes;
using Vela.Common;

namespace Vela.AM.Aom.Repositories
{
	public interface IArchetypeRepository : IBaseRepository<Archetype>
	{
		/// <summary>
		/// Return the archetype with id ‘archetypeId’.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns>Archetype equivalent to ARCHETYPED class in Common reference model. Defines semantics of identfication, lifecycle, versioning, composition and specialisation.</returns>
		Archetype GetArchetype(string archetypeId);
	}
}

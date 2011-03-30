using System.Collections.Generic;
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

		/// <summary>
		/// Checks if this is a valid archetype.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns>True if the archetype is a valid archetype otherwise false.</returns>
		bool IsValidArchetype(string archetypeId);

		/// <summary>
		/// Returns a list of valid archetypes. A valid archetype is the latest version of an archetype and is not deleted.
		/// </summary>
		/// <returns>A list of archetypes.</returns>
		IList<Archetype> GetValidArchetypes();
	}
}

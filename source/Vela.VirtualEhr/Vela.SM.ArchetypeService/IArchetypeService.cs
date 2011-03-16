using System.Collections.Generic;
using Vela.AM.Aom.Archetypes;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.SM.ArchetypeService
{
	/// <summary>
	/// Actions available on Archetypes
	/// </summary>
	public interface IArchetypeService
	{
		/// <summary>
		/// Gets the archetype from the archetype repository with the specified archetypeId.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns>Archetype equivalent to ARCHETYPED class in Common reference model. Defines semantics of identfication, lifecycle, versioning, composition and specialisation.</returns>
		Archetype GetArchetype(string archetypeId);

		/// <summary>
		/// Gets all valid archetypes from the archetype repository. This only returns the latest version of an archetype and doesn't include deleted archetypes.
		/// </summary>
		/// <returns></returns>
		IList<Archetype> GetAllArchetypes();

		/// <summary>
		/// Saves an archetype to the archetype repository. An existing archetype will not be updated, you should save the archetype as a new version.
		/// </summary>
		/// <param name="archetype">The object form of the archetype.</param>
		void Save(Archetype archetype);

		/// <summary>
		/// Saves an archetype to the archetype repository. An existing archetype will not be updated, you should save the archetype as a new version.
		/// </summary>
		/// <param name="archetype">The text form of the archetype. This can be in adl format or xml format.</param>
		void Save(string archetype);

		/// <summary>
		/// Marks an archetype as deleted. Archetypes will not be physically deleted.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		void Delete(string archetypeId);

		/// <summary>
		/// Builds a composition from the specified archetype. The archetype must be valid: it is the latest version and it is not deleted.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns></returns>
		Composition BuildComposition(string archetypeId);
	}
}
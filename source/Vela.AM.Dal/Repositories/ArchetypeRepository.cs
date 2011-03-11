using System.Linq;
using Raven.Client;
using Vela.AM.Aom.Archetypes;
using Vela.AM.Aom.Repositories;
using Vela.Common.Dal;

namespace Vela.AM.Dal.Repositories
{
	public class ArchetypeRepository : BaseRepository<Archetype>, IArchetypeRepository
	{
		public ArchetypeRepository(IDocumentSession session, IQueryable<Archetype> collection) : base(session, collection)
		{
		}

		/// <summary>
		/// Return the archetype with id ‘archetypeId’.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns>Archetype equivalent to ARCHETYPED class in Common reference model. Defines semantics of identfication, lifecycle, versioning, composition and specialisation.</returns>
		public Archetype GetArchetype(string archetypeId)
		{
			return this[archetypeId];
		}
	}
}


using System.Collections.Generic;
using System.Linq;
using Vela.AM.Aom.Archetypes;
using Vela.AM.Aom.Repositories;
using Vela.Common.Dal;

namespace Vela.AM.Dal.Repositories
{
	public class ArchetypeRepository : BaseRepository<Archetype>, IArchetypeRepository
	{
		public ArchetypeRepository(IQueryable<Archetype> collection = null) : base(collection)
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="archetypeId"></param>
		/// <returns></returns>
		public bool IsValidArchetype(string archetypeId)
		{
			var result = from a in Collection
			             where a.ArchetypeId.VersionLessId == this[archetypeId].ArchetypeId.VersionLessId & a.IsDeleted == false
						 orderby a.ArchetypeId.VersionId descending 
			             select a;
			return result.FirstOrDefault().Id == archetypeId;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IList<Archetype> GetValidArchetypes()
		{
			var result = from a in Collection
						 where a.IsDeleted == false
						 select a;
			//TODO: only get the latest version of an archetype
			return result.ToList();
		}
	}
}

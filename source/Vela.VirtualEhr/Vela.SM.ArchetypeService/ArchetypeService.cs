using System;
using System.Collections.Generic;
using Vela.AM.Adl;
using Vela.AM.Aom.Archetypes;
using Vela.AM.Aom.Repositories;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.SM.ArchetypeService
{
	public class ArchetypeService : IArchetypeService
	{
		private readonly IArchetypeRepository _archetypeRepository;
		private readonly ICompositionBuilder _compositionBuilder;
		private readonly IParserFactory _parserFactory;

		public ArchetypeService(IArchetypeRepository archetypeRepository, ICompositionBuilder compositionBuilder, IParserFactory parserFactory)
		{
			_archetypeRepository = archetypeRepository;
			_compositionBuilder = compositionBuilder;
			_parserFactory = parserFactory;
		}

		/// <summary>
		/// Gets the archetype from the archetype repository with the specified archetypeId.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns>Archetype equivalent to ARCHETYPED class in Common reference model. Defines semantics of identfication, lifecycle, versioning, composition and specialisation.</returns>
		public Archetype GetArchetype(string archetypeId)
		{
			return _archetypeRepository[archetypeId];
		}

		/// <summary>
		/// Gets all valid archetypes from the archetype repository. This only returns the latest version of an archetype and doesn't include deleted archetypes.
		/// </summary>
		/// <returns></returns>
		public IList<Archetype> GetAllArchetypes()
		{
			return _archetypeRepository.GetValidArchetypes();
		}

		/// <summary>
		/// Saves an archetype to the archetype repository. An existing archetype will not be updated, you should save the archetype as a new version.
		/// </summary>
		/// <param name="archetype">The object form of the archetype.</param>
		public void Save(Archetype archetype)
		{
			if (!_archetypeRepository.Contains(archetype))
			{
				_archetypeRepository.Save(archetype);
			}
			else
			{
				throw new ArgumentException(string.Format("Archetype with id '{0}' already exist. Provide another version for this archetype.", archetype.Id), "archetype");
			}
		}

		/// <summary>
		/// Saves an archetype to the archetype repository. An existing archetype will not be updated, you should save the archetype as a new version.
		/// </summary>
		/// <param name="archetype">The text form of the archetype. This can be in adl format or xml format.</param>
		public void Save(string archetype)
		{
			var parser = _parserFactory.GetArchetypeParser(archetype, null);
			this.Save(parser.Parse(archetype));
		}

		/// <summary>
		/// Marks an archetype as deleted. Archetypes will not be physically deleted.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		public void Delete(string archetypeId)
		{
			var archetype = _archetypeRepository[archetypeId];
			if (archetype != null)
			{
				archetype.IsDeleted = true;
				_archetypeRepository.Save(archetype);
			}
			else
			{
				throw new ArgumentException(string.Format("Archetype with id '{0}' does not exist.", archetypeId), "archetypeId");
			}
		}

		/// <summary>
		/// Builds a composition from the specified archetype. The archetype must be valid: it is the latest version and it is not deleted.
		/// </summary>
		/// <param name="archetypeId">Multi-axial identifier of this archetype in archetype space.</param>
		/// <returns></returns>
		public Composition BuildComposition(string archetypeId)
		{
			if (_archetypeRepository.IsValidArchetype(archetypeId))
			{
				return _compositionBuilder.Build(_archetypeRepository[archetypeId]);
			}
			throw new ArgumentException(string.Format("Archetype with id '{0}' is not a valid archetype.", archetypeId), "archetypeId");
		}
	}
}

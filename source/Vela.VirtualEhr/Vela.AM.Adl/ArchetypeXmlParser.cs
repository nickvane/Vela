//-----------------------------------------------------------------------
// <copyright file="ArchetypeXmlParser.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.IO;
using schemas.openehr.org.v1;
using Vela.AM.Aom.Archetypes;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Adl
{
	public class ArchetypeXmlParser : IArchetypeParser
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="archetype"></param>
		/// <returns></returns>
		public Archetype Parse(string archetype)
		{
			return ArchetypeXmlParserInternal.Parse(archetype);
		}
	}

	internal static class ArchetypeXmlParserInternal
	{
		public static Archetype Parse(string archetypeXmlString)
		{
			var archetypeInstance = new Archetype();
			using (var textReader = new StringReader(archetypeXmlString))
			{
				archetype archetypeModel = archetype.Load(textReader);

				if (archetypeModel.Content.archetype_id == null || string.IsNullOrEmpty(archetypeModel.Content.archetype_id.value)) throw new ParseException("ArchetypeId cannot be empty");
				if (string.IsNullOrEmpty(archetypeModel.Content.concept)) throw new ParseException("Concept cannot be empty");
				if (archetypeModel.Content.definition == null) throw new ParseException("Definition cannot be empty");
				if (archetypeModel.Content.ontology == null) throw new ParseException("Ontology cannot be empty");
				
				if (archetypeModel.Content.uid != null)
					archetypeInstance.Uid = new HierObjectId(archetypeModel.Content.uid.value);

				archetypeInstance.AdlVersion = archetypeModel.Content.adl_version;
				archetypeInstance.Concept = archetypeModel.Content.concept;
				archetypeInstance.ArchetypeId = new ArchetypeId(archetypeModel.Content.archetype_id.value);
				if (archetypeModel.Content.parent_archetype_id != null)
					archetypeInstance.ParentArchetypeId = new ArchetypeId(archetypeModel.Content.parent_archetype_id.value);

				if (archetypeModel.Content.original_language != null)
				{
					archetypeInstance.OriginalLanguage = archetypeModel.Content.original_language.Map();
				}
				if (archetypeModel.Content.translations != null)
				{
					foreach (TRANSLATION_DETAILS translation in archetypeModel.Content.translations)
					{
						archetypeInstance.Translations.Add(translation.language.code_string, translation.Map());
					}
				}
				if (archetypeModel.Content.is_controlled.HasValue)
					archetypeInstance.IsControlled = archetypeModel.Content.is_controlled.Value;

				if (archetypeModel.Content.description != null)
					archetypeInstance.Description = archetypeModel.Content.description.Map();

				archetypeInstance.Definition = archetypeModel.Content.definition.Map();
				if (archetypeInstance.Definition.ReferenceModelTypeName != archetypeInstance.ArchetypeId.ReferenceModelEntity)
					throw new ParseException(string.Format("Archetype definition typename is not consistent: '{0}' <> '{1}'", archetypeInstance.ArchetypeId.ReferenceModelEntity, archetypeInstance.Definition.ReferenceModelTypeName));

				if (archetypeModel.Content.invariants != null)
				{
					foreach (ASSERTION assertion in archetypeModel.Content.invariants)
					{
						archetypeInstance.Invariants.Add(assertion.Map());
					}
				}

				//TODO: revision history

				archetypeInstance.Ontology = archetypeModel.Content.ontology.Map();
			}

			return archetypeInstance;
		}
	}
}
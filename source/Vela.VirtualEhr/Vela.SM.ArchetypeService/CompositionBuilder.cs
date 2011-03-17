using System;
using Vela.AM.Aom.Archetypes;
using Vela.RM.Core.Common.ArchetypedPackage;using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage;

namespace Vela.SM.ArchetypeService
{
	public class CompositionBuilder : ICompositionBuilder
	{
		public Composition Build(Archetype archetype)
		{
			var composition = new Composition();

			composition.ArchetypeDetails = new Archetyped
			                               	{
			                               		ArchetypeId = new ArchetypeId(archetype.ArchetypeId.Value),
			                               		Version = "1.0.2"
			                               	};
			composition.ArchetypeNodeId = archetype.ArchetypeId.Value;
			composition.Content.Add(GetInstanceOfContentItem(archetype.Definition.ReferenceModelTypeName));
			
			return composition;
		}

		private ContentItem GetInstanceOfContentItem(string typeName)
		{
			object contentItem;
			if (ReferenceModel.Classes.ContainsKey(typeName))
			{
				contentItem = Activator.CreateInstance(typeof(Locatable).Assembly.FullName, ReferenceModel.Classes[typeName].ClassName);

			}
			return null;
		}
	}
}

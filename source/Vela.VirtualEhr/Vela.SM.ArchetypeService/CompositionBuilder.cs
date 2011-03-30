using System;
using System.Diagnostics;
using Vela.AM.Aom.Archetypes;
using Vela.RM.Core.Common.ArchetypedPackage;using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.NavigationPackage;
using Action = Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage.Action;

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

		private static ContentItem GetInstanceOfContentItem(string typeName)
		{
			ContentItem contentItem = null;
			switch (typeName.ToUpperInvariant())
			{
				case "OBSERVATION":
					contentItem = new Observation();
					break;
				case "EVALUATION":
					contentItem = new Evaluation();
					break;
				case "ACTION":
					contentItem = new Action();
					break;
				case "INSTRUCTION":
					contentItem = new Instruction();
					break;
				case "SECTION":
					contentItem = new Section();
					break;
				case "ADMIN_ENTRY":
					contentItem = new AdminEntry();
					break;
				default:
					Debug.WriteLine("unknown typename: " + typeName);
					break;
			}
			return contentItem;
		}
	}
}

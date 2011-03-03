using System.Collections.Generic;
using Vela.AM.Archetypes;

namespace Vela.AM.Ontologies
{
	/// <summary>
	/// Local ontology of an archetype
	/// </summary>
	public class ArchetypeOntology
	{
		/// <summary>
		/// List of terminologies to which term or constraint bindings exist in this terminology.
		/// </summary>
		public HashSet<string> TerminologiesAvailable { get; set; }
		/// <summary>
		/// Specialisation depth of this archetype. Unspecialised archetypes have depth 0, with each additional level of specialisation adding 1 to the specialisation_depth.
		/// </summary>
		public int SpecialisationDepth { get; set; }
		/// <summary>
		/// List of all term codes in the ontology. Most of these correspond to “at” codes in an ADL archetype, which are the node_ids on C_OBJECT descendants. There may be an extra one, if a different term is used as the overall archetype concept from that used as the node_id of the outermost C_OBJECT in the definition part.
		/// </summary>
		public List<string> TermCodes { get; set; }
		/// <summary>
		/// List of all term codes in the ontology. These correspond to the “ac” codes in an ADL archetype, or equivalently, the CONSTRAINT_REF.reference values in the archetype definition.
		/// </summary>
		public List<string> ConstraintCodes { get; set; }
		/// <summary>
		/// List of ‘attribute’ names in ontology terms, typically includes ‘text’, ‘description’, ‘provenance’ etc.
		/// </summary>
		public List<string> TermAttributeNames { get; set; }
		/// <summary>
		/// Archetype which owns this ontology.
		/// </summary>
		public Archetype ParentArchetype { get; set; }
	}
}

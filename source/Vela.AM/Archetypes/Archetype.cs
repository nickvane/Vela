using System.Collections.Generic;
using Vela.AM.Assertions;
using Vela.AM.ConstraintModel;
using Vela.AM.Ontologies;
using Vela.RM.Core.Common.ResourcePackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Archetypes
{
	/// <summary>
	/// Archetype equivalent to ARCHETYPED class in Common reference model. Defines semantics of identfication, lifecycle, versioning, composition and specialisation.
	/// </summary>
	[OpenEhrName("ARCHETYPE")]
	public class Archetype : AuthoredResource
	{
		private IList<Assertion> _invariants;

		/// <summary>
		/// ADL version if archteype was read in from an ADL sharable archetype.
		/// </summary>
		[OpenEhrName("adl_version")]
		public string AdlVersion
		{
			get;
			set;
		}

		/// <summary>
		/// Multi-axial identifier of this archetype in archetype space.
		/// </summary>
		[OpenEhrName("archetype_id")]
		public ArchetypeId ArchetypeId
		{
			get;
			set;
		}

		/// <summary>
		/// OID identifier of this archetype.
		/// </summary>
		[OpenEhrName("uid")]
		public HierObjectId Uid
		{
			get;
			set;
		}

		/// <summary>
		/// The normative meaning of the archetype as a whole, expressed as a local archetype code, typically “at0000”.
		/// </summary>
		[OpenEhrName("concept")]
		public string Concept
		{
			get;
			set;
		}

		/// <summary>
		/// Identifier of the specialisation parent of this archetype.
		/// </summary>
		[OpenEhrName("parent_archetype_id")]
		public ArchetypeId ParentArchetypeId
		{
			get;
			set;
		}

		/// <summary>
		/// Root node of this archetype
		/// </summary>
		[OpenEhrName("definition")]
		public CComplexObject Definition
		{
			get;
			set;
		}

		/// <summary>
		/// The ontology of the archetype.
		/// </summary>
		[OpenEhrName("ontology")]
		public ArchetypeOntology Ontology
		{
			get;
			set;
		}

		/// <summary>
		/// Invariant statements about this object. Statements are expressed in first order predicate logic, and usually refer to at least two attributes.
		/// </summary>
		[OpenEhrName("invariants")]
		public IList<Assertion> Invariants
		{
			get { return _invariants ?? (_invariants = new List<Assertion>()); }
		}

		//TODO: add methods from specification
	}
}

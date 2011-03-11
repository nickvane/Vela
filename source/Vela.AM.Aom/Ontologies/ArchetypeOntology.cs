//-----------------------------------------------------------------------
// <copyright file="ArchetypeOntology.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.AM.Aom.Archetypes;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.Ontologies
{
	/// <summary>
	/// Local ontology of an archetype
	/// </summary>
	[OpenEhrName("ARCHETYPE_ONTOLOGY")]
	public class ArchetypeOntology
	{
		private IDictionary<string, IList<ArchetypeTerminology>> _terminologyDefinitions;
		private IDictionary<string, IDictionary<string, CodePhrase>> _terminologyBindings;
		private IDictionary<string, IList<ArchetypeTerminology>> _constraintDefinitions;
		private IDictionary<string, IList<ArchetypeTerminology>> _constraintBindings;
		private IList<string> _terminologyCodes	;
		private IList<string> _constraintCodes;
		private IList<string> _terminologyAttributeNames;

		/// <summary>
		/// 
		/// </summary>
		public IDictionary<string, IList<ArchetypeTerminology>> TerminologyDefinitions
		{
			get { return _terminologyDefinitions ?? (_terminologyDefinitions = new Dictionary<string, IList<ArchetypeTerminology>>()); }
		}

		/// <summary>
		/// 
		/// </summary>
		public IDictionary<string, IDictionary<string, CodePhrase>> TerminologyBindings
		{
			get { return _terminologyBindings ?? (_terminologyBindings = new Dictionary<string, IDictionary<string, CodePhrase>>()); }
		}

		/// <summary>
		/// 
		/// </summary>
		public IDictionary<string, IList<ArchetypeTerminology>> ConstraintDefinitions
		{
			get { return _constraintDefinitions ?? (_constraintDefinitions = new Dictionary<string, IList<ArchetypeTerminology>>()); }
		}

		/// <summary>
		/// 
		/// </summary>
		public IDictionary<string, IList<ArchetypeTerminology>> ConstraintBindings
		{
			get { return _constraintBindings ?? (_constraintBindings = new Dictionary<string, IList<ArchetypeTerminology>>()); }
		}

		/// <summary>
		/// List of terminologies to which term or constraint bindings exist in this terminology.
		/// </summary>
		[OpenEhrName("terminologies_available")]
		public HashSet<string> AvailableTerminologies { get; set; }

		/// <summary>
		/// Specialisation depth of this archetype. Unspecialised archetypes have depth 0, with each additional level of specialisation adding 1 to the specialisation_depth.
		/// </summary>
		[OpenEhrName("specialisation_depth")]
		public int SpecialisationDepth { get; set; }

		/// <summary>
		/// List of all term codes in the ontology. Most of these correspond to “at” codes in an ADL archetype, which are the node_ids on C_OBJECT descendants. There may be an extra one, if a different term is used as the overall archetype concept from that used as the node_id of the outermost C_OBJECT in the definition part.
		/// </summary>
		[OpenEhrName("term_codes")]
		public IList<string> TerminologyCodes { get { return _terminologyCodes ?? (_terminologyCodes = new List<string>()); } }

		/// <summary>
		/// List of all term codes in the ontology. These correspond to the “ac” codes in an ADL archetype, or equivalently, the CONSTRAINT_REF.reference values in the archetype definition.
		/// </summary>
		[OpenEhrName("constraint_codes")]
		public IList<string> ConstraintCodes { get { return _constraintCodes ?? (_constraintCodes = new List<string>()); } }

		/// <summary>
		/// List of ‘attribute’ names in ontology terms, typically includes ‘text’, ‘description’, ‘provenance’ etc.
		/// </summary>
		[OpenEhrName("term_attribute_names")]
		public IList<string> TerminologyAttributeNames { get { return _terminologyAttributeNames ?? (_terminologyAttributeNames = new List<string>()); } }

		/// <summary>
		/// Archetype which owns this ontology.
		/// </summary>
		[OpenEhrName("parent_archetype")]
		public Archetype ParentArchetype { get; set; }

		/// <summary>
		/// True if language ‘a_lang’ is present in archetype ontology.
		/// </summary>
		/// <param name="language"></param>
		/// <returns></returns>
		[OpenEhrName("has_language")]
		public bool HasLanguage(string language)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if terminology ‘a_terminology’ is present in archetype ontology.
		/// </summary>
		/// <param name="terminologyId"></param>
		/// <returns></returns>
		[OpenEhrName("has_terminology")]
		public bool HasTerminology(string terminologyId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if term_codes has a_code.
		/// </summary>
		/// <param name="terminologyCode"></param>
		/// <returns></returns>
		[OpenEhrName("has_term_code")]
		public bool HasTerminologyCode(string terminologyCode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if constraint_codes has a_code.
		/// </summary>
		/// <param name="constraintCode"></param>
		/// <returns></returns>
		[OpenEhrName("has_constraint_code")]
		public bool HasConstraintCode(string constraintCode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Constraint definition for a code, in a specified language.
		/// </summary>
		/// <param name="language"></param>
		/// <param name="terminologyCode"></param>
		/// <returns></returns>
		[OpenEhrName("constraint_definition")]
		public ArchetypeTerminology GetConstraintDefinition(string language, string terminologyCode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Binding of term corresponding to a_code in target external terminology a_terminology_id as a CODE_PHRASE.
		/// </summary>
		/// <param name="terminologyId"></param>
		/// <param name="terminologyCode"></param>
		/// <returns></returns>
		[OpenEhrName("term_binding")]
		public CodePhrase GetTerminologyBinding(string terminologyId, string terminologyCode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Binding of constraint corresponding to a_code in target external terminology a_terminology_id, as a string, which is usually a formal query expression.
		/// </summary>
		/// <param name="terminologyId"></param>
		/// <param name="terminologyCode"></param>
		/// <returns></returns>
		[OpenEhrName("constraint_binding")]
		public string GetConstraintBinding(string terminologyId, string terminologyCode)
		{
			throw new NotImplementedException();
		}
	}
}
//-----------------------------------------------------------------------
// <copyright file="ArchetypeId.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Identifier for archetypes. Lexical form:
	/// rm_originator ‘-’ rm_name ‘-’ rm_entity ‘.’ concept_name { ‘-’ specialisation }* ‘.v’ number
	/// </summary>
	[Serializable, OpenEhrName("ARCHETYPE_ID")]
	public class ArchetypeId : ObjectId
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Should be in the format rm_originator ‘-’ rm_name ‘-’ rm_entity ‘.’ concept_name { ‘-’ specialisation }* ‘.v’ number</param>
		/// <remarks>
		/// The syntax of an ARCHETYPE_ID is as follows
		///		archetype_id: qualified_rm_entity ‘.’ domain_concept ‘.’ version_id
		/// 
		///		qualified_rm_entity: rm_originator ‘-’ rm_name ‘-’ rm_entity
		///		rm_originator: V_NAME
		///		rm_name: V_NAME
		///		rm_entity: V_NAME
		/// 
		///		domain_concept: concept_name { ‘-’ specialisation }*
		///		concept_name: V_NAME
		///		specialisation: V_NAME
		/// 
		///		version_id: ‘v’ V_NUMBER
		/// 
		///		NUMBER: [0-9]*
		///		NAME: [a-z][a-z0-9()/%$#&]*
		/// 
		/// Examples of values:
		///		• openehr-composition-SECTION.physical_examination.v2
		///		• openehr-composition-SECTION.physical_examination-prenatal.v1
		///		• hl7-rim-act.progress_note.v1
		///		• openehr-composition-OBSERVATION.progress_note-naturopathy.v2
		/// </remarks>
		public ArchetypeId(string value)
			: base(value)
		{
		}

		[OpenEhrName("value")]
		public override string Value
		{
			get
			{
				return QualifiedReferenceModelEntity + "." + DomainConcept + "." + VersionId;
			}
			set
			{
				var split = value.Split('.');
				if (split.Length != 3) throw new ArgumentException(String.Format(Resources.InvalidArchetypeId, value), "value");
				QualifiedReferenceModelEntity = split[0];
				DomainConcept = split[1];
				VersionId = split[2];
			}
		}

		//TODO: check for allowed characters in the id via regex: [a-z][a-z0-9()/%$#&]*

		/// <summary>
		/// Globally qualified reference model entity, e.g. “openehr-composition-OBSERVATION”.
		/// </summary>
		[OpenEhrName("qualified_rm_entity")]
		public string QualifiedReferenceModelEntity
		{
			get
			{
				return ReferenceModelOriginator + "-" + ReferenceModelName + "-" + ReferenceModelEntity;
			}
			set
			{
				var split = value.Split('-');
				if (split.Length != 3) throw new ArgumentException(String.Format(Resources.InvalidArchetypeId, value), "value");
				ReferenceModelOriginator = split[0];
				ReferenceModelName = split[1];
				ReferenceModelEntity = split[2];
			}
		}
		/// <summary>
		/// Name of the concept represented by this archetype, including specialisation, e.g. “biochemistry_result-cholesterol”.
		/// </summary>
		[OpenEhrName("domain_concept")]
		public string DomainConcept
		{
			get
			{
				var value = ConceptName;
				if (!string.IsNullOrEmpty(Specialisation)) value += "-" + Specialisation;
				return value;
			}
			set
			{
				var split = value.Split('-');
				ConceptName = split[0];
				if (split.Length > 1) Specialisation = split[1];
			}
		}

		private string ConceptName
		{
			get;
			set;
		}
		/// <summary>
		/// Organisation originating the reference model on which this archetype is based, e.g. “openehr”, “cen”, “hl7”
		/// </summary>
		[OpenEhrName("rm_originator")]
		public string ReferenceModelOriginator
		{
			get;
			set;
		}
		/// <summary>
		/// Name of the reference model, e.g. “rim”, “ehr_rm”, “en13606”.
		/// </summary>
		[OpenEhrName("rm_name")]
		public string ReferenceModelName
		{
			get;
			set;
		}
		/// <summary>
		/// Name of the ontological level within the reference model to which this archetype is targeted, e.g. for openEHR, “folder”, “composition”, “section”, “entry”.
		/// </summary>
		[OpenEhrName("rm_entity")]
		public string ReferenceModelEntity
		{
			get;
			set;
		}
		/// <summary>
		/// Name of specialisation of concept, if this archetype is a specialisation of another archetype, e.g. “cholesterol”.
		/// </summary>
		[OpenEhrName("specialisation")]
		public string Specialisation
		{
			get;
			set;
		}
		/// <summary>
		/// Version of this archetype.
		/// </summary>
		[OpenEhrName("version_id")]
		public string VersionId
		{
			get;
			set;
		}
	}
}
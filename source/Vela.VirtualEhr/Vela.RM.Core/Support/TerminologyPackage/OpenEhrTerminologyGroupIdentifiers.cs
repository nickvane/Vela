//-----------------------------------------------------------------------
// <copyright file="OpenEhrTerminologyGroupIdentifiers.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Vela.RM.Core.Support.TerminologyPackage
{
	/// <summary>
	/// List of identifiers for groups in the openEHR terminology.
	/// </summary>
	[OpenEhrName("OPENEHR_TERMINOLOGY_GROUP_IDENTIFIERS")]
	public static class OpenEhrTerminologyGroupIdentifiers
	{
		private static readonly Dictionary<string, string> TerminologyIdList = new Dictionary<string, string>() { { "Terminology_id", "openehr" }, 
				{ "Group_id_audit_change_type", "audit change type" } , 
				{ "Group_id_attestation_reason", "attestation reason" } , 
				{ "Group_id_composition_category", "composition category" } , 
				{ "Group_id_event_math_function", "event math function" } , 
				{ "Group_id_instruction_states", "instruction states" } , 
				{ "Group_id_instruction_transitions", "instruction transitions" } , 
				{ "Group_id_null_flavours", "null flavours" } , 
				{ "Group_id_property", "property" } , 
				{ "Group_id_participation_function", "participation function" } , 
				{ "Group_id_participation_mode", "participation mode" } , 
				{ "Group_id_subject_relationship", "subject relationship" } , 
				{ "Group_id_setting", "setting" } , 
				{ "Group_id_term_mapping_purpose", "term mapping purpose" } , 
				{ "Group_id_version_lifecycle_state", "version lifecycle state" } 
				};

		[OpenEhrName("Terminology_id")]
		public readonly static string TerminologyId = TerminologyIdList["Terminology_id"];
		[OpenEhrName("Group_id_audit_change_type")]
		public readonly static string AuditChangeType = TerminologyIdList["Group_id_audit_change_type"];
		[OpenEhrName("Group_id_attestation_reason")]
		public readonly static string AttestationReason = TerminologyIdList["Group_id_attestation_reason"];
		[OpenEhrName("Group_id_composition_category")]
		public readonly static string CompositionCategory = TerminologyIdList["Group_id_composition_category"];
		[OpenEhrName("Group_id_event_math_function")]
		public readonly static string EventMathFunction = TerminologyIdList["Group_id_event_math_function"];
		[OpenEhrName("Group_id_instruction_states")]
		public readonly static string InstructionStates = TerminologyIdList["Group_id_instruction_states"];
		[OpenEhrName("Group_id_instruction_transitions")]
		public readonly static string InstructionTransitions = TerminologyIdList["Group_id_instruction_transitions"];
		[OpenEhrName("Group_id_null_flavours")]
		public readonly static string NullFlavours = TerminologyIdList["Group_id_null_flavours"];
		[OpenEhrName("Group_id_property")]
		public readonly static string Property = TerminologyIdList["Group_id_property"];
		[OpenEhrName("Group_id_participation_function")]
		public readonly static string ParticipationFunction = TerminologyIdList["Group_id_participation_function"];
		[OpenEhrName("Group_id_participation_mode")]
		public readonly static string ParticipationMode = TerminologyIdList["Group_id_participation_mode"];
		[OpenEhrName("Group_id_subject_relationship")]
		public readonly static string SubjectRelationship = TerminologyIdList["Group_id_subject_relationship"];
		[OpenEhrName("Group_id_setting")]
		public readonly static string Setting = TerminologyIdList["Group_id_setting"];
		[OpenEhrName("Group_id_term_mapping_purpose")]
		public readonly static string TerminologyMappingPurpose = TerminologyIdList["Group_id_term_mapping_purpose"];
		[OpenEhrName("Group_id_version_lifecycle_state")]
		public readonly static string VersionLifecycleStatus = TerminologyIdList["Group_id_version_lifecycle_state"];

		/// <summary>
		/// Validity function to test if an identifier is in the set defined by this class.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OpenEhrName("valid_terminology_group_id")]
		public static bool IsValidTerminologyGroupId(string id)
		{
			return TerminologyIdList.ContainsValue(id);
		}
	}
}
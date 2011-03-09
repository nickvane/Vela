//-----------------------------------------------------------------------
// <copyright file="Activity.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataTypes.EncapsulatedPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Defines a single activity within an Instruction, such as a medication administration.
	/// </summary>
	[Serializable]
	[OpenEhrName("ACTIVITY")]
	public class Activity : Locatable
	{
		/// <summary>
		/// Description of the activity, in the form of an archetyped structure.
		/// </summary>
		[OpenEhrName("description")]
		public ItemStructure Description { get; set; }

		/// <summary>
		/// Timing of the activity, in the form of a parsable string, such as an HL7 GTS or ISO8601 string.
		/// </summary>
		[OpenEhrName("timing")]
		public Parsable Timing { get; set; }

		/// <summary>
		/// Perl-compliant regular expression pattern, enclosed in ‘//’ delimiters, indicating the valid archetype identifiers of archetypes for Actions corresponding to this Activity specification. Defaults to “/.*/”, meaning any archetype.
		/// </summary>
		[OpenEhrName("action_archetype_id")]
		public string ActionArchetypeId { get; set; }
	}
}
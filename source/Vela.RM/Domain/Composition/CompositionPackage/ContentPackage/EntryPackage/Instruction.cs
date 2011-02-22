using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.Encapsulatedpackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Used to specify actions in the future. Enables simple and complex specifications to be expressed, including in a fully-computable workflow form.
	/// Used for any actionable statement such as medication and therapeutic orders, monitoring, recall and review. Enough details must be provided for the specification to be directly executed by an actor, either human or machine.
	/// Not to be used for plan items which are only specified in general terms.
	/// </summary>
	[Serializable]
	[OpenEhrName("INSTRUCTION")]
	public class Instruction : CareEntry
	{
		/// <summary>
		/// Mandatory human-readable version of what the Instruction is about.
		/// </summary>
		[OpenEhrName("narrative")]
		public Text Narrative { get; set; }

		/// <summary>
		/// List of all activities in Instruction.
		/// </summary>
		[OpenEhrName("activities")]
		public IList<Activity> Activities { get; set; }

		/// <summary>
		/// Optional expiry date/time to assist determination of when an Instruction can be assumed to have expired. This helps prevent false listing of Instructions as Active when they clearly must have been terminated in some way or other.
		/// </summary>
		[OpenEhrName("expiry_time")]
		public DateTime ExpiryTime { get; set; }

		/// <summary>
		/// Optional workflow engine executable expression of the Instruction.
		/// </summary>
		[OpenEhrName("wf_definition")]
		public Parsable WorkflowDefinition { get; set; }
	}
}

using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Used to record details of the Instruction causing an Action.
	/// </summary>
	[Serializable]
	[OpenEhrName("INSTRUCTION_DETAILS")]
	public class InstructionDetails : Pathable
	{
		/// <summary>
		/// Reference to causing Instruction.
		/// </summary>
		[OpenEhrName("instruction_id")]
		public LocatableRef InstructionId { get; set; }

		/// <summary>
		/// Identifier of Activity within Instruction, in the form of its archetype path.
		/// </summary>
		[OpenEhrName("activity_id")]
		public string ActivityId { get; set; }

		/// <summary>
		/// Various workflow engine state details, potentially including such things as:
		/// • condition that fired to cause this Action to be done (with actual variables substituted);
		/// • list of notifications which actually occurred (with all variables substituted);
		/// • other workflow engine state. 
		/// This specification does not currently define the actual structure or semantics of this field.
		/// </summary>
		[OpenEhrName("wf_details")]
		public ItemStructure WorkflowDetails { get; set; }
	}
}

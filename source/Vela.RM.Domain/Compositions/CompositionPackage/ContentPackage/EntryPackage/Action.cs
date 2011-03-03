using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Used to record a clinical action that has been performed, which may have been ad hoc, or due to the execution of an Activity in an Instruction workflow. Every Action corresponds to a careflow step of some kind or another.
	/// </summary>
	[Serializable]
	[OpenEhrName("ACTION")]
	public class Action : CareEntry
	{
		/// <summary>
		/// Point in time at which this action completed.
		/// </summary>
		[OpenEhrName("time")]
		public DateTime Time { get; set; }

		/// <summary>
		/// Description of the activity to be performed, in the form of an archetyped structure.
		/// </summary>
		[OpenEhrName("description")]
		public ItemStructure Description { get; set; }

		/// <summary>
		/// Details of transition in the Instruction state machine caused by this Action.
		/// </summary>
		[OpenEhrName("ism_transition")]
		public IsmTransition IsmTransition { get; set; }

		/// <summary>
		/// Details to of the Instruction that caused this Action to be performed, if there was one.
		/// </summary>
		[OpenEhrName("instruction_details")]
		public InstructionDetails InstructionDetails { get; set; }
	}
}

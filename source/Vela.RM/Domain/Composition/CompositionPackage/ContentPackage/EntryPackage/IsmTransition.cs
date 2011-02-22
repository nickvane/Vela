using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Model of a transition in the Instruction State machine, caused by a careflow step. The attributes document the careflow step as well as the ISM transition.
	/// </summary>
	[Serializable]
	[OpenEhrName("ISM_TRANSITION")]
	public class IsmTransition : Pathable
	{
		/// <summary>
		/// The ISM current state. Coded by openEHR terminology group “Instruction states”
		/// </summary>
		[OpenEhrName("current_state")]
		public CodedText CurrentState { get; set; }

		/// <summary>
		/// The ISM transition which occurred to arrive in the current_state. Coded by openEHR terminology group “Instruction transitions”.
		/// </summary>
		[OpenEhrName("transition")]
		public CodedText Transition { get; set; }

		/// <summary>
		/// The step in the careflow process which occurred as part of generating this action, e.g. “dispense”, “start_administration”. This attribute represents the clinical  label for the activity, as  opposed to current_state which represents  the state machine (ISM)  computable form. Defined in archetype.
		/// </summary>
		[OpenEhrName("careflow_step")]
		public CodedText CareflowStep { get; set; }
	}
}

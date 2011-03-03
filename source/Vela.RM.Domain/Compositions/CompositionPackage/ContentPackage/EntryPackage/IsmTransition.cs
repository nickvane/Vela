using System;
using System.Collections.Generic;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
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

		///<summary>
		/// The path to an item relative to the root of this archetyped structure.
		///</summary>
		///<param name="item"></param>
		///<returns></returns>
		public override string GetPathOfItem(Pathable item)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// The item at a path (relative to this item); only valid for unique paths, i.e. paths that resolve to a single item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override object GetItemAtPath(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// List of items corresponding to a non-unique path.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override IList<object> GetItemsAtPath(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path exists in the data with respect to the current item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override bool DoesPathExists(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path corresponds to a single item in the data.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override bool IsPathUnique(string path)
		{
			throw new NotImplementedException();
		}
	}
}

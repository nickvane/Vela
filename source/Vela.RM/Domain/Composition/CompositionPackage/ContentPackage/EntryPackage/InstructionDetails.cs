using System;
using System.Collections.Generic;
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
		public override List<object> GetItemsAtPath(string path)
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

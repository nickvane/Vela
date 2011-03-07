using System;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// A constraint defined by proxy, using a reference to an object constraint defined elsewhere in the same archetype. 
	/// Note that since this object refers to another node, there are two objects with available occurrences values. The local occurrences value on an ARCHETYPE_INTERNAL_REF should always be used; when setting this from a serialised form, if no occurrences is mentioned, the target occurrences should be used (not the standard default of {1..1}); otherwise the locally specified occurrences should be used as normal. When serialising out, if the occurrences is the same as that of the target, it can be left out.
	/// </summary>
	[OpenEhrName("ARCHETYPE_INTERNAL_REF")]
	public class ArchetypeInternalRef : CReferenceObject
	{
		/// <summary>
		/// Reference to an object node using archetype path notation.
		/// </summary>
		[OpenEhrName("target_path")]
		public string TargetPath { get; set; }

		/// <summary>
		/// True if constraints represented by other are narrower than this node. Note: not easily evaluatable for CONSTRAINT_REF nodes.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if this node (and all its sub-nodes) is a valid archetype node for its type. This function should be implemented by each subtype to perform semantic validation of itself, and then call the is_valid function in any subparts, and generate the result appropriately
		/// </summary>
		/// <returns></returns>
		public override bool IsValid()
		{
			throw new NotImplementedException();
		}
	}
}

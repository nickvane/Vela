using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract model of constraint on any kind of attribute node.
	/// </summary>
	[OpenEhrName("C_MULTIPLE_ATTRIBUTE")]
	public class CMultipleAttribute : CAttribute
	{
		private List<CObject> _members;

		/// <summary>
		/// Cardinality of this attribute constraint, if it constraints a container attribute.
		/// </summary>
		[OpenEhrName("cardinality")]
		public Cardinality Cardinality { get; set; }

		/// <summary>
		/// List of constraints representing members of the container value of this attribute within the data. Semantics of the uniqueness and ordering of items in the container are given by the cardinality.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("members")]
		public IList<CObject> Members
		{
			get { return _members ?? (_members = new List<CObject>()); }
		}

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

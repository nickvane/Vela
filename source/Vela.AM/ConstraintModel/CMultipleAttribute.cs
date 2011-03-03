using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract model of constraint on any kind of attribute node.
	/// </summary>
	[OpenEhrName("C_MULTIPLE_ATTRIBUTE")]
	public abstract class CMultipleAttribute : CAttribute
	{
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
		public IList<CObject> GetMembers()
		{
			throw new NotImplementedException();
		}
	}
}

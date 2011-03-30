//-----------------------------------------------------------------------
// <copyright file="CSingleAttribute.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.ConstraintModel
{
	/// <summary>
	/// Concrete model of constraint on a single-valued attribute node. The meaning of the inherited children attribute is that they are alternatives.
	/// </summary>
	[OpenEhrName("C_SINGLE_ATTRIBUTE")]
	public class CSingleAttribute : CAttribute
	{
		#region Overrides of ArchetypeConstraint

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

		#endregion

		/// <summary>
		/// List of alternative constraints for the single child of this attribute within the data.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("alternatives")]
		public IList<CObject> GetAlternatives()
		{
			throw new NotImplementedException();
		}
	}
}
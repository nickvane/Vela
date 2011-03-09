//-----------------------------------------------------------------------
// <copyright file="ConstraintRef.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Reference to a constraint described in the same archetype, but outside the main constraint structure. This is used to  refer to constraints  expressed in terms of external resources, such as constraints on terminology value sets.
	/// </summary>
	[OpenEhrName("CONSTRAINT_REF")]
	public class ConstraintRef : CReferenceObject
	{
		/// <summary>
		/// Reference to a constraint in the archetype local ontology.
		/// </summary>
		[OpenEhrName("reference")]
		public string Reference { get; set; }

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
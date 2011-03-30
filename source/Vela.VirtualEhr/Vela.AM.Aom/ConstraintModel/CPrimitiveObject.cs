//-----------------------------------------------------------------------
// <copyright file="CPrimitiveObject.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.AM.Aom.Primitives;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.ConstraintModel
{
	/// <summary>
	/// Constraint on a primitive type.
	/// </summary>
	[OpenEhrName("C_PRIMITIVE_OBJECT")]
	public class CPrimitiveObject : CDefinedObject<CPrimitiveObject>
	{
		/// <summary>
		/// Object actually defining the constraint.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("item")]
		public CPrimitive Item { get; set; }

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
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		public override CPrimitiveObject DefaultValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(CPrimitiveObject value)
		{
			throw new NotImplementedException();
		}
	}
}
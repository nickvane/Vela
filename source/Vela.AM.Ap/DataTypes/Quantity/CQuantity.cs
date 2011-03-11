//-----------------------------------------------------------------------
// <copyright file="CQuantity.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.AM.Aom.ConstraintModel;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.Ap.DataTypes.Quantity
{
	/// <summary>
	/// Constrain instances of DV_QUANTITY.
	/// </summary>
	[OpenEhrName("C_DV_QUANTITY")]
	public class CQuantity : CDomainType<CQuantity>
	{
		private IList<CQuantityItem> _quantityConstraints;

		/// <summary>
		/// List of value/units pairs.
		/// </summary>
		[OpenEhrName("list")]
		public IList<CQuantityItem> QuantityConstraints
		{
			get
			{
				return _quantityConstraints ?? (_quantityConstraints = new List<CQuantityItem>());
			}
		}

		/// <summary>
		/// Optional constraint on units property
		/// </summary>
		[OpenEhrName("property")]
		public CodePhrase Property { get; set; }

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

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		public override CQuantity DefaultValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(CQuantity value)
		{
			throw new NotImplementedException();
		}
	}
}
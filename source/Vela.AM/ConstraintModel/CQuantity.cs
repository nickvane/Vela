//-----------------------------------------------------------------------
// <copyright file="CQuantity.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.AM.ConstraintModel
{
	public class CQuantity : CDomainType<CQuantity>
	{
		private IList<Quantity> _quantities;
		public CodePhrase CodePhrase { get; set; }

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
		/// 
		/// </summary>
		public IList<Quantity> Quantities
		{
			get { return _quantities ?? (_quantities = new List<Quantity>()); }
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
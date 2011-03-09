//-----------------------------------------------------------------------
// <copyright file="ArchetypeSlot.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.AM.Assertions;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Constraint describing a ‘slot’ where another archetype can occur.
	/// </summary>
	[OpenEhrName("ARCHETYPE_SLOT")]
	public class ArchetypeSlot : CReferenceObject
	{
		private IList<Assertion> _excludes;
		private IList<Assertion> _includes;

		/// <summary>
		/// List of constraints defining other archetypes that could be included at this point.
		/// </summary>
		[OpenEhrName("includes")]
		public IList<Assertion> Includes
		{
			get { return _includes ?? (_includes = new List<Assertion>()); }
		}

		/// <summary>
		/// List of constraints defining other archetypes that cannot be included at this point.
		/// </summary>
		[OpenEhrName("excludes")]
		public IList<Assertion> Excludes
		{
			get { return _excludes ?? (_excludes = new List<Assertion>()); }
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
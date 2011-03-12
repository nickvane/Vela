//-----------------------------------------------------------------------
// <copyright file="ArchetypeConstraint.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.ConstraintModel
{
	/// <summary>
	/// Archetype equivalent to LOCATABLE class in openEHR Common reference model. Defines common constraints for any inheritor of LOCATABLE in any reference model.
	/// </summary>
	[OpenEhrName("ARCHETYPE_CONSTRAINT")]
	public abstract class ArchetypeConstraint
	{
		/// <summary>
		/// True if constraints represented by other are narrower than this node. Note: not easily evaluatable for CONSTRAINT_REF nodes.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		[OpenEhrName("is_subset_of")]
		public abstract bool IsSubsetOf(ArchetypeConstraint other);

		/// <summary>
		/// True if this node (and all its sub-nodes) is a valid archetype node for its type. This function should be implemented by each subtype to perform semantic validation of itself, and then call the is_valid function in any subparts, and generate the result appropriately
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_valid")]
		public virtual bool IsValid()
		{
			return true;
		}

		/// <summary>
		/// Path of this node relative to root of archetype.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("path")]
		public string GetPath()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if the relative path a_path exists at this node.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[OpenEhrName("has_path")]
		public bool HasPath(string path)
		{
			throw new NotImplementedException();
		}
	}
}
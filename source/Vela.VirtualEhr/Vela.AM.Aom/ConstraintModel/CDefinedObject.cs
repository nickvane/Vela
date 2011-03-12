//-----------------------------------------------------------------------
// <copyright file="CDefinedObject.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.ConstraintModel
{
	/// <summary>
	/// Abstract parent type of C_OBJECT subtypes that are defined by value, i.e. whose definitions are actually in the archetype rather than being by reference.
	/// </summary>
	[OpenEhrName("C_DEFINED_OBJECT")]
	public abstract class CDefinedObject<T> : CObject
	{
		/// <summary>
		/// Value to be assumed if none sent in data
		/// </summary>
		[OpenEhrName("assumed_value")]
		public T AssumedValue { get; set; }

		/// <summary>
		/// True if there is an assumed value
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("has_assumed_value")]
		public bool HasAssumedValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("default_value")]
		public abstract T DefaultValue();

		/// <summary>
		/// True if any value (i.e. instance) of the reference model type would be allowed. Redefined in descedants.
		/// </summary>
		[OpenEhrName("any_allowed")]
		public bool AnyAllowed { get; set; }

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[OpenEhrName("valid_value")]
		public abstract bool IsValidValue(T value);
	}
}
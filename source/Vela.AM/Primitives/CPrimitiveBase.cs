//-----------------------------------------------------------------------
// <copyright file="CPrimitiveBase.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.AM.Primitives
{
	/// <summary>
	/// Abstract supertype of all primitive types.
	/// </summary>
	[OpenEhrName("")]
	public abstract class CPrimitiveBase<T> : CPrimitive
	{
		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		[OpenEhrName("")]
		public abstract T DefaultValue { get; set; }

		/// <summary>
		/// True if there is an assumed value
		/// </summary>
		[OpenEhrName("")]
		public abstract bool HasAssumedValue { get; set; }

		/// <summary>
		/// Value to be assumed if none sent in data
		/// </summary>
		[OpenEhrName("")]
		public abstract T AssumedValue { get; set; }

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[OpenEhrName("")]
		public abstract bool IsValidValue(T value);
	}
}
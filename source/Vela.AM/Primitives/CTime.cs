//-----------------------------------------------------------------------
// <copyright file="CTime.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.DateTimePackage;

namespace Vela.AM.Primitives
{
	public class CTime : CPrimitiveBase<Time>
	{
		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		public override Time DefaultValue { get; set; }

		/// <summary>
		/// True if there is an assumed value
		/// </summary>
		public override bool HasAssumedValue
		{
			get; set; }

		/// <summary>
		/// Value to be assumed if none sent in data
		/// </summary>
		public override Time AssumedValue { get; set; }

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(Time value)
		{
			throw new NotImplementedException();
		}
	}
}
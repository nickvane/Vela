//-----------------------------------------------------------------------
// <copyright file="CReal.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.AM.Primitives
{
	public class CReal : CPrimitiveBase<double>
	{
		/// <summary>
		/// Set of Integers specifying constraint
		/// </summary>
		public HashSet<double> List
		{
			get;
			set;
		}

		/// <summary>
		/// Range of Integers specifying constraint
		/// </summary>
		public Interval<double> Range
		{
			get;
			set;
		}

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		public override double DefaultValue
		{
			get;
			set;
		}

		/// <summary>
		/// True if there is an assumed value
		/// </summary>
		public override bool HasAssumedValue
		{
			get;
			set;
		}

		/// <summary>
		/// Value to be assumed if none sent in data
		/// </summary>
		public override double AssumedValue
		{
			get;
			set;
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(double value)
		{
			throw new NotImplementedException();
		}
	}
}
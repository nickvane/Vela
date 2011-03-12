//-----------------------------------------------------------------------
// <copyright file="CDateTime.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.AM.Aom.Primitives
{
	public class CDateTime : CPrimitiveBase<DateTime>
	{
		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		public override DateTime DefaultValue
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
		[OpenEhrName("")]
		public override DateTime AssumedValue
		{
			get;
			set;
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[OpenEhrName("")]
		public override bool IsValidValue(DateTime value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Range of DateTimes specifying constraint
		/// </summary>
		public Interval<DateTime> Range
		{
			get;
			set;
		}

		/// <summary>
		/// Regular expression pattern for proposed instances of Duration to match.
		/// </summary>
		public string Pattern
		{
			get;
			set;
		}
	}
}
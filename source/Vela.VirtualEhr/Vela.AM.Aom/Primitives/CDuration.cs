//-----------------------------------------------------------------------
// <copyright file="CDuration.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.Primitives
{
	public class CDuration : CPrimitiveBase<Duration>
	{
		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		public override Duration DefaultValue
		{
			get;
			set;
		}

		/// <summary>
		/// True if there is an assumed value
		/// </summary>
		public override bool HasAssumedValue
		{
			get; set; }

		/// <summary>
		/// Value to be assumed if none sent in data
		/// </summary>
		[OpenEhrName("")]
		public override Duration AssumedValue
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
		public override bool IsValidValue(Duration value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Range of Durations specifying constraint
		/// </summary>
		public Interval<Duration> Range { get; set; }

		/// <summary>
		/// Regular expression pattern for proposed instances of Duration to match.
		/// </summary>
		public string Pattern { get; set; }
	}
}
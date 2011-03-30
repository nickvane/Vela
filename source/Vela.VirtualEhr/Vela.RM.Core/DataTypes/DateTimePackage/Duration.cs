//-----------------------------------------------------------------------
// <copyright file="Duration.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Properties;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.DateTimePackage
{
	/// <summary>
	/// Represents a period of time with respect to a notional point in time, which is not specified. A sign may be used to indicate the duration is “backwards” in time rather than forwards. 
	/// Note that a deviation from ISO8601 is supported, allowing the ‘W’ designator to be mixed with other designators. See assumed types section in the Support IM.
	/// USE: Used for recording the duration of something in the real world, particularly when there is a need a) to represent the duration in customary format, i.e. days, hours, minutes etc, and b) if it will be used in computational operations with date/time quantities, i.e. additions, subtractions etc.
	/// MISUSE: Durations cannot be used to represent points in time, or intervals of time.
	/// </summary>
	[Serializable]
	[OpenEhrName("DV_DURATION")]
	public class Duration : Amount<Duration>
	{
		public Duration()
		{
			
		}

		public Duration(string value)
		{
			Value = value;
		}

		///<summary>
		/// ISO8601 duration
		///</summary>
		[OpenEhrName("value")]
		public string Value
		{
			get;
			set;
		}

		///<summary>
		/// Numeric value of the duration as seconds.
		///</summary>
		///<returns></returns>
		[OpenEhrName("magnitude")]
		public override double Magnitude
		{
			get; set;
			//set { throw new NotSupportedException(string.Format(Resources.NotSupportedReadOnlyProperty, "Magnitude")); }
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Duration other)
		{
			throw new NotImplementedException();
		}
	}
}
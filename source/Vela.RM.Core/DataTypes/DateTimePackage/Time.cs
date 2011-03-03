using System;
using Vela.RM.Core.Properties;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.DateTimePackage
{
	/// <summary>
	/// Represents an absolute point in time from an origin usually interpreted as meaning the start of the current day, specified to the second. Semantics defined by ISO8601.
	/// Used for recording real world times, rather than scientifically measured fine amounts of time. The partial form is used for approximate times of events and substance administrations.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance"), Serializable]
	[OpenEhrName("DV_TIME")]
	public class Time : Temporal<Time, Duration>
	{
		/// <summary>
		/// ISO8601 time string
		/// </summary>
		[OpenEhrName("value")]
		public string Value
		{
			get;
			set;
		}

		///<summary>
		/// Numeric value of the time as seconds since the start of the day
		///</summary>
		///<returns></returns>
		[OpenEhrName("magnitude")]
		public override double Magnitude
		{
			get { return 0; }
			set { throw new NotSupportedException(string.Format(Resources.NotSupportedReadOnlyProperty, "Magnitude")); }
		}

		///<summary>
		/// Addition of a differential amount to this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		public override Time Add(Duration value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Result of subtracting a differential amount from this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		public override Time Subtract(Duration value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Difference of two times.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		[OpenEhrName("diff")]
		public override Duration Diff(Time value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Time other)
		{
			throw new NotImplementedException();
		}
	}
}

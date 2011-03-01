using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Properties;

namespace Vela.RM.Core.DataTypes.DateTimePackage
{
	///<summary>
	/// Represents an absolute point in time, specified to the second. Semantics defined by ISO 8601.
	/// Used for recording a precise point in real world time, and for approximate time stamps, e.g. the origin of a HISTORY in an OBSERVATION which is only partially known.
	///</summary>
	[Serializable]
	[OpenEhrName("DV_DATE_TIME")]
	public class DateTime : Temporal<DateTime, Duration>
	{
		///<summary>
		/// ISO8601 date/time string
		///</summary>
		[OpenEhrName("value")]
		public virtual string Value
		{
			get;
			set;
		}

		///<summary>
		/// Numeric value of the date/time as seconds since the calendar origin point.
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
		public override DateTime Add(Duration value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Result of subtracting a differential amount from this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		public override DateTime Subtract(Duration value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Difference of two date/times.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		public override Duration Diff(DateTime value)
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
		public override int CompareTo(DateTime other)
		{
			if (Value == other.Value) return 0;
			var sorted = new List<string> {other.Value, Value};
			sorted.Sort();
			if (sorted[0] == Value) return -1;
			return 1;
		}
	}
}

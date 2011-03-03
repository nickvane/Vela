using System;
using Vela.RM.Core.Properties;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.DateTimePackage
{
	/// <summary>
	/// Represents an absolute point in time, as measured on the Gregorian calendar, and specified only to the day. Semantics defined by ISO 8601.
	/// USE: Used for recording dates in real world time. The partial form is used for approximate birth dates, dates of death, etc.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance"), Serializable]
	[OpenEhrName("DV_DATE")]
	public class Date : Temporal<Date, Duration>
	{
		/// <summary>
		/// ISO8601 date string
		/// </summary>
		[OpenEhrName("value")]
		public string Value { get; set; }

		/// <summary>
		/// Numeric value of the date as days since the calendar origin point 1/1/0000
		/// </summary>
		[OpenEhrName("magnitude")]
		public override double Magnitude
		{
			get { return 0; }
			set { throw new NotSupportedException(string.Format(Resources.NotSupportedReadOnlyProperty, "Magnitude")); }
		}

		///<summary>
		/// Difference of two dates.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		[OpenEhrName("diff")]
		public override Duration Diff(Date value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Addition of a differential amount to this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		[OpenEhrName("add")]
		public override Date Add(Duration value)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// Result of subtracting a differential amount from this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		[OpenEhrName("subtract")]
		public override Date Subtract(Duration value)
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
		public override int CompareTo(Date other)
		{
			throw new NotImplementedException();
		}
	}
}
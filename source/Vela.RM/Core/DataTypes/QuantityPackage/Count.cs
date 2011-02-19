using System;
using Vela.RM.Core.Support;
using Vela.RM.Properties;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Countable quantities.
	/// USE: Used for countable types such as pregnancies and steps (taken by a physiotherapy patient), number of cigarettes smoked in a day.
	/// MISUSE: Not used for amounts of physical entities (which all have units)
	/// </summary>
	[Serializable]
	[OpenEhrName("DV_COUNT")]
	public class Count : Amount<Count>
	{
		private double _magnitude;

		/// <summary>
		/// Numeric magnitude of the quantity
		/// </summary>
		[OpenEhrName("magnitude")]
		public override double Magnitude
		{
			get { return _magnitude; }
			set
			{
				if (Math.Floor(value) != value) throw new ArgumentException(string.Format(Resources.InvalidIntegerValue, value, "Magnitude"), "value");
				_magnitude = value;
			}
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Count other)
		{
			if (Magnitude == other.Magnitude) return 0;
			if (Magnitude < other.Magnitude) return -1;
			return 1;
		}
	}
}
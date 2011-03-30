//-----------------------------------------------------------------------
// <copyright file="Quantity.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.MeasurementPackage;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Quantitified type representing “scientific” quantities, i.e. quantities expressed as a magnitude and units. Units were inspired by the Unified Code for Units of Measure (UCUM), developed by Gunther Schadow and Clement J. McDonald of The Regenstrief Institute [8]. 
	/// USE: Can also be used for time durations, where it is more convenient to treat these as simply a number of seconds rather than days, months, years.
	/// </summary>
	[Serializable, OpenEhrName("DV_QUANTITY")]
	public class Quantity : Amount<Quantity>
	{
		private readonly IMeasurementService _measurementService;

		public Quantity(IMeasurementService measurementService)
		{
			_measurementService = measurementService;
		}

		public Quantity()
		{
			
		}

		/// <summary>
		/// Numeric magnitude of the quantity.
		/// </summary>
		[OpenEhrName("magnitude")]
		public override double Magnitude { get; set; }

		/// <summary>
		/// Precision to which the value of the quantity is expressed, in terms of number of decimal places. The value 0 implies an integral quantity. The value -1 implies no limit, i.e. any number of decimal places.
		/// </summary>
		[OpenEhrName("precision")]
		public int Precision { get; set; }

		//TODO: check for syntax on set
		/// <summary>
		/// Stringified units, expressed in UCUM unit syntax, e.g. "kg/m2", “mm[Hg]", "ms-1", "km/h". Implemented accordingly in subtypes.
		/// </summary>
		[OpenEhrName("units")]
		public string Units { get; set; }

		/// <summary>
		/// True if precision = 0; quantity represents an integral number.
		/// </summary>
		[OpenEhrName("is_integral")]
		public bool IsIntegral()
		{
			return Precision == 0; 
		}

		/// <summary>
		/// Test if two instances are strictly comparable by ensuring that the measured property is the same, achieved using the Measurement service function units_equivalent.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		[OpenEhrName("is_strictly_comparable_to")]
		public override bool IsStrictlyComparableTo(Quantity other)
		{
			return _measurementService.AreEquivalentUnits(Units, other.Units);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Quantity other)
		{
			if (Magnitude == other.Magnitude) return 0;
			if (Magnitude < other.Magnitude) return -1;
			return 1;
		}
	}
}
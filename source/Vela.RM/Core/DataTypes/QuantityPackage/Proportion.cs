using System;
using Vela.RM.Core.Support;
using Vela.RM.Properties;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Models a ratio of values, i.e. where the numerator and denominator are both pure numbers. The valid_proportion_kind property of the <see cref="ProportionKind"/> class is used to control the type attribute to be one of a defined set.
	/// USE: Used for recording titers (e.g. 1:128), concentration ratios,  e.g. Na:K (unitary denominator), albumin:creatinine ratio, and percentages, e.g. red cell distirbution width (RDW).
	/// MISUSE: Should not be used to represent things like blood pressure which are often written using a ‘/’ character, giving the misleading impression that the item is a ratio, when in fact it is a structured value. Similarly, visual acuity, often written as (e.g.) “6/24”  in clinical notes is not a ratio but an ordinal (which includes non-numeric symbols like CF = count fingers etc). Should not be used for formulations.
	/// </summary>
	[Serializable, OpenEhrName("DV_PROPORTION")]
	public class Proportion : Amount<Proportion>
	{
		private int _precision;

		public Proportion()
		{
			Type = ProportionKind.Ratio;
		}

		/// <summary>
		/// Effective magnitude represented by ratio.
		/// </summary>
		[OpenEhrName("magnitude")]
		public override double Magnitude
		{
			get
			{
				if (Denominator == 0) return 0;
				return Numerator/Denominator;
			}
			set { throw new NotSupportedException(string.Format(Resources.NotSupportedReadOnlyProperty, "Magnitude")); }
		}

		/// <summary>
		/// Numerator of ratio
		/// </summary>
		[OpenEhrName("numerator")]
		public double Numerator { get; set; }

		/// <summary>
		/// Denominator of ratio
		/// </summary>
		[OpenEhrName("denominator")]
		public double Denominator { get; set; }

		/// <summary>
		/// Indicates semantic type of proportion, including percent, unitary etc. Values controlled by inherited properties from <see cref="ProportionKind"/>.
		/// </summary>
		[OpenEhrName("type")]
		public ProportionKind Type { get; set; }

		/// <summary>
		/// Precision  to  which  the  numerator and denominator values of  the  proportion are expressed, in terms of number of decimal places. The value 0 implies an integral quantity. The value -1 implies no limit, i.e. any number of decimal places.
		/// </summary>
		[OpenEhrName("precision")]
		public int Precision
		{
			get { return _precision; }
			set
			{
				if (value < -1) throw new ArgumentException(String.Format(Resources.InvalidPrecision, value), "value");
				_precision = value;
			}
		}

		/// <summary>
		/// True if the numerator and denominator values are integers, i.e. if the precision is 0.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_integral")]
		public bool IsIntegral()
		{
			return Precision == 0;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Proportion other)
		{
			if (Magnitude == other.Magnitude) return 0;
			if (Magnitude < other.Magnitude) return -1;
			return 1;
		}
	}
}
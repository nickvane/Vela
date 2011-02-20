using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.Helper;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Defines a named range to  be associated with any Ordered datum. Each such range is particular to the patient and context, e.g. sex, age, and any other factor which affects ranges.
	/// May be used to represent normal, therapeutic, dangerous, critical etc ranges.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable, OpenEhrName("REFERENCE_RANGE<T:DV_ORDERED>")]
	public class ReferenceRange<T> where T : Ordered<T>
	{
		private Interval<T> _range;

		/// <summary>
		/// Term whose value indicates the meaning of this range, e.g. “normal”, “critical”, “therapeutic” etc.
		/// </summary>
		[OpenEhrName("meaning")]
		public Text Meaning
		{
			get;
			set;
		}

		/// <summary>
		/// The data range for this meaning, e.g. “critical” etc.
		/// </summary>
		[OpenEhrName("range")]
		public Interval<T> Range
		{
			get
			{
				return _range ?? (_range = new Interval<T>());
			}
			set
			{
				_range = value;
			}
		}

		/// <summary>
		/// Indicates if the value is inside the range.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[OpenEhrName("is_in_range")]
		public bool IsInRange(T value)
		{
			return Range.HasElement(value);
		}
	}
}

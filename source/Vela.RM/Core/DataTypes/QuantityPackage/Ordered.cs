using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Abstract class defining the concept of ordered values, which includes ordinals as well as true quantities. It defines the functions ‘&lt;’ and is_strictly_comparable_to, the latter of which must evaluate to True for instances being compared with the ‘&lt;’ function, or used as limits in the IntervalType&lt;T> class.
	/// USE: Data value types which are to be used as limits in the IntervalType&lt;T> class must inherit from this class, and implement the function IsStrictlyComparableTo to ensure that instances compare meaningfully. For example, instances of <see cref="Quantity"/> can only be compared if they measure the same kind of physical quantity.
	/// </summary>
	[Serializable, OpenEhrName("DV_ORDERED")]
	public abstract class Ordered : DataValue, IEquatable<Ordered>
	{
		/// <summary>
		/// Optional normal status indicator of value with respect to normal range for this value. Often included by lab, even if the normal range itself is not included. Coded by ordinals in series HHH, HH, H, (nothing), L, LL, LLL; see openEHR terminology group “normal status”.
		/// </summary>
		[OpenEhrName("normal_status")]
		public CodePhrase NormalStatus
		{
			get;
			set;
		}

		/// <summary>
		/// Optional normal range.
		/// </summary>
		[OpenEhrName("normal_range")]
		public Interval<Ordered> NormalRange
		{
			get;
			set;
		}

		/// <summary>
		/// Optional tagged other reference ranges for this value in its particular measurement context
		/// </summary>
		[OpenEhrName("other_reference_ranges")]
		public IList<ReferenceRange<Ordered>> OtherReferenceRanges
		{
			get;
			set;
		}

		/// <summary>
		/// Value is in the normal range, determined by comparison of the value to the normal_range if present, or by the normal_status marker if present.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_normal")]
		public bool IsNormal()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if this quantity has no reference ranges.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_simple")]
		public bool IsSimple()
		{
			throw new NotImplementedException();
		}

		public bool Equals(Ordered other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.NormalStatus, NormalStatus) && Equals(other.NormalRange, NormalRange) && Equals(other.OtherReferenceRanges, OtherReferenceRanges);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Ordered)) return false;
			return Equals((Ordered)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = (NormalStatus != null ? NormalStatus.GetHashCode() : 0);
				result = (result * 397) ^ (NormalRange != null ? NormalRange.GetHashCode() : 0);
				result = (result * 397) ^ (OtherReferenceRanges != null ? OtherReferenceRanges.GetHashCode() : 0);
				return result;
			}
		}


		public static bool operator ==(Ordered left, Ordered right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Ordered left, Ordered right)
		{
			return !Equals(left, right);
		}

		public static bool operator >(Ordered left, Ordered right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <(Ordered left, Ordered right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >=(Ordered left, Ordered right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <=(Ordered left, Ordered right)
		{
			throw new NotImplementedException();
		}
	}
}

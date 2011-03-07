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
	public abstract class Ordered<T> : DataValue, IEquatable<T>, IComparable<T> where T : Ordered<T>
	{
		private IList<ReferenceRange<T>> _otherReferenceRanges	;

		/// <summary>
		/// Optional normal status indicator of value with respect to normal range for this value. Often included by lab, even if the normal range itself is not included. Coded by ordinals in series HHH, HH, H, (nothing), L, LL, LLL; see openEHR terminology group â€œnormal statusâ€.
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
		public Interval<T> NormalRange
		{
			get;
			set;
		}

		/// <summary>
		/// Optional tagged other reference ranges for this value in its particular measurement context
		/// </summary>
		[OpenEhrName("other_reference_ranges")]
		public IList<ReferenceRange<T>> OtherReferenceRanges
		{
			get { return _otherReferenceRanges ?? (_otherReferenceRanges = new List<ReferenceRange<T>>()); }
		}

		/// <summary>
		/// Value is in the normal range, determined by comparison of the value to the normal_range if present, or by the normal_status marker if present.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_normal")]
		public bool IsNormal()
		{
			return NormalRange == null || NormalRange.HasElement((T)this);
		}

		/// <summary>
		/// True if this quantity has no reference ranges.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_simple")]
		public bool IsSimple()
		{
			return _otherReferenceRanges == null;
		}

		/// <summary>
		/// Test if two instances are strictly comparable.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		[OpenEhrName("is_strictly_comparable_to")]
		public virtual bool IsStrictlyComparableTo(T other)
		{
			return true;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public virtual bool Equals(T other)
		{
			return Compare(this, other) == 0;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="obj"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="obj">An object to compare with this object.</param>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(T)) return false;
			return Equals((T)obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
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

		public static bool operator <(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) < 0;
		}
		public static bool operator >(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) > 0;
		}
		public static bool operator ==(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) == 0;
		}
		public static bool operator !=(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) != 0;
		}
		public static bool operator <=(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) <= 0;
		}
		public static bool operator >=(Ordered<T> obj1, Ordered<T> obj2)
		{
			return Compare(obj1, obj2) >= 0;
		}

		public static int Compare(Ordered<T> obj1, Ordered<T> obj2)
		{
			if (ReferenceEquals(obj1, obj2)) return 0;
			if ((object)obj1 == null) return -1;
			if ((object)obj2 == null) return 1;
			if (!obj1.IsStrictlyComparableTo((T)obj2)) return -1;
			return obj1.CompareTo((T)obj2);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public abstract int CompareTo(T other);
	}
}

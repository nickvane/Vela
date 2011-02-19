using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	///<summary>
	/// Abstract class defining the concept of quantified entities whose values are absolute with respect to an origin. Dates and Times are the main example.
	///</summary>
	[Serializable, OpenEhrName("DV_ABSOLUTE_QUANTITY")]
	public abstract class AbsoluteQuantity<T, TA> : Quantified<T>
		where T : Ordered<T>
		where TA : Amount<TA>
	{
		private bool _isAccuracySet;
		private TA _accuracy;

		/// <summary>
		/// Accuracy of measurement, expressed as a half-range value of the diff type for this quantity (i.e. an accuracy of x means x). A Void (i.e. null) value means accuracy not known.
		/// </summary>
		[OpenEhrName("accuracy")]
		public TA Accuracy
		{
			get
			{
				return _accuracy;
			}
			set
			{
				_isAccuracySet = true;
				_accuracy = value;
			}
		}

		/// <summary>
		/// True if accuracy is not known, e.g. due to not being recorded or discernable.
		/// </summary>
		[OpenEhrName("accuracy_unknown")]
		public bool IsAccuracyUnknown()
		{
			return !_isAccuracySet;
		}

		///<summary>
		/// Addition of a differential amount to this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		[OpenEhrName("add")]
		public abstract T Add(TA value);

		///<summary>
		/// Result of subtracting a differential amount from this quantity.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		[OpenEhrName("subtract")]
		public abstract T Subtract(TA value);

		///<summary>
		/// Difference of two quantities.
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		///<exception cref="NotImplementedException"></exception>
		[OpenEhrName("diff")]
		public abstract TA Diff(T value);
	}
}

//-----------------------------------------------------------------------
// <copyright file="Amount.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	///<summary>
	/// Abstract class defining the concept of relative quantified ‘amounts’. For relative quantities, the ‘+’ and ‘-’ operators are defined (unlike descendants of DV_ABSOLUTE_QUANTITY, such as the date/time types).
	///</summary>
	[Serializable, OpenEhrName("DV_AMOUNT")]
	public abstract class Amount<T> : Quantified<T> where T : Ordered<T>
	{
		private double _accuracy;
		private bool _isAccuracySet;

		/// <summary>
		/// Accuracy of measurement, expressed either as a half-range percent value (accuracy_is_percent = True) or a half-range quantity. A value of 0 means that accuracy is 100%, i.e. no error. A value of unknown_accuracy_value means that accuracy was not recorded.
		/// </summary>
		[OpenEhrName("accuracy")]
		public double Accuracy
		{
			get { return _accuracy; }
			set
			{
				_isAccuracySet = true;
				_accuracy = value;
			}
		}

		/// <summary>
		/// If True, indicates that when this object was created, accuracy was recorded as a percent value; if False, as an absolute quantity value.
		/// </summary>
		[OpenEhrName("accuracy_is_percent")]
		public bool IsAccuracyPercent { get; set; }

		/// <summary>
		/// True if accuracy is not known, e.g. due to not being recorded or discernable.
		/// </summary>
		[OpenEhrName("accuracy_unknown")]
		public bool IsAccuracyUnknown()
		{
			return !_isAccuracySet;
		}

		/// <summary>
		/// Test whether a number is a valid percentage, i.e. between 0 and 100.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[OpenEhrName("valid_percentage")]
		public static bool IsValidPercentage(double value)
		{
			return value >= 0 & value <= 100;
		}
	}
}
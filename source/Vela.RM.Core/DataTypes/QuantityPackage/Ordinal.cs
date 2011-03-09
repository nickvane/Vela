//-----------------------------------------------------------------------
// <copyright file="Ordinal.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Models rankings and scores, e.g. pain,  Apgar values, etc,  where there is a) implied ordering, b) no implication that the distance between each value is constant, and c) the total number of values is finite. Note that although the term ‘ordinal’ in mathematics means natural numbers only, here any integer is allowed, since negative and zero values are often used by medical professionals for values around a neutral point. Examples of sets of ordinal values:
	/// -3, -2, -1, 0, 1, 2, 3 -- reflex response values
	/// 0, 1, 2 -- Apgar values
	/// USE: Used for recording any clinical datum which is customarily recorded using symbolic values. Example: the results on a urinalysis strip, e.g. {neg, trace, +, ++, +++} are used for leucocytes, protein, nitrites etc; for non-haemolysed blood {neg, trace, moderate}; for haemolysed blood {neg, trace, small, moderate, large}.
	/// </summary>
	[Serializable, OpenEhrName("DV_ORDINAL")]
	public class Ordinal : Ordered<Ordinal>
	{
		private ReferenceRange<Ordinal> _limits;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Value in ordered enumeration of values. Any integer value can be used.</param>
		public Ordinal(int value)
		{
			Value = value;
		}

		/// <summary>
		/// Value in ordered enumeration of values. Any integer value can be used.
		/// </summary>
		[OpenEhrName("value")]
		public int Value
		{
			get;
			set;
		}

		/// <summary>
		/// Coded textual representation of this value in the enumeration, which may be strings made from “+” symbols, or other enumerations of terms such as “mild”, “moderate”, “severe”, or even the same number series as the values, e.g. “1”, “2”, “3”. Codes come from archetype.
		/// </summary>
		[OpenEhrName("symbol")]
		public CodedText Symbol
		{
			get;
			set;
		}

		/// <summary>
		/// limits of the ordinal enumeration, to allow comparison of an ordinal value to its limits.
		/// </summary>
		[OpenEhrName("limits")]
		public ReferenceRange<Ordinal> GetLimits()
		{
			return _limits ?? (_limits = new ReferenceRange<Ordinal>());
			//TODO: find out how limits are implemented
		}

		/// <summary>
		/// True if symbols come from same vocabulary, assuming the vocabulary is a subset or value range, e.g. “urine:protein”.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		[OpenEhrName("is_strictly_comparable_to")]
		public override bool IsStrictlyComparableTo(Ordinal other)
		{
			if (other == null) return false;
			//TODO: this implementation might not be correct according to the summary.
			return Symbol == other.Symbol;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public override int CompareTo(Ordinal other)
		{
			if (Value == other.Value) return 0;
			if (Value < other.Value) return -1;
			return 1;
		}
	}
}
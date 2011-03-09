//-----------------------------------------------------------------------
// <copyright file="Cardinality.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Express constraints on the cardinality of container objects which are the values of multiply-valued attributes, including  uniqueness and ordering, providing the means to state that a container acts like a logical list, set or bag. The cardinality cannot contradict the cardinality of the corresponding attribute within the relevant reference model.
	/// </summary>
	[OpenEhrName("CARDINALITY")]
	public class Cardinality
	{
		/// <summary>
		/// True if the members of the container attribute to which this cardinality refers are ordered.
		/// </summary>
		[OpenEhrName("is_ordered")]
		public bool IsOrdered { get; set; }

		/// <summary>
		/// True if the members of the container attribute to which this cardinality refers are unique.
		/// </summary>
		[OpenEhrName("is_unique")]
		public bool IsUnique { get; set; }

		/// <summary>
		/// The interval of this cardinality
		/// </summary>
		[OpenEhrName("interval")]
		public Interval<int> Interval { get; set; }

		/// <summary>
		/// True if the semantics of this cardinality represent a bag, i.e. unordered, non-unique membership.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_bag")]
		public bool IsBag()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if the semantics of this cardinality represent a list, i.e. ordered, non-unique membership.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_list")]
		public bool IsList()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if the semantics of this cardinality represent a set, i.e. unordered, unique membership.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_set")]
		public bool IsSet()
		{
			throw new NotImplementedException();
		}
	}
}
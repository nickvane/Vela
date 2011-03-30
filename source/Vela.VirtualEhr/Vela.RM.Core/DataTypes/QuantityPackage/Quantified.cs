//-----------------------------------------------------------------------
// <copyright file="Quantified.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	///<summary>
	/// Abstract class defining the concept of true quantified values, i.e. values which are not only ordered, but which have a precise magnitude.
	///</summary>
	[Serializable, OpenEhrName("DV_QUANTIFIED")]
	public abstract class Quantified<T> : Ordered<T> where T : Ordered<T>
	{
		private readonly IList<string> _magnitudeStatusList = new List<string> {"=", "<", ">", "<=", ">=", "~"};
		private string _magnitudeStatus;

		/// <summary>
		/// Numeric value of the quantity in canonical (i.e. single value) form. Implemented as constant, function or attribute in subtypes as appropriate. The type Ordered_numeric is mapped to the available appropriate type in each implementation technology.
		/// </summary>
		[OpenEhrName("magnitude")]
		public abstract double Magnitude { get; set; }

		///<summary>
		/// Optional status of magnitude with values:
		/// • “=” : magnitude is a point value
		/// • “&lt;“ : value is &lt; magnitude 
		/// • “>” : value is > magnitude 
		/// • “&lt;=” : value is &lt;= magnitude 
		/// • “>=” : value is >= magnitude 
		/// • “~” : value is approximately magnitude
		/// If not present, meaning is “=”.
		///</summary>
		[OpenEhrName("magnitude_status")]
		public string MagnitudeStatus
		{
			get { return _magnitudeStatus; }
			set { _magnitudeStatus = _magnitudeStatusList.Contains(value) ? value : "="; }
		}
	}
}
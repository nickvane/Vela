//-----------------------------------------------------------------------
// <copyright file="IntervalEvent.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Core.DataStructures.HistoryPackage
{
	/// <summary>
	/// Defines a single interval event in a series.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("INTERVAL_EVENT <T: ITEM_STRUCTURE>")]
	public class IntervalEvent<T> : Event<T> where T : ItemStructure
	{
		/// <summary>
		/// Length of the interval during which the state was true. Void if an instantaneous event.
		/// </summary>
		[OpenEhrName("width")]
		public Duration Width
		{
			get;
			set;
		}

		/// <summary>
		/// Mathematical function of the data of this event, e.g. “maximum”, “mean” etc. Coded using openEHR Terminology group “event math function”.
		/// </summary>
		[OpenEhrName("math_function")]
		public CodedText MathFunction
		{
			get;
			set;
		}

		/// <summary>
		/// Optional count of original samples to which this event corresponds.
		/// </summary>
		[OpenEhrName("sample_count")]
		public int SampleCount
		{
			get;
			set;
		}

		/// <summary>
		/// Start time of the interval of this event.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("interval_start_time")]
		public DateTime GetIntervalStartTime()
		{
			throw new NotImplementedException();
		}
	}
}
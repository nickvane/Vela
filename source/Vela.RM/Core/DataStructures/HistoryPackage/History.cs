using System;
using System.Collections.Generic;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Core.DataStructures.HistoryPackage
{
	/// <summary>
	/// Root object of a linear history, i.e. time series structure. For a periodic series of events, period will be set, and the time of each Event in the History must correspond; i.e. the <see cref="Event{T}"/>.offset must be a multiple of period for each Event. Missing events in a period History are however allowed.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("HISTORY<T: ITEM_STRUCTURE>")]
	public class History<T> : DataStructure where T : ItemStructure
	{
		/// <summary>
		/// The events in the series.
		/// </summary>
		[OpenEhrName("events")]
		public IList<Event<T>> Events
		{
			get;
			set;
		}

		/// <summary>
		/// Time origin of this event history. The first event is not necessarily at the origin point.
		/// </summary>
		[OpenEhrName("origin")]
		public DateTime Origin
		{
			get;
			set;
		}

		/// <summary>
		/// Period between samples in this segment if periodic.
		/// </summary>
		[OpenEhrName("period")]
		public Duration Period
		{
			get;
			set;
		}

		/// <summary>
		/// Duration of the entire History; either corresponds to the duration of all the events, and/or the duration represented by the summary, if it exists.
		/// </summary>
		[OpenEhrName("duration")]
		public Duration Duration
		{
			get;
			set;
		}

		/// <summary>
		/// Optional summary data expressing e.g. text or image which summarises entire History.
		/// </summary>
		[OpenEhrName("summary")]
		public ItemStructure Summary
		{
			get;
			set;
		}

		/// <summary>
		/// Indicates whether history is periodic.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("is_periodic")]
		public bool IsPeriodic()
		{
			throw new NotImplementedException();
		}
	}
}

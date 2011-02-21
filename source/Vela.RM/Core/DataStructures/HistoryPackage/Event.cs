using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ArchetypedPackage;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Core.DataStructures.HistoryPackage
{
	/// <summary>
	/// Defines the abstract notion of a single event in a series. This class is generic, allowing types to be generated which are locked to particular spatial types, such as EVENT<ITEM_LIST>. Subtypes express point or intveral data.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("EVENT <T: ITEM_STRUCTURE>")]
	public abstract class Event<T> : Locatable where T : ItemStructure
	{
		/// <summary>
		/// Time of this event. If the width is non-zero, it is the time point of the trailing edge of the event.
		/// </summary>
		[OpenEhrName("time")]
		public DateTime Time
		{
			get;
			set;
		}

		/// <summary>
		/// The data of this event.
		/// </summary>
		[OpenEhrName("data")]
		public T Data
		{
			get;
			set;
		}

		/// <summary>
		/// Optional state data for this event.
		/// </summary>
		[OpenEhrName("state")]
		public ItemStructure State
		{
			get;
			set;
		}

		/// <summary>
		/// Redefinition of PATHABLE.parent to be of type HISTORY.
		/// </summary>
		[OpenEhrName("parent")]
		public new History<T> Parent
		{
			get;
			set;
		}

		/// <summary>
		/// Offset of this event from origin, computed as time.diff(parent.origin)
		/// </summary>
		[OpenEhrName("offset")]
		public Duration Offset
		{
			get;
			set;
		}
	}
}

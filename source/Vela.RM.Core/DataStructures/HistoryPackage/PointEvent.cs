using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.HistoryPackage
{
	/// <summary>
	/// Defines a single point event in a series.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("POINT_EVENT <T: ITEM_STRUCTURE>")]
	public class PointEvent<T> : Event<T> where T : ItemStructure
	{
	}
}

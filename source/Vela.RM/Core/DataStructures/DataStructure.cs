using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures
{
	/// <summary>
	/// Abstract parent class of all data structure types. Includes the as_hierarchy function which can generate the equivalent CEN EN13606 single hierarchy for each subtype’s physical representation. For example, the physical representation of an ITEM_LIST is List<ELEMENT>; its implementation of as_hierarchy will generate a CLUSTER containing the set of ELEMENT nodes from the list.
	/// </summary>
	[Serializable, OpenEhrName("DATA_STRUCTURE")]
	public abstract class DataStructure //: Locatable
	{
	}
}

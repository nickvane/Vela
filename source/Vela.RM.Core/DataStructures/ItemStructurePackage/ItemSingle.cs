using System;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.ItemStructurePackage
{
	/// <summary>
	/// Logical single value data structure.
	/// Used to represent any data which is logically a single value, such as a person’s height or weight.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM_SINGLE")]
	public class ItemSingle : ItemStructure
	{
		/// <summary>
		/// 
		/// </summary>
		[OpenEhrName("item")]
		public Element Item { get; set; }
	}
}

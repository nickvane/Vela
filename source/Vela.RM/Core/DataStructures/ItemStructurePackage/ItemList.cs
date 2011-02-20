using System;
using System.Linq;
using System.Collections.Generic;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.ItemStructurePackage
{
	/// <summary>
	/// Logical list data structure, where each item has a value and can be referred to by a name and a positional index in the list. The list may be empty.
	/// Used to represent any data which is logically a list of values, such as blood pressure, most protocols, many blood tests etc.
	/// Not to be used for time-based lists, which should be represented with the proper temporal class, i.e. <see cref="History{T}"/>.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM_LIST")]
	public class ItemList : ItemStructure
	{
		private IList<Element> _items;

		/// <summary>
		/// Physical representation of the list.
		/// </summary>
		[OpenEhrName("items")]
		public IList<Element> Items { get
		{
			return _items ?? (_items = new List<Element>());
		}
			set { _items = value; }
		}

		/// <summary>
		/// Retrieve the names of all items
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("names")]
		public IList<Text> GetNames()
		{
			return (from e in Items select e.Name).ToList();
		}

		/// <summary>
		/// Retrieve the item with name ‘a_name’
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("named_item")]
		public Element GetNamedItem(string path)
		{
			return (from e in Items where e.Name.Value == path select e).First();
		}
	}
}

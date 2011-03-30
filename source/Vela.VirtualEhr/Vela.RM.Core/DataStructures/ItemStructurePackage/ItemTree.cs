//-----------------------------------------------------------------------
// <copyright file="ItemTree.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.ItemStructurePackage
{
	/// <summary>
	/// Logical tree data structure. The tree may be empty.
	/// USE: Used to represent data which are logically a tree such as audiology results, microbiology results, biochemistry results.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM_TREE")]
	public class ItemTree : ItemStructure
	{
		private IList<ItemList> _items;

		/// <summary>
		/// Physical representation of the tree.
		/// </summary>
		[OpenEhrName("items")]
		public IList<ItemList> Items
		{
			get
			{
				return _items ?? (_items = new List<ItemList>());
			}
			set
			{
				_items = value;
			}
		}

		/// <summary>
		/// True if path ‘a_path’ is a valid leaf path
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[OpenEhrName("has_element_path")]
		public bool HasElementAtPath(string path)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Return the leaf element at the path ‘a_path’
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[OpenEhrName("element_at_path")]
		public Element GetElementAtPath(string path)
		{
			if (!HasElementAtPath(path)) return null;
			throw new NotImplementedException();
		}
	}
}
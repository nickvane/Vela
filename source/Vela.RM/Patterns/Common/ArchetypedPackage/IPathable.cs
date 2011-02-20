using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Patterns.Common.ArchetypedPackage
{
	///<summary>
	/// Abstract parent of all classes whose instances are reachable by paths, and which know how to locate child object by paths. The  parent feature may be implemented as a function or attribute.
	///</summary>
	[OpenEhrName("PATHABLE")]
	public interface IPathable
	{
		///<summary>
		/// Parent of this node in compositional hierarchy.
		///</summary>
		[OpenEhrName("parent")]
		IPathable Parent { get; set; }

		///<summary>
		/// The path to an item relative to the root of this archetyped structure.
		///</summary>
		///<param name="item"></param>
		///<returns></returns>
		[OpenEhrName("path_of_item")]
		string GetPathOfItem(IPathable item);

		///<summary>
		/// The item at a path (relative to this item); only valid for unique paths, i.e. paths that resolve to a single item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("item_at_path")]
		object GetItemAtPath(string path);

		///<summary>
		/// List of items corresponding to a non-unique path.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("items_at_path")]
		List<Object> GetItemsAtPath(string path);

		///<summary>
		/// True if the path exists in the data with respect to the current item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("path_exists")]
		bool DoesPathExists(string path);

		///<summary>
		/// True if the path corresponds to a single item in the data.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		[OpenEhrName("path_unique")]
		bool IsPathUnique(string path);
	}
}

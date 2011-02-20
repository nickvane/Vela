using System;
using System.Collections.Generic;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.ItemStructurePackage
{
	/// <summary>
	/// Logical relational database  style table data structure, in which columns are named and ordered with respect to each other. Implemented using Cluster-per-row encoding. Each row Cluster must have an identical number of Elements, each of which in turn must have identical names and value types in the corresponding postions in each row. 
	/// Some columns may be designated ‘key’ columns, containing key data for each row, in the manner of relational tables. This allows row-naming, where each row represents a body site, a blood antigen etc. All values in a column have the same data type.
	/// Used to represent any data which is logically a table of values, such as blood pressure, most protocols, many blood tests etc.
	/// Not used for time-based data, which should be represented with the temporal class <see cref="History{T}"/>. The table may be empty.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM_TABLE")]
	public class ItemTable : ItemStructure
	{
		/// <summary>
		/// Physical representation of the table as a list of Clusters, each containing the data of one row of the table.
		/// </summary>
		[OpenEhrName("rows")]
		public List<Cluster> Rows { get; set; }

		//TODO: add functions from specification
	}
}

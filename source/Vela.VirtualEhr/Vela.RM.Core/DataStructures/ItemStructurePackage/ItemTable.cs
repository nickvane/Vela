//-----------------------------------------------------------------------
// <copyright file="ItemTable.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Vela.RM.Core.DataStructures.HistoryPackage;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.DataTypes.TextPackage;
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
		private IList<Cluster> _rows;

		/// <summary>
		/// Physical representation of the table as a list of Clusters, each containing the data of one row of the table.
		/// </summary>
		[OpenEhrName("rows")]
		public IList<Cluster> Rows
		{
			get
			{
				return _rows ?? (_rows = new List<Cluster>());
			}
			set
			{
				_rows = value;
			}
		}

		/// <summary>
		/// Return the number of rows
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("row_count")]
		public int GetRowCount()
		{
			return Rows.Count;
		}

		/// <summary>
		/// Return the number of columns
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("column_count")]
		public int GetColumnCount()
		{
			return GetColumnNames().Count;
		}

		/// <summary>
		/// Return the row names
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("row_names")]
		public IList<Text> GetRowNames()
		{
			return (from r in Rows
					select new Text(((CodedText)((Element)r.Items[0]).Value).Value)).ToList();
		}

		/// <summary>
		/// Return the column names
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("column_names")]
		public IList<Text> GetColumnNames()
		{
			if (Rows.Count > 0)
				return (from e in Rows[0].Items
						select new Text(e.Name.Value)).ToList();
			return new List<Text>();
		}

		/// <summary>
		/// True if there is a row whose first column has the name ‘a_key’
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("has_row_with_name")]
		public bool HasRowWithName(string name)
		{
			return GetRowNames().Select(n => n.Value).Contains(name);
		}

		/// <summary>
		/// True if there is a column with name ‘a_key’
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("has_column_with_name")]
		public bool HasColumnWithName(string name)
		{
			return GetColumnNames().Select(n => n.Value).Contains(name);
		}

		/// <summary>
		/// Return the row whose first column has the name ‘a_key’
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("named_row")]
		public Cluster GetNamedRow(string name)
		{
			if (HasRowWithName(name))
			{
				return (from r in Rows
				        where ((CodedText) ((Element) r.Items[0]).Value).Value == name
				        select r).First();
			}
			return null;
		}

		/// <summary>
		/// True if there is a row whose first n columns have the names in ‘keys’
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		[OpenEhrName("has_row_with_key")]
		public bool HasRowWithKeys(IList<string> keys)
		{
			return GetRowWithKeys(keys) != null;
		}

		/// <summary>
		/// Return the row whose first n columns have names equal to the values in ‘keys’
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		[OpenEhrName("row_with_key")]
		public Cluster GetRowWithKeys(IList<string> keys)
		{
			if (keys == null) return null;
			if (keys.Count > GetColumnCount()) return null;

			var hasRow = true;
			Cluster row = null;
			foreach (var r in Rows)
			{
				for (var i = 0; i < keys.Count(); i++)
				{
					if (((Element)r.Items[i]).Value is CodedText)
					{
						if (((CodedText)(((Element)r.Items[i]).Value)).Value == keys[i])
						{
							hasRow &= true;
						}
						else
						{
							hasRow &= false;
							break;
						}
					}
					else
					{
						hasRow &= false;
						break;
					}
				}
				if (!hasRow) continue;
				row = r;
				break;
			}
			return row;
		}

		/// <summary>
		/// Return the element at the column i, row j.
		/// </summary>
		/// <param name="columnIndex"></param>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		[OpenEhrName("element_at_cell_ij")]
		public Element GetElementAtCell(int columnIndex, int rowIndex)
		{
			if (columnIndex < 1 | rowIndex < 1) return null;
			if (rowIndex > GetRowCount() | columnIndex > GetColumnCount()) return null;
			return (Element) Rows[rowIndex - 1].Items[columnIndex - 1];
		}

		/// <summary>
		/// Return the element at the row whose first column has the name ‘row_key’ and column has the name ‘col_key’
		/// </summary>
		/// <param name="rowKey"></param>
		/// <param name="columnKey"></param>
		/// <returns></returns>
		[OpenEhrName("element_at_named_cell")]
		public Element GetElementAtNamedCell(string rowKey, string columnKey)
		{
			if (HasRowWithName(rowKey) & HasColumnWithName(columnKey))
			{
				var row = GetNamedRow(rowKey);
				return (from e in row.Items where ((Element)e).Name.Value == columnKey select e as Element).First();
			}
			return null;
		}
	}
}
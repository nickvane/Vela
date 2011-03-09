//-----------------------------------------------------------------------
// <copyright file="ItemTableTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataStructures.RepresentationPackage;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Text = Vela.RM.Core.DataTypes.TextPackage.Text;

namespace Vela.RM.Core.UnitTests.DataStructures.ItemStructurePackage
{
	[TestFixture]
	public class WhenUsingItemTable
	{
		private ItemTable _table;
		const string Eyes = "eye(s)";
		const string Visual = "visual acuity";
		const string Right = "right";
		const string Left = "left";
		const string Both = "both";

		[TestFixtureSetUp]
		public void Setup()
		{
			_table = new ItemTable();
			var cluster1 = new Cluster
			{
				Name = new Text("1")
			};
			var element11 = new Element
			{
				Name = new Text(Eyes),
				Value = new CodedText(Right)
			};
			cluster1.Items.Add(element11);
			var element12 = new Element
			{
				Name = new Text(Visual),
				Value = new Ordinal(1)
			};
			cluster1.Items.Add(element12);
			_table.Rows.Add(cluster1);

			var cluster2 = new Cluster
			{
				Name = new Text("2")
			};
			var element21 = new Element
			{
				Name = new Text(Eyes),
				Value = new CodedText(Left)
			};
			cluster2.Items.Add(element21);
			var element22 = new Element
			{
				Name = new Text(Visual),
				Value = new Ordinal(2)
			};
			cluster2.Items.Add(element22);
			_table.Rows.Add(cluster2);

			var cluster3 = new Cluster
			{
				Name = new Text("3")
			};
			var element31 = new Element
			{
				Name = new Text(Eyes),
				Value = new CodedText(Both)
			};
			cluster3.Items.Add(element31);
			var element32 = new Element
			{
				Name = new Text(Visual),
				Value = new Ordinal(3)
			};
			cluster3.Items.Add(element32);

			_table.Rows.Add(cluster3);
		}

		[Test]
		public void RowCountMethodShouldWork()
		{
			Assert.AreEqual(3, _table.GetRowCount());
			var table2 = new ItemTable
			{
				Rows = new List<Cluster>()
			};
			Assert.AreEqual(0, table2.GetRowCount());
		}

		[Test]
		public void ColumnCountMethodShouldWork()
		{
			Assert.AreEqual(2, _table.GetColumnCount());
			Assert.AreEqual(0, new ItemTable().GetColumnCount());
		}

		[Test]
		public void RowNamesMethodShouldWork()
		{
			var names = from n in _table.GetRowNames()
						select n.Value;
			Assert.AreEqual(3, names.Count());
			Assert.IsTrue(names.Contains(Left));
			Assert.IsTrue(names.Contains(Right));
			Assert.IsTrue(names.Contains(Both));
			Assert.AreEqual(0, new ItemTable().GetRowNames().Count);
		}

		[Test]
		public void ColumnNamesMethodShouldWork()
		{
			var names = from n in _table.GetColumnNames()
						select n.Value;
			Assert.AreEqual(2, names.Count());
			Assert.IsTrue(names.Contains(Eyes));
			Assert.IsTrue(names.Contains(Visual));
			Assert.AreEqual(0, new ItemTable().GetColumnNames().Count);
		}

		[Test]
		public void HasRowWithNameMethodShouldWork()
		{
			Assert.IsTrue(_table.HasRowWithName(Left));
			Assert.IsFalse(_table.HasRowWithName("foo"));
		}

		[Test]
		public void HasColumnWithNameMethodShouldWork()
		{
			Assert.IsTrue(_table.HasColumnWithName(Eyes));
			Assert.IsFalse(_table.HasColumnWithName("foo"));
		}

		[Test]
		public void GetNamedRowMethodShouldWork()
		{
			Assert.IsNull(_table.GetNamedRow("foo"));
			Assert.IsNotNull(_table.GetNamedRow(Right));
			Assert.AreEqual(Both, ((CodedText)((Element)_table.GetNamedRow(Both).Items[0]).Value).Value);
		}

		[Test]
		public void HasRowWithKeysMethodShouldWork()
		{
			Assert.IsFalse(_table.HasRowWithKeys(new List<string> { "foo" }));
			Assert.IsTrue(_table.HasRowWithKeys(new List<string> { Right }));
			Assert.IsFalse(_table.HasRowWithKeys(new List<string> { Right, "foo" }));
			Assert.IsFalse(_table.HasRowWithKeys(new List<string> { Right, "foo", "boo" }));
		}

		[Test]
		public void GetRowWithKeysMethodShouldWork()
		{
			Assert.IsNull(_table.GetRowWithKeys(null));
			Assert.IsNull(_table.GetRowWithKeys(new List<string> { "foo" }));
			Assert.IsNull(_table.GetRowWithKeys(new List<string> { Right, "foo" }));
			Assert.IsNull(_table.GetRowWithKeys(new List<string> { Right, "foo", "boo" }));
			Assert.IsNotNull(_table.GetRowWithKeys(new List<string> { Right }));
		}

		[Test]
		public void GetElementAtCellMethodShouldWork()
		{
			Assert.IsNull(_table.GetElementAtCell(0, 0));
			Assert.IsNull(_table.GetElementAtCell(0, 1));
			Assert.IsNull(_table.GetElementAtCell(1, 0));
			Assert.IsNotNull(_table.GetElementAtCell(1, 1));
			Assert.IsNull(_table.GetElementAtCell(3, 1));
			Assert.IsNull(_table.GetElementAtCell(1, 4));
			Assert.IsNull(_table.GetElementAtCell(3, 4));
			Assert.AreEqual(Right, ((CodedText)_table.GetElementAtCell(1, 1).Value).Value);
			Assert.AreEqual(3, ((Ordinal)_table.GetElementAtCell(2, 3).Value).Value);
		}

		[Test]
		public void GetElementAtNamedCellMethodShouldWork()
		{
			Assert.IsNull(_table.GetElementAtNamedCell("foo", "foo"));
			Assert.IsNull(_table.GetElementAtNamedCell("foo", Eyes));
			Assert.IsNull(_table.GetElementAtNamedCell(Right, "foo"));
			Assert.IsNotNull(_table.GetElementAtNamedCell(Right, Eyes));
			Assert.AreEqual(Right, ((CodedText)_table.GetElementAtNamedCell(Right, Eyes).Value).Value);
			Assert.AreEqual(3, ((Ordinal)_table.GetElementAtNamedCell(Both, Visual).Value).Value);
		}
	}
}
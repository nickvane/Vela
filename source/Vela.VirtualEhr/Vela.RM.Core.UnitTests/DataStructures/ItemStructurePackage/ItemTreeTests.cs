//-----------------------------------------------------------------------
// <copyright file="ItemTreeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.ItemStructurePackage;

namespace Vela.RM.Core.UnitTests.DataStructures.ItemStructurePackage
{
	[TestFixture]
	public class WhenUsingItemTree
	{
		[Test]
		public void DefaulPropertiesAndFunctionsShouldWork()
		{
			var tree = new ItemTree();
			Assert.IsNotNull(tree.Items);
			tree.Items = new List<ItemList>();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasElementAtPathShouldThrowException()
		{
			var tree = new ItemTree();
			var hasElement = tree.HasElementAtPath("");
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetElementAtPathShouldThrowException()
		{
			var tree = new ItemTree();
			var element = tree.GetElementAtPath("");
		}
	}
}
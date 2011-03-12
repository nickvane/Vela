//-----------------------------------------------------------------------
// <copyright file="HistoryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.HistoryPackage;
using Vela.RM.Core.DataStructures.ItemStructurePackage;

namespace Vela.RM.Core.UnitTests.DataStructures.HistoryPackage
{
	[TestFixture]
	public class WhenUsingHistory
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPeriodicShouldThrowException()
		{
			var history = new History<ItemStructureTest>();
			var isPeriodic = history.IsPeriodic();
		}
	}

	public class ItemStructureTest : ItemStructure
	{
		
	}
}
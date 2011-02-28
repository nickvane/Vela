using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.HistoryPackage;
using Vela.RM.Core.DataStructures.ItemStructurePackage;

namespace Vela.RM.UnitTests.Core.DataStructures.HistoryPackage
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

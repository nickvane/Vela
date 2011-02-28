using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.HistoryPackage;

namespace Vela.RM.UnitTests.Core.DataStructures.HistoryPackage
{
	[TestFixture]
	public class WhenUsingIntervalEvent
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPeriodicShouldThrowException()
		{
			var history = new IntervalEvent<ItemStructureTest>();
			var startTime = history.GetIntervalStartTime();
		}
	}
}

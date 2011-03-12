//-----------------------------------------------------------------------
// <copyright file="IntervalEventTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.HistoryPackage;

namespace Vela.RM.Core.UnitTests.DataStructures.HistoryPackage
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
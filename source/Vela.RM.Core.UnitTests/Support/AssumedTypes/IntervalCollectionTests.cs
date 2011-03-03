
using System;
using NUnit.Framework;
using Vela.RM.Core.Support.AssumedTypes;

namespace Vela.RM.Unittests.Core.Support.AssumedTypes
{
	[TestFixture]
	public class WhenUsingIntervalCollection
	{
		[Test]
		public void PropertiesShouldBeSet()
		{
			int lower = 2;
			int upper = 8;
			var interval = new IntervalCollection<int>(lower, upper);
			Assert.AreEqual(lower, interval.Lower);
			Assert.AreEqual(upper, interval.Upper);
			Assert.IsFalse(interval.IsLowerUnbounded);
			Assert.IsFalse(interval.IsUpperUnbounded);
		}
	}
}

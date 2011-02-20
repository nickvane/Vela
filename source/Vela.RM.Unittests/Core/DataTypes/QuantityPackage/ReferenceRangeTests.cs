﻿using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Unittests.Core.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingReferenceRange
	{
		[Test]
		public void DefaultPropertiesShouldBeCorrect()
		{
			var referenceRange = new ReferenceRange<OrderedTest>();
			Assert.IsNotNull(referenceRange.Range);
			var range = new Interval<OrderedTest>();
			referenceRange.Range = range;
			var orderedTest = new OrderedTest();
			Assert.AreEqual(range.HasElement(orderedTest), referenceRange.IsInRange(orderedTest));
		}
	}
}

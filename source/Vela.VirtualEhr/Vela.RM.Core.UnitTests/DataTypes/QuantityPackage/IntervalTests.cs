//-----------------------------------------------------------------------
// <copyright file="IntervalTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingInterval
	{
		[Test]
		public void BoundsShouldBeCorrectForReferenceType()
		{
			var interval = new Interval<OrderedTest>();
			Assert.IsTrue(interval.IsLowerUnbounded);
			Assert.IsTrue(interval.IsUpperUnbounded);
			Assert.IsFalse(interval.IsLowerIncluded);
			Assert.IsFalse(interval.IsUpperIncluded);
			Assert.IsTrue(interval.HasElement(new OrderedTest(){Value = 5}));
			Assert.IsTrue(interval.HasElement(new OrderedTest() { Value = 1 }));

			interval.IsLowerIncluded = true;
			interval.IsUpperIncluded = true;
			Assert.IsFalse(interval.IsLowerIncluded);
			Assert.IsFalse(interval.IsUpperIncluded);
			interval.Lower = new OrderedTest() { Value = 2 };
			interval.Upper = new OrderedTest() { Value = 4 };
			Assert.IsTrue(interval.IsLowerIncluded);
			Assert.IsTrue(interval.IsUpperIncluded);
			Assert.IsTrue(interval.HasElement(new OrderedTest() { Value = 2 }));
			Assert.IsTrue(interval.HasElement(new OrderedTest() { Value = 4 }));

			interval.IsLowerIncluded = false;
			interval.IsUpperIncluded = false;
			Assert.IsFalse(interval.HasElement(new OrderedTest() { Value = 2 }));
			Assert.IsFalse(interval.HasElement(new OrderedTest() { Value = 4 }));
			Assert.IsFalse(interval.HasElement(null));
		}

		[Test]
		public void BoundsShouldBeCorrectForValueType()
		{
			var interval = new Interval<int>();
			Assert.IsTrue(interval.IsLowerUnbounded);
			Assert.IsTrue(interval.IsUpperUnbounded);
			Assert.IsFalse(interval.IsLowerIncluded);
			Assert.IsFalse(interval.IsUpperIncluded);
			Assert.IsTrue(interval.HasElement(5));
			Assert.IsTrue(interval.HasElement(1));

			interval.IsLowerIncluded = true;
			interval.IsUpperIncluded = true;
			Assert.IsFalse(interval.IsLowerIncluded);
			Assert.IsFalse(interval.IsUpperIncluded);
			interval.Lower = 2;
			interval.Upper = 4;
			Assert.IsTrue(interval.IsLowerIncluded);
			Assert.IsTrue(interval.IsUpperIncluded);
			Assert.IsTrue(interval.HasElement(2));
			Assert.IsTrue(interval.HasElement(4));

			interval.IsLowerIncluded = false;
			interval.IsUpperIncluded = false;
			Assert.IsFalse(interval.HasElement(2));
			Assert.IsFalse(interval.HasElement(4));

			interval = new Interval<int> {Lower = -2, Upper = 2};
			Assert.IsTrue(interval.HasElement(0));
		}
	}
}
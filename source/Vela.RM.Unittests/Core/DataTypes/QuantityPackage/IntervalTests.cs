using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.UnitTests.Core.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingInterval
	{
		[Test]
		public void BoundsShouldBeCorrect()
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
		}
	}
}
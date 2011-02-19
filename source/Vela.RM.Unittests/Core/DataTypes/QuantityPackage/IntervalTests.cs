using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Unittests.Core.DataTypes.QuantityPackage
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
			Assert.IsTrue(interval.HasElement(new OrderedTest(5)));
			Assert.IsTrue(interval.HasElement(new OrderedTest(1)));

			interval.IsLowerIncluded = true;
			interval.IsUpperIncluded = true;
			Assert.IsFalse(interval.IsLowerIncluded);
			Assert.IsFalse(interval.IsUpperIncluded);
			interval.Lower = new OrderedTest(2);
			interval.Upper = new OrderedTest(4);
			Assert.IsTrue(interval.IsLowerIncluded);
			Assert.IsTrue(interval.IsUpperIncluded);
			Assert.IsTrue(interval.HasElement(new OrderedTest(2)));
			Assert.IsTrue(interval.HasElement(new OrderedTest(4)));

			interval.IsLowerIncluded = false;
			interval.IsUpperIncluded = false;
			Assert.IsFalse(interval.HasElement(new OrderedTest(2)));
			Assert.IsFalse(interval.HasElement(new OrderedTest(4)));
		}
	}

	public class OrderedTest : Ordered<OrderedTest>
	{
		public int Value;

		public OrderedTest(int value)
		{
			Value = value;
		}

		public override int CompareTo(OrderedTest other)
		{
			if (Value == other.Value) return 0;
			if (Value < other.Value) return -1;
			return 1;
		}
	}
}
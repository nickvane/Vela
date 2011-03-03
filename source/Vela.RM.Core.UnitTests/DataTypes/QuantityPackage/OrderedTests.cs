using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingOrderedAsBaseClass
	{
		[Test]
		public void CompareAndEqualityShouldWork()
		{
			var ordered1 = new OrderedTest() { Value = 1 };
			var ordered2 = new OrderedTest() { Value = 2 };
			var ordered3 = new OrderedTest() { Value = 2 };
			OrderedTest ordered4 = null;
			OrderedTest ordered5 = null;

			//equality
			Assert.IsTrue(ordered2 == ordered3);
			Assert.IsTrue(ordered3 == ordered2);
			Assert.IsFalse(ordered2 != ordered3);
			Assert.IsFalse(ordered3 != ordered2);
			Assert.IsTrue(ordered4 == ordered5);
			Assert.IsTrue(ordered5 == ordered4);
			Assert.IsFalse(ordered4 != ordered5);
			Assert.IsFalse(ordered5 != ordered4);
			Assert.IsFalse(ordered4 == ordered1);
			Assert.IsTrue(ordered4 != ordered1);
			Assert.IsTrue(ordered2.Equals(ordered3 as object));
			Assert.IsTrue(ordered2.Equals(ordered2 as object));
			Assert.IsFalse(ordered2.Equals(ordered4 as object));
			Assert.IsFalse(ordered2.Equals(Guid.NewGuid()));

			//compare
			Assert.IsTrue(ordered1 < ordered2);
			Assert.IsFalse(ordered1 > ordered2);
			Assert.IsFalse(ordered2 < ordered1);
			Assert.IsTrue(ordered2 > ordered1);
			Assert.IsTrue(ordered1 <= ordered2);
			Assert.IsFalse(ordered1 >= ordered2);
			Assert.IsFalse(ordered2 <= ordered1);
			Assert.IsTrue(ordered2 >= ordered1);
			Assert.IsTrue(ordered2 <= ordered3);
			Assert.IsTrue(ordered2 >= ordered3);
			Assert.IsTrue(ordered3 <= ordered2);
			Assert.IsTrue(ordered3 >= ordered2);
			Assert.IsTrue(ordered1 > ordered4);

			var ordered6 = new OrderedNotStrictlyComparableTest() { Value = 1 };
			var ordered7 = new OrderedNotStrictlyComparableTest() { Value = 1 };
			Assert.IsFalse(ordered6 == ordered7);
		}

		[Test]
		public void DefaultPropertiesShouldWorkCorrectly()
		{
			var ordered1 = new OrderedTest(){Value = 1};
			Assert.IsTrue(ordered1.IsSimple());
			Assert.IsTrue(ordered1.IsStrictlyComparableTo(null));
			Assert.IsTrue(ordered1.IsNormal());
			var interval1 = new Interval<OrderedTest>();
			ordered1.NormalRange = interval1;
			Assert.AreEqual(interval1.HasElement(ordered1), ordered1.IsNormal());
			var hash = ordered1.GetHashCode();
		}
	}

	public class OrderedTest : Ordered<OrderedTest>
	{
		public int Value;

		public override int CompareTo(OrderedTest other)
		{
			if (Value == other.Value) return 0;
			if (Value < other.Value) return -1;
			return 1;
		}
	}

	public class OrderedNotStrictlyComparableTest : Ordered<OrderedNotStrictlyComparableTest>
	{
		public int Value;

		public override bool IsStrictlyComparableTo(OrderedNotStrictlyComparableTest other)
		{
			return false;
		}

		public override int CompareTo(OrderedNotStrictlyComparableTest other)
		{
			if (Value == other.Value) return 0;
			if (Value < other.Value) return -1;
			return 1;
		}
	}
}

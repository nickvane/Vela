using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingCount
	{
		[Test]
		public void DefaultPropertiesShouldBeSet()
		{
			const double magnitude = 3;
			var count1 = new Count();
			count1.Magnitude = magnitude;
			Assert.AreEqual(magnitude, count1.Magnitude);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void SettingMagnitudeWithDoubleShouldThrowException()
		{
			var count1 = new Count();
			count1.Magnitude = 2.5;
		}

		[Test]
		public void CompareShouldbeCorrect()
		{
			var quantity1 = new Count() { Magnitude = 1 };
			var quantity2 = new Count() { Magnitude = 2 };
			var quantity3 = new Count() { Magnitude = 2 };

			Assert.AreEqual(0, quantity2.CompareTo(quantity3));
			Assert.AreEqual(-1, quantity1.CompareTo(quantity2));
			Assert.AreEqual(1, quantity2.CompareTo(quantity1));
		}
	}
}

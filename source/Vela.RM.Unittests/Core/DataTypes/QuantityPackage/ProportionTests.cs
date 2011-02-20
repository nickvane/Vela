using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Unittests.Core.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingProportion
	{
		[Test]
		public void DefaultPropertiesShouldBeSet()
		{
			var proportion1 = new Proportion();
			Assert.IsTrue(proportion1.IsIntegral());
			Assert.AreEqual(ProportionKind.Ratio, proportion1.Type);
			Assert.AreEqual(0, proportion1.Magnitude);
			const int precision = 2;
			proportion1.Precision = precision;
			Assert.AreEqual(precision, proportion1.Precision);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void SettingMagnitudeShouldThrowException()
		{
			var proportion1 = new Proportion();
			proportion1.Magnitude = 2;
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void PrecisionCannotBeLessThanMinusOne()
		{
			var proportion1 = new Proportion();
			proportion1.Precision = -2;
		}

		[Test]
		public void CompareShouldbeCorrect()
		{
			var quantity1 = new Proportion() { Numerator = 1, Denominator = 1};
			var quantity2 = new Proportion() { Numerator = 2, Denominator = 1 };
			var quantity3 = new Proportion() { Numerator = 2, Denominator = 1 };

			Assert.AreEqual(0, quantity2.CompareTo(quantity3));
			Assert.AreEqual(-1, quantity1.CompareTo(quantity2));
			Assert.AreEqual(1, quantity2.CompareTo(quantity1));
		}
	}
}

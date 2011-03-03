using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingAmount
	{
		[Test]
		public void DefaultPropertiesShouldBeSet()
		{
			var amount1 = new AmountTest();
			Assert.IsTrue(amount1.IsAccuracyUnknown());
			var accuracy = 2.5;
			amount1.Accuracy = accuracy;
			Assert.AreEqual(accuracy, amount1.Accuracy);
			Assert.IsFalse(amount1.IsAccuracyUnknown());
		}

		[Test]
		public void ShouldCheckvalidPercentages()
		{
			Assert.IsTrue(AmountTest.IsValidPercentage(0.2));
			Assert.IsTrue(AmountTest.IsValidPercentage(0));
			Assert.IsTrue(AmountTest.IsValidPercentage(100));
			Assert.IsTrue(AmountTest.IsValidPercentage(89.523));
			Assert.IsFalse(AmountTest.IsValidPercentage(-1));
			Assert.IsFalse(AmountTest.IsValidPercentage(101));
		}
	}

	public class AmountTest : Amount<AmountTest>
	{
		public override int CompareTo(AmountTest other)
		{
			throw new NotImplementedException();
		}

		public override double Magnitude
		{
			get; set; }
	}
}

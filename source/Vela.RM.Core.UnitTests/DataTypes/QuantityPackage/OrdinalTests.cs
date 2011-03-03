using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingOrdinal
	{
		[Test]
		public void DefaultPropertiesShouldBeCorrect()
		{
			var ordinal1 = new Ordinal(0);
			Assert.IsNotNull(ordinal1.GetLimits());
			Ordinal ordinal2 = null;
			var ordinal3 = new Ordinal(0);
			Assert.IsFalse(ordinal1.IsStrictlyComparableTo(ordinal2));
			Assert.IsTrue(ordinal1.IsStrictlyComparableTo(ordinal3));
		}

		[Test]
		public void CompareShouldbeCorrect()
		{
			var ordinal1 = new Ordinal(1);
			var ordinal2 = new Ordinal(2);
			var ordinal3 = new Ordinal(2);

			Assert.AreEqual(0, ordinal2.CompareTo(ordinal3));
			Assert.AreEqual(-1, ordinal1.CompareTo(ordinal2));
			Assert.AreEqual(1, ordinal2.CompareTo(ordinal1));
		}
	}
}

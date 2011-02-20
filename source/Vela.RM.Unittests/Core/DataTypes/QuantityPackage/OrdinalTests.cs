using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Unittests.Core.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingOrdinal
	{
		[Test]
		public void DefaultPropertiesShouldBeCorrect()
		{
			var ordinal1 = new Ordinal();
			Assert.IsNotNull(ordinal1.GetLimits());
			Ordinal ordinal2 = null;
			var ordinal3 = new Ordinal();
			Assert.IsFalse(ordinal1.IsStrictlyComparableTo(ordinal2));
			Assert.IsTrue(ordinal1.IsStrictlyComparableTo(ordinal3));
		}

		[Test]
		public void CompareShouldbeCorrect()
		{
			var ordinal1 = new Ordinal() {Value = 1};
			var ordinal2 = new Ordinal() {Value = 2};
			var ordinal3 = new Ordinal() {Value = 2};

			Assert.AreEqual(0, ordinal2.CompareTo(ordinal3));
			Assert.AreEqual(-1, ordinal1.CompareTo(ordinal2));
			Assert.AreEqual(1, ordinal2.CompareTo(ordinal1));
		}
	}
}

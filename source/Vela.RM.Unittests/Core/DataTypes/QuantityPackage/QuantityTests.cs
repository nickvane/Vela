using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support.MeasurementPackage;

namespace Vela.RM.UnitTests.Core.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingQuantity
	{
		[Test]
		public void DefaultPropertiesShouldBeSet()
		{
			IMeasurementService measurementService = new MeasurementServiceTest();
			var quantity1 = new Quantity(measurementService);
			Assert.IsTrue(quantity1.IsIntegral());
			Assert.IsTrue(quantity1.IsStrictlyComparableTo(new Quantity(measurementService)));
		}

		[Test]
		public void CompareShouldbeCorrect()
		{
			IMeasurementService measurementService = new MeasurementServiceTest();
			var quantity1 = new Quantity(measurementService) { Magnitude = 0.1 };
			var quantity2 = new Quantity(measurementService) { Magnitude = 0.2 };
			var quantity3 = new Quantity(measurementService) { Magnitude = 0.2 };

			Assert.AreEqual(0, quantity2.CompareTo(quantity3));
			Assert.AreEqual(-1, quantity1.CompareTo(quantity2));
			Assert.AreEqual(1, quantity2.CompareTo(quantity1));
		}
	}

	public class MeasurementServiceTest : IMeasurementService
	{
		public bool IsValidUnitsString(string units)
		{
			throw new NotImplementedException();
		}

		public bool AreEquivalentUnits(string unit1, string unit2)
		{
			return true;
		}
	}
}

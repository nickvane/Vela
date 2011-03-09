using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.DateTimePackage;

namespace Vela.RM.Core.UnitTests.DataTypes.DateTimePackage
{
	[TestFixture]
	public class WhenUsingDuration
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var date = new Duration();
			Assert.AreEqual(0, date.Magnitude);
			date = new Duration(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void MagnitudeShouldThrowException()
		{
			var date = new Duration();
			date.Magnitude = 1;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CompareToShouldThrowException()
		{
			var date = new Duration();
			date.CompareTo(null);
		}
	}
}

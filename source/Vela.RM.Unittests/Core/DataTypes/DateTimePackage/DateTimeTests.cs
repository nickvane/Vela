using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.DateTimePackage;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.UnitTests.Core.DataTypes.DateTimePackage
{
	[TestFixture]
	public class WhenUsingDateTime
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var date = new DateTime();
			Assert.AreEqual(0, date.Magnitude);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void MagnitudeShouldThrowException()
		{
			var date = new DateTime();
			date.Magnitude = 1;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DiffShouldThrowException()
		{
			var date = new DateTime();
			date.Diff(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void AddShouldThrowException()
		{
			var date = new DateTime();
			date.Add(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void SubtractShouldThrowException()
		{
			var date = new DateTime();
			date.Subtract(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CompareToShouldThrowException()
		{
			var date = new DateTime();
			date.CompareTo(null);
		}
	}
}

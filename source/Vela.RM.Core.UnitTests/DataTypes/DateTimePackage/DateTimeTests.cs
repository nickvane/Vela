//-----------------------------------------------------------------------
// <copyright file="DateTimeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Core.UnitTests.DataTypes.DateTimePackage
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
		public void CompareShouldWork()
		{
			var date1 = new DateTime { Value = "20110220" };
			var date2 = new DateTime { Value = "20110320" };
			var date3 = new DateTime { Value = "20110220" };

			Assert.IsTrue(date1 == date3);
			Assert.IsTrue(date2 > date1);
			Assert.IsTrue(date3 < date2);
		}
	}
}
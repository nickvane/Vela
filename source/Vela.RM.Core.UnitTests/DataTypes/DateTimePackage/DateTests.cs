//-----------------------------------------------------------------------
// <copyright file="DateTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.DateTimePackage;

namespace Vela.RM.Core.UnitTests.DataTypes.DateTimePackage
{
	[TestFixture]
	public class WhenUsingDate
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var date = new Date();
			Assert.AreEqual(0, date.Magnitude);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void MagnitudeShouldThrowException()
		{
			var date = new Date();
			date.Magnitude = 1;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DiffShouldThrowException()
		{
			var date = new Date();
			date.Diff(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void AddShouldThrowException()
		{
			var date = new Date();
			date.Add(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void SubtractShouldThrowException()
		{
			var date = new Date();
			date.Subtract(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CompareToShouldThrowException()
		{
			var date = new Date();
			date.CompareTo(null);
		}
	}
}
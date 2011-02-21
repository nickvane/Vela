﻿using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.DateTimePackage;

namespace Vela.RM.Unittests.Core.DataTypes.DateTimePackage
{
	[TestFixture]
	public class WhenUsingTime
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var date = new Time();
			Assert.AreEqual(0, date.Magnitude);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void MagnitudeShouldThrowException()
		{
			var date = new Time();
			date.Magnitude = 1;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DiffShouldThrowException()
		{
			var date = new Time();
			date.Diff(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void AddShouldThrowException()
		{
			var date = new Time();
			date.Add(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void SubtractShouldThrowException()
		{
			var date = new Time();
			date.Subtract(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CompareToShouldThrowException()
		{
			var date = new Time();
			date.CompareTo(null);
		}
	}
}

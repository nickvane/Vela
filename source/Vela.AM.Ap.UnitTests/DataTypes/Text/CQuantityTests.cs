//-----------------------------------------------------------------------
// <copyright file="CQuantityTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Ap.DataTypes.Quantity;

namespace Vela.AM.Ap.UnitTests.DataTypes.Text
{
	[TestFixture]
	public class WhenUsingCQuantity
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CQuantity();
			Assert.IsNotNull(instance.QuantityConstraints);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CQuantity();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new CQuantity();
			var result = instance.IsValid();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DefaultValueThrowsException()
		{
			var instance = new CQuantity();
			var result = instance.DefaultValue();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CQuantity();
			var result = instance.IsValidValue(null);
		}
	}
}
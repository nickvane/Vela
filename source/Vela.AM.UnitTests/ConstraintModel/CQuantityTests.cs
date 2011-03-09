using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCQuantity
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CQuantity();
			Assert.IsNotNull(instance.Quantities);
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

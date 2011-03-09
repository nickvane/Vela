using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCComplexObject
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CComplexObject();
			Assert.IsNotNull(instance.Attributes);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CComplexObject();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new CComplexObject();
			var result = instance.IsValid();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DefaultValueThrowsException()
		{
			var instance = new CComplexObject();
			var result = instance.DefaultValue();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CComplexObject();
			var result = instance.IsValidValue(null);
		}
	}
}

using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingArchetypeInternalRef
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var archetypeInternalRef = new ArchetypeInternalRef();
			var result = archetypeInternalRef.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var archetypeInternalRef = new ArchetypeInternalRef();
			var result = archetypeInternalRef.IsValid();
		}
	}
}

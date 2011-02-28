using System;
using NUnit.Framework;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.UnitTests.Patterns.Common.ArchetypedPackage
{
	[TestFixture]
	public class WhenUsingLocatableAsBaseclass
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ConceptShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.Concept;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsArachetypeRootShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.IsArchetypeRoot;
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetPathOfItemShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.GetPathOfItem(locatable);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemAtPathShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.GetItemAtPath("");
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemsAtPathShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.GetItemsAtPath("");
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DoesPathExistsShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.DoesPathExists("");
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPathUniqueShouldThrowException()
		{
			var locatable = new LocatableTest();
			var result = locatable.IsPathUnique("");
		}
	}

	public class LocatableTest : Locatable
	{

	}
}

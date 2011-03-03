using System;
using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	[TestFixture]
	public class WhenUsingIsmTransition
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetPathOfItemThrowsException()
		{
			var transition = new IsmTransition();
			transition.GetPathOfItem(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemAtPathThrowsException()
		{
			var transition = new IsmTransition();
			transition.GetItemAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemsAtPathThrowsException()
		{
			var transition = new IsmTransition();
			transition.GetItemsAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DoesPathExistsThrowsException()
		{
			var transition = new IsmTransition();
			transition.DoesPathExists(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPathUniqueThrowsException()
		{
			var transition = new IsmTransition();
			transition.IsPathUnique(string.Empty);
		}
	}
}

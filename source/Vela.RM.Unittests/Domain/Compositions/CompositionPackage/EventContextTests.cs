using System;
using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.RM.UnitTests.Domain.Compositions.CompositionPackage
{
	[TestFixture]
	public class WhenUsingEventContext
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetPathOfItemThrowsException()
		{
			var eventContext = new EventContext();
			eventContext.GetPathOfItem(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemAtPathThrowsException()
		{
			var eventContext = new EventContext();
			eventContext.GetItemAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemsAtPathThrowsException()
		{
			var eventContext = new EventContext();
			eventContext.GetItemsAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DoesPathExistsThrowsException()
		{
			var eventContext = new EventContext();
			eventContext.DoesPathExists(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPathUniqueThrowsException()
		{
			var eventContext = new EventContext();
			eventContext.IsPathUnique(string.Empty);
		}
	}
}

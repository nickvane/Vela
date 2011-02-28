using System;
using NUnit.Framework;
using Vela.RM.Patterns.Common.GenericPackage;

namespace Vela.RM.UnitTests.Patterns.Common.GenericPackage
{
	[TestFixture]
	public class WhenUsingRevisionHistory
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ShouldReturnMostRecentVersion()
		{
			var history = new RevisionHistory();
			var result = history.GetMostRecentVersion();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ShouldReturnCommittedTimeOfMostRecentVersion()
		{
			var history = new RevisionHistory();
			var result = history.GetCommittedTimeOfMostRecentVersion();
		}
	}
}

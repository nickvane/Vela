using System;
using NUnit.Framework;
using Vela.AM.Primitives;

namespace Vela.AM.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCDateTime
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CDateTime();
			instance.IsValidValue(null);
		}
	}
}

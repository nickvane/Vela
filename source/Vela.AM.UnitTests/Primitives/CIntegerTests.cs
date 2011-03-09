using System;
using NUnit.Framework;
using Vela.AM.Primitives;

namespace Vela.AM.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCInteger
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CInteger();
			instance.IsValidValue(0);
		}
	}
}

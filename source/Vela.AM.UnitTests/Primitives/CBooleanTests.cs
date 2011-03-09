using System;
using NUnit.Framework;
using Vela.AM.Primitives;

namespace Vela.AM.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCBoolean
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CBoolean();
			instance.IsValidValue(false);
		}
	}
}

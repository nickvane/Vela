using System;
using NUnit.Framework;

namespace Vela.AM.Adl.UnitTests
{
	[TestFixture]
	public class WhenUsingParseException
	{
		[Test]
		public void ConstructorWorks()
		{
			var exception = new ParseException("foo");
		}
	}
}

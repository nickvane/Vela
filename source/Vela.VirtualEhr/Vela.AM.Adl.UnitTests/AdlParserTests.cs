using System;
using NUnit.Framework;

namespace Vela.AM.Adl.UnitTests
{
	[TestFixture]
	public class WhenUsingAdlParser
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ParseThrowsException()
		{
			var archetype = ArchetypeAdlParser.Parse(string.Empty);
		}
	}
}

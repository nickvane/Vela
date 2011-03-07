using NUnit.Framework;
using Vela.AM.Archetypes;

namespace Vela.AM.UnitTests.Archetypes
{
	[TestFixture]
	public class WhenUsingArchetype
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetype = new Archetype();
			Assert.IsNotNull(archetype.Invariants);
		}
	}
}

using NUnit.Framework;
using Vela.AM.Ontologies;

namespace Vela.AM.UnitTests.Ontologies
{
	[TestFixture]
	public class WhenUsingArchetypeTerminology
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetypeTerminology = new ArchetypeTerminology();
			Assert.IsNotNull(archetypeTerminology.Items);
		}
	}
}

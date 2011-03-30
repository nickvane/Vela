using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Vela.AM.Adl;

namespace Vela.SM.ArchetypeService.UnitTests
{
	[TestFixture]
	public class WhenUsingCompositionBuilder
	{
		[Test]
		public void Test()
		{
			foreach (var file in Directory.GetFiles(@"Archetypes\xml\", "*.xml"))
			{
				Debug.WriteLine(file);
				var archetypeString = File.ReadAllText(file);
				var archetype = new ArchetypeXmlParser().Parse(archetypeString);
				var compositionBuilder = new CompositionBuilder();
				var composition = compositionBuilder.Build(archetype);
				Assert.IsNotNull(composition, file);
			}
		}
	}
}

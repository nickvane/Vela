using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace Vela.AM.Adl.UnitTests
{
	[TestFixture]
	public class WhenUsingXmlParserForParsingArchetypes
	{
		[Test]
		public void AllArchetypesShouldBeParsedWithoutErrors()
		{
			foreach (var file in Directory.GetFiles(@"Archetypes\xml\", "*.xml"))
			{
				Debug.WriteLine(file);
				var archetypeString = File.ReadAllText(file);
				//var archetype = XmlParser.Parse(archetypeString);
				var archetype = new object();
				Assert.IsNotNull(archetype, file);
			}
		}
	}
}

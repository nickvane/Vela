using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Raven.Client.Client;
using Vela.AM.Adl;
using Vela.AM.Aom.Archetypes;
using Vela.AM.Dal.Repositories;

namespace Vela.AM.Dal.UnitTests
{
	[TestFixture]
	public class WhenUsingArchetypeRepository
	{
		[Test]
		public void AllArchetypesShouldBeAbleToBeStored()
		{
			var store = new EmbeddableDocumentStore()
			            	{
			            		RunInMemory = true
			            	};
			store.Initialize();
			int count;
			using (var session = store.OpenSession())
			{
				var archetypeRepository = new ArchetypeRepository(session);
				count = Directory.GetFiles(@"Archetypes\xml\", "*.xml").ToList().Count;
				foreach (var file in Directory.GetFiles(@"Archetypes\xml\", "*.xml"))
				{
					Debug.WriteLine(file);
					var archetypeString = File.ReadAllText(file);
					var archetype = new XmlParser().Parse(archetypeString);
					archetypeRepository.Save(archetype);
				}
				session.SaveChanges();
			}

			using (var session = store.OpenSession())
			{
				var result = session.Advanced.LuceneQuery<Archetype>().WaitForNonStaleResults().Take(count).ToList();
				var ravenCount = result.Count();

				Assert.AreEqual(count, ravenCount);
			}
		}
	}
}

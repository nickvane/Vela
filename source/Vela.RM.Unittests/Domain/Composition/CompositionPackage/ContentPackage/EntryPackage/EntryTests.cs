using NUnit.Framework;
using Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Unittests.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage
{
	[TestFixture]
	public class EntryTests
	{
		[Test]
		[ExpectedException]
		public void IsPersistentThrowsException()
		{
			var entry = new EntryTest();
			var isSubjectSelf = entry.IsSubjectSelf();
		}
	}

	public class EntryTest : Entry
	{
		
	}
}

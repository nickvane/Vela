using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.UnitTests.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
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

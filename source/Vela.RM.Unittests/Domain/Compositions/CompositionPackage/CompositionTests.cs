using NUnit.Framework;

namespace Vela.RM.UnitTests.Domain.Compositions.CompositionPackage
{
	[TestFixture]
	public class CompositionTests
	{
		[Test]
		[ExpectedException]
		public void IsPersistentThrowsException()
		{
			var composition = new RM.Domain.Compositions.CompositionPackage.Composition();
			var isPersistent = composition.IsPersistent();
		}
	}
}

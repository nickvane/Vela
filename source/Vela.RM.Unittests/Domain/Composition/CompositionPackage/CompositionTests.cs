using NUnit.Framework;

namespace Vela.RM.Unittests.Domain.Composition.CompositionPackage
{
	[TestFixture]
	public class CompositionTests
	{
		[Test]
		[ExpectedException]
		public void IsPersistentThrowsException()
		{
			var composition = new Vela.RM.Domain.Composition.CompositionPackage.Composition();
			var isPersistent = composition.IsPersistent();
		}
	}
}

using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.RM.Dal.Domain.Repositories;

namespace Vela.RM.Dal.UnitTests.Domain.Repositories
{
	[TestFixture]
	public class WhenUsingCompositionVersionRepository
	{
		private MockRepository _mocks;

		[SetUp]
		public void Setup()
		{
			_mocks = new MockRepository();
		}

		[Test]
		public void Test()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new CompositionVersionRepository(session, null);
			Assert.IsNotNull(repository);
		}
	}
}

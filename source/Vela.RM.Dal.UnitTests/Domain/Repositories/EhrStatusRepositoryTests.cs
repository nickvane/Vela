﻿using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.RM.Dal.Domain.Repositories;

namespace Vela.RM.Dal.UnitTests.Domain.Repositories
{
	[TestFixture]
	public class WhenUsingEhrStatusVersionRepository
	{
		[Test]
		public void TestConstructor()
		{
			var mocks = new MockRepository();
			var session = mocks.StrictMock<IDocumentSession>();
			var repository = new EhrStatusVersionRepository(session, null);
		}
	}
}
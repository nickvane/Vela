//-----------------------------------------------------------------------
// <copyright file="DocumentScopeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.Common.Dal;

namespace Vela.Common.UnitTests.Dal
{
	[TestFixture]
	public class WhenUsingDocumentScope
	{
		private MockRepository _mocks;

		[SetUp]
		public void Setup()
		{
			_mocks = new MockRepository();
		}

		[Test]
		public void ChangesAreSavedToStorageWhenDisposed()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			session.Expect(x => x.SaveChanges());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(session))
			{
				Assert.AreEqual(session, DocumentSessionScope.Current);
			}
			
			_mocks.VerifyAll();
		}
	}
}
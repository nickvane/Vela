//-----------------------------------------------------------------------
// <copyright file="DocumentScopeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;

namespace Vela.Common.Dal.UnitTests
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
			session.Expect(x => x.Dispose());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(session))
			{
				Assert.IsNotNull(DocumentSessionScope.Current);
			}
			_mocks.VerifyAll();
		}
	}
}
//-----------------------------------------------------------------------
// <copyright file="RavenRepositoryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Linq;
using Rhino.Mocks;

namespace Vela.Common.Dal.UnitTests
{
	[TestFixture]
	public class WhenUsingRavenRepository
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_mocks = new MockRepository();
			_session = _mocks.StrictMock<IDocumentSession>();
			_document1 = _mocks.StrictMock<IDocument>();
			_document2 = _mocks.StrictMock<IDocument>();
			_document3 = _mocks.StrictMock<IDocument>();

			_collection = new List<IDocument> {_document1, _document2, _document3}.AsQueryable();
			_repository = new BaseRepository<IDocument>(null);
		}

		#endregion

		private MockRepository _mocks;
		private IDocumentSession _session;
		private BaseRepository<IDocument> _repository;
		private IDocument _document1;
		private IDocument _document2;
		private IDocument _document3;
		private IQueryable<IDocument> _collection;

		[Test]
		public void AddStoresDocument()
		{
			Expect.Call(() => _session.Store(_document1));
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();
				
			using (new DocumentSessionScope(_session))
			{
				_repository.Save(_document1);
			}
			_mocks.VerifyAll();
		}

		[Test]
		public void CollectionGetterAndSetter()
		{
			var repositoryWithCollection = new BaseRepository<IDocument>(_collection);
			Assert.AreEqual(_collection, repositoryWithCollection.Collection);
			repositoryWithCollection = new BaseRepository<IDocument>(null);
			Expect.Call(_session.Query<IDocument>()).Return(_mocks.StrictMock<IRavenQueryable<IDocument>>());
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(_session))
			{
				Assert.IsNotNull(repositoryWithCollection.Collection);
			}
			_mocks.VerifyAll();
		}

		[Test]
		public void ContainsItem()
		{
			Assert.IsFalse(_repository.Contains(null));
			const string s = "1";
			Expect.Call(_document1.Id).Return(s);
			Expect.Call(_session.Load<IDocument>(s)).Return(_mocks.StrictMock<IDocument>());
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(_session))
			{
				Assert.IsTrue(_repository.Contains(_document1));
			}
			_mocks.VerifyAll();
		}

		[Test]
		public void CountReturnsNumberOfDocuments()
		{
			using (new DocumentSessionScope(_session))
			{
				var repositoryWithCollection = new BaseRepository<IDocument>(_collection);
				Assert.AreEqual(_collection.Count(), repositoryWithCollection.Count);
			}
		}

		[Test]
		public void IndexerReturnsCorrectDocument()
		{
			const string id = "1";

			Expect.Call(_session.Load<IDocument>(id)).Return(_mocks.StrictMock<IDocument>());
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();
				
			using (new DocumentSessionScope(_session))
			{
				Assert.IsNotNull(_repository[id]);
			}
			_mocks.VerifyAll();
			Assert.IsNull(_repository[string.Empty]);
		}

		[Test]
		public void RemoveDeletesDocument()
		{
			Expect.Call(() => _session.Delete(_document1));
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();
			
			using (new DocumentSessionScope(_session))
			{
				Assert.IsTrue(_repository.Delete(_document1));
			}
			_mocks.VerifyAll();
		}
	}
}
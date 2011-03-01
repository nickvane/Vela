using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Linq;
using Rhino.Mocks;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.Dal.RavenDb;

namespace Vela.Common.UnitTests.Dal.RavenDb
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
			_repository = new RavenRepository<IDocument>(_session, null);
		}

		#endregion

		private MockRepository _mocks;
		private IDocumentSession _session;
		private RavenRepository<IDocument> _repository;
		private IDocument _document1;
		private IDocument _document2;
		private IDocument _document3;
		private IQueryable<IDocument> _collection;

		[Test]
		public void GetEnumerator()
		{
			const string id = "a1";
			var document4 = new TestDocument
			{
				Id = id
			};
			var document5 = new TestDocument
			{
				Id = "a2"
			};
			var document6 = new TestDocument
			{
				Id = "b1"
			};

			var collection = new List<TestDocument> { document4, document5, document6 }.AsQueryable();
			var repository = new RavenRepository<TestDocument>(_session, collection);
			var count = 0;
			foreach (var testDocument in repository)
			{
				count += 1;
			}
			Assert.AreEqual(3, count);
			count = 0;
			foreach (var testDocument in (IEnumerable)repository)
			{
				count += 1;
			}
		}

		[Test]
		public void AddStoresDocument()
		{
			Expect.Call(() => _session.Store(_document1));
			_mocks.ReplayAll();
			_repository.Add(_document1);
			_mocks.VerifyAll();
		}

		[Test]
		[ExpectedException(typeof (NotSupportedException))]
		public void ClearIsNotSupported()
		{
			_repository.Clear();
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void CopyToArrayIsNotSupported()
		{
			_repository.CopyTo(new IDocument[1], 0);
		}

		[Test]
		public void CollectionGetterAndSetter()
		{
			var repositoryWithCollection = new RavenRepository<IDocument>(_session, _collection);
			Assert.AreEqual(_collection, repositoryWithCollection.Collection);
			repositoryWithCollection.Collection = null;
			Expect.Call(_session.Query<IDocument>()).Return(_mocks.StrictMock<IRavenQueryable<IDocument>>());
			_mocks.ReplayAll();
			Assert.IsNotNull(repositoryWithCollection.Collection);
			_mocks.VerifyAll();
		}

		[Test]
		public void ContainsItem()
		{
			Assert.IsFalse(_repository.Contains(null));
			const string s = "1";
			Expect.Call(_document1.Id).Return(s);
			Expect.Call(_session.Load<IDocument>(s)).Return(_mocks.StrictMock<IDocument>());
			_mocks.ReplayAll();
			Assert.IsTrue(_repository.Contains(_document1));
			_mocks.VerifyAll();
		}

		[Test]
		public void CountReturnsNumberOfDocuments()
		{
			var repositoryWithCollection = new RavenRepository<IDocument>(_session, _collection);
			Assert.AreEqual(_collection.Count(), repositoryWithCollection.Count);
		}

		[Test]
		public void IndexerReturnsCorrectDocument()
		{
			const string id = "1";

			Expect.Call(_session.Load<IDocument>(id)).Return(_mocks.StrictMock<IDocument>());
			_mocks.ReplayAll();
			Assert.IsNotNull(_repository[id]);
			_mocks.VerifyAll();
			Assert.IsNull(_repository[string.Empty]);
		}

		[Test]
		public void IsReadOnly()
		{
			Assert.IsFalse(_repository.IsReadOnly);
		}

		[Test]
		public void RemoveDeletesDocument()
		{
			Expect.Call(() => _session.Delete(_document1));
			_mocks.ReplayAll();
			Assert.IsTrue(_repository.Remove(_document1));
			_mocks.VerifyAll();
		}

		[Test]
		public void FindAllAndFindOneReturnItemsAccordingToSpecification()
		{
			const string id = "a1";
			var document4 = new TestDocument
			{
				Id = id
			};
			var document5 = new TestDocument
			{
				Id = "a2"
			};
			var document6 = new TestDocument
			{
				Id = "b1"
			};

			var collection = new List<TestDocument> { document4, document5, document6 }.AsQueryable();
			var repository = new RavenRepository<TestDocument>(_session, collection);
			var result = repository.FindAll(new IdStartsWith("a"));
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());

			var result2 = repository.FindOne(new GetById(id));
			Assert.IsNotNull(result2);
			Assert.AreEqual(id, result2.Id);
		}
	}

	public class IdStartsWith : Specification<TestDocument>
	{
		private readonly string _id;

		public IdStartsWith(string id)
		{
			_id = id;
		}

		public override Expression<Func<TestDocument, bool>> IsSatisfiedBy()
		{
			return x => x.Id.StartsWith(_id);
		}
	}

	public class GetById : Specification<TestDocument>
	{
		private readonly string _id;

		public GetById(string id)
		{
			_id = id;
		}

		public override Expression<Func<TestDocument, bool>> IsSatisfiedBy()
		{
			return x => x.Id ==_id;
		}
	}

	public class TestDocument : IDocument
	{
		#region IDocument Members

		public string Id { get; set; }

		#endregion
	}
}
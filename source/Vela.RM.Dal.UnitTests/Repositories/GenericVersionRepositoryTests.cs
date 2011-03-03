using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.Common.Dal.RavenDB;
using Vela.RM.Core.Common.ChangeControlPackage;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Dal.Repositories;
using Vela.RM.Domain.Entities;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Dal.UnitTests.Repositories
{
	[TestFixture]
	public class WhenUsingGenericVersionRepository
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_mocks = new MockRepository();

			_collection = new List<VersionContainerTest>
			              	{
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id1),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id6),
														CommitAudit = new AuditDetails()
														              	{
														              		TimeCommitted = new DateTime()
														              		                	{
														              		                		Value = "20110301"
														              		                	}
														              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id7),
														CommitAudit = new AuditDetails()
														              	{
														              		TimeCommitted = new DateTime()
														              		                	{
														              		                		Value = "20101224"
														              		                	}
														              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id3),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id8),
														CommitAudit = new AuditDetails()
														              	{
														              		TimeCommitted = new DateTime()
														              		                	{
														              		                		Value = "20110215"
														              		                	}
														              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id9),
														CommitAudit = new AuditDetails()
														              	{
														              		TimeCommitted = new DateTime()
														              		                	{
														              		                		Value = "20100501"
														              		                	}
														              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new ImportedVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id10),
														CommitAudit = new AuditDetails()
														              	{
														              		TimeCommitted = new DateTime()
														              		                	{
														              		                		Value = "20110225"
														              		                	}
														              	}
			              				          	}
			              			},
			              	}.AsQueryable();
		}

		#endregion

		private MockRepository _mocks;
		private IQueryable<VersionContainerTest> _collection;
		readonly string _id1 = Guid.NewGuid().ToString();
		readonly string _id2 = Guid.NewGuid().ToString();
		readonly string _id3 = Guid.NewGuid().ToString();
		const string Id6 = "ED378EAC-FDE9-4B50-9631-EE57992EA6FB::798061F2-09EC-4784-997B-FD5454127D16::1";
		const string Id7 = "FE771BF3-9EB5-4DFA-A3F7-418BD8DD5A3C::0F9A6B36-EE9C-4D97-8BFB-CF097CEA53DB::1";
		const string Id8 = "A780376B-1A1D-4FB3-BBC1-27B53D4D3B7B::7E5E85F8-40E2-4840-9F87-81EAAB76ED0F::1";
		const string Id9 = "EABD7E2B-CAC5-454A-9150-BA2198419128::EC5C9FE8-1DF6-4762-8BFD-6BE0F083D0E6::1.1.2";
		const string Id10 = "8B614C9C-9E29-4BDC-9696-5833E48093D5::0C5EDDB4-6312-4D56-858B-CD76D6AE37E0::1.2.2";


		[Test]
		public void GetAllVersions()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(session, _collection);

			var res = from v in repository.Collection where v.Id == Id7 select v;
			var res2 = res.ToList();

			var result = repository.GetAllVersions(_id2);
			Assert.AreEqual(3, result.Count);

			result = repository.GetAllVersions(_id1);
			Assert.AreEqual(1, result.Count);

			result = repository.GetAllVersions(_id3);
			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public void GetVersionAndHasVersion()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(session, _collection);

			Expect.Call(session.Load<VersionContainerTest>(Id6)).Return(new VersionContainerTest());
			_mocks.ReplayAll();
			Assert.IsTrue(repository.HasVersion(Id6));
			_mocks.VerifyAll();
			Assert.IsFalse(repository.HasVersion(string.Empty));
		}

		[Test]
		public void IsOriginalVersionTrue()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(session, _collection);

			Expect.Call(session.Load<VersionContainerTest>(Id6)).Return(new VersionContainerTest() { Version = new OriginalVersion<VersionTest>() });
			_mocks.ReplayAll();
			Assert.IsTrue(repository.IsOriginalVersion(Id6));
			_mocks.VerifyAll();
		}

		[Test]
		public void GetLatestVersion()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(session, _collection);

			var result = repository.GetLatestVersion(_id2);
			Assert.AreEqual(Id10, result.Id);

			result = repository.GetLatestVersion(_id1);
			Assert.AreEqual(Id6, result.Id);

			result = repository.GetLatestVersion("foo");
			Assert.IsNull(result);
		}

		[Test]
		public void GetLatestVersionFromTrunk()
		{
			var session = _mocks.StrictMock<IDocumentSession>();
			var repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(session, _collection);

			var result = repository.GetLatestVersionFromTrunk(_id2);
			Assert.AreEqual(Id7, result.Id);

			result = repository.GetLatestVersionFromTrunk("foo");
			Assert.IsNull(result);
		}
	}

	public class VersionTest : IDocument
	{
		public string Id
		{
			get; set; }
	}

	public class VersionContainerTest : GenericVersion<VersionTest>
	{
		
	}
}
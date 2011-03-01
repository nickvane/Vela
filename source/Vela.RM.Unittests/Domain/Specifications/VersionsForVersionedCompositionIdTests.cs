using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Specifications;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.UnitTests.Domain.Specifications
{
	[TestFixture]
	public class VersionsForVersionedCompositionIdTrunkTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			_versions = new List<CompositionVersion>
			            	{
			            		new CompositionVersion { VersionedComposition = new VersionedComposition(){Uid = new HierObjectId(Uid1)},  Version = new OriginalVersion<Composition> {Uid = new ObjectVersionId(Id1)}},
			            		new CompositionVersion { VersionedComposition = new VersionedComposition(){Uid = new HierObjectId(Uid2)},  Version = new OriginalVersion<Composition> {Uid = new ObjectVersionId(Id2)}},
			            		new CompositionVersion { VersionedComposition = new VersionedComposition(){Uid = new HierObjectId(Uid2)},  Version = new OriginalVersion<Composition> {Uid = new ObjectVersionId(Id3)}},
			            		new CompositionVersion { VersionedComposition = new VersionedComposition(){Uid = new HierObjectId(Uid2)},  Version = new OriginalVersion<Composition> {Uid = new ObjectVersionId(Id4)}}
			            	}.AsQueryable();
		}

		#endregion

		private IQueryable<CompositionVersion> _versions;
		private const string Id1 = "52028965-5096-49E7-91D6-FD49ACC7F158::98B5E172-5F05-4325-BF87-73D7E6F2247E::1";
		private const string Id2 = "CB551990-46A0-454B-9A7C-D6374E2F0DED::A77B22BE-125F-4DA6-88D8-B8E7A6E2466B::1.2.3";
		private const string Id3 = "A46C1386-8F41-409C-8031-9B635DA1D989::E02174D5-153D-4C9A-B2ED-B271BA4B5E75::1.12.8";
		private const string Id4 = "A77B22BE-125F-4DA6-88D8-B8E7A6E2466B::52028965-5096-49E7-91D6-FD49ACC7F158::2";

		private const string Uid1 = "52A9B25A-B522-48F0-B30A-BFF6C2FB973B";
		private const string Uid2 = "FDBF28CC-A87A-4163-8AD8-FFA7E2DA4311";
		
		[Test]
		public void GetVersionWithVersionId()
		{
			var result = _versions.Where(new VersionsForVersionedCompositionId(Uid1).IsSatisfiedBy()).ToList();
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Count);
			result = _versions.Where(new VersionsForVersionedCompositionId(Uid2).IsSatisfiedBy()).ToList();
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count);
		}
	}
}
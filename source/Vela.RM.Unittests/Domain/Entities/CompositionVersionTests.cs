using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.UnitTests.Domain.Entities
{
	[TestFixture]
	public class WhenUsingCompositionVersion
	{
		[Test]
		public void IdIsVersionId()
		{
			const string uid1 = "52028965-5096-49E7-91D6-FD49ACC7F158::98B5E172-5F05-4325-BF87-73D7E6F2247E::1";
			const string uid2 = "CB551990-46A0-454B-9A7C-D6374E2F0DED::A77B22BE-125F-4DA6-88D8-B8E7A6E2466B::1";
			var compositionVersion = new CompositionVersion();

			Assert.IsNullOrEmpty(compositionVersion.Id);
			compositionVersion.Id = "foo";
			Assert.IsNullOrEmpty(compositionVersion.Id);
			
			compositionVersion.Version = new OriginalVersion<Composition>();
			Assert.IsNullOrEmpty(compositionVersion.Id);
			compositionVersion.Id = "foo";
			Assert.IsNullOrEmpty(compositionVersion.Id);

			compositionVersion.Version.Uid = new ObjectVersionId(uid1);
			Assert.AreEqual(uid1, compositionVersion.Id);
			compositionVersion.Id = uid2;
			Assert.AreEqual(uid2, compositionVersion.Id);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPersistenThrowsException()
		{
			var v = new CompositionVersion();
			var p = v.IsPersistent();
		}
	}
}

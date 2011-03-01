using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.UnitTests.Patterns.Common.ChangeControlPackage
{
	[TestFixture]
	public class WhenUsingVersion
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetOwnerIdShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.GetOwnerId();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsBranchShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.IsBranch();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CanonicalFormShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.GetCanonicalForm();
		}
	}

	public class Versiontest : Version<string>
	{
		public override ObjectVersionId Uid { get; set; }
		public override ObjectVersionId PrecedingVersionUid { get; set; }
		public override string Data { get; set; }
		public override CodedText LifecycleState { get; set; }
	}
}

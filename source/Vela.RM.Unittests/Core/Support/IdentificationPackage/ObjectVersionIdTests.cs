using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.UnitTests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingObjectVersionIdWithValidValues
	{
		[Test]
		public void ValuesShouldBeSetCorrectly()
		{
			const string objectId = "D8EE6A3F-7C70-4858-B37F-6F280EF0A04A";
			const string creatingSystemId = "3BC0C3E8-3828-4E95-8AE9-7819286957F3";
			const string versionTreeId = "1.2.1";
			const string value = objectId + "::" + creatingSystemId + "::" + versionTreeId;
			var id1 = new ObjectVersionId(value);
			Assert.AreEqual(value, id1.Value);
			Assert.AreEqual(objectId, id1.ObjectId.Value);
			Assert.AreEqual(creatingSystemId, id1.CreatingSystemId.Value);
			Assert.AreEqual(versionTreeId, id1.VersionTreeId.Value);
			Assert.IsTrue(id1.IsBranch);
			Assert.AreEqual(value, id1.ToString());
		}
	}

	[TestFixture]
	public class WhenUsingObjectVersionIdWithInValidValues
	{
		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShouldThrowException()
		{
			new ObjectVersionId("1::2");
		}
	}
}

using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingVersionTreeIdWithInvalidValue
	{
		[ExpectedException(typeof(ArgumentException))]
		[TestCase("0")]
		[TestCase("1.0")]
		[TestCase("1.1.0")]
		[TestCase("x")]
		[TestCase("1.x")]
		[TestCase("1.1.x")]
		public void ShouldThrowAnException(string value)
		{
			new VersionTreeId(value);
		}
	}

	[TestFixture]
	public class WhenUsingVersionTreeIdWithValidValues
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			const string value1 = "2";
			var id1 = new VersionTreeId(value1);
			Assert.AreEqual(2, id1.TrunkVersion);
			Assert.IsNull(id1.BranchNumber);
			Assert.IsNull(id1.BranchVersion);
			Assert.IsFalse(id1.IsFirst);
			Assert.IsFalse(id1.IsBranch);
			Assert.AreEqual(value1, id1.Value);

			const string value2 = "1.5";
			var id2 = new VersionTreeId(value2);
			Assert.AreEqual(1, id2.TrunkVersion);
			Assert.AreEqual(5, id2.BranchNumber);
			Assert.IsNull(id2.BranchVersion);
			Assert.IsTrue(id2.IsFirst);
			Assert.IsFalse(id2.IsBranch);
			Assert.AreEqual(value2, id2.Value);

			const string value3 = "12.34.789";
			var id3 = new VersionTreeId(value3);
			Assert.AreEqual(12, id3.TrunkVersion);
			Assert.AreEqual(34, id3.BranchNumber);
			Assert.AreEqual(789, id3.BranchVersion);
			Assert.IsFalse(id3.IsFirst);
			Assert.IsTrue(id3.IsBranch);
			Assert.AreEqual(value3, id3.Value);

		}
	}
}

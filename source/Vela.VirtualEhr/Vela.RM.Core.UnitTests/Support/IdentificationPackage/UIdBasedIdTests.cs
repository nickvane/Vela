//-----------------------------------------------------------------------
// <copyright file="UIdBasedIdTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingUIdBasedId
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			const string root = "BFDB4D31-3E35-4DAB-AFCA-5E6E5C8F61EA";
			const string extension = "openEHR";
			const string value = root + "::" + extension;
			var id1 = new TestId2(value);
			Assert.AreEqual(root, id1.Root.Value);
			Assert.AreEqual(extension, id1.Extension);
			Assert.AreEqual(value, id1.Value);

			var id2 = new TestId2(root);
			Assert.IsFalse(id2.HasExtension);
			Assert.AreEqual(root, id2.Root.Value);
			Assert.IsNullOrEmpty(id2.Extension);
		}
	}

	public class TestId2 : UIdBasedId
	{
		public TestId2(string value)
			: base(value)
		{
		}
	}
}
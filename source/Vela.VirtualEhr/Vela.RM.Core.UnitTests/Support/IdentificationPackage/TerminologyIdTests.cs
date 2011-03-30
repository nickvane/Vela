//-----------------------------------------------------------------------
// <copyright file="TerminologyIdTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingTerminologyIdWithValidValues
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			const string value1 = "snomed-ct";
			var id1 = new TerminologyId(value1);
			Assert.AreEqual(value1, id1.Value);
			Assert.AreEqual(value1, id1.Name);
			Assert.IsEmpty(id1.VersionId);

			const string value2 = "ICD9(1999)";
			var id2 = new TerminologyId(value2);
			Assert.AreEqual(value2, id2.Value);
			Assert.AreEqual("ICD9", id2.Name);
			Assert.AreEqual("1999", id2.VersionId);
		}
	}
}
//-----------------------------------------------------------------------
// <copyright file="UUIdTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingUuId
	{
		[Test]
		public void AValidGuidShouldBeSet()
		{
			const string guid = "BFDB4d31-3e35-4dab-afca-5e6e5c8f61ea";
			var testGuid = new Guid("BFDB4D31-3E35-4DAB-AFCA-5E6E5C8F61EA");

			new UUId(guid);

			var id1 = new UUId(testGuid.ToString());
			Assert.AreEqual(testGuid.ToString(), id1.Value);
			Assert.AreEqual(testGuid.ToString(), id1.ToString());
			Assert.AreEqual(testGuid, id1.ToGuid());
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void AndAnInvalidDomainNameIdIsSet()
		{
			new UUId("notaguid");
		}

	}
}
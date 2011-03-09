//-----------------------------------------------------------------------
// <copyright file="InternetIdTests.cs" company="Vela">
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
	public class WhenUsingInternetId
	{
		[Test]
		public void AValidDomainNameShouldBeSet()
		{
			const string domainName = "wiki.openehr.org";
			new InternetId("openehr.org");
			var id = new InternetId(domainName);
			Assert.AreEqual(domainName, id.Value);
			Assert.AreEqual(domainName, id.ToString());
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void AndAnInvalidDomainNameIdIsSet()
		{
			new InternetId("notadomain-.com");
		}
	}
}
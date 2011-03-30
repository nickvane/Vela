//-----------------------------------------------------------------------
// <copyright file="IsoOIdTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingIsoOId
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			new IsoOId("test");
		}
	}
}
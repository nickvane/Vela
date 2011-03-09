//-----------------------------------------------------------------------
// <copyright file="TemplateIdTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingTemplateIdWithValidValues
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			var id1 = new TemplateId("");
		}
	}
}
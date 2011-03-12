//-----------------------------------------------------------------------
// <copyright file="HierObjectIdTests.cs" company="Vela">
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
	public class WhenUsingHierObjectId
	{
		[Test]
		public void ShouldConstructWithoutExceptions()
		{
			new HierObjectId(Guid.NewGuid().ToString());
			new HierObjectId();
		}
	}
}
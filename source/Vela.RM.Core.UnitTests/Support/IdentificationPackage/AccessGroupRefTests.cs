//-----------------------------------------------------------------------
// <copyright file="AccessGroupRefTests.cs" company="Vela">
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
	public class WhenUsingAccessGroupRef
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			var id = new AccessGroupRef
						{
							Type = RefType.ACCESS_GROUP.ToString()
						};
			Assert.AreEqual(RefType.ACCESS_GROUP.ToString(), id.Type);
		}
	}

	[TestFixture]
	public class WhenUsingAccessGroupRefWithInvalidType
	{
		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShouldThrowException()
		{
			var id = new AccessGroupRef
			{
				Type = "TEST"
			};
		}
	}
}
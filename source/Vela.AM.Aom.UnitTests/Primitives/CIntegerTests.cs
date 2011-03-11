//-----------------------------------------------------------------------
// <copyright file="CIntegerTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Aom.Primitives;

namespace Vela.AM.Aom.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCInteger
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CInteger();
			Assert.IsNotNull(instance.List);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CInteger();
			instance.IsValidValue(0);
		}
	}
}
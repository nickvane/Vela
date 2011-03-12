//-----------------------------------------------------------------------
// <copyright file="CRealTests.cs" company="Vela">
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
	public class WhenUsingCReal
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CReal();
			instance.IsValidValue(0);
		}
	}
}
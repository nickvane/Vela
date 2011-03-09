//-----------------------------------------------------------------------
// <copyright file="ConstraintRefTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingConstraintRef
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new ConstraintRef();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new ConstraintRef();
			var result = instance.IsValid();
		}
	}
}
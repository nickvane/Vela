//-----------------------------------------------------------------------
// <copyright file="CSingleAttributeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Aom.ConstraintModel;

namespace Vela.AM.Aom.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCSingleAttribute
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CSingleAttribute();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new CSingleAttribute();
			var result = instance.IsValid();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetAlternativesThrowsException()
		{
			var instance = new CSingleAttribute();
			var result = instance.GetAlternatives();
		}
	}
}
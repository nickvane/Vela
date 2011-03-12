//-----------------------------------------------------------------------
// <copyright file="CPrimitiveObjectTests.cs" company="Vela">
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
	public class WhenUsingCPrimitiveObject
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CPrimitiveObject();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new CPrimitiveObject();
			var result = instance.IsValid();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DefaultValueThrowsException()
		{
			var instance = new CPrimitiveObject();
			var result = instance.DefaultValue();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CPrimitiveObject();
			var result = instance.IsValidValue(null);
		}
	}
}
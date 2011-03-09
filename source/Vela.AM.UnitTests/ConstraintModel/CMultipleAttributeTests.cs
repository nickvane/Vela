//-----------------------------------------------------------------------
// <copyright file="CMultipleAttributeTests.cs" company="Vela">
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
	public class WhenUsingCMultipleAttribute
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CMultipleAttribute();
			Assert.IsNotNull(instance.Members);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CMultipleAttribute();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new CMultipleAttribute();
			var result = instance.IsValid();
		}
	}
}
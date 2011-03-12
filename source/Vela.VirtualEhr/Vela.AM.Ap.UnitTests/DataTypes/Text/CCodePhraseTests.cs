//-----------------------------------------------------------------------
// <copyright file="CCodePhraseTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Ap.DataTypes.Text;

namespace Vela.AM.Ap.UnitTests.DataTypes.Text
{
	[TestFixture]
	public class WhenUsingCCodePhrase
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CCodePhrase();
			Assert.IsNotNull(instance.CodeList);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CCodePhrase();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DefaultValueThrowsException()
		{
			var instance = new CCodePhrase();
			var result = instance.DefaultValue();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CCodePhrase();
			var result = instance.IsValidValue(null);
		}
	}
}
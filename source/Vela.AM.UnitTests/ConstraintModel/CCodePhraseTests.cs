//-----------------------------------------------------------------------
// <copyright file="CCodePhraseTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCCodePhrase
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new CCodePhrase();
			Assert.IsNotNull(instance.CodePhrases);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new CCodePhrase();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		public void IsValidThrowsException()
		{
			var instance = new CCodePhrase();
			Assert.IsFalse(instance.IsValid());
			instance.CodePhrases.Add(new CodePhrase("foo"));
			Assert.IsTrue(instance.IsValid());
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
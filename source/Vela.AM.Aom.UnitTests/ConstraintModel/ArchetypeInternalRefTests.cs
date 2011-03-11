//-----------------------------------------------------------------------
// <copyright file="ArchetypeInternalRefTests.cs" company="Vela">
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
	public class WhenUsingArchetypeInternalRef
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var archetypeInternalRef = new ArchetypeInternalRef();
			var result = archetypeInternalRef.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var archetypeInternalRef = new ArchetypeInternalRef();
			var result = archetypeInternalRef.IsValid();
		}
	}
}
//-----------------------------------------------------------------------
// <copyright file="ArchetypeSlotTests.cs" company="Vela">
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
	public class WhenUsingArchetypeSlot
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var archetypeSlot = new ArchetypeSlot();
			var result = archetypeSlot.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var archetypeSlot = new ArchetypeSlot();
			var result = archetypeSlot.IsValid();
		}
	}
}
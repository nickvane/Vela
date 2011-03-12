//-----------------------------------------------------------------------
// <copyright file="ArchetypeSlotTests.cs" company="Vela">
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
	public class WhenUsingArchetypeSlot
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetypeSlot = new ArchetypeSlot();
			Assert.IsNotNull(archetypeSlot.Includes);
			Assert.IsNotNull(archetypeSlot.Excludes);
		}
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
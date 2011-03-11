//-----------------------------------------------------------------------
// <copyright file="ArchetypeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.AM.Aom.Archetypes;

namespace Vela.AM.Aom.UnitTests.Archetypes
{
	[TestFixture]
	public class WhenUsingArchetype
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetype = new Archetype();
			Assert.IsNotNull(archetype.Invariants);
		}

		[Test]
		public void IdIsProperlyRouted()
		{
			var archetype = new Archetype();
			Assert.IsNullOrEmpty(archetype.Id);
			const string id1 = "openEHR-EHR-CLUSTER.cranial_nerves.v1";
			archetype.Id = id1;
			Assert.AreEqual(id1, archetype.Id);
			const string id2 = "local-EHR-CLUSTER.cranial_nerves.v1";
			archetype.Id = id2;
			Assert.AreEqual(id2, archetype.Id);
		}
	}
}
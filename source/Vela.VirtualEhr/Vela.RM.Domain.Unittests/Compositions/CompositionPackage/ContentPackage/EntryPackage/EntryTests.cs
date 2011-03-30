//-----------------------------------------------------------------------
// <copyright file="EntryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	[TestFixture]
	public class WhenUsingEntry
	{
		[Test]
		[ExpectedException]
		public void IsPersistentThrowsException()
		{
			var entry = new EntryTest();
			var isSubjectSelf = entry.IsSubjectSelf();
		}

		[Test]
		public void ListsAreNotNull()
		{
			var entry = new EntryTest();
			Assert.IsNotNull(entry.OtherParticipations);
		}
	}

	public class EntryTest : Entry
	{
		
	}
}
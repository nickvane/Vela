//-----------------------------------------------------------------------
// <copyright file="CompositionTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage
{
	[TestFixture]
	public class CompositionTests
	{
		[Test]
		[ExpectedException]
		public void IsPersistentThrowsException()
		{
			var composition = new Composition();
			var isPersistent = composition.IsPersistent();
		}

		[Test]
		public void ListsAreNotNull()
		{
			var composition = new Composition();
			Assert.IsNotNull(composition.Content);
		}
	}
}
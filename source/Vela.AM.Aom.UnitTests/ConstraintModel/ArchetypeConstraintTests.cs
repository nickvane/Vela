//-----------------------------------------------------------------------
// <copyright file="ArchetypeConstraintTests.cs" company="Vela">
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
	public class WhenUsingArchetypeConstraint
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetPathThrowsException()
		{
			var archetypeConstraint = new ArchetypeConstraintTest();
			var result = archetypeConstraint.GetPath();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasPathThrowsException()
		{
			var archetypeConstraint = new ArchetypeConstraintTest();
			var result = archetypeConstraint.HasPath(string.Empty);
		}
	}

	public class ArchetypeConstraintTest : ArchetypeConstraint
	{
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		public override bool IsValid()
		{
			throw new NotImplementedException();
		}
	}
}
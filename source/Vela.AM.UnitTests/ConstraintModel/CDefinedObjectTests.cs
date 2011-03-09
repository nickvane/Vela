using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCDefinedObject
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasAssumedValueThrowsException()
		{
			var instance = new DefinedObjectTest();
			var result = instance.HasAssumedValue();
		}
	}

	public class DefinedObjectTest : CDefinedObject<DefinedObjectTest>
	{
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		public override DefinedObjectTest DefaultValue()
		{
			throw new NotImplementedException();
		}

		public override bool IsValidValue(DefinedObjectTest value)
		{
			throw new NotImplementedException();
		}
	}
}

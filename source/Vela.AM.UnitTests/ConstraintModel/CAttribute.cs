using System;
using NUnit.Framework;
using Vela.AM.ConstraintModel;

namespace Vela.AM.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCAttribute
	{
		[Test]
		public void ListsAreNotNull()
		{
			var attribute = new AttributeTest();
			Assert.IsNotNull(attribute.Children);
		}
	}

	public class AttributeTest : CAttribute
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

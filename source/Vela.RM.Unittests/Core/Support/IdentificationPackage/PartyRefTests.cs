using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.UnitTests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingPartyRef
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			var id = new PartyRef
						{
							Type = RefType.PERSON.ToString()
						};
			Assert.AreEqual(RefType.PERSON.ToString(), id.Type);
			id.Type = RefType.ORGANISATION.ToString();
			id.Type = RefType.GROUP.ToString();
			id.Type = RefType.AGENT.ToString();
			id.Type = RefType.ROLE.ToString();
			id.Type = RefType.PARTY.ToString();
			id.Type = RefType.ACTOR.ToString();
		}
	}

	[TestFixture]
	public class WhenUsingPartyRefWithInvalidType
	{
		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShouldThrowException()
		{
			new PartyRef
				{
					Type = "%$*+/."
				};
		}
	}

	[TestFixture]
	public class WhenUsingPartyRefWithNotAllowedType
	{
		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShouldThrowException()
		{
			new PartyRef
				{
					Type = RefType.ANY.ToString()
				};
		}
	}
}

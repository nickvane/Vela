using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.UnitTests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingGenericId
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			new GenericId("test");
		}
	}
}

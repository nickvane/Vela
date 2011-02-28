using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.UnitTests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingIsoOId
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			new IsoOId("test");
		}
	}
}

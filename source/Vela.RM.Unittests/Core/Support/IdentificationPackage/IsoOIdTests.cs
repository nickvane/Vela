using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Unittests.Core.Support.IdentificationPackage
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

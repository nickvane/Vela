using NUnit.Framework;
using Vela.RM.Core.Common.ArchetypedPackage;

namespace Vela.RM.Core.UnitTests.Common.ArchetypedPackage
{
	[TestFixture]
	public class WhenUsingFeederAudit
	{
		[Test]
		public void ListsAreNotNull()
		{
			var feeder = new FeederAudit();
			Assert.IsNotNull(feeder.OriginatingSystemItemIds);
			Assert.IsNotNull(feeder.FeederSystemIds);
		}
	}
}
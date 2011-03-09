using NUnit.Framework;
using Vela.RM.Core.Common.ResourcePackage;

namespace Vela.RM.Core.UnitTests.Common.ResourcePackage
{
	[TestFixture]
	public class WhenUsingResourceDescription
	{
		[Test]
		public void ListPropertiesAreNotNull()
		{
			var item = new ResourceDescription();
			Assert.IsNotNull(item.Details);
			Assert.IsNotNull(item.OtherDetails);
			Assert.IsNotNull(item.OriginalAuthor);
			Assert.IsNotNull(item.OtherContributors);
		}
	}
}

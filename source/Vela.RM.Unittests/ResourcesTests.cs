using NUnit.Framework;

namespace Vela.RM.UnitTests
{
	[TestFixture]
	public class WhenUsingResources
	{
		[Test]
		public void ThereShouldBeNoErrors()
		{
			var culture = Properties.Resources.Culture;
			Properties.Resources.Culture = culture;

			var resources = new Properties.Resources();
		}
	}
}

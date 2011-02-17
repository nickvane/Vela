using NUnit.Framework;

namespace Vela.RM.Unittests
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

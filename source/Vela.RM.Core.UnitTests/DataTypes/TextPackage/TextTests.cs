using NUnit.Framework;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingText
	{
		[Test]
		public void MappingsShouldReturnEmptyList()
		{
			var text = new RM.Core.DataTypes.TextPackage.Text("");
			Assert.NotNull(text.Mappings);
		}
	}
}

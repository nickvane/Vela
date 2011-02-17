using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Unittests.Core.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingParagraph
	{
		[Test]
		public void ItemsShouldReturnEmptyList()
		{
			var text = new Paragraph();
			Assert.NotNull(text.Items);
		}
	}
}

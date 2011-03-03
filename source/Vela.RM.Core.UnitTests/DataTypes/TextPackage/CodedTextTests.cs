using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingCodedText
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var text = new CodedText("");
		}
	}
}

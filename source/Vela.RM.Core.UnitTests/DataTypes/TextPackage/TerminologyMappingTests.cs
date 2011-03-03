using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingTerminologyMapping
	{
		[Test]
		public void DefaultMatchIsUnknown()
		{
			var mapping = new TerminologyMapping();
			Assert.IsTrue(mapping.IsValidMatchCode());
			Assert.IsTrue(mapping.IsUnknown());
			Assert.IsFalse(mapping.IsBroader());
			Assert.IsFalse(mapping.IsEquivalent());
			Assert.IsFalse(mapping.IsNarrower());
		}
	}
}

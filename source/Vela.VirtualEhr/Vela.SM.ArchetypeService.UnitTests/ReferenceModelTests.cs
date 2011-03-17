using NUnit.Framework;

namespace Vela.SM.ArchetypeService.UnitTests
{
	[TestFixture]
	public class WhenUsingReferenceModel
	{
		[Test]
		public void Test()
		{
			var classes = ReferenceModel.Classes;
			var count = classes.Count;
		}
	}
}

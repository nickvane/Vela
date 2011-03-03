using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	[TestFixture]
	public class WhenUsingInstruction
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instruction = new Instruction();
			Assert.IsNotNull(instruction.Activities);
		}
	}
}

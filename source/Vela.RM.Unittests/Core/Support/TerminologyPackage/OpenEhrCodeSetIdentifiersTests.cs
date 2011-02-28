using NUnit.Framework;
using Vela.RM.Core.Support.TerminologyPackage;

namespace Vela.RM.UnitTests.Core.Support.TerminologyPackage
{
	[TestFixture]
	public class WhenUsingCodeSetIdentifiers
	{
		[Test]
		public void ShouldBeNoExceptions()
		{
			var test = OpenEhrCodeSetIdentifiers.CharacterSets;
			test = OpenEhrCodeSetIdentifiers.CompressionAlgorithms;
			test = OpenEhrCodeSetIdentifiers.Countries;
			test = OpenEhrCodeSetIdentifiers.IntegrityCheckAlgorithms;
			test = OpenEhrCodeSetIdentifiers.Languages;
			test = OpenEhrCodeSetIdentifiers.MediaTypes;
			test = OpenEhrCodeSetIdentifiers.NormalStatuses;

			Assert.IsTrue(OpenEhrCodeSetIdentifiers.IsValidCodeSetId(test));
			Assert.IsFalse(OpenEhrCodeSetIdentifiers.IsValidCodeSetId("boo"));
		}
	}
}

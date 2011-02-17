using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Unittests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingObjectId
	{
		private const string Test = "test";
		private const string Test2 = "test2";

		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			var id = new TestId1(Test);
			Assert.AreEqual(Test, id.Value);
			Assert.AreEqual(Test, id.ToString());
			id.Value = Test2;
			Assert.AreEqual(Test2, id.Value);
		}
	}

	public class TestId1 : ObjectId
	{
		public TestId1(string value)
			: base(value)
		{
		}

		public override string Value
		{
			get;
			set;
		}
	}
}

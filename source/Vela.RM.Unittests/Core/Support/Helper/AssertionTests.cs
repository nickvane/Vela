using System;
using NUnit.Framework;
using Vela.RM.Core.Support.Helper;

namespace Vela.RM.Unittests.Core.Support.Helper
{
	[TestFixture]
	public class WhenUsingAssertion
	{
		[Test, ExpectedException(typeof(ArgumentException))]
		public void AssertFalseCondition()
		{
			Assertion.WhenFalse("test", 1 != 1);
		}

		[Test]
		public void DoNotAssertFalseCondition()
		{
			Assertion.WhenFalse("test", 1 == 1);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void AssertTrueCondition()
		{
			Assertion.WhenTrue("test", 1 == 1);
		}

		[Test]
		public void DoNotAssertTrueCondition()
		{
			Assertion.WhenTrue("test", 1 != 1);
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void AssertNullWithParameter()
		{
			Assertion.WhenNull("test", null);
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void AssertNull()
		{
			Assertion.WhenNull(null);
		}

		[Test]
		public void DoNotAssertNull()
		{
			Assertion.WhenNull("test", new object());
			Assertion.WhenNull(new object());
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestCase(null, false)]
		[TestCase("", false)]
		[TestCase(" ", true)]
		[TestCase("                          ", true)]
		public void AssertEmpty(string value, bool trim)
		{
			Assertion.WhenEmpty(value, trim);
		}

		[Test]
		public void DoNotAssertEmpty()
		{
			Assertion.WhenEmpty("test");
			Assertion.WhenEmpty(" x ");
			Assertion.WhenEmpty(" x ", true);
			Assertion.WhenEmpty("test", " x ");
			Assertion.WhenEmpty("test", " x ", true);
		}
	}
}

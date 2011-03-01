using System;
using NUnit.Framework;
using Vela.Common.Helper;

namespace Vela.Common.UnitTests.Helper
{
	[TestFixture]
	public class WhenUsingICustomAttributeProviderExtensionMethods
	{
		[Test]
		public void CorrectAttributesShouldBeReturned()
		{
			Assert.AreEqual(1, typeof(WhenUsingICustomAttributeProviderExtensionMethods).GetAttributes<TestFixtureAttribute>(false).Count);
		}

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void ThrowsExceptionWhenParameterIsNull()
		{
			Type w = null;
			w.GetAttributes<SerializableAttribute>(false);
		}
	}
}

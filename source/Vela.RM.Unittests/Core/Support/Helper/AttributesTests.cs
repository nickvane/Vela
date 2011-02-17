using System;
using NUnit.Framework;
using Vela.RM.Core.Support.Helper;

namespace Vela.RM.Unittests.Core.Support.Helper
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

using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.UriPackage;

namespace Vela.RM.UnitTests.Core.DataTypes.UriPackage
{
	[TestFixture]
	public class WhenUsingEhrUri
	{

		[Test]
		public void ValueShouldBeSet()
		{
			const string value = "ehr://test";
			var uri = new EhrUri(value);
			Assert.AreEqual(value, uri.Value);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void InvalidValueShouldThrowException()
		{
			new EhrUri("test");
		}
	}
}

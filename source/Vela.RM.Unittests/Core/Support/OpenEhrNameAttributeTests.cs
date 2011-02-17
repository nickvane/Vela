using System.Linq;
using NUnit.Framework;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.Helper;

namespace Vela.RM.Unittests.Core.Support
{
	[TestFixture]
	public class WhenUsingOpenEhrNameAttribute
	{
		[Test]
		public void NameShouldBeSet()
		{
			Assert.AreEqual("DOMAIN_OBJECT", typeof(DomainObject).GetAttributes<OpenEhrNameAttribute>(false).First().Name);
			Assert.AreEqual("SOME_OBJECT", typeof(DomainObject).GetMethod("SomeMethod").GetAttributes<OpenEhrNameAttribute>(false).First().Name);
			Assert.AreEqual("SOME_PROPERTY", typeof(DomainObject).GetProperty("SomeProperty").GetAttributes<OpenEhrNameAttribute>(false).First().Name);
		}
	}

	[OpenEhrName("DOMAIN_OBJECT")]
	public class DomainObject
	{
		[OpenEhrName("SOME_OBJECT")]
		public void SomeMethod()
		{

		}

		[OpenEhrName("SOME_PROPERTY")]
		public string SomeProperty
		{
			get;
			set;
		}
	}
}

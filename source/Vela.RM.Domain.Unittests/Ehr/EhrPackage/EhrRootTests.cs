using System;
using NUnit.Framework;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.Domain.UnitTests.Ehr.EhrPackage
{
	[TestFixture]
	public class WhenUsingEhrRoot
	{
		[Test]
		public void IdShouldRouteToEhrId()
		{
			var ehr = new EhrRoot();
			Assert.IsNullOrEmpty(ehr.Id);
			var id = Guid.NewGuid().ToString();
			ehr.Id = id;
			Assert.AreEqual(id, ehr.Id);
		}

		[Test]
		public void ListsAreNotNull()
		{
			var ehr = new EhrRoot();
			Assert.IsNotNull(ehr.Compositions);
			Assert.IsNotNull(ehr.Contributions);
		}
	}
}

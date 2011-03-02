using System;
using NUnit.Framework;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.UnitTests.Domain.Ehr.EhrPackage
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
	}
}

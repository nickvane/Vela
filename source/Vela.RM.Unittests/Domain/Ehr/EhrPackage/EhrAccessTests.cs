using System;
using NUnit.Framework;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.UnitTests.Domain.Ehr.EhrPackage
{
	[TestFixture]
	public class WhenUsingEhrAccess
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetSchemeShouldThrowException()
		{
			var access = new EhrAccess();
			var scheme = access.GetScheme();
		}
	}
}

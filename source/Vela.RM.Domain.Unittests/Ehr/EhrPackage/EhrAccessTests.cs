using System;
using NUnit.Framework;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.Domain.UnitTests.Ehr.EhrPackage
{
	[TestFixture]
	public class WhenUsingEhrAccess
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetSchemeShouldThrowException()
		{
			var access = new EhrAccess();
			var scheme = access.Scheme;
		}
	}
}

using System;
using NUnit.Framework;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.UnitTests.Domain.Ehr.EhrPackage
{
	[TestFixture]
	public class WhenUsingVersionedComposition
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPersistenThrowsException()
		{
			var v = new VersionedComposition();
			var p = v.IsPersistent();
		}
	}
}

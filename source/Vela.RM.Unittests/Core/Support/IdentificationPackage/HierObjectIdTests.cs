using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Unittests.Core.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingHierObjectId
	{
		[Test]
		public void ShouldConstructWithoutExceptions()
		{
			new HierObjectId(Guid.NewGuid().ToString());
		}
	}
}

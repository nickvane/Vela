using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.RepresentationPackage;

namespace Vela.RM.Unittests.Core.DataStructures.RepresentationPackage
{
	[TestFixture]
	public class WhenUsingElement
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsNullShouldThrowException()
		{
			var element = new Element();
			var result = element.IsNull();
		}
	}
}

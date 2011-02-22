using System;
using NUnit.Framework;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Unittests.Patterns.Common.ChangeControlPackage
{
	[TestFixture]
	public class WhenUsingOriginalVersion
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsMergedShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.IsMerged();
		}
	}
}

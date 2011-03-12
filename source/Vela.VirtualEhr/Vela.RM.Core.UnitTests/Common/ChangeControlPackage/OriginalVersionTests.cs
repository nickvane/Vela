//-----------------------------------------------------------------------
// <copyright file="OriginalVersionTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.Common.ChangeControlPackage;

namespace Vela.RM.Core.UnitTests.Common.ChangeControlPackage
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
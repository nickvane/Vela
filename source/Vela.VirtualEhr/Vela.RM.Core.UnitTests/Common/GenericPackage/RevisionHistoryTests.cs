//-----------------------------------------------------------------------
// <copyright file="RevisionHistoryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.Common.GenericPackage;

namespace Vela.RM.Core.UnitTests.Common.GenericPackage
{
	[TestFixture]
	public class WhenUsingRevisionHistory
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ShouldReturnMostRecentVersion()
		{
			var history = new RevisionHistory();
			var result = history.GetMostRecentVersion();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ShouldReturnCommittedTimeOfMostRecentVersion()
		{
			var history = new RevisionHistory();
			var result = history.GetCommittedTimeOfMostRecentVersion();
		}
	}
}
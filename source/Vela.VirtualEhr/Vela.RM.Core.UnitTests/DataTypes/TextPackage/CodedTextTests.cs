//-----------------------------------------------------------------------
// <copyright file="CodedTextTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingCodedText
	{
		[Test]
		public void DefaultPropertiesShouldWork()
		{
			var text = new CodedText("");
		}
	}
}
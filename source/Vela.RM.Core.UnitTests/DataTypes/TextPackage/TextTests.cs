//-----------------------------------------------------------------------
// <copyright file="TextTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingText
	{
		[Test]
		public void MappingsShouldReturnEmptyList()
		{
			var text = new RM.Core.DataTypes.TextPackage.Text("");
			Assert.NotNull(text.Mappings);
		}
	}
}
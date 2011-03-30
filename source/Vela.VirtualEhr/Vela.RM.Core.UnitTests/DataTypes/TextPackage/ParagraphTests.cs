//-----------------------------------------------------------------------
// <copyright file="ParagraphTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.TextPackage
{
	[TestFixture]
	public class WhenUsingParagraph
	{
		[Test]
		public void ItemsShouldReturnEmptyList()
		{
			var text = new Paragraph();
			Assert.NotNull(text.Items);
		}
	}
}
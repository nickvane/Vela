//-----------------------------------------------------------------------
// <copyright file="EhrUriTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.UriPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.UriPackage
{
	[TestFixture]
	public class WhenUsingEhrUri
	{

		[Test]
		public void ValueShouldBeSet()
		{
			const string value = "ehr://test";
			var uri = new EhrUri(value);
			Assert.AreEqual(value, uri.Value);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void InvalidValueShouldThrowException()
		{
			new EhrUri("test");
		}
	}
}
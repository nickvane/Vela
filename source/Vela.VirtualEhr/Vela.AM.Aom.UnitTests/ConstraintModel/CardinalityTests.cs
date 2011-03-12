//-----------------------------------------------------------------------
// <copyright file="CardinalityTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Aom.ConstraintModel;

namespace Vela.AM.Aom.UnitTests.ConstraintModel
{
	[TestFixture]
	public class WhenUsingCardinality
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsBagThrowsException()
		{
			var cardinality = new Cardinality();
			var result = cardinality.IsBag();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsListThrowsException()
		{
			var cardinality = new Cardinality();
			var result = cardinality.IsList();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSetThrowsException()
		{
			var cardinality = new Cardinality();
			var result = cardinality.IsSet();
		}
	}
}
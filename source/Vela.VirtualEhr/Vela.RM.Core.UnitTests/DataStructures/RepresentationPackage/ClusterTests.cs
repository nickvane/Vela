//-----------------------------------------------------------------------
// <copyright file="ClusterTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.RepresentationPackage;

namespace Vela.RM.Core.UnitTests.DataStructures.RepresentationPackage
{
	[TestFixture]
	public class WhenUsingCluster
	{
		[Test]
		public void DefaultProperties()
		{
			var cluster = new Cluster();
			Assert.IsNotNull(cluster.Items);
			cluster.Items = new List<Item>();
		}
	}
}
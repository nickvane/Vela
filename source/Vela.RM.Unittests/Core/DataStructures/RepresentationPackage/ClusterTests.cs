using System.Collections.Generic;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.RepresentationPackage;

namespace Vela.RM.UnitTests.Core.DataStructures.RepresentationPackage
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

using System.Linq;
using NUnit.Framework;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.UnitTests.LinqSpecs.DomainSample;

namespace Vela.Common.UnitTests.LinqSpecs
{
	[TestFixture]
	public class AdHocSpecificationFixture
	{
		[Test]
		public void SimpleAdhocShouldWork()
		{
			var specification = new AdHocSpecification<string>(n => n.StartsWith("J"));

			var result = new SampleRepository()
								.Retrieve(specification);

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsTrue(result.Contains("Julian"));
			Assert.IsFalse(result.Contains("Manuel"));
		}
	}
}
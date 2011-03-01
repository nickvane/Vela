using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.UnitTests.LinqSpecs.DomainSample;

namespace Vela.Common.UnitTests.LinqSpecs
{
	[TestFixture]
	public class OtherSamples
	{
		[Test]
		public void CombinationSample()
		{
			var startWithM = new AdHocSpecification<string>(n => n.StartsWith("M"));
			var endsWithN = new AdHocSpecification<string>(n => n.EndsWith("n"));


			IEnumerable<string> result = new SampleRepository()
				.Retrieve(startWithM | !endsWithN);

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsFalse(result.Contains("Julian"));
			Assert.IsTrue(result.Contains("Manuel"));
		}
	}
}
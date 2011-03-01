using System.Linq;
using NUnit.Framework;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.UnitTests.LinqSpecs.DomainSample;

namespace Vela.Common.UnitTests.LinqSpecs.BooleanOperators
{
	[TestFixture]
	public class NegateSpecificationFixture
	{
		[Test]
		public void NegateShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var specification = new NegateSpecification<string>(startWithJ);

			var result = new SampleRepository()
				.Retrieve(specification);

			Assert.IsFalse(result.Contains("Jose"));
			Assert.IsFalse(result.Contains("Julian"));
			Assert.IsTrue(result.Contains("Manuel"));
		}

		[Test]
		public void NegateOperatorShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			
			var result = new SampleRepository()
				.Retrieve(!startWithJ);

			Assert.IsFalse(result.Contains("Jose"));
			Assert.IsFalse(result.Contains("Julian"));
			Assert.IsTrue(result.Contains("Manuel"));
		}

		[Test]
		public void EqualsReturnTrueWhenTheNegatedSpecAreEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));

			var spec = !startWithJ;

			Assert.AreEqual(spec, !startWithJ);
		}

		[Test]
		public void EqualsReturnFalseWhenTheNegatedSpecAreNotEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var anotherAdHocSpec = new AdHocSpecification<string>(n => n.StartsWith("dasdas"));

			var spec = !startWithJ;

			Assert.AreNotEqual(spec, !anotherAdHocSpec);
		}
	}
}
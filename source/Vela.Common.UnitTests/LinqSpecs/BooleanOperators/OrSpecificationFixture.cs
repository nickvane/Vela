using System.Linq;
using NUnit.Framework;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.UnitTests.LinqSpecs.DomainSample;

namespace Vela.Common.UnitTests.LinqSpecs.BooleanOperators
{
	[TestFixture]
	public class OrSpecificationFixture
	{
		[Test]
		public void OrShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithN = new AdHocSpecification<string>(n => n.EndsWith("n"));

			var result = new SampleRepository()
				.Retrieve(new OrSpecification<string>(startWithJ, endsWithN));

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsTrue(result.Contains("Julian"));
			Assert.IsFalse(result.Contains("Manuel"));
		}

		[Test]
		public void OrOperatorShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithN = new AdHocSpecification<string>(n => n.EndsWith("n"));

			var result = new SampleRepository()
				.Retrieve(startWithJ || endsWithN);

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsTrue(result.Contains("Julian"));
			Assert.IsFalse(result.Contains("Manuel"));
		}

		[Test]
		public void EqualsReturnTrueWhenBothSidesAreEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));
			var spec = startWithJ || endsWithE;

			Assert.AreEqual(spec, startWithJ || endsWithE);
			Assert.AreNotEqual(spec, endsWithE || startWithJ);
		}

		[Test]
		public void EqualsReturnFalseWhenBothSidesAreNotEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));
			var endsWithF = new AdHocSpecification<string>(n => n.EndsWith("f"));
			var spec = startWithJ || endsWithE;

			Assert.AreNotEqual(spec, startWithJ || endsWithF);
		}
	}
}
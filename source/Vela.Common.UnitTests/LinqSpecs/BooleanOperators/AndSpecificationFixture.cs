using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vela.Common.Dal.LinqSpecs;
using Vela.Common.UnitTests.LinqSpecs.DomainSample;

namespace Vela.Common.UnitTests.LinqSpecs.BooleanOperators
{
	//Note; no matter if you are using & operator, or && operator.. both works as an &&.


	[TestFixture]
	public class AndSpecificationFixture
	{
		[Test]
		public void AndShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));          
			var specfication = new AndSpecification<string>(startWithJ, endsWithE);

			IEnumerable<string> result = new SampleRepository()
				.Retrieve(specfication);

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsFalse(result.Contains("Julian"));
			Assert.IsFalse(result.Contains("Manuel"));
		}

		[Test]
		public void AndOperatorShouldWork()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));


			// & or && both operators behave as &&.

			IEnumerable<string> result = new SampleRepository()
				.Retrieve(startWithJ & endsWithE);

			Assert.IsTrue(result.Contains("Jose"));
			Assert.IsFalse(result.Contains("Julian"));
			Assert.IsFalse(result.Contains("Manuel"));
		}

		[Test]
		public void EqualsReturnTrueWhenBothSidesAreEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));
			var spec = startWithJ & endsWithE;

			Assert.AreEqual(spec, startWithJ & endsWithE);
			Assert.AreNotEqual(spec, endsWithE & startWithJ);
		}

		[Test]
		public void EqualsReturnFalseWhenBothSidesAreNotEquals()
		{
			var startWithJ = new AdHocSpecification<string>(n => n.StartsWith("J"));
			var endsWithE = new AdHocSpecification<string>(n => n.EndsWith("e"));
			var endsWithF = new AdHocSpecification<string>(n => n.EndsWith("f"));
			var spec = startWithJ & endsWithE;

			Assert.AreNotEqual(spec, startWithJ & endsWithF);
		}
	}
}
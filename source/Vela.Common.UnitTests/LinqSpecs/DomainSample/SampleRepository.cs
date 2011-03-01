using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Vela.Common.Dal.LinqSpecs;

namespace Vela.Common.UnitTests.LinqSpecs.DomainSample
{
	public class SampleRepository : ReadOnlyCollection<string>
	{
		public SampleRepository()
			: base(new[] { "Jose", "Manuel", "Julian" })
		{ }

		public IEnumerable<string> Retrieve(Specification<string> specfication)
		{
			return this.AsQueryable().Where(specfication.IsSatisfiedBy());
		}
	}
}
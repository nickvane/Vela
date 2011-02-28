using System;
using System.Linq.Expressions;
using Vela.Common.Dal.LinqSpecs;
using Vela.RM.Domain.Entities;

namespace Vela.RM.Domain.Specifications
{
	public class VersionsFromTrunk : Specification<CompositionVersion>
	{
		/// <summary>
		/// Is the specification satisfied?
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<CompositionVersion, bool>> IsSatisfiedBy()
		{
			return v => v.Version.Uid.VersionTreeId.IsBranch == false;
		}
	}
}

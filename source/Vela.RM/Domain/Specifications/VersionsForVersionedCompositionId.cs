using System;
using System.Linq.Expressions;
using Vela.Common.Dal.LinqSpecs;
using Vela.RM.Domain.Entities;

namespace Vela.RM.Domain.Specifications
{
	public class VersionsForVersionedCompositionId : Specification<CompositionVersion>
	{
		private readonly string _versionedCompositionid;

		public VersionsForVersionedCompositionId(string versionedCompositionId)
		{
			_versionedCompositionid = versionedCompositionId;
		}

		/// <summary>
		/// Is the specification satisfied?
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<CompositionVersion, bool>> IsSatisfiedBy()
		{
			return v => v.VersionedComposition.Uid.Value == _versionedCompositionid;
		}
	}
}

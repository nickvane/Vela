using System;
using System.Linq.Expressions;
using Vela.Common.Dal.LinqSpecs;
using Vela.RM.Domain.Entities;

namespace Vela.RM.Domain.Specifications
{
	public class VersionWithVersionId : Specification<CompositionVersion>
	{
		private readonly string _versionId;

		public VersionWithVersionId(string versionId)
		{
			_versionId = versionId;
		}

		/// <summary>
		/// Is the specification satisfied?
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<CompositionVersion, bool>> IsSatisfiedBy()
		{
			return v => v.Version.Uid.Value == _versionId;
		}
	}
}

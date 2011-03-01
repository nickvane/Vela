using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Vela.Common.Dal.RavenDb;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;
using Vela.RM.Domain.Specifications;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Dal.Domain.Repositories
{
	public class CompositionVersionRepository : RavenRepository<CompositionVersion>, ICompositionVersionRepository
	{
		public CompositionVersionRepository(IDocumentSession session, IQueryable<CompositionVersion> collection) : base(session, collection)
		{
		}

		///<summary>
		/// Return a list of all versions of a versionedComposition.
		///</summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		public IList<CompositionVersion> GetAllVersions(string versionedCompositionId)
		{
			return FindAll(new VersionsForVersionedCompositionId(versionedCompositionId)).ToList();
		}

		///<summary>
		/// True if a version with ‘versionId’ exists.
		///</summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		public bool HasVersion(string versionId)
		{
			return GetVersion(versionId) != null;
		}

		/// <summary>
		/// Return the version with id ‘versionId’.
		/// </summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		public CompositionVersion GetVersion(string versionId)
		{
			return this[versionId];
		}

		///<summary>
		/// True if version with ‘versionId’ is an ORIGINAL_VERSION.
		///</summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		public bool IsOriginalVersion(string versionId)
		{
			var compositionVersion = GetVersion(versionId);
			return compositionVersion != null && compositionVersion.Version.GetType().IsAssignableFrom(typeof (OriginalVersion<Composition>));
		}

		/// <summary>
		/// Return the most recently added version (i.e. on trunk or any branch).
		/// </summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		public CompositionVersion GetLatestVersion(string versionedCompositionId)
		{
			return
				GetQuery(new VersionsForVersionedCompositionId(versionedCompositionId)).OrderByDescending
					(v => v.Version.CommitAudit.TimeCommitted).FirstOrDefault();
		}

		/// <summary>
		/// Return the most recently added trunk version.
		/// </summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		public CompositionVersion GetLatestVersionFromTrunk(string versionedCompositionId)
		{
			return
				GetQuery(new VersionsForVersionedCompositionId(versionedCompositionId) && new VersionsFromTrunk()).OrderByDescending
					(v => v.Version.CommitAudit.TimeCommitted).FirstOrDefault();
		}
	}
}
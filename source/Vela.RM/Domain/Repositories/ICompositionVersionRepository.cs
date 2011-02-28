using System.Collections.Generic;
using Vela.Common.Dal.RavenDb;
using Vela.RM.Domain.Entities;

namespace Vela.RM.Domain.Repositories
{
	public interface ICompositionVersionRepository : IRepository<CompositionVersion>
	{
		///<summary>
		/// Return a list of all versions of a versionedComposition.
		///</summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		IList<CompositionVersion> GetAllVersions(string versionedCompositionId);

		///<summary>
		/// True if a version with ‘versionId’ exists.
		///</summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		bool HasVersion(string versionId);

		/// <summary>
		/// Return the version with id ‘versionId’.
		/// </summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		CompositionVersion GetVersion(string versionId);

		///<summary>
		/// True if version with ‘versionId’ is an ORIGINAL_VERSION.
		///</summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		bool IsOriginalVersion(string versionId);

		/// <summary>
		/// Return the most recently added version (i.e. on trunk or any branch).
		/// </summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		CompositionVersion GetLatestVersion(string versionedCompositionId);

		/// <summary>
		/// Return the most recently added trunk version.
		/// </summary>
		/// <param name="versionedCompositionId"></param>
		/// <returns></returns>
		CompositionVersion GetLatestVersionFromTrunk(string versionedCompositionId);
	}
}

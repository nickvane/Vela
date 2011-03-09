//-----------------------------------------------------------------------
// <copyright file="IGenericVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Vela.Common.Dal.RavenDB;

namespace Vela.RM.Domain.Repositories
{
	public interface IGenericVersionRepository<T> : IRavenRepository<T> where T : IDocument
	{
		///<summary>
		/// Return a list of all versions of a versionedComposition.
		///</summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		IList<T> GetAllVersions(string versionedObjectId);

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
		T GetVersion(string versionId);

		///<summary>
		/// True if version with ‘versionId’ is an ORIGINAL_VERSION.
		///</summary>
		/// <param name="versionId"></param>
		/// <returns></returns>
		bool IsOriginalVersion(string versionId);

		/// <summary>
		/// Return the most recently added version (i.e. on trunk or any branch).
		/// </summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		T GetLatestVersion(string versionedObjectId);

		/// <summary>
		/// Return the most recently added trunk version.
		/// </summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		T GetLatestVersionFromTrunk(string versionedObjectId);
	}
}
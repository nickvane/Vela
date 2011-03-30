//-----------------------------------------------------------------------
// <copyright file="GenericVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Vela.Common.Dal;
using Vela.RM.Core.Common.ChangeControlPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class GenericVersionRepository<T, TA> : BaseRepository<T>, IGenericVersionRepository<T> where T : class, IGenericVersion<TA> where TA : class
	{
		public GenericVersionRepository(IQueryable<T> collection = null)
			: base(collection)
		{
		}

		///<summary>
		/// Return a list of all versions of a versionedComposition.
		///</summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		public IList<T> GetAllVersions(string versionedObjectId)
		{
			var result = from v in Collection where v.Uid.Value == versionedObjectId select v;
			return result.ToList();
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
		public T GetVersion(string versionId)
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
			var version = GetVersion(versionId);
			return version != null && version.Version.GetType().IsAssignableFrom(typeof (OriginalVersion<TA>));
		}

		/// <summary>
		/// Return the most recently added version (i.e. on trunk or any branch).
		/// </summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		public T GetLatestVersion(string versionedObjectId)
		{
			var result = from v in Collection 
						 where v.Uid.Value == versionedObjectId 
						 orderby v.Version.CommitAudit.TimeCommitted descending
						 select v;
			return result.FirstOrDefault();
		}

		/// <summary>
		/// Return the most recently added trunk version.
		/// </summary>
		/// <param name="versionedObjectId"></param>
		/// <returns></returns>
		public T GetLatestVersionFromTrunk(string versionedObjectId)
		{
			var result = from v in Collection
						 where v.Uid.Value == versionedObjectId
						 where v.Version.IsBranch == false
						 orderby v.Version.CommitAudit.TimeCommitted descending
						 select v;
			return result.FirstOrDefault();
		}
	}
}
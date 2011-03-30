using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Patterns.Common.ChangeControlPackage
{
	public interface IVersionedObjectService<T>
	{
		///<summary>
		/// Return a list of all versions in this object.
		///</summary>
		[OpenEhrName("all_versions")]
		IList<T> GetAllVersions(VersionedObject<T> obj);

		///<summary>
		/// Return a list of ids of all versions in this object.
		///</summary>
		[OpenEhrName("all_version_ids")]
		IList<T> GetAllVersionIds(VersionedObject<T> obj);

		///<summary>
		/// True if a version with an_id exists.
		///</summary>
		[OpenEhrName("has_version_id")]
		bool HasVersionId(ObjectVersionId versionId);

		///<summary>
		/// True if version with an_id is an ORIGINAL_VERSION.
		///</summary>
		[OpenEhrName("is_original_version")]
		bool IsOriginalVersion(ObjectVersionId versionId);
	}
}

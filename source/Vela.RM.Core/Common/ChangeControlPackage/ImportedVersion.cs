using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.ChangeControlPackage
{
	///<summary>
	/// Versions whose content is an <see cref="OriginalVersion{T}"/> copied from another location; this class inherits commit_audit and contribution from <see cref="Version{T}"/>, providing imported versions with their own audit trail and Contribution, distinct from those of the imported <see cref="OriginalVersion{T}"/>.
	///</summary>
	///<typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("IMPORTED_VERSION<T>")]
	public class ImportedVersion<T> : Version<T>
	{
		/// <summary>
		/// The ORIGINAL_VERSION object that was imported.
		/// </summary>
		[OpenEhrName("item")]
		public OriginalVersion<T> Item { get; set; }

		/// <summary>
		/// Computed version of inheritance precursor, derived as item.uid.
		/// </summary>
		[OpenEhrName("uid")]
		public override ObjectVersionId Uid { get; set; }

		/// <summary>
		/// Computed version of inheritance precursor, derived as item.preceding_version_uid
		/// </summary>
		[OpenEhrName("preceding_version_uid")]
		public override ObjectVersionId PrecedingVersionUid { get; set; }

		/// <summary>
		/// Data of wrapped ORIGINAL_VERSION.
		/// </summary>
		[OpenEhrName("data")]
		public override T Data { get; set; }

		/// <summary>
		/// Lifecycle state of the content item in wrapped  ORIGINAL_VERSION, derived as item.lifecycle_state.
		/// </summary>
		[OpenEhrName("lifecycle_state")]
		public override CodedText LifecycleState { get; set; }
	}
}

using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.GenericPackage;

namespace Vela.RM.Patterns.Common.ChangeControlPackage
{
	///<summary>
	/// Abstract model of one Version within a Version container, containing data, commit audit trail, and the identifier of its Contribution.
	///</summary>
	///<typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("VERSION<T>")]
	public abstract class Version<T>
	{
		/// <summary>
		/// Unique identifier of this version, containing owner_id, version_tree_id and creating_system_id.
		/// </summary>
		[OpenEhrName("uid")]
		public abstract ObjectVersionId Uid { get; set; }

		/// <summary>
		/// Unique identifier of the version of which this version is a modification; Void if this is the first version.
		/// </summary>
		[OpenEhrName("preceding_version_uid")]
		public abstract ObjectVersionId PrecedingVersionUid { get; set; }

		/// <summary>
		/// Original content of this Version.
		/// </summary>
		[OpenEhrName("data")]
		public abstract T Data { get; set; }

		/// <summary>
		/// Lifecycle state of this version; coded by openEHR vocabulary “version lifecycle state”
		/// </summary>
		[OpenEhrName("lifecycle_state")]
		public abstract CodedText LifecycleState { get; set; }

		/// <summary>
		/// Audit trail corresponding to the committal of this version to the VERSIONED_OBJECT.
		/// </summary>
		[OpenEhrName("commit_audit")]
		public AuditDetails CommitAudit { get; set; }

		/// <summary>
		/// Contribution in which this version was added.
		/// </summary>
		[OpenEhrName("contribution")]
		public ObjectRef Contribution { get; set; }

		/// <summary>
		/// OpenPGP digital signature or digest of content committed in this Version.
		/// </summary>
		[OpenEhrName("signature")]
		public string Signature { get; set; }

		///<summary>
		/// Unique identifier of the owning VERSIONED_OBJECT.
		///</summary>
		///<returns></returns>
		[OpenEhrName("owner_id")]
		public HierObjectId GetOwnerId()
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if this Version represents a branch. Derived from uid attribute.
		///</summary>
		///<returns></returns>
		[OpenEhrName("is_branch")]
		public bool IsBranch
		{
			get
			{
				return Uid != null && Uid.IsBranch;
			}
		}

		///<summary>
		/// Canonical form of Version object, created by serialising all attributes except signature.
		///</summary>
		///<returns></returns>
		[OpenEhrName("canonical_form")]
		public string GetCanonicalForm()
		{
			throw new NotImplementedException();
		}
	}
}

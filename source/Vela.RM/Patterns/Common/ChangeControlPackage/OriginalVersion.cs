using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.GenericPackage;

namespace Vela.RM.Patterns.Common.ChangeControlPackage
{
	///<summary>
	/// A Version containing locally created content and optional attestations.
	///</summary>
	///<typeparam name="T"></typeparam>
	[Serializable]
	[OpenEhrName("ORIGINAL_VERSION<T>")]
	public class OriginalVersion<T> : Version<T>
	{
		/// <summary>
		/// Stored version of inheritance precursor.
		/// </summary>
		[OpenEhrName("uid")]
		public override ObjectVersionId Uid { get; set; }

		/// <summary>
		/// Stored version of inheritance precursor.
		/// </summary>
		[OpenEhrName("preceding_version_uid")]
		public override ObjectVersionId PrecedingVersionUid { get; set; }

		/// <summary>
		/// The data being versioned. If not present, this corresponds to logical deletion.
		/// </summary>
		[OpenEhrName("data")]
		public override T Data { get; set; }

		/// <summary>
		/// Lifecycle state of the content item in this version.
		/// </summary>
		[OpenEhrName("lifecycle_state")]
		public override CodedText LifecycleState { get; set; }

		///<summary>
		/// Identifiers of other versions whose content was merged into this version, if any.
		///</summary>
		[OpenEhrName("other_input_version_uids")]
		public List<ObjectVersionId> OtherInputVersionUids { get; set; }

		///<summary>
		/// Set of attestations relating to this version
		///</summary>
		[OpenEhrName("attestations")]
		public List<Attestation> Attestations { get; set; }

		///<summary>
		/// True if this Version was created from more than just the preceding (checked out) version.
		///</summary>
		///<returns></returns>
		[OpenEhrName("is_merged")]
		public bool IsMerged()
		{
			throw new NotImplementedException();
		}
	}
}

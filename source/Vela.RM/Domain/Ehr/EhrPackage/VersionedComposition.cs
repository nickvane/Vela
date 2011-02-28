using System;
using Vela.Common.Dal.RavenDb;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// Version-controlled composition  abstraction, defined by inheriting VERSIONED_OBJECT{COMPOSITION}.
	/// </summary>
	[Serializable]
	[OpenEhrName("VERSIONED_COMPOSITION")]
	public class VersionedComposition : VersionedObject<Compositions.CompositionPackage.Composition>, IDocument
	{
		/// <summary>
		/// Indicates whether this composition set is persistent; derived from first version.
		/// </summary>
		[OpenEhrName("is_persistent")]
		public bool IsPersistent()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Implementation of IDocument. Maps to Uid.Value
		/// </summary>
		public virtual string Id
		{
			get
			{
				if (Uid == null) Uid = new HierObjectId();
				return Uid.Value;
			}
			set
			{
				if (Uid == null) Uid = new HierObjectId();
				Uid.Value = value;
			}
		}
	}
}
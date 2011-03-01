using System;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// Version-controlled composition  abstraction, defined by inheriting VERSIONED_OBJECT{COMPOSITION}.
	/// </summary>
	[Serializable]
	[OpenEhrName("VERSIONED_COMPOSITION")]
	public class VersionedComposition : VersionedObject<Compositions.CompositionPackage.Composition>
	{
		/// <summary>
		/// Indicates whether this composition set is persistent; derived from first version.
		/// </summary>
		[OpenEhrName("is_persistent")]
		public bool IsPersistent()
		{
			throw new NotImplementedException();
		}
	}
}
using System;
using System.Collections.Generic;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.ChangeControlPackage
{
	///<summary>
	/// Collection a contribution of one or more versions added to a change-controlled repository.
	///</summary>
	[Serializable, OpenEhrName("CONTRIBUTION")]
	public class Contribution
	{
		/// <summary>
		/// Audit trail corresponding to the committal of this Contribution.
		/// </summary>
		[OpenEhrName("audit")]
		public AuditDetails Audit { get; set; }

		/// <summary>
		/// Unique identifier for this contribution.
		/// </summary>
		[OpenEhrName("uid")]
		public HierObjectId Uid { get; set; }

		/// <summary>
		/// Set of references to versions causing changes to this EHR. Each contribution contains a list of versions, which may include paths pointing to any number of VERSIONABLE items, i.e. items of type COMPOSITION and FOLDER.
		/// </summary>
		[OpenEhrName("versions")]
		public HashSet<ObjectRef> Versions { get; set; }
	}
}
using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.Encapsulatedpackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Patterns.Common.ArchetypedPackage
{
	/// <summary>
	/// Audit and other meta-data for systems in the feeder chain.
	/// </summary>
	[Serializable]
	[OpenEhrName("FEEDER_AUDIT")]
	public class FeederAudit
	{
		/// <summary>
		/// Any audit information for the information item from the originating system.
		/// </summary>
		[OpenEhrName("originating_system_audit")]
		public FeederAuditDetails OriginatingSystemAudit { get; set; }

		/// <summary>
		/// Identifiers used for the item in the originating system, e.g. filler and placer ids.
		/// </summary>
		[OpenEhrName("originating_system_item_ids")]
		public List<Identifier> OriginatingSystemItemIds { get; set; }

		/// <summary>
		/// Any audit information for the information item from the feeder system, if different from the originating system.
		/// </summary>
		[OpenEhrName("feeder_system_audit")]
		public FeederAuditDetails FeederSystemAudit { get; set; }

		/// <summary>
		/// Identifiers used for the item in the feeder system, where the feeder system is distinct from the originating system.
		/// </summary>
		[OpenEhrName("feeder_system_item_ids")]
		public List<Identifier> FeederSystemIds { get; set; }

		/// <summary>
		/// Optional inline inclusion of or reference to original content corresponding to the openEHR content at this node. Typically a URI reference to a document or message in a persistent store associated with the EHR.
		/// </summary>
		[OpenEhrName("original_content")]
		public Encapsulated OriginalContent { get; set; }
	}
}

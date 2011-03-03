using System;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.ArchetypedPackage
{
	/// <summary>
	/// Audit details for any system in a feeder system chain. Audit details here means the general notion of who/where/when the information item to which the audit is attached was created. None of the attributes is defined as mandatory, however, in different scenarios, various combinations of attributes will usually be mandatory. This can be controlled by specifying feeder audit details in legacy archetypes.
	/// </summary>
	[Serializable]
	[OpenEhrName("FEEDER_AUDIT_DETAILS")]
	public class FeederAuditDetails
	{
		/// <summary>
		/// Identifier of the system which handled the information item.
		/// </summary>
		[OpenEhrName("system_id")]
		public string SystemId { get; set; }

		/// <summary>
		/// Optional provider(s) who created, committed, forwarded or otherwise handled the item
		/// </summary>
		[OpenEhrName("provider")]
		public PartyIdentified Provider { get; set; }

		/// <summary>
		/// Identifier of the particular site/facility within an organisation which handled the item. For computability, this identifier needs to be e.g. a PKI identifier which can be included in the identifier list of the PARTY_IDENTIFIED object.
		/// </summary>
		[OpenEhrName("location")]
		public PartyIdentified Location { get; set; }

		//TODO: check if this needs to be DV_DATE_TIME class or if it can be System.DateTime
		/// <summary>
		/// Time of handling the item. For an originating system, this will be time of creation, for an intermediate feeder system, this will be a time of accession or other time of handling, where available.
		/// </summary>
		[OpenEhrName("time")]
		public DateTime Time { get; set; }

		/// <summary>
		/// Identifiers for subject of the received information item.
		/// </summary>
		[OpenEhrName("subject")]
		public PartyProxy Subject { get; set; }

		/// <summary>
		/// Any identifier used in the system such as “interim”, “final”, or numeric versions if available.
		/// </summary>
		[OpenEhrName("version_id")]
		public string VersionId { get; set; }
	}
}

using System;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.GenericPackage
{
	/// <summary>
	/// Abstract concept of a proxy description of a party, including an optional link to data for this party in a demographic or other identity management system. Subtyped into <see cref="PartySelf"/> and <see cref="PartyIdentified"/>.
	/// </summary>
	[Serializable]
	[OpenEhrName("PARTY_PROXY")]
	public abstract class PartyProxy
	{
		/// <summary>
		/// Optional reference to more detailed demographic or identification information for this party, in an external system.
		/// </summary>
		[OpenEhrName("external_ref")]
		public PartyRef ExternalRef { get; set; }
	}
}

//-----------------------------------------------------------------------
// <copyright file="RevisionHistoryItem.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.GenericPackage
{
	/// <summary>
	/// An entry in a revision history, corresponding to a version from a versioned container. Consists of AUDIT_DETAILS instances with revision identifier of the revision to which the AUDIT_DETAILS intance belongs.
	/// </summary>
	[OpenEhrName("REVISION_HISTORY_ITEM")]
	public class RevisionHistoryItem
	{
		/// <summary>
		/// The audits for this revision; there will always be at least one commit audit (which may itself be an ATTESTATION), there may also be further attestations.
		/// </summary>
		[OpenEhrName("audits")]
		public IList<AuditDetails> Audits { get; set; }

		/// <summary>
		/// Version identifier for this revision.
		/// </summary>
		[OpenEhrName("version_id")]
		public ObjectVersionId VersionId { get; set; }
	}
}
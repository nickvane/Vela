//-----------------------------------------------------------------------
// <copyright file="Attestation.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.EncapsulatedPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.DataTypes.UriPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.GenericPackage
{
	///<summary>
	/// Record an attestation by a party of item(s) of record content. The type of attestation is recorded by the reason attribute, which my be coded.
	///</summary>
	[Serializable]
	[OpenEhrName("ATTESTATION")]
	public class Attestation : AuditDetails
	{
		/// <summary>
		/// Optional visual representation of content attested e.g. screen image.
		/// </summary>
		[OpenEhrName("attested_view")]
		public Multimedia AttestedView { get; set; }

		/// <summary>
		/// Proof of attestation.
		/// </summary>
		[OpenEhrName("proof")]
		public string Proof { get; set; }

		/// <summary>
		/// Items attested, expressed as fully qualified runtime paths to the items in question. Although not recommended, these may include fine-grained items which have been attested in some other system. Otherwise it is assumed to be for the entire VERSION with which it is associated.
		/// </summary>
		[OpenEhrName("items")]
		public IList<EhrUri> Items { get; set; }

		/// <summary>
		/// Reason of this attestation. Optionally coded by the openEHR Terminology group “attestation reason”; includes values like “authorisation”, “witness” etc.
		/// </summary>
		[OpenEhrName("reason")]
		public Text Reason { get; set; }

		/// <summary>
		/// True if this attestation is outstanding; False means it has been completed.
		/// </summary>
		[OpenEhrName("is_pending")]
		public bool IsPending { get; set; }
	}
}
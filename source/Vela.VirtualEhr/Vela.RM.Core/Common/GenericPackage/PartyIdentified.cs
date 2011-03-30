//-----------------------------------------------------------------------
// <copyright file="PartyIdentified.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.GenericPackage
{
	/// <summary>
	/// Proxy data for an identified party other than the subject of the record, minimally consisting of human-readable identifier(s), such as name, formal (and possibly computable) identifiers such as NHS number, and an optional link to external data. There must be at least one of name, identifier or external_ref present.
	/// USE: Used to describe parties where only identifiers may be known, and there is no entry at all in the demographic system (or even no demographic system). Typically for health care providers, e.g. name and provider number of an institution.
	/// MISUSE: Should not be used to include patient identifying information.
	/// </summary>
	[Serializable]
	[OpenEhrName("PARTY_IDENTIFIED")]
	public class PartyIdentified : PartyProxy
	{
		///<summary>
		/// Optional human-readable name (in String form).
		///</summary>
		[OpenEhrName("name")]
		public string Name { get; set; }

		///<summary>
		/// One or more formal identifiers (possibly computable).
		///</summary>
		[OpenEhrName("identifiers")]
		public IList<Identifier> Identifiers { get; set; }
	}
}